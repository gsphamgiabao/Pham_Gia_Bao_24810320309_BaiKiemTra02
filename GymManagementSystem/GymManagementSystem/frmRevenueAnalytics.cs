// ============================================================
// frmRevenueAnalytics.cs  –  BÀI TẬP 4
// Multi-Threading: Async/Await & Không khóa UI
// ============================================================
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GymManagementSystem
{
    /// <summary>
    /// Form thống kê doanh thu – minh hoạ async/await, CancellationToken, UI không bị đơ.
    /// </summary>
    public class frmRevenueAnalytics : Form
    {
        // ── Khu vực tiêu chí ──────────────────────────────────────
        private Label          lblFrom;
        private Label          lblTo;
        private Label          lblBranch;
        private DateTimePicker dtpFrom;
        private DateTimePicker dtpTo;
        private ComboBox       cboBranch;
        private Button         btnStats;
        private Button         btnCancel;

        // ── Khu vực trạng thái ────────────────────────────────────
        private ProgressBar pgbLoading;
        private Label       lblProcessingStatus;

        // ── Khu vực kết quả ───────────────────────────────────────
        private DataGridView dgvRevenueData;

        // ── Hủy tác vụ ───────────────────────────────────────────
        private CancellationTokenSource? _cts;

        // ─────────────────────────────────────────────────────────
        public frmRevenueAnalytics()
        {
            BuildUI();
        }

        // ─────────────────────────────────────────────────────────
        // Xây dựng giao diện thủ công (không dùng Designer)
        // ─────────────────────────────────────────────────────────
        private void BuildUI()
        {
            this.Text            = "Bảng điều khiển thống kê doanh thu";
            this.Size            = new Size(900, 640);
            this.MinimumSize     = new Size(800, 580);
            this.StartPosition   = FormStartPosition.CenterScreen;
            this.Font            = new Font("Segoe UI", 9.5f);

            // ── Panel tiêu chí ────────────────────────────────────
            var panelCriteria = new Panel
            {
                Location  = new Point(10, 10),
                Size      = new Size(860, 48),
                BorderStyle = BorderStyle.FixedSingle
            };

            lblFrom = new Label { Text = "Từ ngày:", Location = new Point(8, 14), AutoSize = true };
            dtpFrom = new DateTimePicker
            {
                Location = new Point(68, 10),
                Width    = 110,
                Format   = DateTimePickerFormat.Short,
                Value    = DateTime.Today.AddMonths(-1)
            };

            lblTo = new Label { Text = "Đến ngày:", Location = new Point(190, 14), AutoSize = true };
            dtpTo = new DateTimePicker
            {
                Location = new Point(258, 10),
                Width    = 110,
                Format   = DateTimePickerFormat.Short,
                Value    = DateTime.Today
            };

            lblBranch = new Label { Text = "Chi nhánh:", Location = new Point(382, 14), AutoSize = true };
            cboBranch = new ComboBox
            {
                Location       = new Point(450, 10),
                Width          = 130,
                DropDownStyle  = ComboBoxStyle.DropDownList
            };
            cboBranch.Items.AddRange(new[] { "Tất cả", "Chi nhánh 1", "Chi nhánh 2", "Chi nhánh 3" });
            cboBranch.SelectedIndex = 0;

            btnStats = new Button
            {
                Text     = "Thống Kê Doanh Thu",
                Location = new Point(595, 9),
                Size     = new Size(140, 28),
                BackColor = Color.SteelBlue,
                ForeColor = Color.White,
                FlatStyle = FlatStyle.Flat
            };

            btnCancel = new Button
            {
                Text      = "Hủy Thao Tác",
                Location  = new Point(742, 9),
                Size      = new Size(110, 28),
                BackColor = Color.Firebrick,
                ForeColor = Color.White,
                FlatStyle = FlatStyle.Flat,
                Enabled   = false
            };

            btnStats.Click  += async (s, e) => await BtnStats_ClickAsync();
            btnCancel.Click += BtnCancel_Click;

            panelCriteria.Controls.AddRange(new Control[]
            {
                lblFrom, dtpFrom, lblTo, dtpTo,
                lblBranch, cboBranch, btnStats, btnCancel
            });

            // ── Panel trạng thái ──────────────────────────────────
            var panelStatus = new Panel
            {
                Location    = new Point(10, 68),
                Size        = new Size(860, 36),
                BorderStyle = BorderStyle.FixedSingle
            };

            pgbLoading = new ProgressBar
            {
                Location = new Point(8, 8),
                Size     = new Size(480, 18),
                Minimum  = 0,
                Maximum  = 100,
                Value    = 0
            };

            lblProcessingStatus = new Label
            {
                Location  = new Point(500, 10),
                AutoSize  = true,
                Text      = "Sẵn sàng",
                ForeColor = Color.DarkGreen,
                Font      = new Font("Segoe UI", 9.5f, FontStyle.Bold)
            };

            panelStatus.Controls.AddRange(new Control[] { pgbLoading, lblProcessingStatus });

            // ── DataGridView kết quả ──────────────────────────────
            dgvRevenueData = new DataGridView
            {
                Location          = new Point(10, 114),
                Size              = new Size(860, 470),
                AutoGenerateColumns = true,
                ReadOnly          = true,
                AllowUserToAddRows = false,
                SelectionMode     = DataGridViewSelectionMode.FullRowSelect,
                AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill,
                Anchor            = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right,
                BackgroundColor   = Color.White,
                BorderStyle       = BorderStyle.Fixed3D
            };

            this.Controls.AddRange(new Control[] { panelCriteria, panelStatus, dgvRevenueData });
        }

        // ─────────────────────────────────────────────────────────
        // XỬ LÝ NÚT "THỐNG KÊ DOANH THU" – async/await
        // ─────────────────────────────────────────────────────────
        private async Task BtnStats_ClickAsync()
        {
            // Kiểm tra ngày hợp lệ
            if (dtpFrom.Value.Date > dtpTo.Value.Date)
            {
                MessageBox.Show("Ngày bắt đầu không được lớn hơn ngày kết thúc!",
                    "Lỗi nhập liệu", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Khoá nút, mở nút Hủy
            btnStats.Enabled  = false;
            btnCancel.Enabled = true;
            pgbLoading.Value  = 0;
            SetStatus("Đang xử lý...", Color.DarkOrange);

            // Tạo CancellationTokenSource mới cho mỗi lần chạy
            _cts = new CancellationTokenSource();
            var token = _cts.Token;

            // Progress<int> tự marshal callback về UI Thread
            var progress = new Progress<int>(percent =>
            {
                pgbLoading.Value = Math.Min(percent, 100);
                SetStatus($"Đang xử lý... {percent}%", Color.DarkOrange);
            });

            try
            {
                // ── Đẩy toàn bộ công việc nặng xuống Background Thread ──
                var result = await Task.Run(
                    () => GenerateRevenueData(
                              dtpFrom.Value.Date,
                              dtpTo.Value.Date,
                              cboBranch.SelectedItem?.ToString() ?? "Tất cả",
                              progress,
                              token),
                    token);

                // Bind kết quả lên DataGridView (trên UI Thread)
                dgvRevenueData.DataSource = new BindingList<RevenueTransaction>(result);
                SetStatus($"Hoàn thành – {result.Count} giao dịch", Color.DarkGreen);
            }
            catch (OperationCanceledException)
            {
                // Hủy thành công – thông báo và reset
                pgbLoading.Value = 0;
                SetStatus("Đã hủy thao tác!", Color.Firebrick);
                MessageBox.Show("Đã hủy thao tác!", "Thông báo",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                SetStatus("Lỗi!", Color.Red);
                MessageBox.Show($"Lỗi khi thống kê:\n{ex.Message}", "Lỗi",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                // Luôn khôi phục trạng thái nút
                btnStats.Enabled  = true;
                btnCancel.Enabled = false;
                _cts?.Dispose();
                _cts = null;
            }
        }

        // ─────────────────────────────────────────────────────────
        // XỬ LÝ NÚT "HỦY THAO TÁC"
        // ─────────────────────────────────────────────────────────
        private void BtnCancel_Click(object? sender, EventArgs e)
        {
            btnCancel.Enabled = false;
            _cts?.Cancel();   // Gửi tín hiệu hủy an toàn đến background thread
        }

        // ─────────────────────────────────────────────────────────
        // GIẢ LẬP TRUY XUẤT CSDL – chạy trên Background Thread
        // Thời gian ~4-6 giây (5000 bản ghi × 1 ms/bản ghi)
        // ─────────────────────────────────────────────────────────
        private List<RevenueTransaction> GenerateRevenueData(
            DateTime from,
            DateTime to,
            string branch,
            IProgress<int> progress,
            CancellationToken token)
        {
            const int totalRecords = 5000;
            var rnd  = new Random();
            var list = new List<RevenueTransaction>(totalRecords);
            int dayRange = Math.Max((to - from).Days, 0);

            for (int i = 0; i < totalRecords; i++)
            {
                // Kiểm tra yêu cầu hủy trước mỗi bản ghi
                token.ThrowIfCancellationRequested();

                // Giả lập ~1 ms tính toán/truy vấn mỗi bản ghi → tổng ~5 giây
                Thread.Sleep(1);

                var date   = from.AddDays(rnd.Next(dayRange + 1));
                var br     = branch == "Tất cả" ? $"Chi nhánh {rnd.Next(1, 4)}" : branch;
                var amount = rnd.Next(100_000, 5_000_001);
                var desc   = $"Giao dịch #{i + 1:D5}";

                list.Add(new RevenueTransaction
                {
                    MaGiaoDich     = i + 1,
                    TransactionDate = date,
                    ChiNhanh       = br,
                    DoanhThu       = amount,
                    MoTa           = desc
                });

                // Báo tiến độ mỗi 5% (20 lần tổng cộng)
                if ((i + 1) % (totalRecords / 20) == 0)
                {
                    int percent = (i + 1) * 100 / totalRecords;
                    progress.Report(percent);
                }
            }

            progress.Report(100);

            // Lọc kết quả theo tiêu chí người dùng
            return list.Where(t =>
                t.TransactionDate >= from &&
                t.TransactionDate <= to  &&
                (branch == "Tất cả" || t.ChiNhanh == branch))
                .ToList();
        }

        // ─────────────────────────────────────────────────────────
        // Helper: cập nhật label trạng thái
        // ─────────────────────────────────────────────────────────
        private void SetStatus(string text, Color color)
        {
            lblProcessingStatus.Text      = text;
            lblProcessingStatus.ForeColor = color;
        }
    }

    // ─────────────────────────────────────────────────────────────
    // MODEL: Giao dịch doanh thu
    // ─────────────────────────────────────────────────────────────
    public class RevenueTransaction
    {
        public int      MaGiaoDich      { get; set; }
        public DateTime TransactionDate { get; set; }
        public string   ChiNhanh        { get; set; } = string.Empty;
        public decimal  DoanhThu        { get; set; }
        public string   MoTa            { get; set; } = string.Empty;
    }
}
