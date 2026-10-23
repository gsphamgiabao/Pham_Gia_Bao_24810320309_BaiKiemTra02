namespace HospitalManagementSystem.Forms
{
    partial class frmPatientProfiles
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
            this.pnlHeader = new System.Windows.Forms.Panel();
            this.lblHeaderSubtitle = new System.Windows.Forms.Label();
            this.lblHeaderTitle = new System.Windows.Forms.Label();
            this.pnlTopContainer = new System.Windows.Forms.Panel();
            this.grpPatientInfo = new System.Windows.Forms.GroupBox();
            this.txtDiagnosis = new System.Windows.Forms.TextBox();
            this.lblDiagnosis = new System.Windows.Forms.Label();
            this.cboTreatmentStatus = new System.Windows.Forms.ComboBox();
            this.lblTreatmentStatus = new System.Windows.Forms.Label();
            this.cboDoctor = new System.Windows.Forms.ComboBox();
            this.lblDoctor = new System.Windows.Forms.Label();
            this.dtpAdmissionDate = new System.Windows.Forms.DateTimePicker();
            this.lblAdmissionDate = new System.Windows.Forms.Label();
            this.txtBedNumber = new System.Windows.Forms.TextBox();
            this.lblBedNumber = new System.Windows.Forms.Label();
            this.cboDepartment = new System.Windows.Forms.ComboBox();
            this.lblDepartment = new System.Windows.Forms.Label();
            this.txtAddress = new System.Windows.Forms.TextBox();
            this.lblAddress = new System.Windows.Forms.Label();
            this.txtPhone = new System.Windows.Forms.TextBox();
            this.lblPhone = new System.Windows.Forms.Label();
            this.dtpDob = new System.Windows.Forms.DateTimePicker();
            this.lblDob = new System.Windows.Forms.Label();
            this.cboGender = new System.Windows.Forms.ComboBox();
            this.lblGender = new System.Windows.Forms.Label();
            this.txtFullName = new System.Windows.Forms.TextBox();
            this.lblFullName = new System.Windows.Forms.Label();
            this.btnAutoId = new System.Windows.Forms.Button();
            this.txtPatientId = new System.Windows.Forms.TextBox();
            this.lblPatientId = new System.Windows.Forms.Label();
            this.pnlActions = new System.Windows.Forms.Panel();
            this.btnViewRecord = new System.Windows.Forms.Button();
            this.btnReset = new System.Windows.Forms.Button();
            this.btnDelete = new System.Windows.Forms.Button();
            this.btnEdit = new System.Windows.Forms.Button();
            this.btnAdd = new System.Windows.Forms.Button();
            this.pnlFilter = new System.Windows.Forms.Panel();
            this.btnResetFilter = new System.Windows.Forms.Button();
            this.btnSearch = new System.Windows.Forms.Button();
            this.cboFilterStatus = new System.Windows.Forms.ComboBox();
            this.lblFilterStatus = new System.Windows.Forms.Label();
            this.cboFilterDept = new System.Windows.Forms.ComboBox();
            this.lblFilterDept = new System.Windows.Forms.Label();
            this.txtSearchKeyword = new System.Windows.Forms.TextBox();
            this.lblSearch = new System.Windows.Forms.Label();
            this.grpList = new System.Windows.Forms.GroupBox();
            this.dgvPatients = new System.Windows.Forms.DataGridView();
            this.pnlFooter = new System.Windows.Forms.Panel();
            this.lblStatDischarged = new System.Windows.Forms.Label();
            this.lblStatWaiting = new System.Windows.Forms.Label();
            this.lblStatTreating = new System.Windows.Forms.Label();
            this.lblStatTotal = new System.Windows.Forms.Label();
            this.errorProvider1 = new System.Windows.Forms.ErrorProvider(this.components);
            this.pnlHeader.SuspendLayout();
            this.pnlTopContainer.SuspendLayout();
            this.grpPatientInfo.SuspendLayout();
            this.pnlActions.SuspendLayout();
            this.pnlFilter.SuspendLayout();
            this.grpList.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvPatients)).BeginInit();
            this.pnlFooter.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).BeginInit();
            this.SuspendLayout();
            // 
            // pnlHeader
            // 
            this.pnlHeader.BackColor = System.Drawing.Color.FromArgb(13, 100, 140);
            this.pnlHeader.Controls.Add(this.lblHeaderSubtitle);
            this.pnlHeader.Controls.Add(this.lblHeaderTitle);
            this.pnlHeader.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlHeader.Location = new System.Drawing.Point(0, 0);
            this.pnlHeader.Name = "pnlHeader";
            this.pnlHeader.Size = new System.Drawing.Size(1120, 60);
            this.pnlHeader.TabIndex = 0;
            // 
            // lblHeaderSubtitle
            // 
            this.lblHeaderSubtitle.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lblHeaderSubtitle.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.lblHeaderSubtitle.ForeColor = System.Drawing.Color.FromArgb(220, 240, 255);
            this.lblHeaderSubtitle.Location = new System.Drawing.Point(0, 32);
            this.lblHeaderSubtitle.Name = "lblHeaderSubtitle";
            this.lblHeaderSubtitle.Size = new System.Drawing.Size(1120, 20);
            this.lblHeaderSubtitle.TabIndex = 1;
            this.lblHeaderSubtitle.Text = "Hệ thống Quản lý Bệnh viện Đa khoa - Mô-đun Quản lý và Truy xuất Bệnh án Nội trú/Ngoại trú";
            this.lblHeaderSubtitle.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblHeaderTitle
            // 
            this.lblHeaderTitle.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lblHeaderTitle.Font = new System.Drawing.Font("Segoe UI", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.lblHeaderTitle.ForeColor = System.Drawing.Color.White;
            this.lblHeaderTitle.Location = new System.Drawing.Point(0, 5);
            this.lblHeaderTitle.Name = "lblHeaderTitle";
            this.lblHeaderTitle.Size = new System.Drawing.Size(1120, 28);
            this.lblHeaderTitle.TabIndex = 0;
            this.lblHeaderTitle.Text = "QUẢN LÝ HỒ SƠ BỆNH NHÂN & TRUY XUẤT BỆNH ÁN";
            this.lblHeaderTitle.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // pnlTopContainer
            // 
            this.pnlTopContainer.Controls.Add(this.grpPatientInfo);
            this.pnlTopContainer.Controls.Add(this.pnlActions);
            this.pnlTopContainer.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlTopContainer.Location = new System.Drawing.Point(0, 60);
            this.pnlTopContainer.Name = "pnlTopContainer";
            this.pnlTopContainer.Padding = new System.Windows.Forms.Padding(10, 8, 10, 4);
            this.pnlTopContainer.Size = new System.Drawing.Size(1120, 220);
            this.pnlTopContainer.TabIndex = 1;
            // 
            // grpPatientInfo
            // 
            this.grpPatientInfo.Controls.Add(this.txtDiagnosis);
            this.grpPatientInfo.Controls.Add(this.lblDiagnosis);
            this.grpPatientInfo.Controls.Add(this.cboTreatmentStatus);
            this.grpPatientInfo.Controls.Add(this.lblTreatmentStatus);
            this.grpPatientInfo.Controls.Add(this.cboDoctor);
            this.grpPatientInfo.Controls.Add(this.lblDoctor);
            this.grpPatientInfo.Controls.Add(this.dtpAdmissionDate);
            this.grpPatientInfo.Controls.Add(this.lblAdmissionDate);
            this.grpPatientInfo.Controls.Add(this.txtBedNumber);
            this.grpPatientInfo.Controls.Add(this.lblBedNumber);
            this.grpPatientInfo.Controls.Add(this.cboDepartment);
            this.grpPatientInfo.Controls.Add(this.lblDepartment);
            this.grpPatientInfo.Controls.Add(this.txtAddress);
            this.grpPatientInfo.Controls.Add(this.lblAddress);
            this.grpPatientInfo.Controls.Add(this.txtPhone);
            this.grpPatientInfo.Controls.Add(this.lblPhone);
            this.grpPatientInfo.Controls.Add(this.dtpDob);
            this.grpPatientInfo.Controls.Add(this.lblDob);
            this.grpPatientInfo.Controls.Add(this.cboGender);
            this.grpPatientInfo.Controls.Add(this.lblGender);
            this.grpPatientInfo.Controls.Add(this.txtFullName);
            this.grpPatientInfo.Controls.Add(this.lblFullName);
            this.grpPatientInfo.Controls.Add(this.btnAutoId);
            this.grpPatientInfo.Controls.Add(this.txtPatientId);
            this.grpPatientInfo.Controls.Add(this.lblPatientId);
            this.grpPatientInfo.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grpPatientInfo.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.grpPatientInfo.ForeColor = System.Drawing.Color.FromArgb(13, 71, 107);
            this.grpPatientInfo.Location = new System.Drawing.Point(10, 8);
            this.grpPatientInfo.Name = "grpPatientInfo";
            this.grpPatientInfo.Size = new System.Drawing.Size(950, 208);
            this.grpPatientInfo.TabIndex = 0;
            this.grpPatientInfo.TabStop = false;
            this.grpPatientInfo.Text = "THÔNG TIN CHI TIẾT HỒ SƠ BỆNH NHÂN";
            // 
            // txtDiagnosis
            // 
            this.txtDiagnosis.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtDiagnosis.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.txtDiagnosis.Location = new System.Drawing.Point(685, 126);
            this.txtDiagnosis.Multiline = true;
            this.txtDiagnosis.Name = "txtDiagnosis";
            this.txtDiagnosis.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtDiagnosis.Size = new System.Drawing.Size(250, 68);
            this.txtDiagnosis.TabIndex = 24;
            // 
            // lblDiagnosis
            // 
            this.lblDiagnosis.AutoSize = true;
            this.lblDiagnosis.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.lblDiagnosis.ForeColor = System.Drawing.Color.Black;
            this.lblDiagnosis.Location = new System.Drawing.Point(685, 107);
            this.lblDiagnosis.Name = "lblDiagnosis";
            this.lblDiagnosis.Size = new System.Drawing.Size(126, 15);
            this.lblDiagnosis.TabIndex = 23;
            this.lblDiagnosis.Text = "Chẩn đoán / Bệnh án:";
            // 
            // cboTreatmentStatus
            // 
            this.cboTreatmentStatus.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboTreatmentStatus.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.cboTreatmentStatus.FormattingEnabled = true;
            this.cboTreatmentStatus.Location = new System.Drawing.Point(445, 171);
            this.cboTreatmentStatus.Name = "cboTreatmentStatus";
            this.cboTreatmentStatus.Size = new System.Drawing.Size(215, 23);
            this.cboTreatmentStatus.TabIndex = 22;
            // 
            // lblTreatmentStatus
            // 
            this.lblTreatmentStatus.AutoSize = true;
            this.lblTreatmentStatus.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.lblTreatmentStatus.ForeColor = System.Drawing.Color.Black;
            this.lblTreatmentStatus.Location = new System.Drawing.Point(340, 175);
            this.lblTreatmentStatus.Name = "lblTreatmentStatus";
            this.lblTreatmentStatus.Size = new System.Drawing.Size(90, 15);
            this.lblTreatmentStatus.TabIndex = 21;
            this.lblTreatmentStatus.Text = "Tình trạng Đ/t:";
            // 
            // cboDoctor
            // 
            this.cboDoctor.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboDoctor.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.cboDoctor.FormattingEnabled = true;
            this.cboDoctor.Location = new System.Drawing.Point(445, 136);
            this.cboDoctor.Name = "cboDoctor";
            this.cboDoctor.Size = new System.Drawing.Size(215, 23);
            this.cboDoctor.TabIndex = 20;
            // 
            // lblDoctor
            // 
            this.lblDoctor.AutoSize = true;
            this.lblDoctor.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.lblDoctor.ForeColor = System.Drawing.Color.Black;
            this.lblDoctor.Location = new System.Drawing.Point(340, 140);
            this.lblDoctor.Name = "lblDoctor";
            this.lblDoctor.Size = new System.Drawing.Size(77, 15);
            this.lblDoctor.TabIndex = 19;
            this.lblDoctor.Text = "Bác sĩ điều trị:";
            // 
            // dtpAdmissionDate
            // 
            this.dtpAdmissionDate.CustomFormat = "dd/MM/yyyy";
            this.dtpAdmissionDate.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.dtpAdmissionDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpAdmissionDate.Location = new System.Drawing.Point(445, 101);
            this.dtpAdmissionDate.Name = "dtpAdmissionDate";
            this.dtpAdmissionDate.Size = new System.Drawing.Size(215, 23);
            this.dtpAdmissionDate.TabIndex = 18;
            // 
            // lblAdmissionDate
            // 
            this.lblAdmissionDate.AutoSize = true;
            this.lblAdmissionDate.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.lblAdmissionDate.ForeColor = System.Drawing.Color.Black;
            this.lblAdmissionDate.Location = new System.Drawing.Point(340, 105);
            this.lblAdmissionDate.Name = "lblAdmissionDate";
            this.lblAdmissionDate.Size = new System.Drawing.Size(95, 15);
            this.lblAdmissionDate.TabIndex = 17;
            this.lblAdmissionDate.Text = "Ngày nhập viện:";
            // 
            // txtBedNumber
            // 
            this.txtBedNumber.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.txtBedNumber.Location = new System.Drawing.Point(445, 66);
            this.txtBedNumber.Name = "txtBedNumber";
            this.txtBedNumber.Size = new System.Drawing.Size(215, 23);
            this.txtBedNumber.TabIndex = 16;
            // 
            // lblBedNumber
            // 
            this.lblBedNumber.AutoSize = true;
            this.lblBedNumber.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.lblBedNumber.ForeColor = System.Drawing.Color.Black;
            this.lblBedNumber.Location = new System.Drawing.Point(340, 70);
            this.lblBedNumber.Name = "lblBedNumber";
            this.lblBedNumber.Size = new System.Drawing.Size(99, 15);
            this.lblBedNumber.TabIndex = 15;
            this.lblBedNumber.Text = "Phòng - Giường:";
            // 
            // cboDepartment
            // 
            this.cboDepartment.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboDepartment.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.cboDepartment.FormattingEnabled = true;
            this.cboDepartment.Location = new System.Drawing.Point(445, 31);
            this.cboDepartment.Name = "cboDepartment";
            this.cboDepartment.Size = new System.Drawing.Size(215, 23);
            this.cboDepartment.TabIndex = 14;
            // 
            // lblDepartment
            // 
            this.lblDepartment.AutoSize = true;
            this.lblDepartment.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.lblDepartment.ForeColor = System.Drawing.Color.Black;
            this.lblDepartment.Location = new System.Drawing.Point(340, 35);
            this.lblDepartment.Name = "lblDepartment";
            this.lblDepartment.Size = new System.Drawing.Size(85, 15);
            this.lblDepartment.TabIndex = 13;
            this.lblDepartment.Text = "Khoa điều trị:";
            // 
            // txtAddress
            // 
            this.txtAddress.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtAddress.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.txtAddress.Location = new System.Drawing.Point(685, 48);
            this.txtAddress.Multiline = true;
            this.txtAddress.Name = "txtAddress";
            this.txtAddress.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtAddress.Size = new System.Drawing.Size(250, 48);
            this.txtAddress.TabIndex = 12;
            // 
            // lblAddress
            // 
            this.lblAddress.AutoSize = true;
            this.lblAddress.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.lblAddress.ForeColor = System.Drawing.Color.Black;
            this.lblAddress.Location = new System.Drawing.Point(685, 28);
            this.lblAddress.Name = "lblAddress";
            this.lblAddress.Size = new System.Drawing.Size(84, 15);
            this.lblAddress.TabIndex = 11;
            this.lblAddress.Text = "Địa chỉ liên hệ:";
            // 
            // txtPhone
            // 
            this.txtPhone.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.txtPhone.Location = new System.Drawing.Point(100, 171);
            this.txtPhone.MaxLength = 11;
            this.txtPhone.Name = "txtPhone";
            this.txtPhone.Size = new System.Drawing.Size(215, 23);
            this.txtPhone.TabIndex = 10;
            // 
            // lblPhone
            // 
            this.lblPhone.AutoSize = true;
            this.lblPhone.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.lblPhone.ForeColor = System.Drawing.Color.Black;
            this.lblPhone.Location = new System.Drawing.Point(10, 175);
            this.lblPhone.Name = "lblPhone";
            this.lblPhone.Size = new System.Drawing.Size(80, 15);
            this.lblPhone.TabIndex = 9;
            this.lblPhone.Text = "Số điện thoại:";
            // 
            // dtpDob
            // 
            this.dtpDob.CustomFormat = "dd/MM/yyyy";
            this.dtpDob.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.dtpDob.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpDob.Location = new System.Drawing.Point(100, 136);
            this.dtpDob.Name = "dtpDob";
            this.dtpDob.Size = new System.Drawing.Size(215, 23);
            this.dtpDob.TabIndex = 8;
            // 
            // lblDob
            // 
            this.lblDob.AutoSize = true;
            this.lblDob.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.lblDob.ForeColor = System.Drawing.Color.Black;
            this.lblDob.Location = new System.Drawing.Point(10, 140);
            this.lblDob.Name = "lblDob";
            this.lblDob.Size = new System.Drawing.Size(63, 15);
            this.lblDob.TabIndex = 7;
            this.lblDob.Text = "Ngày sinh:";
            // 
            // cboGender
            // 
            this.cboGender.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboGender.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.cboGender.FormattingEnabled = true;
            this.cboGender.Location = new System.Drawing.Point(100, 101);
            this.cboGender.Name = "cboGender";
            this.cboGender.Size = new System.Drawing.Size(215, 23);
            this.cboGender.TabIndex = 6;
            // 
            // lblGender
            // 
            this.lblGender.AutoSize = true;
            this.lblGender.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.lblGender.ForeColor = System.Drawing.Color.Black;
            this.lblGender.Location = new System.Drawing.Point(10, 105);
            this.lblGender.Name = "lblGender";
            this.lblGender.Size = new System.Drawing.Size(55, 15);
            this.lblGender.TabIndex = 5;
            this.lblGender.Text = "Giới tính:";
            // 
            // txtFullName
            // 
            this.txtFullName.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.txtFullName.Location = new System.Drawing.Point(100, 66);
            this.txtFullName.Name = "txtFullName";
            this.txtFullName.Size = new System.Drawing.Size(215, 23);
            this.txtFullName.TabIndex = 4;
            // 
            // lblFullName
            // 
            this.lblFullName.AutoSize = true;
            this.lblFullName.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.lblFullName.ForeColor = System.Drawing.Color.Black;
            this.lblFullName.Location = new System.Drawing.Point(10, 70);
            this.lblFullName.Name = "lblFullName";
            this.lblFullName.Size = new System.Drawing.Size(61, 15);
            this.lblFullName.TabIndex = 3;
            this.lblFullName.Text = "Họ và tên:";
            // 
            // btnAutoId
            // 
            this.btnAutoId.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.btnAutoId.Location = new System.Drawing.Point(245, 30);
            this.btnAutoId.Name = "btnAutoId";
            this.btnAutoId.Size = new System.Drawing.Size(70, 25);
            this.btnAutoId.TabIndex = 2;
            this.btnAutoId.Text = "Tạo mã";
            this.btnAutoId.UseVisualStyleBackColor = true;
            // 
            // txtPatientId
            // 
            this.txtPatientId.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.txtPatientId.ForeColor = System.Drawing.Color.FromArgb(13, 110, 253);
            this.txtPatientId.Location = new System.Drawing.Point(100, 31);
            this.txtPatientId.Name = "txtPatientId";
            this.txtPatientId.Size = new System.Drawing.Size(140, 23);
            this.txtPatientId.TabIndex = 1;
            // 
            // lblPatientId
            // 
            this.lblPatientId.AutoSize = true;
            this.lblPatientId.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.lblPatientId.ForeColor = System.Drawing.Color.Black;
            this.lblPatientId.Location = new System.Drawing.Point(10, 35);
            this.lblPatientId.Name = "lblPatientId";
            this.lblPatientId.Size = new System.Drawing.Size(46, 15);
            this.lblPatientId.TabIndex = 0;
            this.lblPatientId.Text = "Mã BN:";
            // 
            // pnlActions
            // 
            this.pnlActions.Controls.Add(this.btnViewRecord);
            this.pnlActions.Controls.Add(this.btnReset);
            this.pnlActions.Controls.Add(this.btnDelete);
            this.pnlActions.Controls.Add(this.btnEdit);
            this.pnlActions.Controls.Add(this.btnAdd);
            this.pnlActions.Dock = System.Windows.Forms.DockStyle.Right;
            this.pnlActions.Location = new System.Drawing.Point(945, 8);
            this.pnlActions.Name = "pnlActions";
            this.pnlActions.Padding = new System.Windows.Forms.Padding(8, 6, 4, 6);
            this.pnlActions.Size = new System.Drawing.Size(165, 208);
            this.pnlActions.TabIndex = 1;
            // 
            // btnViewRecord
            // 
            this.btnViewRecord.BackColor = System.Drawing.Color.FromArgb(108, 117, 125);
            this.btnViewRecord.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnViewRecord.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnViewRecord.FlatAppearance.BorderSize = 0;
            this.btnViewRecord.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnViewRecord.Font = new System.Drawing.Font("Segoe UI", 8.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.btnViewRecord.ForeColor = System.Drawing.Color.White;
            this.btnViewRecord.Location = new System.Drawing.Point(8, 162);
            this.btnViewRecord.Name = "btnViewRecord";
            this.btnViewRecord.Size = new System.Drawing.Size(153, 36);
            this.btnViewRecord.TabIndex = 4;
            this.btnViewRecord.Text = "📄 Trích lục Bệnh án";
            this.btnViewRecord.UseVisualStyleBackColor = false;
            // 
            // btnReset
            // 
            this.btnReset.BackColor = System.Drawing.Color.FromArgb(13, 202, 240);
            this.btnReset.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnReset.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnReset.FlatAppearance.BorderSize = 0;
            this.btnReset.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnReset.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.btnReset.ForeColor = System.Drawing.Color.Black;
            this.btnReset.Location = new System.Drawing.Point(8, 124);
            this.btnReset.Name = "btnReset";
            this.btnReset.Size = new System.Drawing.Size(153, 38);
            this.btnReset.TabIndex = 3;
            this.btnReset.Text = "🔄 Làm mới";
            this.btnReset.UseVisualStyleBackColor = false;
            // 
            // btnDelete
            // 
            this.btnDelete.BackColor = System.Drawing.Color.FromArgb(220, 53, 69);
            this.btnDelete.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnDelete.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnDelete.FlatAppearance.BorderSize = 0;
            this.btnDelete.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnDelete.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.btnDelete.ForeColor = System.Drawing.Color.White;
            this.btnDelete.Location = new System.Drawing.Point(8, 86);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(153, 38);
            this.btnDelete.TabIndex = 2;
            this.btnDelete.Text = "🗑 Xóa hồ sơ";
            this.btnDelete.UseVisualStyleBackColor = false;
            // 
            // btnEdit
            // 
            this.btnEdit.BackColor = System.Drawing.Color.FromArgb(255, 193, 7);
            this.btnEdit.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnEdit.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnEdit.FlatAppearance.BorderSize = 0;
            this.btnEdit.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnEdit.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.btnEdit.ForeColor = System.Drawing.Color.Black;
            this.btnEdit.Location = new System.Drawing.Point(8, 48);
            this.btnEdit.Name = "btnEdit";
            this.btnEdit.Size = new System.Drawing.Size(153, 38);
            this.btnEdit.TabIndex = 1;
            this.btnEdit.Text = "✏ Cập nhật";
            this.btnEdit.UseVisualStyleBackColor = false;
            // 
            // btnAdd
            // 
            this.btnAdd.BackColor = System.Drawing.Color.FromArgb(25, 135, 84);
            this.btnAdd.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnAdd.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnAdd.FlatAppearance.BorderSize = 0;
            this.btnAdd.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAdd.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.btnAdd.ForeColor = System.Drawing.Color.White;
            this.btnAdd.Location = new System.Drawing.Point(8, 10);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(153, 38);
            this.btnAdd.TabIndex = 0;
            this.btnAdd.Text = "➕ Thêm hồ sơ";
            this.btnAdd.UseVisualStyleBackColor = false;
            // 
            // pnlFilter
            // 
            this.pnlFilter.BackColor = System.Drawing.Color.FromArgb(240, 245, 250);
            this.pnlFilter.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlFilter.Controls.Add(this.btnResetFilter);
            this.pnlFilter.Controls.Add(this.btnSearch);
            this.pnlFilter.Controls.Add(this.cboFilterStatus);
            this.pnlFilter.Controls.Add(this.lblFilterStatus);
            this.pnlFilter.Controls.Add(this.cboFilterDept);
            this.pnlFilter.Controls.Add(this.lblFilterDept);
            this.pnlFilter.Controls.Add(this.txtSearchKeyword);
            this.pnlFilter.Controls.Add(this.lblSearch);
            this.pnlFilter.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlFilter.Location = new System.Drawing.Point(0, 280);
            this.pnlFilter.Name = "pnlFilter";
            this.pnlFilter.Size = new System.Drawing.Size(1120, 44);
            this.pnlFilter.TabIndex = 2;
            // 
            // btnResetFilter
            // 
            this.btnResetFilter.BackColor = System.Drawing.Color.White;
            this.btnResetFilter.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnResetFilter.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnResetFilter.Font = new System.Drawing.Font("Segoe UI", 8.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.btnResetFilter.Location = new System.Drawing.Point(985, 7);
            this.btnResetFilter.Name = "btnResetFilter";
            this.btnResetFilter.Size = new System.Drawing.Size(85, 28);
            this.btnResetFilter.TabIndex = 7;
            this.btnResetFilter.Text = "Hủy lọc";
            this.btnResetFilter.UseVisualStyleBackColor = false;
            // 
            // btnSearch
            // 
            this.btnSearch.BackColor = System.Drawing.Color.FromArgb(13, 110, 253);
            this.btnSearch.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnSearch.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSearch.Font = new System.Drawing.Font("Segoe UI", 8.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.btnSearch.ForeColor = System.Drawing.Color.White;
            this.btnSearch.Location = new System.Drawing.Point(895, 7);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(85, 28);
            this.btnSearch.TabIndex = 6;
            this.btnSearch.Text = "🔍 Lọc / Tìm";
            this.btnSearch.UseVisualStyleBackColor = false;
            // 
            // cboFilterStatus
            // 
            this.cboFilterStatus.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboFilterStatus.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.cboFilterStatus.FormattingEnabled = true;
            this.cboFilterStatus.Location = new System.Drawing.Point(715, 10);
            this.cboFilterStatus.Name = "cboFilterStatus";
            this.cboFilterStatus.Size = new System.Drawing.Size(165, 23);
            this.cboFilterStatus.TabIndex = 5;
            // 
            // lblFilterStatus
            // 
            this.lblFilterStatus.AutoSize = true;
            this.lblFilterStatus.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.lblFilterStatus.ForeColor = System.Drawing.Color.FromArgb(13, 71, 107);
            this.lblFilterStatus.Location = new System.Drawing.Point(620, 14);
            this.lblFilterStatus.Name = "lblFilterStatus";
            this.lblFilterStatus.Size = new System.Drawing.Size(89, 15);
            this.lblFilterStatus.TabIndex = 4;
            this.lblFilterStatus.Text = "Tình trạng Đ/t:";
            // 
            // cboFilterDept
            // 
            this.cboFilterDept.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboFilterDept.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.cboFilterDept.FormattingEnabled = true;
            this.cboFilterDept.Location = new System.Drawing.Point(400, 10);
            this.cboFilterDept.Name = "cboFilterDept";
            this.cboFilterDept.Size = new System.Drawing.Size(205, 23);
            this.cboFilterDept.TabIndex = 3;
            // 
            // lblFilterDept
            // 
            this.lblFilterDept.AutoSize = true;
            this.lblFilterDept.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.lblFilterDept.ForeColor = System.Drawing.Color.FromArgb(13, 71, 107);
            this.lblFilterDept.Location = new System.Drawing.Point(315, 14);
            this.lblFilterDept.Name = "lblFilterDept";
            this.lblFilterDept.Size = new System.Drawing.Size(81, 15);
            this.lblFilterDept.TabIndex = 2;
            this.lblFilterDept.Text = "Khoa điều trị:";
            // 
            // txtSearchKeyword
            // 
            this.txtSearchKeyword.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.txtSearchKeyword.Location = new System.Drawing.Point(125, 10);
            this.txtSearchKeyword.Name = "txtSearchKeyword";
            this.txtSearchKeyword.PlaceholderText = "Nhập Mã BN hoặc Tên bệnh nhân...";
            this.txtSearchKeyword.Size = new System.Drawing.Size(175, 23);
            this.txtSearchKeyword.TabIndex = 1;
            // 
            // lblSearch
            // 
            this.lblSearch.AutoSize = true;
            this.lblSearch.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.lblSearch.ForeColor = System.Drawing.Color.FromArgb(13, 71, 107);
            this.lblSearch.Location = new System.Drawing.Point(15, 14);
            this.lblSearch.Name = "lblSearch";
            this.lblSearch.Size = new System.Drawing.Size(107, 15);
            this.lblSearch.TabIndex = 0;
            this.lblSearch.Text = "Truy xuất nhanh:";
            // 
            // grpList
            // 
            this.grpList.Controls.Add(this.dgvPatients);
            this.grpList.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grpList.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.grpList.ForeColor = System.Drawing.Color.FromArgb(13, 71, 107);
            this.grpList.Location = new System.Drawing.Point(0, 324);
            this.grpList.Name = "grpList";
            this.grpList.Padding = new System.Windows.Forms.Padding(8);
            this.grpList.Size = new System.Drawing.Size(1120, 296);
            this.grpList.TabIndex = 3;
            this.grpList.TabStop = false;
            this.grpList.Text = "DANH SÁCH BỆNH NHÂN ĐANG THEO DÕI & ĐIỀU TRỊ";
            // 
            // dgvPatients
            // 
            this.dgvPatients.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvPatients.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvPatients.Location = new System.Drawing.Point(8, 25);
            this.dgvPatients.Name = "dgvPatients";
            this.dgvPatients.RowTemplate.Height = 25;
            this.dgvPatients.Size = new System.Drawing.Size(1104, 263);
            this.dgvPatients.TabIndex = 0;
            // 
            // pnlFooter
            // 
            this.pnlFooter.BackColor = System.Drawing.Color.FromArgb(235, 240, 245);
            this.pnlFooter.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlFooter.Controls.Add(this.lblStatDischarged);
            this.pnlFooter.Controls.Add(this.lblStatWaiting);
            this.pnlFooter.Controls.Add(this.lblStatTreating);
            this.pnlFooter.Controls.Add(this.lblStatTotal);
            this.pnlFooter.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pnlFooter.Location = new System.Drawing.Point(0, 620);
            this.pnlFooter.Name = "pnlFooter";
            this.pnlFooter.Size = new System.Drawing.Size(1120, 32);
            this.pnlFooter.TabIndex = 4;
            // 
            // lblStatDischarged
            // 
            this.lblStatDischarged.AutoSize = true;
            this.lblStatDischarged.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.lblStatDischarged.ForeColor = System.Drawing.Color.FromArgb(108, 117, 125);
            this.lblStatDischarged.Location = new System.Drawing.Point(580, 8);
            this.lblStatDischarged.Name = "lblStatDischarged";
            this.lblStatDischarged.Size = new System.Drawing.Size(107, 15);
            this.lblStatDischarged.TabIndex = 3;
            this.lblStatDischarged.Text = "Đã xuất viện: 0 ca";
            // 
            // lblStatWaiting
            // 
            this.lblStatWaiting.AutoSize = true;
            this.lblStatWaiting.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.lblStatWaiting.ForeColor = System.Drawing.Color.FromArgb(253, 126, 20);
            this.lblStatWaiting.Location = new System.Drawing.Point(380, 8);
            this.lblStatWaiting.Name = "lblStatWaiting";
            this.lblStatWaiting.Size = new System.Drawing.Size(123, 15);
            this.lblStatWaiting.TabIndex = 2;
            this.lblStatWaiting.Text = "Chờ phẫu thuật: 0 ca";
            // 
            // lblStatTreating
            // 
            this.lblStatTreating.AutoSize = true;
            this.lblStatTreating.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.lblStatTreating.ForeColor = System.Drawing.Color.FromArgb(25, 135, 84);
            this.lblStatTreating.Location = new System.Drawing.Point(190, 8);
            this.lblStatTreating.Name = "lblStatTreating";
            this.lblStatTreating.Size = new System.Drawing.Size(120, 15);
            this.lblStatTreating.TabIndex = 1;
            this.lblStatTreating.Text = "Đang điều trị: 0 ca";
            // 
            // lblStatTotal
            // 
            this.lblStatTotal.AutoSize = true;
            this.lblStatTotal.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.lblStatTotal.ForeColor = System.Drawing.Color.FromArgb(13, 110, 253);
            this.lblStatTotal.Location = new System.Drawing.Point(15, 8);
            this.lblStatTotal.Name = "lblStatTotal";
            this.lblStatTotal.Size = new System.Drawing.Size(125, 15);
            this.lblStatTotal.TabIndex = 0;
            this.lblStatTotal.Text = "Tổng số hồ sơ: 0 ca";
            // 
            // errorProvider1
            // 
            this.errorProvider1.BlinkStyle = System.Windows.Forms.ErrorBlinkStyle.NeverBlink;
            this.errorProvider1.ContainerControl = this;
            // 
            // frmPatientProfiles
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(1120, 652);
            this.Controls.Add(this.grpList);
            this.Controls.Add(this.pnlFooter);
            this.Controls.Add(this.pnlFilter);
            this.Controls.Add(this.pnlTopContainer);
            this.Controls.Add(this.pnlHeader);
            this.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.MinimumSize = new System.Drawing.Size(950, 600);
            this.Name = "frmPatientProfiles";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Quản lý Hồ sơ Bệnh nhân & Truy xuất Bệnh án";
            this.pnlHeader.ResumeLayout(false);
            this.pnlTopContainer.ResumeLayout(false);
            this.grpPatientInfo.ResumeLayout(false);
            this.grpPatientInfo.PerformLayout();
            this.pnlActions.ResumeLayout(false);
            this.pnlFilter.ResumeLayout(false);
            this.pnlFilter.PerformLayout();
            this.grpList.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvPatients)).EndInit();
            this.pnlFooter.ResumeLayout(false);
            this.pnlFooter.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel pnlHeader;
        private System.Windows.Forms.Label lblHeaderSubtitle;
        private System.Windows.Forms.Label lblHeaderTitle;
        private System.Windows.Forms.Panel pnlTopContainer;
        private System.Windows.Forms.GroupBox grpPatientInfo;
        private System.Windows.Forms.Label lblPatientId;
        private System.Windows.Forms.TextBox txtPatientId;
        private System.Windows.Forms.Button btnAutoId;
        private System.Windows.Forms.TextBox txtFullName;
        private System.Windows.Forms.Label lblFullName;
        private System.Windows.Forms.Label lblGender;
        private System.Windows.Forms.ComboBox cboGender;
        private System.Windows.Forms.Label lblDob;
        private System.Windows.Forms.DateTimePicker dtpDob;
        private System.Windows.Forms.Label lblPhone;
        private System.Windows.Forms.TextBox txtPhone;
        private System.Windows.Forms.Label lblAddress;
        private System.Windows.Forms.TextBox txtAddress;
        private System.Windows.Forms.Label lblDepartment;
        private System.Windows.Forms.ComboBox cboDepartment;
        private System.Windows.Forms.Label lblBedNumber;
        private System.Windows.Forms.TextBox txtBedNumber;
        private System.Windows.Forms.Label lblAdmissionDate;
        private System.Windows.Forms.DateTimePicker dtpAdmissionDate;
        private System.Windows.Forms.Label lblDoctor;
        private System.Windows.Forms.ComboBox cboDoctor;
        private System.Windows.Forms.Label lblTreatmentStatus;
        private System.Windows.Forms.ComboBox cboTreatmentStatus;
        private System.Windows.Forms.Label lblDiagnosis;
        private System.Windows.Forms.TextBox txtDiagnosis;
        private System.Windows.Forms.Panel pnlActions;
        private System.Windows.Forms.Button btnAdd;
        private System.Windows.Forms.Button btnEdit;
        private System.Windows.Forms.Button btnDelete;
        private System.Windows.Forms.Button btnReset;
        private System.Windows.Forms.Button btnViewRecord;
        private System.Windows.Forms.Panel pnlFilter;
        private System.Windows.Forms.Label lblSearch;
        private System.Windows.Forms.TextBox txtSearchKeyword;
        private System.Windows.Forms.Label lblFilterDept;
        private System.Windows.Forms.ComboBox cboFilterDept;
        private System.Windows.Forms.Label lblFilterStatus;
        private System.Windows.Forms.ComboBox cboFilterStatus;
        private System.Windows.Forms.Button btnSearch;
        private System.Windows.Forms.Button btnResetFilter;
        private System.Windows.Forms.GroupBox grpList;
        private System.Windows.Forms.DataGridView dgvPatients;
        private System.Windows.Forms.Panel pnlFooter;
        private System.Windows.Forms.Label lblStatTotal;
        private System.Windows.Forms.Label lblStatTreating;
        private System.Windows.Forms.Label lblStatWaiting;
        private System.Windows.Forms.Label lblStatDischarged;
        private System.Windows.Forms.ErrorProvider errorProvider1;
    }
}
