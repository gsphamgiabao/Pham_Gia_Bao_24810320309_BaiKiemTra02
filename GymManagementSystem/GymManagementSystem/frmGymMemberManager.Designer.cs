namespace GymManagementSystem
{
    partial class frmGymMemberManager
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

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            components = new System.ComponentModel.Container();
            pnlHeader = new Panel();
            lblTitle = new Label();
            grpMemberInfo = new GroupBox();
            txtFee = new TextBox();
            lblFee = new Label();
            dtpStartDate = new DateTimePicker();
            lblStartDate = new Label();
            cboPackage = new ComboBox();
            lblPackage = new Label();
            txtPhone = new TextBox();
            lblPhone = new Label();
            txtFullName = new TextBox();
            lblFullName = new Label();
            txtMemberId = new TextBox();
            lblMemberId = new Label();
            pnlActions = new Panel();
            btnReset = new Button();
            btnDelete = new Button();
            btnEdit = new Button();
            btnAdd = new Button();
            grpMembersList = new GroupBox();
            dgvMembers = new DataGridView();
            statusStrip1 = new StatusStrip();
            lblStatus = new ToolStripStatusLabel();
            errorProvider1 = new ErrorProvider(components);
            pnlHeader.SuspendLayout();
            grpMemberInfo.SuspendLayout();
            pnlActions.SuspendLayout();
            grpMembersList.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvMembers).BeginInit();
            statusStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)errorProvider1).BeginInit();
            SuspendLayout();
            // 
            // pnlHeader
            // 
            pnlHeader.BackColor = Color.FromArgb(24, 76, 120);
            pnlHeader.Controls.Add(lblTitle);
            pnlHeader.Dock = DockStyle.Top;
            pnlHeader.Location = new Point(0, 0);
            pnlHeader.Name = "pnlHeader";
            pnlHeader.Size = new Size(964, 55);
            pnlHeader.TabIndex = 0;
            // 
            // lblTitle
            // 
            lblTitle.Dock = DockStyle.Fill;
            lblTitle.Font = new Font("Segoe UI", 15F, FontStyle.Bold);
            lblTitle.ForeColor = Color.White;
            lblTitle.Location = new Point(0, 0);
            lblTitle.Name = "lblTitle";
            lblTitle.Size = new Size(964, 55);
            lblTitle.TabIndex = 0;
            lblTitle.Text = "HỆ THỐNG QUẢN LÝ DỊCH VỤ PHÒNG GYM & HỘI VIÊN";
            lblTitle.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // grpMemberInfo
            // 
            grpMemberInfo.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            grpMemberInfo.Controls.Add(txtFee);
            grpMemberInfo.Controls.Add(lblFee);
            grpMemberInfo.Controls.Add(dtpStartDate);
            grpMemberInfo.Controls.Add(lblStartDate);
            grpMemberInfo.Controls.Add(cboPackage);
            grpMemberInfo.Controls.Add(lblPackage);
            grpMemberInfo.Controls.Add(txtPhone);
            grpMemberInfo.Controls.Add(lblPhone);
            grpMemberInfo.Controls.Add(txtFullName);
            grpMemberInfo.Controls.Add(lblFullName);
            grpMemberInfo.Controls.Add(txtMemberId);
            grpMemberInfo.Controls.Add(lblMemberId);
            grpMemberInfo.Font = new Font("Segoe UI", 9.75F, FontStyle.Bold);
            grpMemberInfo.ForeColor = Color.FromArgb(24, 76, 120);
            grpMemberInfo.Location = new Point(16, 65);
            grpMemberInfo.Name = "grpMemberInfo";
            grpMemberInfo.Size = new Size(932, 150);
            grpMemberInfo.TabIndex = 1;
            grpMemberInfo.TabStop = false;
            grpMemberInfo.Text = "Thông tin hội viên";
            // 
            // txtFee
            // 
            txtFee.Font = new Font("Segoe UI", 9.75F);
            txtFee.Location = new Point(605, 106);
            txtFee.Name = "txtFee";
            txtFee.Size = new Size(295, 25);
            txtFee.TabIndex = 11;
            // 
            // lblFee
            // 
            lblFee.AutoSize = true;
            lblFee.Font = new Font("Segoe UI", 9.75F);
            lblFee.ForeColor = Color.Black;
            lblFee.Location = new Point(485, 110);
            lblFee.Name = "lblFee";
            lblFee.Size = new Size(102, 17);
            lblFee.TabIndex = 10;
            lblFee.Text = "Phí dịch vụ (VNĐ):";
            // 
            // dtpStartDate
            // 
            dtpStartDate.CustomFormat = "dd/MM/yyyy";
            dtpStartDate.Font = new Font("Segoe UI", 9.75F);
            dtpStartDate.Format = DateTimePickerFormat.Custom;
            dtpStartDate.Location = new Point(605, 68);
            dtpStartDate.Name = "dtpStartDate";
            dtpStartDate.Size = new Size(295, 25);
            dtpStartDate.TabIndex = 9;
            // 
            // lblStartDate
            // 
            lblStartDate.AutoSize = true;
            lblStartDate.Font = new Font("Segoe UI", 9.75F);
            lblStartDate.ForeColor = Color.Black;
            lblStartDate.Location = new Point(485, 72);
            lblStartDate.Name = "lblStartDate";
            lblStartDate.Size = new Size(92, 17);
            lblStartDate.TabIndex = 8;
            lblStartDate.Text = "Ngày đăng ký:";
            // 
            // cboPackage
            // 
            cboPackage.DropDownStyle = ComboBoxStyle.DropDownList;
            cboPackage.Font = new Font("Segoe UI", 9.75F);
            cboPackage.FormattingEnabled = true;
            cboPackage.Location = new Point(605, 28);
            cboPackage.Name = "cboPackage";
            cboPackage.Size = new Size(295, 25);
            cboPackage.TabIndex = 7;
            // 
            // lblPackage
            // 
            lblPackage.AutoSize = true;
            lblPackage.Font = new Font("Segoe UI", 9.75F);
            lblPackage.ForeColor = Color.Black;
            lblPackage.Location = new Point(485, 32);
            lblPackage.Name = "lblPackage";
            lblPackage.Size = new Size(54, 17);
            lblPackage.TabIndex = 6;
            lblPackage.Text = "Gói tập:";
            // 
            // txtPhone
            // 
            txtPhone.Font = new Font("Segoe UI", 9.75F);
            txtPhone.Location = new Point(135, 106);
            txtPhone.MaxLength = 10;
            txtPhone.Name = "txtPhone";
            txtPhone.Size = new Size(295, 25);
            txtPhone.TabIndex = 5;
            // 
            // lblPhone
            // 
            lblPhone.AutoSize = true;
            lblPhone.Font = new Font("Segoe UI", 9.75F);
            lblPhone.ForeColor = Color.Black;
            lblPhone.Location = new Point(20, 110);
            lblPhone.Name = "lblPhone";
            lblPhone.Size = new Size(88, 17);
            lblPhone.TabIndex = 4;
            lblPhone.Text = "Số điện thoại:";
            // 
            // txtFullName
            // 
            txtFullName.Font = new Font("Segoe UI", 9.75F);
            txtFullName.Location = new Point(135, 68);
            txtFullName.Name = "txtFullName";
            txtFullName.Size = new Size(295, 25);
            txtFullName.TabIndex = 3;
            // 
            // lblFullName
            // 
            lblFullName.AutoSize = true;
            lblFullName.Font = new Font("Segoe UI", 9.75F);
            lblFullName.ForeColor = Color.Black;
            lblFullName.Location = new Point(20, 72);
            lblFullName.Name = "lblFullName";
            lblFullName.Size = new Size(67, 17);
            lblFullName.TabIndex = 2;
            lblFullName.Text = "Họ và tên:";
            // 
            // txtMemberId
            // 
            txtMemberId.BackColor = Color.FromArgb(242, 244, 247);
            txtMemberId.Font = new Font("Segoe UI", 9.75F, FontStyle.Bold);
            txtMemberId.ForeColor = Color.FromArgb(24, 76, 120);
            txtMemberId.Location = new Point(135, 28);
            txtMemberId.Name = "txtMemberId";
            txtMemberId.ReadOnly = true;
            txtMemberId.Size = new Size(295, 25);
            txtMemberId.TabIndex = 1;
            // 
            // lblMemberId
            // 
            lblMemberId.AutoSize = true;
            lblMemberId.Font = new Font("Segoe UI", 9.75F);
            lblMemberId.ForeColor = Color.Black;
            lblMemberId.Location = new Point(20, 32);
            lblMemberId.Name = "lblMemberId";
            lblMemberId.Size = new Size(83, 17);
            lblMemberId.TabIndex = 0;
            lblMemberId.Text = "Mã hội viên:";
            // 
            // pnlActions
            // 
            pnlActions.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            pnlActions.Controls.Add(btnReset);
            pnlActions.Controls.Add(btnDelete);
            pnlActions.Controls.Add(btnEdit);
            pnlActions.Controls.Add(btnAdd);
            pnlActions.Location = new Point(16, 222);
            pnlActions.Name = "pnlActions";
            pnlActions.Size = new Size(932, 50);
            pnlActions.TabIndex = 2;
            // 
            // btnReset
            // 
            btnReset.Anchor = AnchorStyles.None;
            btnReset.BackColor = Color.FromArgb(84, 110, 122);
            btnReset.Cursor = Cursors.Hand;
            btnReset.FlatStyle = FlatStyle.Flat;
            btnReset.Font = new Font("Segoe UI", 9.75F, FontStyle.Bold);
            btnReset.ForeColor = Color.White;
            btnReset.Location = new Point(626, 6);
            btnReset.Name = "btnReset";
            btnReset.Size = new Size(135, 38);
            btnReset.TabIndex = 3;
            btnReset.Text = "Làm mới";
            btnReset.UseVisualStyleBackColor = false;
            // 
            // btnDelete
            // 
            btnDelete.Anchor = AnchorStyles.None;
            btnDelete.BackColor = Color.FromArgb(198, 40, 40);
            btnDelete.Cursor = Cursors.Hand;
            btnDelete.FlatStyle = FlatStyle.Flat;
            btnDelete.Font = new Font("Segoe UI", 9.75F, FontStyle.Bold);
            btnDelete.ForeColor = Color.White;
            btnDelete.Location = new Point(476, 6);
            btnDelete.Name = "btnDelete";
            btnDelete.Size = new Size(135, 38);
            btnDelete.TabIndex = 2;
            btnDelete.Text = "Xóa hội viên";
            btnDelete.UseVisualStyleBackColor = false;
            // 
            // btnEdit
            // 
            btnEdit.Anchor = AnchorStyles.None;
            btnEdit.BackColor = Color.FromArgb(21, 101, 192);
            btnEdit.Cursor = Cursors.Hand;
            btnEdit.FlatStyle = FlatStyle.Flat;
            btnEdit.Font = new Font("Segoe UI", 9.75F, FontStyle.Bold);
            btnEdit.ForeColor = Color.White;
            btnEdit.Location = new Point(326, 6);
            btnEdit.Name = "btnEdit";
            btnEdit.Size = new Size(135, 38);
            btnEdit.TabIndex = 1;
            btnEdit.Text = "Sửa thông tin";
            btnEdit.UseVisualStyleBackColor = false;
            // 
            // btnAdd
            // 
            btnAdd.Anchor = AnchorStyles.None;
            btnAdd.BackColor = Color.FromArgb(46, 125, 50);
            btnAdd.Cursor = Cursors.Hand;
            btnAdd.FlatStyle = FlatStyle.Flat;
            btnAdd.Font = new Font("Segoe UI", 9.75F, FontStyle.Bold);
            btnAdd.ForeColor = Color.White;
            btnAdd.Location = new Point(176, 6);
            btnAdd.Name = "btnAdd";
            btnAdd.Size = new Size(135, 38);
            btnAdd.TabIndex = 0;
            btnAdd.Text = "Thêm mới";
            btnAdd.UseVisualStyleBackColor = false;
            // 
            // grpMembersList
            // 
            grpMembersList.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            grpMembersList.Controls.Add(dgvMembers);
            grpMembersList.Font = new Font("Segoe UI", 9.75F, FontStyle.Bold);
            grpMembersList.ForeColor = Color.FromArgb(24, 76, 120);
            grpMembersList.Location = new Point(16, 278);
            grpMembersList.Name = "grpMembersList";
            grpMembersList.Size = new Size(932, 320);
            grpMembersList.TabIndex = 3;
            grpMembersList.TabStop = false;
            grpMembersList.Text = "Danh sách hội viên";
            // 
            // dgvMembers
            // 
            dgvMembers.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            dgvMembers.BackgroundColor = Color.White;
            dgvMembers.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvMembers.Font = new Font("Segoe UI", 9.75F);
            dgvMembers.Location = new Point(15, 25);
            dgvMembers.Name = "dgvMembers";
            dgvMembers.Size = new Size(902, 280);
            dgvMembers.TabIndex = 0;
            // 
            // statusStrip1
            // 
            statusStrip1.Items.AddRange(new ToolStripItem[] { lblStatus });
            statusStrip1.Location = new Point(0, 608);
            statusStrip1.Name = "statusStrip1";
            statusStrip1.Size = new Size(964, 22);
            statusStrip1.TabIndex = 4;
            statusStrip1.Text = "statusStrip1";
            // 
            // lblStatus
            // 
            lblStatus.Font = new Font("Segoe UI", 9F);
            lblStatus.ForeColor = Color.FromArgb(50, 50, 50);
            lblStatus.Name = "lblStatus";
            lblStatus.Size = new Size(207, 17);
            lblStatus.Text = "Tổng số hội viên: 0 | Trạng thái: Sẵn sàng";
            // 
            // errorProvider1
            // 
            errorProvider1.BlinkStyle = ErrorBlinkStyle.NeverBlink;
            errorProvider1.ContainerControl = this;
            // 
            // frmGymMemberManager
            // 
            AutoScaleDimensions = new SizeF(7F, 17F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(248, 249, 250);
            ClientSize = new Size(964, 630);
            Controls.Add(statusStrip1);
            Controls.Add(grpMembersList);
            Controls.Add(pnlActions);
            Controls.Add(grpMemberInfo);
            Controls.Add(pnlHeader);
            Font = new Font("Segoe UI", 9.75F);
            MinimumSize = new Size(920, 580);
            Name = "frmGymMemberManager";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Hệ Thống Quản Lý Dịch Vụ Phòng Gym & Hội Viên";
            pnlHeader.ResumeLayout(false);
            grpMemberInfo.ResumeLayout(false);
            grpMemberInfo.PerformLayout();
            pnlActions.ResumeLayout(false);
            grpMembersList.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dgvMembers).EndInit();
            statusStrip1.ResumeLayout(false);
            statusStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)errorProvider1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Panel pnlHeader;
        private Label lblTitle;
        private GroupBox grpMemberInfo;
        private TextBox txtMemberId;
        private Label lblMemberId;
        private TextBox txtFullName;
        private Label lblFullName;
        private TextBox txtPhone;
        private Label lblPhone;
        private ComboBox cboPackage;
        private Label lblPackage;
        private DateTimePicker dtpStartDate;
        private Label lblStartDate;
        private TextBox txtFee;
        private Label lblFee;
        private Panel pnlActions;
        private Button btnAdd;
        private Button btnEdit;
        private Button btnDelete;
        private Button btnReset;
        private GroupBox grpMembersList;
        private DataGridView dgvMembers;
        private StatusStrip statusStrip1;
        private ToolStripStatusLabel lblStatus;
        private ErrorProvider errorProvider1;
    }
}
