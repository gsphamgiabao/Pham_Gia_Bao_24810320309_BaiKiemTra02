using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RevenueAnalyticsSystem
{
    public partial class frmRevenueAnalytics : Form
    {
        // ─── CancellationTokenSource để hủy tác vụ ngầm ───────────────────────
        private CancellationTokenSource? _cts;

        public frmRevenueAnalytics()
        {
            InitializeComponent();
        }

        // ─── Khởi tạo dữ liệu ban đầu khi form load ─────────────────────────
        private void frmRevenueAnalytics_Load(object sender, EventArgs e)
        {
            // Đổ dữ liệu cho ComboBox Chi Nhánh
            cboChiNhanh.Items.AddRange(new string[]
            {
                "Tất cả chi nhánh",
                "Chi nhánh Hà Nội",
                "Chi nhánh TP.HCM",
                "Chi nhánh Đà Nẵng",
                "Chi nhánh Cần Thơ"
            });
            cboChiNhanh.SelectedIndex = 0;

            // Mặc định khoảng ngày: 1 tháng gần nhất
            dtpDenNgay.Value  = DateTime.Today;
            dtpTuNgay.Value   = DateTime.Today.AddMonths(-1);

            // Thiết lập cột DataGridView
            SetupDataGridView();

            // Trạng thái ban đầu
            lblProcessingStatus.Text = "Sẵn sàng thống kê.";
            pgbLoading.Value          = 0;
            btnHuy.Enabled            = false;
        }

        // ─── Cấu hình cột cho DataGridView ───────────────────────────────────
        private void SetupDataGridView()
        {
            dgvRevenueData.Columns.Clear();

            dgvRevenueData.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "colSTT", HeaderText = "STT", Width = 50,
                DefaultCellStyle = new DataGridViewCellStyle
                    { Alignment = DataGridViewContentAlignment.MiddleCenter }
            });
            dgvRevenueData.Columns.Add(new DataGridViewTextBoxColumn
                { Name = "colMaGD", HeaderText = "Mã Giao Dịch", Width = 120 });
            dgvRevenueData.Columns.Add(new DataGridViewTextBoxColumn
                { Name = "colChiNhanh", HeaderText = "Chi Nhánh", Width = 155 });
            dgvRevenueData.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "colNgayGD", HeaderText = "Ngày GD", Width = 100,
                DefaultCellStyle = new DataGridViewCellStyle
                    { Alignment = DataGridViewContentAlignment.MiddleCenter }
            });
            dgvRevenueData.Columns.Add(new DataGridViewTextBoxColumn
                { Name = "colLoaiGD", HeaderText = "Loại Giao Dịch", Width = 110 });
            dgvRevenueData.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "colDoanhThu", HeaderText = "Doanh Thu (VNĐ)", Width = 145,
                DefaultCellStyle = new DataGridViewCellStyle
                    { Alignment = DataGridViewContentAlignment.MiddleRight }
            });
            dgvRevenueData.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "colTrangThai", HeaderText = "Trạng Thái",
                AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill   // cột cuối tự fill
            });
        }

        // ─── XỬ LÝ BẤT ĐỒNG BỘ: Nút [Thống Kê Doanh Thu] ──────────────────
        private async void btnThongKe_Click(object sender, EventArgs e)
        {
            // Validate ngày
            if (dtpTuNgay.Value.Date > dtpDenNgay.Value.Date)
            {
                MessageBox.Show("Ngày bắt đầu không được lớn hơn ngày kết thúc!",
                    "Lỗi Thời Gian", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Tạo CancellationTokenSource mới cho mỗi lần chạy
            _cts = new CancellationTokenSource();
            CancellationToken token = _cts.Token;

            // ── Cập nhật UI trước khi bắt đầu ──
            btnThongKe.Enabled        = false;
            btnHuy.Enabled            = true;
            dgvRevenueData.Rows.Clear();
            pgbLoading.Value          = 0;
            lblProcessingStatus.Text  = "Đang khởi tạo tác vụ...";

            // Progress<T> tự động marshal callback về UI Thread
            var progress = new Progress<(int Percent, string Message)>(report =>
            {
                pgbLoading.Value         = report.Percent;
                lblProcessingStatus.Text = report.Message;
            });

            // Lấy tham số từ UI
            DateTime tuNgay   = dtpTuNgay.Value.Date;
            DateTime denNgay  = dtpDenNgay.Value.Date;
            string   chiNhanh = cboChiNhanh.SelectedItem?.ToString() ?? "Tất cả chi nhánh";

            try
            {
                // ── Đẩy công việc nặng xuống Background Thread ──────────────
                List<RevenueRecord> data = await Task.Run(
                    () => GenerateRevenueData(tuNgay, denNgay, chiNhanh, progress, token),
                    token);

                // ── Đổ dữ liệu vào DataGridView (trên UI Thread) ────────────
                dgvRevenueData.SuspendLayout();
                foreach (var (row, index) in data.Select((r, i) => (r, i + 1)))
                {
                    dgvRevenueData.Rows.Add(
                        index,
                        row.MaGD,
                        row.ChiNhanh,
                        row.NgayGD.ToString("dd/MM/yyyy"),
                        row.LoaiGD,
                        row.DoanhThu.ToString("N0"),
                        row.TrangThai);
                }
                dgvRevenueData.ResumeLayout();

                // Tô màu dòng theo trạng thái
                ColorizeRows();

                pgbLoading.Value         = 100;
                lblProcessingStatus.Text = $"✔ Hoàn thành! Tổng cộng {data.Count} giao dịch.";
            }
            catch (OperationCanceledException)
            {
                // ── Xử lý khi người dùng nhấn [Hủy Thao Tác] ──────────────
                pgbLoading.Value         = 0;
                dgvRevenueData.Rows.Clear();
                lblProcessingStatus.Text = "Đã hủy thao tác!";
            }
            catch (Exception ex)
            {
                lblProcessingStatus.Text = $"❌ Lỗi: {ex.Message}";
                MessageBox.Show($"Đã xảy ra lỗi:\n{ex.Message}",
                    "Lỗi Hệ Thống", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                // ── Khôi phục UI dù thành công, hủy hay lỗi ──────────────
                btnThongKe.Enabled = true;
                btnHuy.Enabled     = false;
                _cts?.Dispose();
                _cts = null;
            }
        }

        // ─── Nút [Hủy Thao Tác]: gửi tín hiệu hủy đến Background Thread ────
        private void btnHuy_Click(object sender, EventArgs e)
        {
            btnHuy.Enabled           = false;
            lblProcessingStatus.Text = "Đang hủy tác vụ...";
            _cts?.Cancel();
        }

        // ─── TÁC VỤ NẶNG: Giả lập truy xuất CSDL & tổng hợp dữ liệu ────────
        // Chạy trên Background Thread (được gọi qua Task.Run)
        private static List<RevenueRecord> GenerateRevenueData(
            DateTime tuNgay,
            DateTime denNgay,
            string chiNhanh,
            IProgress<(int Percent, string Message)> progress,
            CancellationToken token)
        {
            var result = new List<RevenueRecord>();
            var rng    = new Random();

            string[] chiNhanhList  = { "Chi nhánh Hà Nội", "Chi nhánh TP.HCM", "Chi nhánh Đà Nẵng", "Chi nhánh Cần Thơ" };
            string[] loaiGDList    = { "Bán lẻ", "Bán buôn", "Online", "Đại lý", "Xuất khẩu" };
            string[] trangThaiList = { "Hoàn thành", "Hoàn thành", "Hoàn thành", "Chờ duyệt", "Đã hủy" };

            const int TotalSteps  = 10;
            int totalRecords      = rng.Next(80, 151);
            int batchSize         = totalRecords / TotalSteps;
            // Mỗi bước 400–600ms → tổng 4–6 giây
            int delayEachStep     = rng.Next(400, 601);
            int dayRange          = Math.Max(0, (denNgay - tuNgay).Days);

            for (int step = 0; step < TotalSteps; step++)
            {
                // Kiểm tra hủy trước khi sleep
                token.ThrowIfCancellationRequested();

                // Giả lập công việc nặng (truy vấn DB, tính toán)
                Thread.Sleep(delayEachStep);

                // Kiểm tra hủy sau khi sleep
                token.ThrowIfCancellationRequested();

                // Tạo dữ liệu cho batch này
                for (int j = 0; j < batchSize; j++)
                {
                    string cn = chiNhanh == "Tất cả chi nhánh"
                        ? chiNhanhList[rng.Next(chiNhanhList.Length)]
                        : chiNhanh;

                    result.Add(new RevenueRecord
                    {
                        MaGD      = $"GD{rng.Next(100_000, 999_999)}",
                        ChiNhanh  = cn,
                        NgayGD    = tuNgay.AddDays(dayRange == 0 ? 0 : rng.Next(dayRange + 1)),
                        LoaiGD    = loaiGDList[rng.Next(loaiGDList.Length)],
                        DoanhThu  = rng.Next(1_000_000, 50_000_001),
                        TrangThai = trangThaiList[rng.Next(trangThaiList.Length)]
                    });
                }

                // Báo cáo tiến độ về UI Thread thông qua IProgress<T>
                int percent = (step + 1) * 10;
                progress.Report((
                    percent,
                    $"Đang tổng hợp dữ liệu... {percent}%  ({result.Count} giao dịch)"
                ));
            }

            return result;
        }

        // ─── Tô màu dòng theo Trạng Thái ─────────────────────────────────────
        private void ColorizeRows()
        {
            foreach (DataGridViewRow row in dgvRevenueData.Rows)
            {
                string status = row.Cells["colTrangThai"].Value?.ToString() ?? "";
                row.DefaultCellStyle.BackColor = status switch
                {
                    "Hoàn thành" => Color.FromArgb(232, 255, 234),   // xanh nhạt
                    "Chờ duyệt"  => Color.FromArgb(255, 252, 220),   // vàng nhạt
                    "Đã hủy"     => Color.FromArgb(255, 228, 228),   // đỏ nhạt
                    _            => Color.White
                };
            }
        }
    }

    // ─── Model dữ liệu giao dịch ─────────────────────────────────────────────
    internal sealed class RevenueRecord
    {
        public string   MaGD      { get; set; } = string.Empty;
        public string   ChiNhanh  { get; set; } = string.Empty;
        public DateTime NgayGD    { get; set; }
        public string   LoaiGD    { get; set; } = string.Empty;
        public long     DoanhThu  { get; set; }
        public string   TrangThai { get; set; } = string.Empty;
    }
}
