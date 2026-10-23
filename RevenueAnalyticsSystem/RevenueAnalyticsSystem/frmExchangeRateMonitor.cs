using System;
using System.Collections.Generic;
using System.Drawing;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RevenueAnalyticsSystem
{
    // ═══════════════════════════════════════════════════════════════════════════
    // BÀI TẬP 5: MÔ PHỎNG GIÁM SÁT TỶ GIÁ TÀI CHÍNH THỜI GIAN THỰC
    //
    // Minh hoạ:
    //   • System.Threading.Timer  – cập nhật tỷ giá theo chu kỳ trên ThreadPool
    //   • IProgress<T>            – marshal kết quả về UI Thread an toàn
    //   • CancellationTokenSource – dừng / tiếp tục giám sát
    //   • Interlocked             – đếm tổng cập nhật thread-safe
    //   • Volatile read/write     – đọc giá hiện tại không cần lock
    // ═══════════════════════════════════════════════════════════════════════════
    public partial class frmExchangeRateMonitor : Form
    {
        // ── Timer & đồng bộ ─────────────────────────────────────────────────
        private System.Threading.Timer? _rateTimer;
        private CancellationTokenSource? _cts;

        // ── Bộ đếm cập nhật (thread-safe với Interlocked) ───────────────────
        private long _totalUpdates = 0;

        // ── Trạng thái đang chạy (volatile để tránh stale-read) ─────────────
        private volatile bool _isRunning = false;

        // ── Chu kỳ cập nhật (ms) ────────────────────────────────────────────
        private int _intervalMs = 2000;

        // ── Random dùng chung cho background thread ──────────────────────────
        private readonly Random _rng = new();

        // ── Lịch sử cập nhật ────────────────────────────────────────────────
        private readonly List<RateSnapshot> _history = new();

        // ── IProgress<T> – callback luôn chạy trên UI Thread ────────────────
        private IProgress<RateUpdate>? _progress;

        // ── Bảng tỷ giá hiện tại (volatile) ─────────────────────────────────
        // Key = mã cặp tiền, Value = tỷ giá hiện tại
        private volatile Dictionary<string, decimal> _currentRates = new();

        // ── Dữ liệu nền: tỷ giá tham chiếu & biên độ dao động ───────────────
        private static readonly (string Pair, decimal BaseRate, decimal Volatility)[] RateConfig =
        {
            ("USD/VND",   24_850m,  300m),
            ("EUR/VND",   27_200m,  400m),
            ("JPY/VND",   163m,     5m  ),
            ("GBP/VND",   31_500m,  500m),
            ("CNY/VND",   3_430m,   80m ),
            ("KRW/VND",   17.8m,    0.5m),
            ("AUD/VND",   16_100m,  250m),
            ("SGD/VND",   18_500m,  280m),
        };

        // ════════════════════════════════════════════════════════════════════
        public frmExchangeRateMonitor()
        {
            InitializeComponent();
        }

        // ─── Form Load ──────────────────────────────────────────────────────
        private void frmExchangeRateMonitor_Load(object sender, EventArgs e)
        {
            SetupDataGridView();
            SetupHistoryGridColumns();
            InitCurrentRates();
            PopulateGrid();           // hiển thị tỷ giá ban đầu

            trkInterval.Minimum = 5;  // 0.5 s (đơn vị 100ms)
            trkInterval.Maximum = 50; // 5.0 s
            trkInterval.Value   = 20; // 2.0 s mặc định
            UpdateIntervalLabel();

            UpdateStatusBar("⏸ Chưa bắt đầu giám sát. Nhấn [Bắt đầu] để khởi động.");
            UpdateCounterLabel();

            // Tạo IProgress<RateUpdate> – callback luôn chạy trên UI Thread
            _progress = new Progress<RateUpdate>(OnRateUpdateReceived);
        }

        // ─── Khởi tạo tỷ giá ban đầu ────────────────────────────────────────
        private void InitCurrentRates()
        {
            var dict = new Dictionary<string, decimal>();
            foreach (var (pair, baseRate, _) in RateConfig)
                dict[pair] = baseRate;
            _currentRates = dict;
        }

        // ─── Cấu hình cột DataGridView Lịch Sử ────────────────────────────────
        private void SetupHistoryGridColumns()
        {
            dgvHistory.Columns.Clear();
            dgvHistory.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "colHNo", HeaderText = "#", Width = 50,
                DefaultCellStyle = new DataGridViewCellStyle
                    { Alignment = DataGridViewContentAlignment.MiddleCenter }
            });
            dgvHistory.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "colHPair", HeaderText = "Cặp Tiền", Width = 90,
                DefaultCellStyle = new DataGridViewCellStyle
                    { Alignment = DataGridViewContentAlignment.MiddleCenter, Font = new Font("Consolas", 9f, FontStyle.Bold) }
            });
            dgvHistory.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "colHRate", HeaderText = "Tỷ Giá", Width = 120,
                DefaultCellStyle = new DataGridViewCellStyle
                    { Alignment = DataGridViewContentAlignment.MiddleRight, Font = new Font("Consolas", 9f) }
            });
            dgvHistory.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "colHChange", HeaderText = "Thay Đổi", Width = 100,
                DefaultCellStyle = new DataGridViewCellStyle
                    { Alignment = DataGridViewContentAlignment.MiddleRight }
            });
            dgvHistory.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "colHPct", HeaderText = "% Thay Đổi", Width = 100,
                DefaultCellStyle = new DataGridViewCellStyle
                    { Alignment = DataGridViewContentAlignment.MiddleRight }
            });
            dgvHistory.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "colHTime", HeaderText = "Thời Gian",
                AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill,
                DefaultCellStyle = new DataGridViewCellStyle
                    { Alignment = DataGridViewContentAlignment.MiddleCenter }
            });
        }

        // ─── Cấu hình DataGridView ───────────────────────────────────────────
        private void SetupDataGridView()
        {
            dgvRates.Columns.Clear();

            dgvRates.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "colPair", HeaderText = "Cặp Tiền",
                Width = 110,
                DefaultCellStyle = new DataGridViewCellStyle
                    { Alignment = DataGridViewContentAlignment.MiddleCenter, Font = new Font("Consolas", 9.5f, FontStyle.Bold) }
            });
            dgvRates.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "colRate", HeaderText = "Tỷ Giá (VNĐ)",
                Width = 160,
                DefaultCellStyle = new DataGridViewCellStyle
                    { Alignment = DataGridViewContentAlignment.MiddleRight, Font = new Font("Consolas", 10f) }
            });
            dgvRates.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "colChange", HeaderText = "Thay Đổi",
                Width = 110,
                DefaultCellStyle = new DataGridViewCellStyle
                    { Alignment = DataGridViewContentAlignment.MiddleRight }
            });
            dgvRates.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "colPct", HeaderText = "% Thay Đổi",
                Width = 105,
                DefaultCellStyle = new DataGridViewCellStyle
                    { Alignment = DataGridViewContentAlignment.MiddleRight }
            });
            dgvRates.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "colTrend", HeaderText = "Xu Hướng",
                Width = 90,
                DefaultCellStyle = new DataGridViewCellStyle
                    { Alignment = DataGridViewContentAlignment.MiddleCenter, Font = new Font("Segoe UI Emoji", 10f) }
            });
            dgvRates.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "colTime", HeaderText = "Cập Nhật Lúc",
                AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill,
                DefaultCellStyle = new DataGridViewCellStyle
                    { Alignment = DataGridViewContentAlignment.MiddleCenter }
            });
        }

        // ─── Đổ dữ liệu ban đầu vào DataGridView ───────────────────────────
        private void PopulateGrid()
        {
            dgvRates.Rows.Clear();
            var now = DateTime.Now;
            foreach (var (pair, _, _) in RateConfig)
            {
                decimal rate = _currentRates[pair];
                dgvRates.Rows.Add(pair, FormatRate(pair, rate), "—", "—", "—", now.ToString("HH:mm:ss"));
            }
        }

        // ════════════════════════════════════════════════════════════════════
        // ĐIỀU KHIỂN GIÁM SÁT
        // ════════════════════════════════════════════════════════════════════

        // ─── Nút [Bắt Đầu] ──────────────────────────────────────────────────
        private void btnStart_Click(object sender, EventArgs e)
        {
            if (_isRunning) return;

            _isRunning = true;
            _cts = new CancellationTokenSource();
            _intervalMs = trkInterval.Value * 100;  // TrackBar đơn vị 100ms

            // Cập nhật UI
            btnStart.Enabled    = false;
            btnStop.Enabled     = true;
            btnPause.Enabled    = true;
            trkInterval.Enabled = false;
            UpdateStatusBar("🟢 Đang giám sát tỷ giá theo thời gian thực...");

            // Khởi động System.Threading.Timer
            // - callback chạy trên ThreadPool thread, không phải UI Thread
            _rateTimer = new System.Threading.Timer(
                callback: TimerCallback,
                state:    null,
                dueTime:  0,               // bắt đầu ngay lập tức
                period:   _intervalMs);    // lặp theo chu kỳ
        }

        // ─── Nút [Dừng] ──────────────────────────────────────────────────────
        private void btnStop_Click(object sender, EventArgs e)
        {
            StopMonitoring();
            UpdateStatusBar($"🔴 Đã dừng giám sát. Tổng cập nhật: {_totalUpdates:N0} lần.");
        }

        // ─── Nút [Tạm Dừng / Tiếp Tục] ─────────────────────────────────────
        private void btnPause_Click(object sender, EventArgs e)
        {
            if (!_isRunning) return;

            if (_rateTimer != null && btnPause.Text.Contains("Tạm Dừng"))
            {
                // Tạm dừng: đặt period = Infinite (timer không fire nữa)
                _rateTimer.Change(Timeout.Infinite, Timeout.Infinite);
                btnPause.Text = "▶  Tiếp Tục";
                btnPause.BackColor = Color.FromArgb(39, 174, 96);
                UpdateStatusBar("⏸ Đã tạm dừng. Nhấn [Tiếp Tục] để giám sát lại.");
            }
            else
            {
                // Tiếp tục: kích hoạt lại timer
                _rateTimer?.Change(0, _intervalMs);
                btnPause.Text = "⏸  Tạm Dừng";
                btnPause.BackColor = Color.FromArgb(230, 126, 34);
                UpdateStatusBar("🟢 Đang giám sát tỷ giá theo thời gian thực...");
            }
        }

        // ─── Nút [Xóa Lịch Sử] ──────────────────────────────────────────────
        private void btnClearHistory_Click(object sender, EventArgs e)
        {
            _history.Clear();
            dgvHistory.Rows.Clear();
            Interlocked.Exchange(ref _totalUpdates, 0);
            UpdateCounterLabel();
            UpdateStatusBar("🧹 Đã xóa toàn bộ lịch sử cập nhật.");
        }

        // ─── Dừng & dọn dẹp giám sát ────────────────────────────────────────
        private void StopMonitoring()
        {
            _isRunning = false;
            _rateTimer?.Change(Timeout.Infinite, Timeout.Infinite);
            _rateTimer?.Dispose();
            _rateTimer = null;
            _cts?.Cancel();
            _cts?.Dispose();
            _cts = null;

            btnStart.Enabled  = true;
            btnStop.Enabled   = false;
            btnPause.Enabled  = false;
            btnPause.Text     = "⏸  Tạm Dừng";
            btnPause.BackColor = Color.FromArgb(230, 126, 34);
            trkInterval.Enabled = true;
        }

        // ════════════════════════════════════════════════════════════════════
        // TIMER CALLBACK – chạy trên ThreadPool thread
        // ════════════════════════════════════════════════════════════════════
        private void TimerCallback(object? state)
        {
            // Nếu đã bị yêu cầu dừng → thoát ngay
            if (_cts?.IsCancellationRequested ?? true) return;

            var timestamp = DateTime.Now;
            var updates   = new List<RateUpdate>();

            // Snapshot rates hiện tại (volatile read)
            var prevRates = _currentRates;
            var newRates  = new Dictionary<string, decimal>(prevRates);

            foreach (var (pair, baseRate, volatility) in RateConfig)
            {
                // Tạo giá mới ngẫu nhiên với biên độ dao động realistic
                decimal prev    = prevRates[pair];
                decimal delta   = (decimal)(_rng.NextDouble() * 2 - 1) * volatility;
                // Clamp để không trôi quá xa so với tỷ giá tham chiếu
                decimal newRate = Math.Clamp(prev + delta,
                    baseRate - volatility * 3,
                    baseRate + volatility * 3);

                // Làm tròn phù hợp từng cặp
                newRate = pair.StartsWith("KRW") ? Math.Round(newRate, 1)
                        : pair.StartsWith("JPY") ? Math.Round(newRate, 1)
                        : Math.Round(newRate, 0);

                newRates[pair] = newRate;

                decimal change  = newRate - prev;
                decimal pct     = prev == 0 ? 0 : change / prev * 100;

                updates.Add(new RateUpdate
                {
                    Pair      = pair,
                    NewRate   = newRate,
                    PrevRate  = prev,
                    Change    = change,
                    ChangePct = pct,
                    Timestamp = timestamp
                });
            }

            // Cập nhật volatile dictionary (gán nguyên object mới = atomic)
            _currentRates = newRates;

            // Tăng bộ đếm thread-safe
            Interlocked.Increment(ref _totalUpdates);

            // Gửi kết quả về UI Thread qua IProgress<T>
            _progress?.Report(new RateUpdate
            {
                Pair      = string.Empty, // batch marker
                Batch     = updates,
                Timestamp = timestamp,
                UpdateNo  = Interlocked.Read(ref _totalUpdates)
            });
        }

        // ════════════════════════════════════════════════════════════════════
        // NHẬN KẾT QUẢ TRÊN UI THREAD (Progress<T> callback)
        // ════════════════════════════════════════════════════════════════════
        private void OnRateUpdateReceived(RateUpdate report)
        {
            if (!_isRunning) return;

            dgvRates.SuspendLayout();

            foreach (var upd in report.Batch ?? new List<RateUpdate>())
            {
                // Tìm dòng theo cặp tiền
                DataGridViewRow? row = null;
                foreach (DataGridViewRow r in dgvRates.Rows)
                    if (r.Cells["colPair"].Value?.ToString() == upd.Pair) { row = r; break; }

                if (row == null) continue;

                // Xu hướng & màu sắc
                string trend;
                Color  cellColor;
                Color  changeColor;

                if (upd.Change > 0)
                {
                    trend       = "↑  Tăng";
                    cellColor   = Color.FromArgb(220, 255, 220);   // xanh lá nhạt
                    changeColor = Color.FromArgb(0, 150, 0);
                }
                else if (upd.Change < 0)
                {
                    trend       = "↓  Giảm";
                    cellColor   = Color.FromArgb(255, 220, 220);   // đỏ nhạt
                    changeColor = Color.FromArgb(200, 0, 0);
                }
                else
                {
                    trend       = "—  Không đổi";
                    cellColor   = Color.FromArgb(245, 245, 245);
                    changeColor = Color.Gray;
                }

                // Cập nhật cells
                row.Cells["colRate"].Value   = FormatRate(upd.Pair, upd.NewRate);
                row.Cells["colChange"].Value = (upd.Change >= 0 ? "+" : "") + FormatRate(upd.Pair, upd.Change);
                row.Cells["colPct"].Value    = (upd.ChangePct >= 0 ? "+" : "") + upd.ChangePct.ToString("F3") + "%";
                row.Cells["colTrend"].Value  = trend;
                row.Cells["colTime"].Value   = upd.Timestamp.ToString("HH:mm:ss.fff");

                // Tô màu dòng
                row.DefaultCellStyle.BackColor = cellColor;
                row.Cells["colChange"].Style.ForeColor = changeColor;
                row.Cells["colPct"].Style.ForeColor    = changeColor;
                row.Cells["colTrend"].Style.ForeColor  = changeColor;

                // Thêm vào lịch sử
                _history.Add(new RateSnapshot
                {
                    No        = (int)report.UpdateNo,
                    Pair      = upd.Pair,
                    Rate      = upd.NewRate,
                    Change    = upd.Change,
                    ChangePct = upd.ChangePct,
                    Timestamp = upd.Timestamp
                });
            }

            dgvRates.ResumeLayout();

            // Cập nhật DataGridView Lịch Sử (chỉ 200 dòng gần nhất)
            RefreshHistoryGrid();

            // Cập nhật bộ đếm & thanh trạng thái
            UpdateCounterLabel();
            UpdateStatusBar(
                $"🟢 Đang giám sát — Lần cập nhật #{report.UpdateNo:N0}  |  {report.Timestamp:HH:mm:ss.fff}");
        }

        // ─── Làm mới DataGridView Lịch Sử (200 dòng gần nhất) ─────────────
        private void RefreshHistoryGrid()
        {
            dgvHistory.SuspendLayout();
            dgvHistory.Rows.Clear();

            int start = Math.Max(0, _history.Count - 200);
            for (int i = _history.Count - 1; i >= start; i--)
            {
                var s = _history[i];
                string sign = s.Change >= 0 ? "+" : "";
                dgvHistory.Rows.Add(
                    s.No,
                    s.Pair,
                    FormatRate(s.Pair, s.Rate),
                    sign + FormatRate(s.Pair, s.Change),
                    sign + s.ChangePct.ToString("F3") + "%",
                    s.Timestamp.ToString("HH:mm:ss.fff"));
            }

            // Tô màu lịch sử
            foreach (DataGridViewRow row in dgvHistory.Rows)
            {
                string chStr = row.Cells["colHChange"].Value?.ToString() ?? "";
                if (chStr.StartsWith("+") && chStr != "+0" && !chStr.StartsWith("+0.000"))
                    row.DefaultCellStyle.BackColor = Color.FromArgb(230, 255, 230);
                else if (!chStr.StartsWith("+") && chStr != "—")
                    row.DefaultCellStyle.BackColor = Color.FromArgb(255, 230, 230);
            }

            dgvHistory.ResumeLayout();
        }

        // ════════════════════════════════════════════════════════════════════
        // HELPERS UI
        // ════════════════════════════════════════════════════════════════════

        private void UpdateStatusBar(string msg)
        {
            lblStatus.Text = msg;
        }

        private void UpdateCounterLabel()
        {
            lblCounter.Text = $"Tổng cập nhật: {Interlocked.Read(ref _totalUpdates):N0}";
        }

        private static string FormatRate(string pair, decimal value)
        {
            // JPY & KRW cần 1 chữ số thập phân; các cặp khác làm tròn nguyên
            return pair.StartsWith("JPY") || pair.StartsWith("KRW")
                ? value.ToString("N1")
                : value.ToString("N0");
        }

        // ─── TrackBar thay đổi chu kỳ ───────────────────────────────────────
        private void trkInterval_Scroll(object sender, EventArgs e)
        {
            _intervalMs = trkInterval.Value * 100;
            UpdateIntervalLabel();

            // Nếu đang chạy thì áp dụng ngay
            if (_isRunning)
                _rateTimer?.Change(0, _intervalMs);
        }

        private void UpdateIntervalLabel()
        {
            lblInterval.Text = $"Chu kỳ: {trkInterval.Value * 100} ms ({trkInterval.Value * 0.1:F1}s)";
        }

        // ─── Form Closing ───────────────────────────────────────────────────
        private void frmExchangeRateMonitor_FormClosing(object sender, FormClosingEventArgs e)
        {
            StopMonitoring();
        }
    }

    // ═══════════════════════════════════════════════════════════════════════════
    // MODEL: Một bản cập nhật tỷ giá được gửi qua IProgress<T>
    // ═══════════════════════════════════════════════════════════════════════════
    internal sealed class RateUpdate
    {
        public string             Pair      { get; set; } = string.Empty;
        public decimal            NewRate   { get; set; }
        public decimal            PrevRate  { get; set; }
        public decimal            Change    { get; set; }
        public decimal            ChangePct { get; set; }
        public DateTime           Timestamp { get; set; }
        public long               UpdateNo  { get; set; }
        public List<RateUpdate>?  Batch     { get; set; }
    }

    // ═══════════════════════════════════════════════════════════════════════════
    // MODEL: Một mục lịch sử tỷ giá
    // ═══════════════════════════════════════════════════════════════════════════
    internal sealed class RateSnapshot
    {
        public int      No        { get; set; }
        public string   Pair      { get; set; } = string.Empty;
        public decimal  Rate      { get; set; }
        public decimal  Change    { get; set; }
        public decimal  ChangePct { get; set; }
        public DateTime Timestamp { get; set; }
    }
}
