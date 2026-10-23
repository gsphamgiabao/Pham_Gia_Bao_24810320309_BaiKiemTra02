using System;
using System.Drawing;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CryptoStockTickerSystem
{
    // ═══════════════════════════════════════════════════════════════════════════
    // BÀI TẬP 5: MÔ PHỎNG GIÁM SÁT TỶ GIÁ TÀI CHÍNH THỜI GIAN THỰC
    //            CROSS-THREAD SAFETY & PROCESSING
    //
    // Kỹ thuật trọng tâm:
    //   • Task.Run + vòng lặp vô hạn   → Background Loop xử lý ngầm
    //   • this.InvokeRequired           → Phát hiện cross-thread call
    //   • this.Invoke(new Action(...))  → Marshal hành động về Main UI Thread
    //   • CancellationTokenSource       → Hủy vòng lặp ngầm sạch sẽ
    //
    // QUY TẮC VÀNG: Background Thread TUYỆT ĐỐI không được đụng vào Control.
    //               Mọi thao tác UI đều phải đi qua Invoke() / BeginInvoke().
    // ═══════════════════════════════════════════════════════════════════════════
    public partial class frmCryptoStockTicker : Form
    {
        // ── Quản lý vòng lặp ngầm ───────────────────────────────────────────
        private CancellationTokenSource? _cts;
        private Task?                    _monitorTask;

        // ── Trạng thái tạm dừng ─────────────────────────────────────────────
        // volatile: nhiều thread đọc/ghi — tránh CPU cache stale read
        private volatile bool _isPaused  = false;
        private volatile bool _isRunning = false;

        // ── Tỷ giá & thống kê (chỉ đọc/ghi trên Main UI Thread) ────────────
        private decimal _lastPrice = 0m;
        private int     _syncCount = 0;

        // ── Nguồn số ngẫu nhiên cho Background Thread ───────────────────────
        private readonly Random _rng = new();

        // ── Giá BTC tham chiếu & biên độ dao động (USD) ─────────────────────
        private const decimal BASE_PRICE = 67_000m;
        private const decimal VOLATILITY = 1_500m;

        // ════════════════════════════════════════════════════════════════════
        public frmCryptoStockTicker()
        {
            InitializeComponent();
        }

        // ─── Form Load ──────────────────────────────────────────────────────
        private void frmCryptoStockTicker_Load(object sender, EventArgs e)
        {
            _lastPrice = BASE_PRICE;
            UpdatePriceDisplay(BASE_PRICE, 0m);

            tsslLastUpdate.Text = "Chưa đồng bộ";
            tsslSyncCount.Text  = "Số lượt đồng bộ: 0";

            SetControlState(isRunning: false);
        }

        // ════════════════════════════════════════════════════════════════════
        // SỰ KIỆN NÚT BẤM
        // ════════════════════════════════════════════════════════════════════

        // ─── Nút [Bắt đầu Giám sát] ─────────────────────────────────────────
        private void btnStart_Click(object sender, EventArgs e)
        {
            if (_isRunning) return;

            _isRunning = true;
            _isPaused  = false;
            _cts       = new CancellationTokenSource();

            SetControlState(isRunning: true);
            AddHistoryLog("━━━ Bắt đầu giám sát BTC/USD ━━━", BASE_PRICE, 0m);

            // ── Khởi động Background Loop trên ThreadPool ──────────────────
            // Task.Run đẩy vòng lặp xuống Thread riêng — UI Thread không bị block
            _monitorTask = Task.Run(() => BackgroundMonitorLoop(_cts.Token), _cts.Token);
        }

        // ─── Nút [Tạm dừng] ─────────────────────────────────────────────────
        private void btnPause_Click(object sender, EventArgs e)
        {
            if (!_isRunning) return;

            _isPaused = !_isPaused;   // toggle volatile flag — Background Thread đọc được ngay

            if (_isPaused)
            {
                btnPause.Text      = "▶  Tiếp Tục";
                btnPause.BackColor = Color.FromArgb(39, 174, 96);
                tsslLastUpdate.Text = $"⏸ Đã tạm dừng lúc {DateTime.Now:HH:mm:ss}";
            }
            else
            {
                btnPause.Text      = "⏸  Tạm Dừng";
                btnPause.BackColor = Color.FromArgb(230, 126, 34);
                tsslLastUpdate.Text = "🟢 Tiếp tục giám sát...";
            }
        }

        // ─── Nút [Dừng Giám Sát] ────────────────────────────────────────────
        private void btnStop_Click(object sender, EventArgs e)
        {
            StopMonitor();
            AddHistoryLog("━━━ Đã dừng giám sát ━━━", _lastPrice, 0m);
        }

        // ─── Nút [Xóa Nhật Ký] ──────────────────────────────────────────────
        private void btnClear_Click(object sender, EventArgs e)
        {
            dgvHistoryLog.Rows.Clear();
            _syncCount         = 0;
            tsslSyncCount.Text = "Số lượt đồng bộ: 0";
        }

        // ════════════════════════════════════════════════════════════════════
        // VÒNG LẶP NGẦM — CHẠY TRÊN BACKGROUND THREAD (ThreadPool)
        //
        //   ⚠ Không được phép đụng vào bất kỳ Control nào từ đây!
        //   ⚠ Mọi cập nhật UI phải thông qua Invoke() / BeginInvoke().
        // ════════════════════════════════════════════════════════════════════
        private void BackgroundMonitorLoop(CancellationToken token)
        {
            while (!token.IsCancellationRequested)
            {
                // ── Nếu đang tạm dừng: sleep ngắn rồi kiểm tra lại ─────────
                if (_isPaused)
                {
                    Thread.Sleep(300);
                    continue;
                }

                // ── Giả lập độ trễ mạng / xử lý (2 giây) ───────────────────
                try
                {
                    Task.Delay(2000, token).GetAwaiter().GetResult();
                }
                catch (OperationCanceledException)
                {
                    break;
                }

                if (token.IsCancellationRequested) break;

                // ── Tính giá mới ngẫu nhiên (logic nghiệp vụ — ở đây là hợp lệ) ─
                decimal change   = (decimal)(_rng.NextDouble() * 2 - 1) * VOLATILITY;
                decimal newPrice = Math.Max(1_000m, _lastPrice + change);
                newPrice         = Math.Round(newPrice, 2);
                decimal delta    = newPrice - _lastPrice;
                DateTime stamp   = DateTime.Now;

                // ── ĐẨY cập nhật về Main UI Thread qua Invoke() ─────────────
                // ĐÂY LÀ TRÁI TIM của Cross-Thread Safety:
                //   • this.InvokeRequired = true  → đang ở Background Thread
                //   • this.Invoke() block cho đến khi UI Thread thực thi xong Action
                SafeInvoke(() =>
                {
                    _lastPrice = newPrice;
                    _syncCount++;

                    UpdatePriceDisplay(newPrice, delta);
                    UpdateStatusStrip(stamp);
                    AddHistoryLog(stamp.ToString("HH:mm:ss.fff"), newPrice, delta);
                });
            }

            // Vòng lặp kết thúc — về UI Thread cập nhật nút bấm
            SafeInvoke(() =>
            {
                if (_isRunning) SetControlState(isRunning: false);
            });
        }

        // ════════════════════════════════════════════════════════════════════
        // HELPER: SafeInvoke — bao gói đầy đủ quy tắc InvokeRequired
        //
        //   Khi gọi từ Background Thread:
        //     → InvokeRequired = true  → this.Invoke() marshal về UI Thread
        //   Khi gọi từ UI Thread:
        //     → InvokeRequired = false → chạy trực tiếp, không wrap thừa
        // ════════════════════════════════════════════════════════════════════
        private void SafeInvoke(Action action)
        {
            if (IsDisposed) return;

            try
            {
                if (this.InvokeRequired)
                {
                    // Cross-thread call: Background Thread → UI Thread
                    this.Invoke(new Action(action));
                }
                else
                {
                    // Đang ở UI Thread rồi, gọi trực tiếp
                    action();
                }
            }
            catch (ObjectDisposedException)
            {
                // Form bị đóng trong khi Invoke đang chờ → bỏ qua an toàn
            }
        }

        // ════════════════════════════════════════════════════════════════════
        // CÁC PHƯƠNG THỨC CẬP NHẬT UI
        // (Chỉ được gọi từ UI Thread — trực tiếp hoặc qua SafeInvoke)
        // ════════════════════════════════════════════════════════════════════

        // ─── Cập nhật Label giá BTC ──────────────────────────────────────────
        private void UpdatePriceDisplay(decimal price, decimal delta)
        {
            lblBTCPrice.Text = $"₿  {price:N2}  USD";

            if (delta > 0)
            {
                lblBTCPrice.ForeColor       = Color.FromArgb(0, 180, 0);
                lblDeltaIndicator.Text      = $"▲ +{delta:N2} USD";
                lblDeltaIndicator.ForeColor = Color.FromArgb(0, 180, 0);
            }
            else if (delta < 0)
            {
                lblBTCPrice.ForeColor       = Color.FromArgb(210, 0, 0);
                lblDeltaIndicator.Text      = $"▼ {delta:N2} USD";
                lblDeltaIndicator.ForeColor = Color.FromArgb(210, 0, 0);
            }
            else
            {
                lblBTCPrice.ForeColor       = Color.FromArgb(60, 60, 60);
                lblDeltaIndicator.Text      = "━  Chưa cập nhật";
                lblDeltaIndicator.ForeColor = Color.Gray;
            }
        }

        // ─── Cập nhật StatusStrip ────────────────────────────────────────────
        private void UpdateStatusStrip(DateTime stamp)
        {
            tsslLastUpdate.Text = $"🕐 Cập nhật lúc: {stamp:HH:mm:ss}";
            tsslSyncCount.Text  = $"Số lượt đồng bộ: {_syncCount:N0}";
        }

        // ─── Thêm dòng vào DataGridView lịch sử ─────────────────────────────
        private void AddHistoryLog(string timeOrLabel, decimal price, decimal delta)
        {
            string trendIcon;
            string changeStr;
            Color  rowColor;

            if (delta > 0)
            {
                trendIcon = "▲ Tăng";
                changeStr = $"+{delta:N2}";
                rowColor  = Color.FromArgb(225, 255, 225);
            }
            else if (delta < 0)
            {
                trendIcon = "▼ Giảm";
                changeStr = $"{delta:N2}";
                rowColor  = Color.FromArgb(255, 225, 225);
            }
            else
            {
                trendIcon = "━ Mở đầu";
                changeStr = "—";
                rowColor  = Color.FromArgb(240, 240, 255);
            }

            // Thêm vào đầu (mới nhất trên cùng)
            int rowIndex = dgvHistoryLog.Rows.Add();
            var row      = dgvHistoryLog.Rows[rowIndex];

            row.Cells["colTime"].Value   = timeOrLabel;
            row.Cells["colPrice"].Value  = (delta == 0 && changeStr == "—")
                                           ? "—" : $"{price:N2}";
            row.Cells["colChange"].Value = changeStr;
            row.Cells["colTrend"].Value  = trendIcon;
            row.Cells["colSync"].Value   = (delta == 0 && changeStr == "—")
                                           ? "—" : _syncCount.ToString("N0");
            row.DefaultCellStyle.BackColor = rowColor;

            // Giới hạn 500 dòng
            if (dgvHistoryLog.Rows.Count > 500)
                dgvHistoryLog.Rows.RemoveAt(dgvHistoryLog.Rows.Count - 1);

            // Cuộn lên đầu
            if (dgvHistoryLog.Rows.Count > 0)
                dgvHistoryLog.FirstDisplayedScrollingRowIndex = 0;
        }

        // ─── Dừng & dọn dẹp ─────────────────────────────────────────────────
        private void StopMonitor()
        {
            if (!_isRunning) return;
            _isRunning = false;
            _isPaused  = false;
            _cts?.Cancel();
            _cts?.Dispose();
            _cts = null;
            SetControlState(isRunning: false);
        }

        // ─── Bật/tắt trạng thái control ─────────────────────────────────────
        private void SetControlState(bool isRunning)
        {
            btnStart.Enabled = !isRunning;
            btnStop.Enabled  =  isRunning;
            btnPause.Enabled =  isRunning;

            if (!isRunning)
            {
                btnPause.Text      = "⏸  Tạm Dừng";
                btnPause.BackColor = Color.FromArgb(230, 126, 34);
            }
        }

        // ─── Form Closing ────────────────────────────────────────────────────
        private void frmCryptoStockTicker_FormClosing(object sender, FormClosingEventArgs e)
        {
            StopMonitor();
        }
    }
}
