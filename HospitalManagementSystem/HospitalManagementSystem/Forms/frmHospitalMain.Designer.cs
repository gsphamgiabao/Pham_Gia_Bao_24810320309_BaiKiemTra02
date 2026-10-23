namespace HospitalManagementSystem.Forms
{
    partial class frmHospitalMain
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.menuStripMain = new System.Windows.Forms.MenuStrip();
            this.mnuSystem = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuReloadData = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuLogout = new System.Windows.Forms.ToolStripMenuItem();
            this.sepSystem1 = new System.Windows.Forms.ToolStripSeparator();
            this.mnuExit = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuManagement = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuPatientProfiles = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuDoctorSchedule = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuDepartmentList = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuWindows = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuCascade = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuTileHorizontal = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuTileVertical = new System.Windows.Forms.ToolStripMenuItem();
            this.sepWindows1 = new System.Windows.Forms.ToolStripSeparator();
            this.mnuCloseAll = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuHelp = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuAbout = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMain = new System.Windows.Forms.ToolStrip();
            this.btnTsPatient = new System.Windows.Forms.ToolStripButton();
            this.btnTsSchedule = new System.Windows.Forms.ToolStripButton();
            this.btnTsDept = new System.Windows.Forms.ToolStripButton();
            this.sepTs1 = new System.Windows.Forms.ToolStripSeparator();
            this.btnTsReload = new System.Windows.Forms.ToolStripButton();
            this.sepTs2 = new System.Windows.Forms.ToolStripSeparator();
            this.btnTsCascade = new System.Windows.Forms.ToolStripButton();
            this.btnTsTileH = new System.Windows.Forms.ToolStripButton();
            this.btnTsTileV = new System.Windows.Forms.ToolStripButton();
            this.btnTsCloseAll = new System.Windows.Forms.ToolStripButton();
            this.statusStripMain = new System.Windows.Forms.StatusStrip();
            this.lblDutyOfficer = new System.Windows.Forms.ToolStripStatusLabel();
            this.lblStatusSep1 = new System.Windows.Forms.ToolStripStatusLabel();
            this.lblSystemStatus = new System.Windows.Forms.ToolStripStatusLabel();
            this.progressBar = new System.Windows.Forms.ToolStripProgressBar();
            this.lblSpring = new System.Windows.Forms.ToolStripStatusLabel();
            this.lblOpenWindows = new System.Windows.Forms.ToolStripStatusLabel();
            this.lblClock = new System.Windows.Forms.ToolStripStatusLabel();
            this.menuStripMain.SuspendLayout();
            this.toolStripMain.SuspendLayout();
            this.statusStripMain.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStripMain
            // 
            this.menuStripMain.BackColor = System.Drawing.Color.FromArgb(245, 248, 252);
            this.menuStripMain.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.menuStripMain.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnuSystem,
            this.mnuManagement,
            this.mnuWindows,
            this.mnuHelp});
            this.menuStripMain.Location = new System.Drawing.Point(0, 0);
            this.menuStripMain.MdiWindowListItem = this.mnuWindows;
            this.menuStripMain.Name = "menuStripMain";
            this.menuStripMain.Padding = new System.Windows.Forms.Padding(6, 4, 0, 4);
            this.menuStripMain.Size = new System.Drawing.Size(1264, 29);
            this.menuStripMain.TabIndex = 0;
            this.menuStripMain.Text = "menuStripMain";
            // 
            // mnuSystem
            // 
            this.mnuSystem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnuReloadData,
            this.mnuLogout,
            this.sepSystem1,
            this.mnuExit});
            this.mnuSystem.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.mnuSystem.ForeColor = System.Drawing.Color.FromArgb(13, 71, 107);
            this.mnuSystem.Name = "mnuSystem";
            this.mnuSystem.Size = new System.Drawing.Size(76, 21);
            this.mnuSystem.Text = "&Hệ thống";
            // 
            // mnuReloadData
            // 
            this.mnuReloadData.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.mnuReloadData.Name = "mnuReloadData";
            this.mnuReloadData.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.R)));
            this.mnuReloadData.Size = new System.Drawing.Size(201, 22);
            this.mnuReloadData.Text = "&Nạp lại dữ liệu";
            // 
            // mnuLogout
            // 
            this.mnuLogout.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.mnuLogout.Name = "mnuLogout";
            this.mnuLogout.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.L)));
            this.mnuLogout.Size = new System.Drawing.Size(201, 22);
            this.mnuLogout.Text = "Đăng &xuất";
            // 
            // sepSystem1
            // 
            this.sepSystem1.Name = "sepSystem1";
            this.sepSystem1.Size = new System.Drawing.Size(198, 6);
            // 
            // mnuExit
            // 
            this.mnuExit.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.mnuExit.Name = "mnuExit";
            this.mnuExit.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Alt | System.Windows.Forms.Keys.F4)));
            this.mnuExit.Size = new System.Drawing.Size(201, 22);
            this.mnuExit.Text = "&Thoát";
            // 
            // mnuManagement
            // 
            this.mnuManagement.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnuPatientProfiles,
            this.mnuDoctorSchedule,
            this.mnuDepartmentList});
            this.mnuManagement.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.mnuManagement.ForeColor = System.Drawing.Color.FromArgb(13, 71, 107);
            this.mnuManagement.Name = "mnuManagement";
            this.mnuManagement.Size = new System.Drawing.Size(68, 21);
            this.mnuManagement.Text = "&Quản lý";
            // 
            // mnuPatientProfiles
            // 
            this.mnuPatientProfiles.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.mnuPatientProfiles.Name = "mnuPatientProfiles";
            this.mnuPatientProfiles.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.P)));
            this.mnuPatientProfiles.Size = new System.Drawing.Size(248, 22);
            this.mnuPatientProfiles.Text = "Hồ sơ &Bệnh nhân";
            // 
            // mnuDoctorSchedule
            // 
            this.mnuDoctorSchedule.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.mnuDoctorSchedule.Name = "mnuDoctorSchedule";
            this.mnuDoctorSchedule.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.D)));
            this.mnuDoctorSchedule.Size = new System.Drawing.Size(248, 22);
            this.mnuDoctorSchedule.Text = "&Danh mục Bác sĩ / Lịch trực";
            // 
            // mnuDepartmentList
            // 
            this.mnuDepartmentList.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.mnuDepartmentList.Name = "mnuDepartmentList";
            this.mnuDepartmentList.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.K)));
            this.mnuDepartmentList.Size = new System.Drawing.Size(248, 22);
            this.mnuDepartmentList.Text = "Danh mục &Khoa / Phòng";
            // 
            // mnuWindows
            // 
            this.mnuWindows.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnuCascade,
            this.mnuTileHorizontal,
            this.mnuTileVertical,
            this.sepWindows1,
            this.mnuCloseAll});
            this.mnuWindows.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.mnuWindows.ForeColor = System.Drawing.Color.FromArgb(13, 71, 107);
            this.mnuWindows.Name = "mnuWindows";
            this.mnuWindows.Size = new System.Drawing.Size(64, 21);
            this.mnuWindows.Text = "&Cửa sổ";
            // 
            // mnuCascade
            // 
            this.mnuCascade.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.mnuCascade.Name = "mnuCascade";
            this.mnuCascade.Size = new System.Drawing.Size(227, 22);
            this.mnuCascade.Text = "Sắp xếp &Xếp tầng (Cascade)";
            // 
            // mnuTileHorizontal
            // 
            this.mnuTileHorizontal.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.mnuTileHorizontal.Name = "mnuTileHorizontal";
            this.mnuTileHorizontal.Size = new System.Drawing.Size(227, 22);
            this.mnuTileHorizontal.Text = "Sắp xếp &Ngang (Tile Horiz)";
            // 
            // mnuTileVertical
            // 
            this.mnuTileVertical.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.mnuTileVertical.Name = "mnuTileVertical";
            this.mnuTileVertical.Size = new System.Drawing.Size(227, 22);
            this.mnuTileVertical.Text = "Sắp xếp &Dọc (Tile Vertical)";
            // 
            // sepWindows1
            // 
            this.sepWindows1.Name = "sepWindows1";
            this.sepWindows1.Size = new System.Drawing.Size(224, 6);
            // 
            // mnuCloseAll
            // 
            this.mnuCloseAll.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.mnuCloseAll.Name = "mnuCloseAll";
            this.mnuCloseAll.Size = new System.Drawing.Size(227, 22);
            this.mnuCloseAll.Text = "Đón&g tất cả";
            // 
            // mnuHelp
            // 
            this.mnuHelp.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnuAbout});
            this.mnuHelp.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.mnuHelp.ForeColor = System.Drawing.Color.FromArgb(13, 71, 107);
            this.mnuHelp.Name = "mnuHelp";
            this.mnuHelp.Size = new System.Drawing.Size(73, 21);
            this.mnuHelp.Text = "Trợ &giúp";
            // 
            // mnuAbout
            // 
            this.mnuAbout.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.mnuAbout.Name = "mnuAbout";
            this.mnuAbout.Size = new System.Drawing.Size(176, 22);
            this.mnuAbout.Text = "&Giới thiệu Hệ thống";
            // 
            // toolStripMain
            // 
            this.toolStripMain.BackColor = System.Drawing.Color.FromArgb(238, 243, 248);
            this.toolStripMain.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.toolStripMain.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.toolStripMain.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.toolStripMain.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.btnTsPatient,
            this.btnTsSchedule,
            this.btnTsDept,
            this.sepTs1,
            this.btnTsReload,
            this.sepTs2,
            this.btnTsCascade,
            this.btnTsTileH,
            this.btnTsTileV,
            this.btnTsCloseAll});
            this.toolStripMain.Location = new System.Drawing.Point(0, 29);
            this.toolStripMain.Name = "toolStripMain";
            this.toolStripMain.Padding = new System.Windows.Forms.Padding(10, 3, 1, 3);
            this.toolStripMain.Size = new System.Drawing.Size(1264, 33);
            this.toolStripMain.TabIndex = 1;
            this.toolStripMain.Text = "toolStripMain";
            // 
            // btnTsPatient
            // 
            this.btnTsPatient.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.btnTsPatient.ForeColor = System.Drawing.Color.FromArgb(13, 71, 107);
            this.btnTsPatient.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnTsPatient.Margin = new System.Windows.Forms.Padding(0, 1, 6, 2);
            this.btnTsPatient.Name = "btnTsPatient";
            this.btnTsPatient.Size = new System.Drawing.Size(124, 24);
            this.btnTsPatient.Text = "Hồ sơ Bệnh nhân";
            // 
            // btnTsSchedule
            // 
            this.btnTsSchedule.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.btnTsSchedule.ForeColor = System.Drawing.Color.FromArgb(16, 100, 80);
            this.btnTsSchedule.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnTsSchedule.Margin = new System.Windows.Forms.Padding(0, 1, 6, 2);
            this.btnTsSchedule.Name = "btnTsSchedule";
            this.btnTsSchedule.Size = new System.Drawing.Size(117, 24);
            this.btnTsSchedule.Text = "Lịch trực Bác sĩ";
            // 
            // btnTsDept
            // 
            this.btnTsDept.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.btnTsDept.ForeColor = System.Drawing.Color.FromArgb(50, 80, 140);
            this.btnTsDept.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnTsDept.Margin = new System.Windows.Forms.Padding(0, 1, 6, 2);
            this.btnTsDept.Name = "btnTsDept";
            this.btnTsDept.Size = new System.Drawing.Size(100, 24);
            this.btnTsDept.Text = "Khoa / Phòng";
            // 
            // sepTs1
            // 
            this.sepTs1.Margin = new System.Windows.Forms.Padding(0, 0, 6, 0);
            this.sepTs1.Name = "sepTs1";
            this.sepTs1.Size = new System.Drawing.Size(6, 27);
            // 
            // btnTsReload
            // 
            this.btnTsReload.ForeColor = System.Drawing.Color.Black;
            this.btnTsReload.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnTsReload.Margin = new System.Windows.Forms.Padding(0, 1, 6, 2);
            this.btnTsReload.Name = "btnTsReload";
            this.btnTsReload.Size = new System.Drawing.Size(107, 24);
            this.btnTsReload.Text = "Nạp lại dữ liệu";
            // 
            // sepTs2
            // 
            this.sepTs2.Margin = new System.Windows.Forms.Padding(0, 0, 6, 0);
            this.sepTs2.Name = "sepTs2";
            this.sepTs2.Size = new System.Drawing.Size(6, 27);
            // 
            // btnTsCascade
            // 
            this.btnTsCascade.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btnTsCascade.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnTsCascade.Margin = new System.Windows.Forms.Padding(0, 1, 6, 2);
            this.btnTsCascade.Name = "btnTsCascade";
            this.btnTsCascade.Size = new System.Drawing.Size(24, 24);
            this.btnTsCascade.Text = "Sắp xếp Xếp tầng (Cascade)";
            // 
            // btnTsTileH
            // 
            this.btnTsTileH.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btnTsTileH.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnTsTileH.Margin = new System.Windows.Forms.Padding(0, 1, 6, 2);
            this.btnTsTileH.Name = "btnTsTileH";
            this.btnTsTileH.Size = new System.Drawing.Size(24, 24);
            this.btnTsTileH.Text = "Sắp xếp Ngang (Tile Horizontal)";
            // 
            // btnTsTileV
            // 
            this.btnTsTileV.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btnTsTileV.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnTsTileV.Margin = new System.Windows.Forms.Padding(0, 1, 6, 2);
            this.btnTsTileV.Name = "btnTsTileV";
            this.btnTsTileV.Size = new System.Drawing.Size(24, 24);
            this.btnTsTileV.Text = "Sắp xếp Dọc (Tile Vertical)";
            // 
            // btnTsCloseAll
            // 
            this.btnTsCloseAll.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btnTsCloseAll.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnTsCloseAll.Margin = new System.Windows.Forms.Padding(0, 1, 6, 2);
            this.btnTsCloseAll.Name = "btnTsCloseAll";
            this.btnTsCloseAll.Size = new System.Drawing.Size(24, 24);
            this.btnTsCloseAll.Text = "Đóng tất cả cửa sổ con";
            // 
            // statusStripMain
            // 
            this.statusStripMain.BackColor = System.Drawing.Color.FromArgb(235, 240, 245);
            this.statusStripMain.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.statusStripMain.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.lblDutyOfficer,
            this.lblStatusSep1,
            this.lblSystemStatus,
            this.progressBar,
            this.lblSpring,
            this.lblOpenWindows,
            this.lblClock});
            this.statusStripMain.Location = new System.Drawing.Point(0, 727);
            this.statusStripMain.Name = "statusStripMain";
            this.statusStripMain.Padding = new System.Windows.Forms.Padding(1, 0, 14, 0);
            this.statusStripMain.Size = new System.Drawing.Size(1264, 24);
            this.statusStripMain.TabIndex = 2;
            this.statusStripMain.Text = "statusStripMain";
            // 
            // lblDutyOfficer
            // 
            this.lblDutyOfficer.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.lblDutyOfficer.ForeColor = System.Drawing.Color.FromArgb(13, 71, 107);
            this.lblDutyOfficer.Name = "lblDutyOfficer";
            this.lblDutyOfficer.Size = new System.Drawing.Size(378, 19);
            this.lblDutyOfficer.Text = "Bác sĩ trực ban: BS. CKII Nguyễn Văn An (Mã: BS01) - Trực trưởng ca";
            // 
            // lblStatusSep1
            // 
            this.lblStatusSep1.ForeColor = System.Drawing.Color.FromArgb(180, 190, 200);
            this.lblStatusSep1.Name = "lblStatusSep1";
            this.lblStatusSep1.Size = new System.Drawing.Size(10, 19);
            this.lblStatusSep1.Text = "|";
            // 
            // lblSystemStatus
            // 
            this.lblSystemStatus.ForeColor = System.Drawing.Color.FromArgb(25, 135, 84);
            this.lblSystemStatus.Name = "lblSystemStatus";
            this.lblSystemStatus.Size = new System.Drawing.Size(126, 19);
            this.lblSystemStatus.Text = "Hệ thống MDI sẵn sàng";
            // 
            // progressBar
            // 
            this.progressBar.Name = "progressBar";
            this.progressBar.Size = new System.Drawing.Size(120, 18);
            this.progressBar.Style = System.Windows.Forms.ProgressBarStyle.Continuous;
            this.progressBar.Visible = false;
            // 
            // lblSpring
            // 
            this.lblSpring.Name = "lblSpring";
            this.lblSpring.Size = new System.Drawing.Size(585, 19);
            this.lblSpring.Spring = true;
            // 
            // lblOpenWindows
            // 
            this.lblOpenWindows.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.lblOpenWindows.ForeColor = System.Drawing.Color.FromArgb(70, 80, 95);
            this.lblOpenWindows.Name = "lblOpenWindows";
            this.lblOpenWindows.Size = new System.Drawing.Size(106, 19);
            this.lblOpenWindows.Text = "Cửa sổ đang mở: 0";
            // 
            // lblClock
            // 
            this.lblClock.ForeColor = System.Drawing.Color.Black;
            this.lblClock.Name = "lblClock";
            this.lblClock.Size = new System.Drawing.Size(49, 19);
            this.lblClock.Text = "00:00:00";
            // 
            // frmHospitalMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1264, 751);
            this.Controls.Add(this.statusStripMain);
            this.Controls.Add(this.toolStripMain);
            this.Controls.Add(this.menuStripMain);
            this.IsMdiContainer = true;
            this.MainMenuStrip = this.menuStripMain;
            this.MinimumSize = new System.Drawing.Size(1024, 680);
            this.Name = "frmHospitalMain";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "HỆ THỐNG MDI QUẢN LÝ BỆNH VIỆN & TRUY XUẤT HỒ SƠ BỆNH ÁN";
            this.menuStripMain.ResumeLayout(false);
            this.menuStripMain.PerformLayout();
            this.toolStripMain.ResumeLayout(false);
            this.toolStripMain.PerformLayout();
            this.statusStripMain.ResumeLayout(false);
            this.statusStripMain.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStripMain;
        private System.Windows.Forms.ToolStripMenuItem mnuSystem;
        private System.Windows.Forms.ToolStripMenuItem mnuReloadData;
        private System.Windows.Forms.ToolStripMenuItem mnuLogout;
        private System.Windows.Forms.ToolStripSeparator sepSystem1;
        private System.Windows.Forms.ToolStripMenuItem mnuExit;
        private System.Windows.Forms.ToolStripMenuItem mnuManagement;
        private System.Windows.Forms.ToolStripMenuItem mnuPatientProfiles;
        private System.Windows.Forms.ToolStripMenuItem mnuDoctorSchedule;
        private System.Windows.Forms.ToolStripMenuItem mnuDepartmentList;
        private System.Windows.Forms.ToolStripMenuItem mnuWindows;
        private System.Windows.Forms.ToolStripMenuItem mnuCascade;
        private System.Windows.Forms.ToolStripMenuItem mnuTileHorizontal;
        private System.Windows.Forms.ToolStripMenuItem mnuTileVertical;
        private System.Windows.Forms.ToolStripSeparator sepWindows1;
        private System.Windows.Forms.ToolStripMenuItem mnuCloseAll;
        private System.Windows.Forms.ToolStripMenuItem mnuHelp;
        private System.Windows.Forms.ToolStripMenuItem mnuAbout;
        private System.Windows.Forms.ToolStrip toolStripMain;
        private System.Windows.Forms.ToolStripButton btnTsPatient;
        private System.Windows.Forms.ToolStripButton btnTsSchedule;
        private System.Windows.Forms.ToolStripButton btnTsDept;
        private System.Windows.Forms.ToolStripSeparator sepTs1;
        private System.Windows.Forms.ToolStripButton btnTsReload;
        private System.Windows.Forms.ToolStripSeparator sepTs2;
        private System.Windows.Forms.ToolStripButton btnTsCascade;
        private System.Windows.Forms.ToolStripButton btnTsTileH;
        private System.Windows.Forms.ToolStripButton btnTsTileV;
        private System.Windows.Forms.ToolStripButton btnTsCloseAll;
        private System.Windows.Forms.StatusStrip statusStripMain;
        private System.Windows.Forms.ToolStripStatusLabel lblDutyOfficer;
        private System.Windows.Forms.ToolStripStatusLabel lblStatusSep1;
        private System.Windows.Forms.ToolStripStatusLabel lblSystemStatus;
        private System.Windows.Forms.ToolStripProgressBar progressBar;
        private System.Windows.Forms.ToolStripStatusLabel lblSpring;
        private System.Windows.Forms.ToolStripStatusLabel lblOpenWindows;
        private System.Windows.Forms.ToolStripStatusLabel lblClock;
    }
}
