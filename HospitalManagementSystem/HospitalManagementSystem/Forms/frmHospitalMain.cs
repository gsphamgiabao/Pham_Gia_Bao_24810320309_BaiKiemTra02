using System;
using System.Drawing;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using HospitalManagementSystem.Data;
using HospitalManagementSystem.Utils;

namespace HospitalManagementSystem.Forms
{
    public partial class frmHospitalMain : Form
    {
        private readonly System.Windows.Forms.Timer _clockTimer = new System.Windows.Forms.Timer();

        public frmHospitalMain()
        {
            InitializeComponent();
            InitHospitalSystem();
        }

        #region Khởi tạo Hệ thống MDI và Giao diện

        private void InitHospitalSystem()
        {
            // Cấu hình phông nền MDI Client chuyên nghiệp
            ConfigureMdiClientBackground();

            // Gán các Icon vector vẽ bằng GDI+ cho Menu và ToolStrip
            SetupIcons();

            // Khởi chạy đồng hồ thời gian thực
            _clockTimer.Interval = 1000;
            _clockTimer.Tick += (s, e) => lblClock.Text = DateTime.Now.ToString("dd/MM/yyyy HH:mm:ss");
            _clockTimer.Start();
            lblClock.Text = DateTime.Now.ToString("dd/MM/yyyy HH:mm:ss");

            // Đăng ký các sự kiện điều hướng Menu và ToolStrip
            RegisterNavigationEvents();

            // Cập nhật trạng thái ban đầu
            UpdateOpenWindowsStatus();

            // Tự động mở Form Hồ sơ Bệnh nhân khi khởi chạy ứng dụng
            this.Shown += (s, e) => OpenChildForm<frmPatientProfiles>();
        }

        private void ConfigureMdiClientBackground()
        {
            foreach (Control c in this.Controls)
            {
                if (c is MdiClient mdiClient)
                {
                    mdiClient.BackColor = Color.FromArgb(235, 242, 250);
                    break;
                }
            }
        }

        private void SetupIcons()
        {
            try
            {
                // Vector icons cho MenuStrip
                mnuPatientProfiles.Image = IconHelper.CreatePatientIcon(16);
                mnuDoctorSchedule.Image = IconHelper.CreateDoctorIcon(16);
                mnuDepartmentList.Image = IconHelper.CreateDepartmentIcon(16);
                mnuReloadData.Image = IconHelper.CreateReloadIcon(16);
                mnuLogout.Image = IconHelper.CreateLogoutIcon(16);
                mnuExit.Image = IconHelper.CreateExitIcon(16);
                mnuCascade.Image = IconHelper.CreateCascadeIcon(16);
                mnuTileHorizontal.Image = IconHelper.CreateTileHorizontalIcon(16);
                mnuTileVertical.Image = IconHelper.CreateTileVerticalIcon(16);
                mnuCloseAll.Image = IconHelper.CreateCloseAllIcon(16);
                mnuAbout.Image = IconHelper.CreateAboutIcon(16);

                // Vector icons cho ToolStrip
                btnTsPatient.Image = IconHelper.CreatePatientIcon(20);
                btnTsSchedule.Image = IconHelper.CreateDoctorIcon(20);
                btnTsDept.Image = IconHelper.CreateDepartmentIcon(20);
                btnTsReload.Image = IconHelper.CreateReloadIcon(20);
                btnTsCascade.Image = IconHelper.CreateCascadeIcon(20);
                btnTsTileH.Image = IconHelper.CreateTileHorizontalIcon(20);
                btnTsTileV.Image = IconHelper.CreateTileVerticalIcon(20);
                btnTsCloseAll.Image = IconHelper.CreateCloseAllIcon(20);

                // Icon trực ban ở StatusStrip
                lblDutyOfficer.Image = IconHelper.CreateDoctorIcon(16);
            }
            catch
            {
                // Nếu môi trường không hỗ trợ GDI+, hệ thống vẫn chạy bình thường
            }
        }

        private void RegisterNavigationEvents()
        {
            // 1. Quản lý mở Form con MDI
            mnuPatientProfiles.Click += (s, e) => OpenChildForm<frmPatientProfiles>();
            btnTsPatient.Click += (s, e) => OpenChildForm<frmPatientProfiles>();

            mnuDoctorSchedule.Click += (s, e) => OpenChildForm<frmDoctorSchedule>();
            btnTsSchedule.Click += (s, e) => OpenChildForm<frmDoctorSchedule>();

            mnuDepartmentList.Click += (s, e) => OpenChildForm<frmDepartmentList>();
            btnTsDept.Click += (s, e) => OpenChildForm<frmDepartmentList>();

            // 2. Thao tác sắp xếp Cửa sổ MDI
            mnuCascade.Click += (s, e) => this.LayoutMdi(MdiLayout.Cascade);
            btnTsCascade.Click += (s, e) => this.LayoutMdi(MdiLayout.Cascade);

            mnuTileHorizontal.Click += (s, e) => this.LayoutMdi(MdiLayout.TileHorizontal);
            btnTsTileH.Click += (s, e) => this.LayoutMdi(MdiLayout.TileHorizontal);

            mnuTileVertical.Click += (s, e) => this.LayoutMdi(MdiLayout.TileVertical);
            btnTsTileV.Click += (s, e) => this.LayoutMdi(MdiLayout.TileVertical);

            mnuCloseAll.Click += (s, e) => CloseAllChildForms();
            btnTsCloseAll.Click += (s, e) => CloseAllChildForms();

            // 3. Hệ thống: Nạp lại dữ liệu, Đăng xuất, Thoát
            mnuReloadData.Click += async (s, e) => await ReloadDataWithProgressAsync();
            btnTsReload.Click += async (s, e) => await ReloadDataWithProgressAsync();

            mnuLogout.Click += BtnLogout_Click;
            mnuExit.Click += (s, e) => this.Close();

            // 4. Trợ giúp
            mnuAbout.Click += (s, e) =>
            {
                using var frm = new frmAbout();
                frm.ShowDialog(this);
            };
        }

        #endregion

        #region Quản lý Vòng đời Form con MDI chuẩn mực

        /// <summary>
        /// Yêu cầu nghiệp vụ cốt lõi:
        /// - Khi người dùng click chọn Menu Form con, hệ thống phải duyệt qua danh sách MdiChildren.
        /// - Nếu Form đã mở: gọi lệnh Activate() để mang Form đó lên trên cùng (ngăn Duplicate).
        /// - Nếu Form chưa mở: khởi tạo Instance mới, gán MdiParent = this và gọi .Show().
        /// </summary>
        public T OpenChildForm<T>() where T : Form, new()
        {
            // 1. Duyệt qua danh sách các Form con đang mở (MdiChildren)
            foreach (Form child in this.MdiChildren)
            {
                if (child is T targetForm)
                {
                    // Nếu Form đang bị thu nhỏ (Minimized), khôi phục về trạng thái bình thường
                    if (targetForm.WindowState == FormWindowState.Minimized)
                    {
                        targetForm.WindowState = FormWindowState.Normal;
                    }

                    // Kích hoạt mang Form lên trên cùng
                    targetForm.Activate();
                    lblSystemStatus.Text = $"Đã kích hoạt cửa sổ: {targetForm.Text}";
                    UpdateOpenWindowsStatus();
                    return targetForm;
                }
            }

            // 2. Nếu Form chưa mở, khởi tạo Instance mới, gán MdiParent = this và gọi .Show()
            T newForm = new T
            {
                MdiParent = this,
                StartPosition = FormStartPosition.CenterScreen
            };

            // Đăng ký sự kiện cập nhật trạng thái khi form đóng
            newForm.FormClosed += (s, e) => UpdateOpenWindowsStatus();
            newForm.Show();

            lblSystemStatus.Text = $"Đã mở cửa sổ mới: {newForm.Text}";
            UpdateOpenWindowsStatus();
            return newForm;
        }

        private void CloseAllChildForms()
        {
            var openChildren = this.MdiChildren.ToArray();
            if (openChildren.Length == 0)
            {
                MessageBox.Show("Hiện không có cửa sổ con nào đang mở!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            foreach (Form child in openChildren)
            {
                child.Close();
            }

            lblSystemStatus.Text = "Đã đóng tất cả các cửa sổ con.";
            UpdateOpenWindowsStatus();
        }

        private void UpdateOpenWindowsStatus()
        {
            int count = this.MdiChildren.Length;
            lblOpenWindows.Text = $"Cửa sổ đang mở: {count}";
        }

        #endregion

        #region Tác vụ Hệ thống (Nạp lại dữ liệu, Đăng xuất, Thoát)

        private async Task ReloadDataWithProgressAsync()
        {
            try
            {
                progressBar.Visible = true;
                progressBar.Value = 0;
                lblSystemStatus.Text = "Đang đồng bộ và nạp lại dữ liệu hệ thống...";

                // Mô phỏng tiến trình nạp dữ liệu mượt mà
                for (int i = 0; i <= 100; i += 25)
                {
                    progressBar.Value = i;
                    await Task.Delay(80);
                }

                // Thực hiện nạp lại dữ liệu từ DataStore
                HospitalDataStore.ReloadAllData();

                lblSystemStatus.Text = "Nạp lại toàn bộ dữ liệu hệ thống thành công!";
            }
            finally
            {
                await Task.Delay(400);
                progressBar.Visible = false;
            }
        }

        private void BtnLogout_Click(object? sender, EventArgs e)
        {
            var result = MessageBox.Show(
                "Bạn có chắc chắn muốn đăng xuất khỏi ca trực hiện tại?\n\n" +
                "Tất cả các cửa sổ con đang thao tác sẽ được đóng lại để đảm bảo an toàn hồ sơ y tế.",
                "Xác nhận đăng xuất",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
            {
                CloseAllChildForms();
                lblDutyOfficer.Text = "Bác sĩ trực ban: (Chưa đăng nhập)";
                lblSystemStatus.Text = "Đã đăng xuất phiên làm việc an toàn.";

                MessageBox.Show(
                    "Đã đăng xuất thành công khỏi hệ thống bệnh viện!\n" +
                    "Nhấn OK để tái thiết lập phiên làm việc trực ban mới.",
                    "Đăng xuất thành công",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information);

                lblDutyOfficer.Text = "Bác sĩ trực ban: BS. CKII Nguyễn Văn An (Mã: BS01) - Trực trưởng ca";
                lblSystemStatus.Text = "Hệ thống MDI sẵn sàng";
            }
        }

        protected override void OnFormClosing(FormClosingEventArgs e)
        {
            if (e.CloseReason == CloseReason.UserClosing)
            {
                var result = MessageBox.Show(
                    "Bạn có chắc chắn muốn thoát khỏi Hệ thống Quản lý Bệnh viện & Bệnh án không?",
                    "Xác nhận thoát hệ thống",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Question);

                if (result == DialogResult.No)
                {
                    e.Cancel = true;
                    return;
                }
            }

            _clockTimer.Stop();
            _clockTimer.Dispose();
            base.OnFormClosing(e);
        }

        #endregion
    }
}
