namespace HospitalManagementSystem.Forms
{
    partial class frmDoctorSchedule
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
            this.pnlTop = new System.Windows.Forms.Panel();
            this.grpScheduleInfo = new System.Windows.Forms.GroupBox();
            this.txtNote = new System.Windows.Forms.TextBox();
            this.lblNote = new System.Windows.Forms.Label();
            this.cboRole = new System.Windows.Forms.ComboBox();
            this.lblRole = new System.Windows.Forms.Label();
            this.txtDutyRoom = new System.Windows.Forms.TextBox();
            this.lblDutyRoom = new System.Windows.Forms.Label();
            this.cboShift = new System.Windows.Forms.ComboBox();
            this.lblShift = new System.Windows.Forms.Label();
            this.dtpDutyDate = new System.Windows.Forms.DateTimePicker();
            this.lblDutyDate = new System.Windows.Forms.Label();
            this.cboDepartment = new System.Windows.Forms.ComboBox();
            this.lblDepartment = new System.Windows.Forms.Label();
            this.cboDoctor = new System.Windows.Forms.ComboBox();
            this.lblDoctor = new System.Windows.Forms.Label();
            this.btnAutoId = new System.Windows.Forms.Button();
            this.txtScheduleId = new System.Windows.Forms.TextBox();
            this.lblScheduleId = new System.Windows.Forms.Label();
            this.pnlActions = new System.Windows.Forms.Panel();
            this.btnReset = new System.Windows.Forms.Button();
            this.btnDelete = new System.Windows.Forms.Button();
            this.btnEdit = new System.Windows.Forms.Button();
            this.btnAdd = new System.Windows.Forms.Button();
            this.pnlFilter = new System.Windows.Forms.Panel();
            this.btnResetFilter = new System.Windows.Forms.Button();
            this.btnFilter = new System.Windows.Forms.Button();
            this.cboFilterDept = new System.Windows.Forms.ComboBox();
            this.lblFilterDept = new System.Windows.Forms.Label();
            this.dtpFilterDate = new System.Windows.Forms.DateTimePicker();
            this.chkFilterDate = new System.Windows.Forms.CheckBox();
            this.grpList = new System.Windows.Forms.GroupBox();
            this.dgvSchedules = new System.Windows.Forms.DataGridView();
            this.errorProvider1 = new System.Windows.Forms.ErrorProvider(this.components);
            this.pnlHeader.SuspendLayout();
            this.pnlTop.SuspendLayout();
            this.grpScheduleInfo.SuspendLayout();
            this.pnlActions.SuspendLayout();
            this.pnlFilter.SuspendLayout();
            this.grpList.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvSchedules)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).BeginInit();
            this.SuspendLayout();
            // 
            // pnlHeader
            // 
            this.pnlHeader.BackColor = System.Drawing.Color.FromArgb(16, 120, 95);
            this.pnlHeader.Controls.Add(this.lblHeaderSubtitle);
            this.pnlHeader.Controls.Add(this.lblHeaderTitle);
            this.pnlHeader.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlHeader.Location = new System.Drawing.Point(0, 0);
            this.pnlHeader.Name = "pnlHeader";
            this.pnlHeader.Size = new System.Drawing.Size(1020, 60);
            this.pnlHeader.TabIndex = 0;
            // 
            // lblHeaderSubtitle
            // 
            this.lblHeaderSubtitle.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lblHeaderSubtitle.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.lblHeaderSubtitle.ForeColor = System.Drawing.Color.FromArgb(220, 250, 240);
            this.lblHeaderSubtitle.Location = new System.Drawing.Point(0, 32);
            this.lblHeaderSubtitle.Name = "lblHeaderSubtitle";
            this.lblHeaderSubtitle.Size = new System.Drawing.Size(1020, 20);
            this.lblHeaderSubtitle.TabIndex = 1;
            this.lblHeaderSubtitle.Text = "Hệ thống Phân bổ Ca trực, Giám sát kíp trực Cấp cứu & Chuyên khoa Bệnh viện";
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
            this.lblHeaderTitle.Size = new System.Drawing.Size(1020, 28);
            this.lblHeaderTitle.TabIndex = 0;
            this.lblHeaderTitle.Text = "LỊCH TRỰC BÁC SĨ & ĐIỀU HÀNH CA TRỰC";
            this.lblHeaderTitle.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // pnlTop
            // 
            this.pnlTop.Controls.Add(this.grpScheduleInfo);
            this.pnlTop.Controls.Add(this.pnlActions);
            this.pnlTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlTop.Location = new System.Drawing.Point(0, 60);
            this.pnlTop.Name = "pnlTop";
            this.pnlTop.Padding = new System.Windows.Forms.Padding(10, 8, 10, 4);
            this.pnlTop.Size = new System.Drawing.Size(1020, 190);
            this.pnlTop.TabIndex = 1;
            // 
            // grpScheduleInfo
            // 
            this.grpScheduleInfo.Controls.Add(this.txtNote);
            this.grpScheduleInfo.Controls.Add(this.lblNote);
            this.grpScheduleInfo.Controls.Add(this.cboRole);
            this.grpScheduleInfo.Controls.Add(this.lblRole);
            this.grpScheduleInfo.Controls.Add(this.txtDutyRoom);
            this.grpScheduleInfo.Controls.Add(this.lblDutyRoom);
            this.grpScheduleInfo.Controls.Add(this.cboShift);
            this.grpScheduleInfo.Controls.Add(this.lblShift);
            this.grpScheduleInfo.Controls.Add(this.dtpDutyDate);
            this.grpScheduleInfo.Controls.Add(this.lblDutyDate);
            this.grpScheduleInfo.Controls.Add(this.cboDepartment);
            this.grpScheduleInfo.Controls.Add(this.lblDepartment);
            this.grpScheduleInfo.Controls.Add(this.cboDoctor);
            this.grpScheduleInfo.Controls.Add(this.lblDoctor);
            this.grpScheduleInfo.Controls.Add(this.btnAutoId);
            this.grpScheduleInfo.Controls.Add(this.txtScheduleId);
            this.grpScheduleInfo.Controls.Add(this.lblScheduleId);
            this.grpScheduleInfo.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grpScheduleInfo.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.grpScheduleInfo.ForeColor = System.Drawing.Color.FromArgb(16, 100, 80);
            this.grpScheduleInfo.Location = new System.Drawing.Point(10, 8);
            this.grpScheduleInfo.Name = "grpScheduleInfo";
            this.grpScheduleInfo.Size = new System.Drawing.Size(850, 178);
            this.grpScheduleInfo.TabIndex = 0;
            this.grpScheduleInfo.TabStop = false;
            this.grpScheduleInfo.Text = "THÔNG TIN PHÂN BỔ CA TRỰC";
            // 
            // txtNote
            // 
            this.txtNote.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtNote.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.txtNote.Location = new System.Drawing.Point(465, 134);
            this.txtNote.Multiline = true;
            this.txtNote.Name = "txtNote";
            this.txtNote.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtNote.Size = new System.Drawing.Size(365, 36);
            this.txtNote.TabIndex = 16;
            // 
            // lblNote
            // 
            this.lblNote.AutoSize = true;
            this.lblNote.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.lblNote.ForeColor = System.Drawing.Color.Black;
            this.lblNote.Location = new System.Drawing.Point(380, 138);
            this.lblNote.Name = "lblNote";
            this.lblNote.Size = new System.Drawing.Size(51, 15);
            this.lblNote.TabIndex = 15;
            this.lblNote.Text = "Ghi chú:";
            // 
            // cboRole
            // 
            this.cboRole.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.cboRole.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboRole.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.cboRole.FormattingEnabled = true;
            this.cboRole.Location = new System.Drawing.Point(465, 98);
            this.cboRole.Name = "cboRole";
            this.cboRole.Size = new System.Drawing.Size(365, 23);
            this.cboRole.TabIndex = 14;
            // 
            // lblRole
            // 
            this.lblRole.AutoSize = true;
            this.lblRole.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.lblRole.ForeColor = System.Drawing.Color.Black;
            this.lblRole.Location = new System.Drawing.Point(380, 102);
            this.lblRole.Name = "lblRole";
            this.lblRole.Size = new System.Drawing.Size(68, 15);
            this.lblRole.TabIndex = 13;
            this.lblRole.Text = "Vai trò trực:";
            // 
            // txtDutyRoom
            // 
            this.txtDutyRoom.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtDutyRoom.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.txtDutyRoom.Location = new System.Drawing.Point(465, 63);
            this.txtDutyRoom.Name = "txtDutyRoom";
            this.txtDutyRoom.Size = new System.Drawing.Size(365, 23);
            this.txtDutyRoom.TabIndex = 12;
            // 
            // lblDutyRoom
            // 
            this.lblDutyRoom.AutoSize = true;
            this.lblDutyRoom.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.lblDutyRoom.ForeColor = System.Drawing.Color.Black;
            this.lblDutyRoom.Location = new System.Drawing.Point(380, 67);
            this.lblDutyRoom.Name = "lblDutyRoom";
            this.lblDutyRoom.Size = new System.Drawing.Size(69, 15);
            this.lblDutyRoom.TabIndex = 11;
            this.lblDutyRoom.Text = "Phòng trực:";
            // 
            // cboShift
            // 
            this.cboShift.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.cboShift.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboShift.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.cboShift.FormattingEnabled = true;
            this.cboShift.Location = new System.Drawing.Point(465, 28);
            this.cboShift.Name = "cboShift";
            this.cboShift.Size = new System.Drawing.Size(365, 23);
            this.cboShift.TabIndex = 10;
            // 
            // lblShift
            // 
            this.lblShift.AutoSize = true;
            this.lblShift.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.lblShift.ForeColor = System.Drawing.Color.Black;
            this.lblShift.Location = new System.Drawing.Point(380, 32);
            this.lblShift.Name = "lblShift";
            this.lblShift.Size = new System.Drawing.Size(46, 15);
            this.lblShift.TabIndex = 9;
            this.lblShift.Text = "Ca trực:";
            // 
            // dtpDutyDate
            // 
            this.dtpDutyDate.CustomFormat = "dd/MM/yyyy";
            this.dtpDutyDate.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.dtpDutyDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpDutyDate.Location = new System.Drawing.Point(100, 134);
            this.dtpDutyDate.Name = "dtpDutyDate";
            this.dtpDutyDate.Size = new System.Drawing.Size(255, 23);
            this.dtpDutyDate.TabIndex = 8;
            // 
            // lblDutyDate
            // 
            this.lblDutyDate.AutoSize = true;
            this.lblDutyDate.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.lblDutyDate.ForeColor = System.Drawing.Color.Black;
            this.lblDutyDate.Location = new System.Drawing.Point(10, 138);
            this.lblDutyDate.Name = "lblDutyDate";
            this.lblDutyDate.Size = new System.Drawing.Size(62, 15);
            this.lblDutyDate.TabIndex = 7;
            this.lblDutyDate.Text = "Ngày trực:";
            // 
            // cboDepartment
            // 
            this.cboDepartment.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboDepartment.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.cboDepartment.FormattingEnabled = true;
            this.cboDepartment.Location = new System.Drawing.Point(100, 98);
            this.cboDepartment.Name = "cboDepartment";
            this.cboDepartment.Size = new System.Drawing.Size(255, 23);
            this.cboDepartment.TabIndex = 6;
            // 
            // lblDepartment
            // 
            this.lblDepartment.AutoSize = true;
            this.lblDepartment.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.lblDepartment.ForeColor = System.Drawing.Color.Black;
            this.lblDepartment.Location = new System.Drawing.Point(10, 102);
            this.lblDepartment.Name = "lblDepartment";
            this.lblDepartment.Size = new System.Drawing.Size(81, 15);
            this.lblDepartment.TabIndex = 5;
            this.lblDepartment.Text = "Khoa công tác:";
            // 
            // cboDoctor
            // 
            this.cboDoctor.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboDoctor.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.cboDoctor.FormattingEnabled = true;
            this.cboDoctor.Location = new System.Drawing.Point(100, 63);
            this.cboDoctor.Name = "cboDoctor";
            this.cboDoctor.Size = new System.Drawing.Size(255, 23);
            this.cboDoctor.TabIndex = 4;
            // 
            // lblDoctor
            // 
            this.lblDoctor.AutoSize = true;
            this.lblDoctor.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.lblDoctor.ForeColor = System.Drawing.Color.Black;
            this.lblDoctor.Location = new System.Drawing.Point(10, 67);
            this.lblDoctor.Name = "lblDoctor";
            this.lblDoctor.Size = new System.Drawing.Size(65, 15);
            this.lblDoctor.TabIndex = 3;
            this.lblDoctor.Text = "Bác sĩ trực:";
            // 
            // btnAutoId
            // 
            this.btnAutoId.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.btnAutoId.Location = new System.Drawing.Point(285, 27);
            this.btnAutoId.Name = "btnAutoId";
            this.btnAutoId.Size = new System.Drawing.Size(70, 25);
            this.btnAutoId.TabIndex = 2;
            this.btnAutoId.Text = "Tạo mã";
            this.btnAutoId.UseVisualStyleBackColor = true;
            // 
            // txtScheduleId
            // 
            this.txtScheduleId.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.txtScheduleId.ForeColor = System.Drawing.Color.FromArgb(16, 120, 95);
            this.txtScheduleId.Location = new System.Drawing.Point(100, 28);
            this.txtScheduleId.Name = "txtScheduleId";
            this.txtScheduleId.Size = new System.Drawing.Size(180, 23);
            this.txtScheduleId.TabIndex = 1;
            // 
            // lblScheduleId
            // 
            this.lblScheduleId.AutoSize = true;
            this.lblScheduleId.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.lblScheduleId.ForeColor = System.Drawing.Color.Black;
            this.lblScheduleId.Location = new System.Drawing.Point(10, 32);
            this.lblScheduleId.Name = "lblScheduleId";
            this.lblScheduleId.Size = new System.Drawing.Size(67, 15);
            this.lblScheduleId.TabIndex = 0;
            this.lblScheduleId.Text = "Mã ca trực:";
            // 
            // pnlActions
            // 
            this.pnlActions.Controls.Add(this.btnReset);
            this.pnlActions.Controls.Add(this.btnDelete);
            this.pnlActions.Controls.Add(this.btnEdit);
            this.pnlActions.Controls.Add(this.btnAdd);
            this.pnlActions.Dock = System.Windows.Forms.DockStyle.Right;
            this.pnlActions.Location = new System.Drawing.Point(860, 8);
            this.pnlActions.Name = "pnlActions";
            this.pnlActions.Padding = new System.Windows.Forms.Padding(10, 5, 5, 5);
            this.pnlActions.Size = new System.Drawing.Size(150, 178);
            this.pnlActions.TabIndex = 1;
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
            this.btnReset.Location = new System.Drawing.Point(10, 131);
            this.btnReset.Name = "btnReset";
            this.btnReset.Size = new System.Drawing.Size(135, 42);
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
            this.btnDelete.Location = new System.Drawing.Point(10, 89);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(135, 42);
            this.btnDelete.TabIndex = 2;
            this.btnDelete.Text = "🗑 Hủy ca trực";
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
            this.btnEdit.Location = new System.Drawing.Point(10, 47);
            this.btnEdit.Name = "btnEdit";
            this.btnEdit.Size = new System.Drawing.Size(135, 42);
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
            this.btnAdd.Location = new System.Drawing.Point(10, 5);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(135, 42);
            this.btnAdd.TabIndex = 0;
            this.btnAdd.Text = "➕ Thêm ca trực";
            this.btnAdd.UseVisualStyleBackColor = false;
            // 
            // pnlFilter
            // 
            this.pnlFilter.BackColor = System.Drawing.Color.FromArgb(240, 248, 245);
            this.pnlFilter.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlFilter.Controls.Add(this.btnResetFilter);
            this.pnlFilter.Controls.Add(this.btnFilter);
            this.pnlFilter.Controls.Add(this.cboFilterDept);
            this.pnlFilter.Controls.Add(this.lblFilterDept);
            this.pnlFilter.Controls.Add(this.dtpFilterDate);
            this.pnlFilter.Controls.Add(this.chkFilterDate);
            this.pnlFilter.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlFilter.Location = new System.Drawing.Point(0, 250);
            this.pnlFilter.Name = "pnlFilter";
            this.pnlFilter.Size = new System.Drawing.Size(1020, 44);
            this.pnlFilter.TabIndex = 2;
            // 
            // btnResetFilter
            // 
            this.btnResetFilter.BackColor = System.Drawing.Color.White;
            this.btnResetFilter.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnResetFilter.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnResetFilter.Font = new System.Drawing.Font("Segoe UI", 8.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.btnResetFilter.Location = new System.Drawing.Point(740, 7);
            this.btnResetFilter.Name = "btnResetFilter";
            this.btnResetFilter.Size = new System.Drawing.Size(85, 28);
            this.btnResetFilter.TabIndex = 5;
            this.btnResetFilter.Text = "Hủy lọc";
            this.btnResetFilter.UseVisualStyleBackColor = false;
            // 
            // btnFilter
            // 
            this.btnFilter.BackColor = System.Drawing.Color.FromArgb(16, 120, 95);
            this.btnFilter.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnFilter.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnFilter.Font = new System.Drawing.Font("Segoe UI", 8.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.btnFilter.ForeColor = System.Drawing.Color.White;
            this.btnFilter.Location = new System.Drawing.Point(645, 7);
            this.btnFilter.Name = "btnFilter";
            this.btnFilter.Size = new System.Drawing.Size(85, 28);
            this.btnFilter.TabIndex = 4;
            this.btnFilter.Text = "🔍 Lọc";
            this.btnFilter.UseVisualStyleBackColor = false;
            // 
            // cboFilterDept
            // 
            this.cboFilterDept.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboFilterDept.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.cboFilterDept.FormattingEnabled = true;
            this.cboFilterDept.Location = new System.Drawing.Point(405, 10);
            this.cboFilterDept.Name = "cboFilterDept";
            this.cboFilterDept.Size = new System.Drawing.Size(225, 23);
            this.cboFilterDept.TabIndex = 3;
            // 
            // lblFilterDept
            // 
            this.lblFilterDept.AutoSize = true;
            this.lblFilterDept.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.lblFilterDept.ForeColor = System.Drawing.Color.FromArgb(16, 100, 80);
            this.lblFilterDept.Location = new System.Drawing.Point(315, 14);
            this.lblFilterDept.Name = "lblFilterDept";
            this.lblFilterDept.Size = new System.Drawing.Size(81, 15);
            this.lblFilterDept.TabIndex = 2;
            this.lblFilterDept.Text = "Khoa điều trị:";
            // 
            // dtpFilterDate
            // 
            this.dtpFilterDate.CustomFormat = "dd/MM/yyyy";
            this.dtpFilterDate.Enabled = false;
            this.dtpFilterDate.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.dtpFilterDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpFilterDate.Location = new System.Drawing.Point(155, 10);
            this.dtpFilterDate.Name = "dtpFilterDate";
            this.dtpFilterDate.Size = new System.Drawing.Size(140, 23);
            this.dtpFilterDate.TabIndex = 1;
            // 
            // chkFilterDate
            // 
            this.chkFilterDate.AutoSize = true;
            this.chkFilterDate.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.chkFilterDate.ForeColor = System.Drawing.Color.FromArgb(16, 100, 80);
            this.chkFilterDate.Location = new System.Drawing.Point(15, 12);
            this.chkFilterDate.Name = "chkFilterDate";
            this.chkFilterDate.Size = new System.Drawing.Size(132, 19);
            this.chkFilterDate.TabIndex = 0;
            this.chkFilterDate.Text = "Lọc theo ngày trực:";
            this.chkFilterDate.UseVisualStyleBackColor = true;
            // 
            // grpList
            // 
            this.grpList.Controls.Add(this.dgvSchedules);
            this.grpList.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grpList.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.grpList.ForeColor = System.Drawing.Color.FromArgb(16, 100, 80);
            this.grpList.Location = new System.Drawing.Point(0, 294);
            this.grpList.Name = "grpList";
            this.grpList.Padding = new System.Windows.Forms.Padding(8);
            this.grpList.Size = new System.Drawing.Size(1020, 317);
            this.grpList.TabIndex = 3;
            this.grpList.TabStop = false;
            this.grpList.Text = "BẢNG PHÂN BỔ LỊCH TRỰC CHI TIẾT";
            // 
            // dgvSchedules
            // 
            this.dgvSchedules.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvSchedules.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvSchedules.Location = new System.Drawing.Point(8, 25);
            this.dgvSchedules.Name = "dgvSchedules";
            this.dgvSchedules.RowTemplate.Height = 25;
            this.dgvSchedules.Size = new System.Drawing.Size(1004, 284);
            this.dgvSchedules.TabIndex = 0;
            // 
            // errorProvider1
            // 
            this.errorProvider1.BlinkStyle = System.Windows.Forms.ErrorBlinkStyle.NeverBlink;
            this.errorProvider1.ContainerControl = this;
            // 
            // frmDoctorSchedule
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(1020, 611);
            this.Controls.Add(this.grpList);
            this.Controls.Add(this.pnlFilter);
            this.Controls.Add(this.pnlTop);
            this.Controls.Add(this.pnlHeader);
            this.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.MinimumSize = new System.Drawing.Size(880, 520);
            this.Name = "frmDoctorSchedule";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Lịch trực Bác sĩ & Phân công Ca trực";
            this.pnlHeader.ResumeLayout(false);
            this.pnlTop.ResumeLayout(false);
            this.grpScheduleInfo.ResumeLayout(false);
            this.grpScheduleInfo.PerformLayout();
            this.pnlActions.ResumeLayout(false);
            this.pnlFilter.ResumeLayout(false);
            this.pnlFilter.PerformLayout();
            this.grpList.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvSchedules)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel pnlHeader;
        private System.Windows.Forms.Label lblHeaderSubtitle;
        private System.Windows.Forms.Label lblHeaderTitle;
        private System.Windows.Forms.Panel pnlTop;
        private System.Windows.Forms.GroupBox grpScheduleInfo;
        private System.Windows.Forms.Label lblScheduleId;
        private System.Windows.Forms.TextBox txtScheduleId;
        private System.Windows.Forms.Button btnAutoId;
        private System.Windows.Forms.Label lblDoctor;
        private System.Windows.Forms.ComboBox cboDoctor;
        private System.Windows.Forms.Label lblDepartment;
        private System.Windows.Forms.ComboBox cboDepartment;
        private System.Windows.Forms.Label lblDutyDate;
        private System.Windows.Forms.DateTimePicker dtpDutyDate;
        private System.Windows.Forms.Label lblShift;
        private System.Windows.Forms.ComboBox cboShift;
        private System.Windows.Forms.Label lblDutyRoom;
        private System.Windows.Forms.TextBox txtDutyRoom;
        private System.Windows.Forms.Label lblRole;
        private System.Windows.Forms.ComboBox cboRole;
        private System.Windows.Forms.Label lblNote;
        private System.Windows.Forms.TextBox txtNote;
        private System.Windows.Forms.Panel pnlActions;
        private System.Windows.Forms.Button btnAdd;
        private System.Windows.Forms.Button btnEdit;
        private System.Windows.Forms.Button btnDelete;
        private System.Windows.Forms.Button btnReset;
        private System.Windows.Forms.Panel pnlFilter;
        private System.Windows.Forms.CheckBox chkFilterDate;
        private System.Windows.Forms.DateTimePicker dtpFilterDate;
        private System.Windows.Forms.Label lblFilterDept;
        private System.Windows.Forms.ComboBox cboFilterDept;
        private System.Windows.Forms.Button btnFilter;
        private System.Windows.Forms.Button btnResetFilter;
        private System.Windows.Forms.GroupBox grpList;
        private System.Windows.Forms.DataGridView dgvSchedules;
        private System.Windows.Forms.ErrorProvider errorProvider1;
    }
}
