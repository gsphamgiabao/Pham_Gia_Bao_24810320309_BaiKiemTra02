namespace RevenueAnalyticsSystem
{
    partial class frmExchangeRateMonitor
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
                components.Dispose();
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        private void InitializeComponent()
        {
            components = new System.ComponentModel.Container();

            // ── Khai báo controls ─────────────────────────────────────────
            pnlTop          = new Panel();
            lblTitle        = new Label();
            grpControl      = new GroupBox();
            btnStart        = new Button();
            btnStop         = new Button();
            btnPause        = new Button();
            lblInterval     = new Label();
            trkInterval     = new TrackBar();
            btnClearHistory = new Button();
            pnlBottom       = new Panel();
            lblStatus       = new Label();
            lblCounter      = new Label();
            splitMain       = new SplitContainer();
            grpLive         = new GroupBox();
            dgvRates        = new DataGridView();
            grpHistory      = new GroupBox();
            dgvHistory      = new DataGridView();

            pnlTop.SuspendLayout();
            grpControl.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)trkInterval).BeginInit();
            pnlBottom.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)splitMain).BeginInit();
            splitMain.SuspendLayout();
            grpLive.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvRates).BeginInit();
            grpHistory.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvHistory).BeginInit();
            SuspendLayout();

            // ══════════════════════════════════════════════════════════════
            // lblTitle
            // ══════════════════════════════════════════════════════════════
            lblTitle.Text      = "📈  MÔ PHỎNG GIÁM SÁT TỶ GIÁ TÀI CHÍNH THỜI GIAN THỰC";
            lblTitle.Font      = new Font("Segoe UI", 13f, FontStyle.Bold);
            lblTitle.ForeColor = Color.White;
            lblTitle.Dock      = DockStyle.Fill;
            lblTitle.TextAlign = ContentAlignment.MiddleCenter;

            // ══════════════════════════════════════════════════════════════
            // pnlTop  (header)
            // ══════════════════════════════════════════════════════════════
            pnlTop.Dock      = DockStyle.Top;
            pnlTop.Height    = 52;
            pnlTop.BackColor = Color.FromArgb(15, 52, 96);
            pnlTop.Controls.Add(lblTitle);

            // ══════════════════════════════════════════════════════════════
            // btnStart
            // ══════════════════════════════════════════════════════════════
            btnStart.Text      = "▶  Bắt Đầu";
            btnStart.Location  = new Point(10, 26);
            btnStart.Size      = new Size(115, 36);
            btnStart.BackColor = Color.FromArgb(39, 174, 96);
            btnStart.ForeColor = Color.White;
            btnStart.FlatStyle = FlatStyle.Flat;
            btnStart.FlatAppearance.BorderSize = 0;
            btnStart.Font      = new Font("Segoe UI", 9.5f, FontStyle.Bold);
            btnStart.Cursor    = Cursors.Hand;
            btnStart.Click    += btnStart_Click;

            // ══════════════════════════════════════════════════════════════
            // btnStop
            // ══════════════════════════════════════════════════════════════
            btnStop.Text      = "■  Dừng";
            btnStop.Location  = new Point(133, 26);
            btnStop.Size      = new Size(100, 36);
            btnStop.BackColor = Color.FromArgb(192, 57, 43);
            btnStop.ForeColor = Color.White;
            btnStop.FlatStyle = FlatStyle.Flat;
            btnStop.FlatAppearance.BorderSize = 0;
            btnStop.Font      = new Font("Segoe UI", 9.5f, FontStyle.Bold);
            btnStop.Cursor    = Cursors.Hand;
            btnStop.Enabled   = false;
            btnStop.Click    += btnStop_Click;

            // ══════════════════════════════════════════════════════════════
            // btnPause
            // ══════════════════════════════════════════════════════════════
            btnPause.Text      = "⏸  Tạm Dừng";
            btnPause.Location  = new Point(241, 26);
            btnPause.Size      = new Size(120, 36);
            btnPause.BackColor = Color.FromArgb(230, 126, 34);
            btnPause.ForeColor = Color.White;
            btnPause.FlatStyle = FlatStyle.Flat;
            btnPause.FlatAppearance.BorderSize = 0;
            btnPause.Font      = new Font("Segoe UI", 9.5f, FontStyle.Bold);
            btnPause.Cursor    = Cursors.Hand;
            btnPause.Enabled   = false;
            btnPause.Click    += btnPause_Click;

            // ══════════════════════════════════════════════════════════════
            // lblInterval
            // ══════════════════════════════════════════════════════════════
            lblInterval.Text      = "Chu kỳ: 2000 ms (2.0s)";
            lblInterval.Location  = new Point(375, 28);
            lblInterval.Size      = new Size(175, 20);
            lblInterval.Font      = new Font("Segoe UI", 9f, FontStyle.Italic);
            lblInterval.ForeColor = Color.FromArgb(50, 50, 100);
            lblInterval.TextAlign = ContentAlignment.MiddleLeft;

            // ══════════════════════════════════════════════════════════════
            // trkInterval
            // ══════════════════════════════════════════════════════════════
            trkInterval.Location  = new Point(555, 20);
            trkInterval.Size      = new Size(220, 45);
            trkInterval.TickFrequency = 5;
            trkInterval.Scroll   += trkInterval_Scroll;

            // ══════════════════════════════════════════════════════════════
            // btnClearHistory
            // ══════════════════════════════════════════════════════════════
            btnClearHistory.Text      = "🧹 Xóa Lịch Sử";
            btnClearHistory.Location  = new Point(790, 26);
            btnClearHistory.Size      = new Size(130, 36);
            btnClearHistory.Anchor    = AnchorStyles.Top | AnchorStyles.Right;
            btnClearHistory.BackColor = Color.FromArgb(100, 100, 130);
            btnClearHistory.ForeColor = Color.White;
            btnClearHistory.FlatStyle = FlatStyle.Flat;
            btnClearHistory.FlatAppearance.BorderSize = 0;
            btnClearHistory.Font      = new Font("Segoe UI", 9.5f, FontStyle.Bold);
            btnClearHistory.Cursor    = Cursors.Hand;
            btnClearHistory.Click    += btnClearHistory_Click;

            // ══════════════════════════════════════════════════════════════
            // grpControl
            // ══════════════════════════════════════════════════════════════
            grpControl.Text     = "  Điều Khiển Giám Sát";
            grpControl.Location = new Point(12, 60);
            grpControl.Size     = new Size(976, 74);
            grpControl.Anchor   = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            grpControl.Font     = new Font("Segoe UI", 9f, FontStyle.Bold);
            grpControl.Controls.AddRange(new Control[]
            {
                btnStart, btnStop, btnPause,
                lblInterval, trkInterval, btnClearHistory
            });

            // ══════════════════════════════════════════════════════════════
            // pnlBottom  (status bar)
            // ══════════════════════════════════════════════════════════════
            lblStatus.Text      = "⏸ Chưa bắt đầu giám sát.";
            lblStatus.Dock      = DockStyle.Fill;
            lblStatus.Font      = new Font("Segoe UI", 9f, FontStyle.Italic);
            lblStatus.ForeColor = Color.White;
            lblStatus.TextAlign = ContentAlignment.MiddleLeft;
            lblStatus.Padding   = new Padding(6, 0, 0, 0);

            lblCounter.Text      = "Tổng cập nhật: 0";
            lblCounter.Dock      = DockStyle.Right;
            lblCounter.Width     = 200;
            lblCounter.Font      = new Font("Segoe UI", 9f, FontStyle.Bold);
            lblCounter.ForeColor = Color.FromArgb(200, 230, 255);
            lblCounter.TextAlign = ContentAlignment.MiddleRight;
            lblCounter.Padding   = new Padding(0, 0, 8, 0);

            pnlBottom.Dock      = DockStyle.Bottom;
            pnlBottom.Height    = 30;
            pnlBottom.BackColor = Color.FromArgb(15, 52, 96);
            pnlBottom.Controls.AddRange(new Control[] { lblStatus, lblCounter });

            // ══════════════════════════════════════════════════════════════
            // dgvRates  (bảng tỷ giá hiện tại)
            // ══════════════════════════════════════════════════════════════
            ApplyDataGridStyle(dgvRates);
            dgvRates.Dock = DockStyle.Fill;

            // ══════════════════════════════════════════════════════════════
            // grpLive
            // ══════════════════════════════════════════════════════════════
            grpLive.Text = "  🔴 Tỷ Giá Hiện Tại";
            grpLive.Dock = DockStyle.Fill;
            grpLive.Font = new Font("Segoe UI", 9f, FontStyle.Bold);
            grpLive.Controls.Add(dgvRates);

            // ══════════════════════════════════════════════════════════════
            // dgvHistory  (bảng lịch sử)
            // ══════════════════════════════════════════════════════════════
            ApplyDataGridStyle(dgvHistory);
            SetupHistoryGridColumns();
            dgvHistory.Dock = DockStyle.Fill;

            // ══════════════════════════════════════════════════════════════
            // grpHistory
            // ══════════════════════════════════════════════════════════════
            grpHistory.Text = "  📋 Lịch Sử Cập Nhật (200 dòng gần nhất)";
            grpHistory.Dock = DockStyle.Fill;
            grpHistory.Font = new Font("Segoe UI", 9f, FontStyle.Bold);
            grpHistory.Controls.Add(dgvHistory);

            // ══════════════════════════════════════════════════════════════
            // splitMain  (chia đôi: trái = live, phải = history)
            // ══════════════════════════════════════════════════════════════
            splitMain.Dock        = DockStyle.Fill;
            splitMain.Orientation = Orientation.Vertical;
            splitMain.SplitterDistance = 540;
            splitMain.Panel1.Controls.Add(grpLive);
            splitMain.Panel2.Controls.Add(grpHistory);

            // ══════════════════════════════════════════════════════════════
            // Panel chứa splitMain (phần giữa form)
            // ══════════════════════════════════════════════════════════════
            var pnlCenter = new Panel
            {
                Dock    = DockStyle.Fill,
                Padding = new Padding(12, 142, 12, 8)
            };
            pnlCenter.Controls.Add(splitMain);

            // ══════════════════════════════════════════════════════════════
            // Form  frmExchangeRateMonitor
            // ══════════════════════════════════════════════════════════════
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode       = AutoScaleMode.Font;
            ClientSize          = new Size(1000, 700);
            MinimumSize         = new Size(820, 560);
            StartPosition       = FormStartPosition.CenterScreen;
            Text                = "Mô Phỏng Giám Sát Tỷ Giá Tài Chính Thời Gian Thực";
            Font                = new Font("Segoe UI", 9f);
            BackColor           = Color.FromArgb(245, 246, 250);
            Controls.AddRange(new Control[] { pnlCenter, grpControl, pnlTop, pnlBottom });
            Load         += frmExchangeRateMonitor_Load;
            FormClosing  += frmExchangeRateMonitor_FormClosing;

            pnlTop.ResumeLayout(false);
            grpControl.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)trkInterval).EndInit();
            pnlBottom.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)splitMain).EndInit();
            splitMain.ResumeLayout(false);
            grpLive.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dgvRates).EndInit();
            grpHistory.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dgvHistory).EndInit();
            ResumeLayout(false);
        }

        // ─── Áp dụng style chung cho DataGridView ───────────────────────────
        private static void ApplyDataGridStyle(DataGridView dgv)
        {
            dgv.ReadOnly                    = true;
            dgv.AllowUserToAddRows          = false;
            dgv.AllowUserToDeleteRows       = false;
            dgv.AllowUserToResizeRows       = false;
            dgv.SelectionMode               = DataGridViewSelectionMode.FullRowSelect;
            dgv.BackgroundColor             = Color.White;
            dgv.BorderStyle                 = BorderStyle.None;
            dgv.RowHeadersVisible           = false;
            dgv.GridColor                   = Color.FromArgb(220, 220, 225);
            dgv.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgv.EnableHeadersVisualStyles   = false;
            dgv.RowTemplate.Height          = 28;
            dgv.ColumnHeadersDefaultCellStyle = new DataGridViewCellStyle
            {
                BackColor = Color.FromArgb(15, 52, 96),
                ForeColor = Color.White,
                Font      = new Font("Segoe UI", 9f, FontStyle.Bold),
                Alignment = DataGridViewContentAlignment.MiddleCenter
            };
            dgv.AlternatingRowsDefaultCellStyle = new DataGridViewCellStyle
            {
                BackColor = Color.FromArgb(248, 249, 252)
            };
        }

        // ─── Cấu hình cột DataGridView Lịch Sử ─────────────────────────────
        private static void SetupHistoryGridColumns(DataGridView dgv = null!)
        {
            // Không làm gì ở Designer – cột được thiết lập trong frmExchangeRateMonitor_Load
            // thông qua SetupHistoryGrid() gọi sau InitializeComponent()
        }

        #endregion

        // ── Field declarations ────────────────────────────────────────────────
        private Panel           pnlTop;
        private Label           lblTitle;
        private GroupBox        grpControl;
        private Button          btnStart;
        private Button          btnStop;
        private Button          btnPause;
        private Label           lblInterval;
        private TrackBar        trkInterval;
        private Button          btnClearHistory;
        private Panel           pnlBottom;
        private Label           lblStatus;
        private Label           lblCounter;
        private SplitContainer  splitMain;
        private GroupBox        grpLive;
        private DataGridView    dgvRates;
        private GroupBox        grpHistory;
        private DataGridView    dgvHistory;
    }
}
