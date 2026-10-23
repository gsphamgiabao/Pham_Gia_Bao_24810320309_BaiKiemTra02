namespace RevenueAnalyticsSystem
{
    partial class frmRevenueAnalytics
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            components = new System.ComponentModel.Container();

            // ── Khai báo tất cả controls ──────────────────────────────────
            grpCriteria         = new GroupBox();
            lblTuNgay           = new Label();
            dtpTuNgay           = new DateTimePicker();
            lblDenNgay          = new Label();
            dtpDenNgay          = new DateTimePicker();
            lblChiNhanh         = new Label();
            cboChiNhanh         = new ComboBox();
            btnThongKe          = new Button();
            btnHuy              = new Button();
            grpStatus           = new GroupBox();
            pgbLoading          = new ProgressBar();
            lblProcessingStatus = new Label();
            grpResult           = new GroupBox();
            dgvRevenueData      = new DataGridView();

            grpCriteria.SuspendLayout();
            grpStatus.SuspendLayout();
            grpResult.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvRevenueData).BeginInit();
            SuspendLayout();

            // ══════════════════════════════════════════════════════════════
            // lblTuNgay
            // ══════════════════════════════════════════════════════════════
            lblTuNgay.Text      = "Từ ngày:";
            lblTuNgay.Location  = new Point(10, 32);
            lblTuNgay.Size      = new Size(62, 23);
            lblTuNgay.TextAlign = ContentAlignment.MiddleRight;

            // ══════════════════════════════════════════════════════════════
            // dtpTuNgay
            // ══════════════════════════════════════════════════════════════
            dtpTuNgay.Location = new Point(76, 30);
            dtpTuNgay.Size     = new Size(140, 27);
            dtpTuNgay.Format   = DateTimePickerFormat.Short;

            // ══════════════════════════════════════════════════════════════
            // lblDenNgay
            // ══════════════════════════════════════════════════════════════
            lblDenNgay.Text      = "Đến ngày:";
            lblDenNgay.Location  = new Point(224, 32);
            lblDenNgay.Size      = new Size(67, 23);
            lblDenNgay.TextAlign = ContentAlignment.MiddleRight;

            // ══════════════════════════════════════════════════════════════
            // dtpDenNgay
            // ══════════════════════════════════════════════════════════════
            dtpDenNgay.Location = new Point(295, 30);
            dtpDenNgay.Size     = new Size(140, 27);
            dtpDenNgay.Format   = DateTimePickerFormat.Short;

            // ══════════════════════════════════════════════════════════════
            // lblChiNhanh
            // ══════════════════════════════════════════════════════════════
            lblChiNhanh.Text      = "Chi nhánh:";
            lblChiNhanh.Location  = new Point(443, 32);
            lblChiNhanh.Size      = new Size(70, 23);
            lblChiNhanh.TextAlign = ContentAlignment.MiddleRight;

            // ══════════════════════════════════════════════════════════════
            // cboChiNhanh
            // ══════════════════════════════════════════════════════════════
            cboChiNhanh.Location      = new Point(517, 30);
            cboChiNhanh.Size          = new Size(175, 27);
            cboChiNhanh.DropDownStyle = ComboBoxStyle.DropDownList;

            // ══════════════════════════════════════════════════════════════
            // btnThongKe  (anchored Right)
            // ══════════════════════════════════════════════════════════════
            btnThongKe.Text      = "Thống Kê Doanh Thu";
            btnThongKe.Location  = new Point(707, 26);
            btnThongKe.Size      = new Size(152, 34);
            btnThongKe.Anchor    = AnchorStyles.Top | AnchorStyles.Right;
            btnThongKe.BackColor = Color.FromArgb(0, 120, 215);
            btnThongKe.ForeColor = Color.White;
            btnThongKe.FlatStyle = FlatStyle.Flat;
            btnThongKe.FlatAppearance.BorderSize = 0;
            btnThongKe.Font      = new Font("Segoe UI", 9.5f, FontStyle.Bold);
            btnThongKe.Cursor    = Cursors.Hand;
            btnThongKe.Click    += btnThongKe_Click;

            // ══════════════════════════════════════════════════════════════
            // btnHuy  (anchored Right)
            // ══════════════════════════════════════════════════════════════
            btnHuy.Text      = "Hủy Thao Tác";
            btnHuy.Location  = new Point(867, 26);
            btnHuy.Size      = new Size(108, 34);
            btnHuy.Anchor    = AnchorStyles.Top | AnchorStyles.Right;
            btnHuy.BackColor = Color.FromArgb(196, 43, 28);
            btnHuy.ForeColor = Color.White;
            btnHuy.FlatStyle = FlatStyle.Flat;
            btnHuy.FlatAppearance.BorderSize = 0;
            btnHuy.Font      = new Font("Segoe UI", 9.5f, FontStyle.Bold);
            btnHuy.Cursor    = Cursors.Hand;
            btnHuy.Enabled   = false;
            btnHuy.Click    += btnHuy_Click;

            // ══════════════════════════════════════════════════════════════
            // grpCriteria
            // ══════════════════════════════════════════════════════════════
            grpCriteria.Text     = "  Tiêu Chí Thống Kê";
            grpCriteria.Location = new Point(12, 12);
            grpCriteria.Size     = new Size(986, 74);
            grpCriteria.Anchor   = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            grpCriteria.Font     = new Font("Segoe UI", 9f, FontStyle.Bold);
            grpCriteria.Controls.AddRange(new Control[]
            {
                lblTuNgay, dtpTuNgay,
                lblDenNgay, dtpDenNgay,
                lblChiNhanh, cboChiNhanh,
                btnThongKe, btnHuy
            });

            // ══════════════════════════════════════════════════════════════
            // pgbLoading
            // ══════════════════════════════════════════════════════════════
            pgbLoading.Location = new Point(10, 28);
            pgbLoading.Size     = new Size(964, 22);
            pgbLoading.Anchor   = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            pgbLoading.Minimum  = 0;
            pgbLoading.Maximum  = 100;
            pgbLoading.Value    = 0;

            // ══════════════════════════════════════════════════════════════
            // lblProcessingStatus
            // ══════════════════════════════════════════════════════════════
            lblProcessingStatus.Text      = "Sẵn sàng thống kê.";
            lblProcessingStatus.Location  = new Point(10, 58);
            lblProcessingStatus.Size      = new Size(964, 20);
            lblProcessingStatus.Anchor    = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            lblProcessingStatus.ForeColor = Color.FromArgb(0, 103, 192);
            lblProcessingStatus.Font      = new Font("Segoe UI", 9f, FontStyle.Italic);

            // ══════════════════════════════════════════════════════════════
            // grpStatus
            // ══════════════════════════════════════════════════════════════
            grpStatus.Text     = "  Trạng Thái Xử Lý";
            grpStatus.Location = new Point(12, 94);
            grpStatus.Size     = new Size(986, 88);
            grpStatus.Anchor   = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            grpStatus.Font     = new Font("Segoe UI", 9f, FontStyle.Bold);
            grpStatus.Controls.AddRange(new Control[] { pgbLoading, lblProcessingStatus });

            // ══════════════════════════════════════════════════════════════
            // dgvRevenueData
            // ══════════════════════════════════════════════════════════════
            dgvRevenueData.Location                    = new Point(10, 26);
            dgvRevenueData.Size                        = new Size(964, 436);
            dgvRevenueData.Anchor                      = AnchorStyles.Top | AnchorStyles.Bottom
                                                       | AnchorStyles.Left | AnchorStyles.Right;
            dgvRevenueData.ReadOnly                    = true;
            dgvRevenueData.AllowUserToAddRows          = false;
            dgvRevenueData.AllowUserToDeleteRows       = false;
            dgvRevenueData.AllowUserToResizeRows       = false;
            dgvRevenueData.SelectionMode               = DataGridViewSelectionMode.FullRowSelect;
            dgvRevenueData.BackgroundColor             = Color.White;
            dgvRevenueData.BorderStyle                 = BorderStyle.None;
            dgvRevenueData.RowHeadersVisible           = false;
            dgvRevenueData.GridColor                   = Color.FromArgb(220, 220, 220);
            dgvRevenueData.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvRevenueData.AlternatingRowsDefaultCellStyle = new DataGridViewCellStyle
            {
                BackColor = Color.FromArgb(248, 249, 250)
            };
            dgvRevenueData.ColumnHeadersDefaultCellStyle = new DataGridViewCellStyle
            {
                BackColor = Color.FromArgb(0, 120, 215),
                ForeColor = Color.White,
                Font      = new Font("Segoe UI", 9f, FontStyle.Bold),
                Alignment = DataGridViewContentAlignment.MiddleCenter
            };
            dgvRevenueData.EnableHeadersVisualStyles = false;

            // ══════════════════════════════════════════════════════════════
            // grpResult
            // ══════════════════════════════════════════════════════════════
            grpResult.Text     = "  Kết Quả Thống Kê";
            grpResult.Location = new Point(12, 190);
            grpResult.Size     = new Size(986, 472);
            grpResult.Anchor   = AnchorStyles.Top | AnchorStyles.Bottom
                               | AnchorStyles.Left | AnchorStyles.Right;
            grpResult.Font     = new Font("Segoe UI", 9f, FontStyle.Bold);
            grpResult.Controls.Add(dgvRevenueData);

            // ══════════════════════════════════════════════════════════════
            // Form  frmRevenueAnalytics
            // ══════════════════════════════════════════════════════════════
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode       = AutoScaleMode.Font;
            ClientSize          = new Size(1010, 680);
            MinimumSize         = new Size(750, 520);
            StartPosition       = FormStartPosition.CenterScreen;
            Text                = "Bảng Điều Khiển Thống Kê Doanh Thu";
            Font                = new Font("Segoe UI", 9f);
            BackColor           = Color.FromArgb(245, 246, 248);
            Controls.AddRange(new Control[] { grpCriteria, grpStatus, grpResult });
            Load += frmRevenueAnalytics_Load;

            grpCriteria.ResumeLayout(false);
            grpStatus.ResumeLayout(false);
            grpResult.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dgvRevenueData).EndInit();
            ResumeLayout(false);
        }

        #endregion

        // ── Khai báo fields cho Designer ──────────────────────────────────────
        private GroupBox        grpCriteria;
        private Label           lblTuNgay;
        private DateTimePicker  dtpTuNgay;
        private Label           lblDenNgay;
        private DateTimePicker  dtpDenNgay;
        private Label           lblChiNhanh;
        private ComboBox        cboChiNhanh;
        private Button          btnThongKe;
        private Button          btnHuy;
        private GroupBox        grpStatus;
        private ProgressBar     pgbLoading;
        private Label           lblProcessingStatus;
        private GroupBox        grpResult;
        private DataGridView    dgvRevenueData;
    }
}
