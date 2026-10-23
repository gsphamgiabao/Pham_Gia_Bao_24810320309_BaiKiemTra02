namespace RevenueAnalyticsSystem
{
    partial class frmCryptoStockTicker
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
            pnlHeader        = new Panel();
            lblFormTitle     = new Label();
            lblSubtitle      = new Label();
            grpControl       = new GroupBox();
            btnStart         = new Button();
            btnPause         = new Button();
            btnStop          = new Button();
            btnClear         = new Button();
            grpLivePrice     = new GroupBox();
            pnlPriceBox      = new Panel();
            lblBTCLabel      = new Label();
            lblBTCPrice      = new Label();
            lblDeltaIndicator = new Label();
            lblThreadNote    = new Label();
            grpHistory       = new GroupBox();
            dgvHistoryLog    = new DataGridView();
            statusStrip      = new StatusStrip();
            tsslLastUpdate   = new ToolStripStatusLabel();
            tsslSep          = new ToolStripSeparator();
            tsslSyncCount    = new ToolStripStatusLabel();

            pnlHeader.SuspendLayout();
            grpControl.SuspendLayout();
            grpLivePrice.SuspendLayout();
            pnlPriceBox.SuspendLayout();
            grpHistory.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvHistoryLog).BeginInit();
            statusStrip.SuspendLayout();
            SuspendLayout();

            // ══════════════════════════════════════════════════════════════
            // pnlHeader
            // ══════════════════════════════════════════════════════════════
            pnlHeader.Dock      = DockStyle.Top;
            pnlHeader.Height    = 70;
            pnlHeader.BackColor = Color.FromArgb(20, 20, 30);
            pnlHeader.Controls.AddRange(new Control[] { lblFormTitle, lblSubtitle });

            lblFormTitle.Text      = "₿  CRYPTO STOCK TICKER — BTC/USD";
            lblFormTitle.Font      = new Font("Segoe UI", 14f, FontStyle.Bold);
            lblFormTitle.ForeColor = Color.FromArgb(255, 215, 0);   // gold
            lblFormTitle.Location  = new Point(12, 8);
            lblFormTitle.Size      = new Size(700, 30);

            lblSubtitle.Text      = "Cross-Thread Safety Demo  ·  InvokeRequired / this.Invoke()";
            lblSubtitle.Font      = new Font("Segoe UI", 9f, FontStyle.Italic);
            lblSubtitle.ForeColor = Color.FromArgb(150, 170, 200);
            lblSubtitle.Location  = new Point(14, 40);
            lblSubtitle.Size      = new Size(700, 20);

            // ══════════════════════════════════════════════════════════════
            // btnStart
            // ══════════════════════════════════════════════════════════════
            btnStart.Text      = "▶  Bắt Đầu Giám Sát";
            btnStart.Location  = new Point(12, 28);
            btnStart.Size      = new Size(165, 38);
            btnStart.BackColor = Color.FromArgb(39, 174, 96);
            btnStart.ForeColor = Color.White;
            btnStart.FlatStyle = FlatStyle.Flat;
            btnStart.FlatAppearance.BorderSize = 0;
            btnStart.Font      = new Font("Segoe UI", 9.5f, FontStyle.Bold);
            btnStart.Cursor    = Cursors.Hand;
            btnStart.Click    += btnStart_Click;

            // ══════════════════════════════════════════════════════════════
            // btnPause
            // ══════════════════════════════════════════════════════════════
            btnPause.Text      = "⏸  Tạm Dừng";
            btnPause.Location  = new Point(185, 28);
            btnPause.Size      = new Size(128, 38);
            btnPause.BackColor = Color.FromArgb(230, 126, 34);
            btnPause.ForeColor = Color.White;
            btnPause.FlatStyle = FlatStyle.Flat;
            btnPause.FlatAppearance.BorderSize = 0;
            btnPause.Font      = new Font("Segoe UI", 9.5f, FontStyle.Bold);
            btnPause.Cursor    = Cursors.Hand;
            btnPause.Enabled   = false;
            btnPause.Click    += btnPause_Click;

            // ══════════════════════════════════════════════════════════════
            // btnStop
            // ══════════════════════════════════════════════════════════════
            btnStop.Text      = "■  Dừng";
            btnStop.Location  = new Point(321, 28);
            btnStop.Size      = new Size(100, 38);
            btnStop.BackColor = Color.FromArgb(192, 57, 43);
            btnStop.ForeColor = Color.White;
            btnStop.FlatStyle = FlatStyle.Flat;
            btnStop.FlatAppearance.BorderSize = 0;
            btnStop.Font      = new Font("Segoe UI", 9.5f, FontStyle.Bold);
            btnStop.Cursor    = Cursors.Hand;
            btnStop.Enabled   = false;
            btnStop.Click    += btnStop_Click;

            // ══════════════════════════════════════════════════════════════
            // btnClear
            // ══════════════════════════════════════════════════════════════
            btnClear.Text      = "🗑  Xóa Nhật Ký";
            btnClear.Location  = new Point(429, 28);
            btnClear.Size      = new Size(128, 38);
            btnClear.Anchor    = AnchorStyles.Top | AnchorStyles.Right;
            btnClear.BackColor = Color.FromArgb(100, 100, 120);
            btnClear.ForeColor = Color.White;
            btnClear.FlatStyle = FlatStyle.Flat;
            btnClear.FlatAppearance.BorderSize = 0;
            btnClear.Font      = new Font("Segoe UI", 9.5f, FontStyle.Bold);
            btnClear.Cursor    = Cursors.Hand;
            btnClear.Click    += btnClear_Click;

            // ══════════════════════════════════════════════════════════════
            // grpControl
            // ══════════════════════════════════════════════════════════════
            grpControl.Text     = "  Điều Khiển Giám Sát";
            grpControl.Location = new Point(12, 78);
            grpControl.Size     = new Size(760, 78);
            grpControl.Anchor   = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            grpControl.Font     = new Font("Segoe UI", 9f, FontStyle.Bold);
            grpControl.Controls.AddRange(new Control[]
                { btnStart, btnPause, btnStop, btnClear });

            // ══════════════════════════════════════════════════════════════
            // pnlPriceBox  (ô giá lớn)
            // ══════════════════════════════════════════════════════════════
            pnlPriceBox.Location  = new Point(10, 26);
            pnlPriceBox.Size      = new Size(736, 120);
            pnlPriceBox.Anchor    = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            pnlPriceBox.BackColor = Color.FromArgb(15, 15, 25);
            pnlPriceBox.BorderStyle = BorderStyle.FixedSingle;
            pnlPriceBox.Controls.AddRange(new Control[]
                { lblBTCLabel, lblBTCPrice, lblDeltaIndicator, lblThreadNote });

            lblBTCLabel.Text      = "BTC / USD";
            lblBTCLabel.Font      = new Font("Segoe UI", 10f, FontStyle.Bold);
            lblBTCLabel.ForeColor = Color.FromArgb(255, 215, 0);
            lblBTCLabel.Location  = new Point(16, 10);
            lblBTCLabel.Size      = new Size(120, 22);

            lblBTCPrice.Text      = "₿  67,000.00  USD";
            lblBTCPrice.Font      = new Font("Consolas", 30f, FontStyle.Bold);
            lblBTCPrice.ForeColor = Color.FromArgb(60, 60, 60);
            lblBTCPrice.Location  = new Point(12, 34);
            lblBTCPrice.Size      = new Size(560, 56);
            lblBTCPrice.AutoSize  = false;

            lblDeltaIndicator.Text      = "━  Chưa cập nhật";
            lblDeltaIndicator.Font      = new Font("Segoe UI", 12f, FontStyle.Bold);
            lblDeltaIndicator.ForeColor = Color.Gray;
            lblDeltaIndicator.Location  = new Point(16, 86);
            lblDeltaIndicator.Size      = new Size(400, 26);

            lblThreadNote.Text      = "⚙ UI Thread";
            lblThreadNote.Font      = new Font("Segoe UI", 8f, FontStyle.Italic);
            lblThreadNote.ForeColor = Color.FromArgb(80, 100, 140);
            lblThreadNote.Location  = new Point(580, 10);
            lblThreadNote.Size      = new Size(145, 20);
            lblThreadNote.Anchor    = AnchorStyles.Top | AnchorStyles.Right;
            lblThreadNote.TextAlign = ContentAlignment.MiddleRight;

            // ══════════════════════════════════════════════════════════════
            // grpLivePrice
            // ══════════════════════════════════════════════════════════════
            grpLivePrice.Text     = "  🔴 Giá BTC/USD Thời Gian Thực";
            grpLivePrice.Location = new Point(12, 164);
            grpLivePrice.Size     = new Size(760, 158);
            grpLivePrice.Anchor   = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            grpLivePrice.Font     = new Font("Segoe UI", 9f, FontStyle.Bold);
            grpLivePrice.Controls.Add(pnlPriceBox);

            // ══════════════════════════════════════════════════════════════
            // dgvHistoryLog
            // ══════════════════════════════════════════════════════════════
            dgvHistoryLog.Dock                        = DockStyle.Fill;
            dgvHistoryLog.ReadOnly                    = true;
            dgvHistoryLog.AllowUserToAddRows          = false;
            dgvHistoryLog.AllowUserToDeleteRows       = false;
            dgvHistoryLog.AllowUserToResizeRows       = false;
            dgvHistoryLog.SelectionMode               = DataGridViewSelectionMode.FullRowSelect;
            dgvHistoryLog.BackgroundColor             = Color.White;
            dgvHistoryLog.BorderStyle                 = BorderStyle.None;
            dgvHistoryLog.RowHeadersVisible           = false;
            dgvHistoryLog.GridColor                   = Color.FromArgb(220, 220, 225);
            dgvHistoryLog.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvHistoryLog.EnableHeadersVisualStyles   = false;
            dgvHistoryLog.RowTemplate.Height          = 26;
            dgvHistoryLog.ColumnHeadersDefaultCellStyle = new DataGridViewCellStyle
            {
                BackColor = Color.FromArgb(20, 20, 30),
                ForeColor = Color.FromArgb(255, 215, 0),
                Font      = new Font("Segoe UI", 9f, FontStyle.Bold),
                Alignment = DataGridViewContentAlignment.MiddleCenter
            };

            // Cột: Thời Gian
            dgvHistoryLog.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "colTime", HeaderText = "Thời Gian", Width = 140,
                DefaultCellStyle = new DataGridViewCellStyle
                    { Alignment = DataGridViewContentAlignment.MiddleCenter,
                      Font = new Font("Consolas", 9f) }
            });
            // Cột: Giá BTC
            dgvHistoryLog.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "colPrice", HeaderText = "Giá BTC (USD)", Width = 165,
                DefaultCellStyle = new DataGridViewCellStyle
                    { Alignment = DataGridViewContentAlignment.MiddleRight,
                      Font = new Font("Consolas", 9.5f, FontStyle.Bold) }
            });
            // Cột: Thay đổi
            dgvHistoryLog.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "colChange", HeaderText = "Thay Đổi (USD)", Width = 155,
                DefaultCellStyle = new DataGridViewCellStyle
                    { Alignment = DataGridViewContentAlignment.MiddleRight,
                      Font = new Font("Consolas", 9.5f) }
            });
            // Cột: Xu hướng
            dgvHistoryLog.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "colTrend", HeaderText = "Xu Hướng", Width = 105,
                DefaultCellStyle = new DataGridViewCellStyle
                    { Alignment = DataGridViewContentAlignment.MiddleCenter }
            });
            // Cột: Lượt đồng bộ
            dgvHistoryLog.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "colSync", HeaderText = "Lượt Đồng Bộ",
                AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill,
                DefaultCellStyle = new DataGridViewCellStyle
                    { Alignment = DataGridViewContentAlignment.MiddleCenter }
            });

            // ══════════════════════════════════════════════════════════════
            // grpHistory
            // ══════════════════════════════════════════════════════════════
            grpHistory.Text     = "  📋 Nhật Ký Lịch Sử Biến Động (500 dòng gần nhất)";
            grpHistory.Location = new Point(12, 330);
            grpHistory.Size     = new Size(760, 320);
            grpHistory.Anchor   = AnchorStyles.Top | AnchorStyles.Bottom
                                 | AnchorStyles.Left | AnchorStyles.Right;
            grpHistory.Font     = new Font("Segoe UI", 9f, FontStyle.Bold);
            grpHistory.Controls.Add(dgvHistoryLog);

            // ══════════════════════════════════════════════════════════════
            // StatusStrip
            // ══════════════════════════════════════════════════════════════
            tsslLastUpdate.Text    = "Chưa đồng bộ";
            tsslLastUpdate.Font    = new Font("Segoe UI", 9f, FontStyle.Regular);
            tsslLastUpdate.ForeColor = Color.FromArgb(0, 80, 180);
            tsslLastUpdate.Spring  = true;
            tsslLastUpdate.TextAlign = ContentAlignment.MiddleLeft;

            tsslSep.Margin = new Padding(5, 0, 5, 0);

            tsslSyncCount.Text     = "Số lượt đồng bộ: 0";
            tsslSyncCount.Font     = new Font("Segoe UI", 9f, FontStyle.Bold);
            tsslSyncCount.ForeColor = Color.FromArgb(0, 120, 60);
            tsslSyncCount.BorderSides = ToolStripStatusLabelBorderSides.Left;

            statusStrip.Items.AddRange(new ToolStripItem[]
                { tsslLastUpdate, tsslSep, tsslSyncCount });
            statusStrip.BackColor = Color.FromArgb(235, 237, 245);
            statusStrip.Font      = new Font("Segoe UI", 9f);

            // ══════════════════════════════════════════════════════════════
            // Form  frmCryptoStockTicker
            // ══════════════════════════════════════════════════════════════
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode       = AutoScaleMode.Font;
            ClientSize          = new Size(784, 690);
            MinimumSize         = new Size(600, 560);
            StartPosition       = FormStartPosition.CenterScreen;
            Text                = "Crypto Stock Ticker — BTC/USD Real-time Monitor";
            Font                = new Font("Segoe UI", 9f);
            BackColor           = Color.FromArgb(245, 246, 250);
            Controls.AddRange(new Control[]
            {
                grpHistory, grpLivePrice, grpControl, pnlHeader, statusStrip
            });
            Load         += frmCryptoStockTicker_Load;
            FormClosing  += frmCryptoStockTicker_FormClosing;

            pnlHeader.ResumeLayout(false);
            grpControl.ResumeLayout(false);
            grpLivePrice.ResumeLayout(false);
            pnlPriceBox.ResumeLayout(false);
            grpHistory.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dgvHistoryLog).EndInit();
            statusStrip.ResumeLayout(false);
            statusStrip.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        // ── Field declarations ────────────────────────────────────────────────
        private Panel                  pnlHeader;
        private Label                  lblFormTitle;
        private Label                  lblSubtitle;
        private GroupBox               grpControl;
        private Button                 btnStart;
        private Button                 btnPause;
        private Button                 btnStop;
        private Button                 btnClear;
        private GroupBox               grpLivePrice;
        private Panel                  pnlPriceBox;
        private Label                  lblBTCLabel;
        private Label                  lblBTCPrice;
        private Label                  lblDeltaIndicator;
        private Label                  lblThreadNote;
        private GroupBox               grpHistory;
        private DataGridView           dgvHistoryLog;
        private StatusStrip            statusStrip;
        private ToolStripStatusLabel   tsslLastUpdate;
        private ToolStripSeparator     tsslSep;
        private ToolStripStatusLabel   tsslSyncCount;
    }
}
