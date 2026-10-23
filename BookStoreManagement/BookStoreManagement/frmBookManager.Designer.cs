namespace BookStoreManagement
{
    partial class frmBookManager
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
            menuStrip1 = new MenuStrip();
            mnuFile = new ToolStripMenuItem();
            mnuOpenCsv = new ToolStripMenuItem();
            mnuSaveCsv = new ToolStripMenuItem();
            toolStripSeparator1 = new ToolStripSeparator();
            mnuExportReport = new ToolStripMenuItem();
            toolStripSeparator2 = new ToolStripSeparator();
            mnuExit = new ToolStripMenuItem();
            mnuEdit = new ToolStripMenuItem();
            mnuAdd = new ToolStripMenuItem();
            mnuUpdate = new ToolStripMenuItem();
            mnuDelete = new ToolStripMenuItem();
            toolStripSeparator3 = new ToolStripSeparator();
            mnuSearch = new ToolStripMenuItem();
            mnuRefresh = new ToolStripMenuItem();
            mnuHelp = new ToolStripMenuItem();
            mnuAbout = new ToolStripMenuItem();
            toolStrip1 = new ToolStrip();
            btnTsOpen = new ToolStripButton();
            btnTsSave = new ToolStripButton();
            toolStripSeparator4 = new ToolStripSeparator();
            btnTsAdd = new ToolStripButton();
            btnTsEdit = new ToolStripButton();
            btnTsDelete = new ToolStripButton();
            btnTsRefresh = new ToolStripButton();
            toolStripSeparator5 = new ToolStripSeparator();
            btnTsUploadCover = new ToolStripButton();
            toolStripSeparator6 = new ToolStripSeparator();
            lblTsSearch = new ToolStripLabel();
            txtTsKeyword = new ToolStripTextBox();
            btnTsSearch = new ToolStripButton();
            btnTsClearSearch = new ToolStripButton();
            pnlHeader = new Panel();
            lblHeaderSub = new Label();
            lblHeaderTitle = new Label();
            statusStrip1 = new StatusStrip();
            lblTotalTitles = new ToolStripStatusLabel();
            lblTotalQuantity = new ToolStripStatusLabel();
            lblTotalValue = new ToolStripStatusLabel();
            lblStatusMessage = new ToolStripStatusLabel();
            lblClock = new ToolStripStatusLabel();
            pnlMainContainer = new Panel();
            grpBookList = new GroupBox();
            dgvBooks = new DataGridView();
            pnlSearchFilter = new Panel();
            btnResetFilter = new Button();
            btnDoSearch = new Button();
            cboFilterCat = new ComboBox();
            lblFilter = new Label();
            txtSearchKeyword = new TextBox();
            lblSearch = new Label();
            grpBookInfo = new GroupBox();
            pnlCoverAction = new Panel();
            btnRemoveImage = new Button();
            btnBrowseImage = new Button();
            picBookCover = new PictureBox();
            pnlActions = new FlowLayoutPanel();
            btnAdd = new Button();
            btnEdit = new Button();
            btnDelete = new Button();
            btnReset = new Button();
            btnExportCsv = new Button();
            btnImportCsv = new Button();
            txtCoverPath = new TextBox();
            lblCoverPath = new Label();
            numQuantity = new NumericUpDown();
            lblQuantity = new Label();
            txtPrice = new TextBox();
            lblPrice = new Label();
            numPublishYear = new NumericUpDown();
            lblPublishYear = new Label();
            cboPublisher = new ComboBox();
            lblPublisher = new Label();
            cboCategory = new ComboBox();
            lblCategory = new Label();
            txtAuthor = new TextBox();
            lblAuthor = new Label();
            txtTitle = new TextBox();
            lblTitleInput = new Label();
            txtBookId = new TextBox();
            lblBookId = new Label();
            errorProvider1 = new ErrorProvider(components);
            clockTimer = new System.Windows.Forms.Timer(components);
            menuStrip1.SuspendLayout();
            toolStrip1.SuspendLayout();
            pnlHeader.SuspendLayout();
            statusStrip1.SuspendLayout();
            pnlMainContainer.SuspendLayout();
            grpBookList.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvBooks).BeginInit();
            pnlSearchFilter.SuspendLayout();
            grpBookInfo.SuspendLayout();
            pnlCoverAction.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)picBookCover).BeginInit();
            pnlActions.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)numQuantity).BeginInit();
            ((System.ComponentModel.ISupportInitialize)numPublishYear).BeginInit();
            ((System.ComponentModel.ISupportInitialize)errorProvider1).BeginInit();
            SuspendLayout();
            // 
            // menuStrip1
            // 
            menuStrip1.BackColor = Color.White;
            menuStrip1.Font = new Font("Segoe UI", 9.5F);
            menuStrip1.ImageScalingSize = new Size(20, 20);
            menuStrip1.Items.AddRange(new ToolStripItem[] { mnuFile, mnuEdit, mnuHelp });
            menuStrip1.Location = new Point(0, 0);
            menuStrip1.Name = "menuStrip1";
            menuStrip1.Padding = new Padding(6, 2, 0, 2);
            menuStrip1.Size = new Size(1084, 25);
            menuStrip1.TabIndex = 0;
            menuStrip1.Text = "menuStrip1";
            // 
            // mnuFile
            // 
            mnuFile.DropDownItems.AddRange(new ToolStripItem[] { mnuOpenCsv, mnuSaveCsv, toolStripSeparator1, mnuExportReport, toolStripSeparator2, mnuExit });
            mnuFile.Name = "mnuFile";
            mnuFile.Size = new Size(40, 21);
            mnuFile.Text = "&File";
            // 
            // mnuOpenCsv
            // 
            mnuOpenCsv.Name = "mnuOpenCsv";
            mnuOpenCsv.ShortcutKeys = Keys.Control | Keys.O;
            mnuOpenCsv.Size = new Size(230, 22);
            mnuOpenCsv.Text = "&Mở file CSV";
            // 
            // mnuSaveCsv
            // 
            mnuSaveCsv.Name = "mnuSaveCsv";
            mnuSaveCsv.ShortcutKeys = Keys.Control | Keys.S;
            mnuSaveCsv.Size = new Size(230, 22);
            mnuSaveCsv.Text = "&Lưu file CSV";
            // 
            // toolStripSeparator1
            // 
            toolStripSeparator1.Name = "toolStripSeparator1";
            toolStripSeparator1.Size = new Size(227, 6);
            // 
            // mnuExportReport
            // 
            mnuExportReport.Name = "mnuExportReport";
            mnuExportReport.ShortcutKeys = Keys.Control | Keys.E;
            mnuExportReport.Size = new Size(230, 22);
            mnuExportReport.Text = "&Xuất báo cáo kho...";
            // 
            // toolStripSeparator2
            // 
            toolStripSeparator2.Name = "toolStripSeparator2";
            toolStripSeparator2.Size = new Size(227, 6);
            // 
            // mnuExit
            // 
            mnuExit.Name = "mnuExit";
            mnuExit.ShortcutKeys = Keys.Alt | Keys.F4;
            mnuExit.Size = new Size(230, 22);
            mnuExit.Text = "T&hoát";
            // 
            // mnuEdit
            // 
            mnuEdit.DropDownItems.AddRange(new ToolStripItem[] { mnuAdd, mnuUpdate, mnuDelete, toolStripSeparator3, mnuSearch, mnuRefresh });
            mnuEdit.Name = "mnuEdit";
            mnuEdit.Size = new Size(42, 21);
            mnuEdit.Text = "&Edit";
            // 
            // mnuAdd
            // 
            mnuAdd.Name = "mnuAdd";
            mnuAdd.ShortcutKeys = Keys.Control | Keys.N;
            mnuAdd.Size = new Size(203, 22);
            mnuAdd.Text = "&Thêm";
            // 
            // mnuUpdate
            // 
            mnuUpdate.Name = "mnuUpdate";
            mnuUpdate.ShortcutKeys = Keys.Control | Keys.U;
            mnuUpdate.Size = new Size(203, 22);
            mnuUpdate.Text = "&Cập nhật";
            // 
            // mnuDelete
            // 
            mnuDelete.Name = "mnuDelete";
            mnuDelete.ShortcutKeys = Keys.Delete;
            mnuDelete.Size = new Size(203, 22);
            mnuDelete.Text = "&Xóa";
            // 
            // toolStripSeparator3
            // 
            toolStripSeparator3.Name = "toolStripSeparator3";
            toolStripSeparator3.Size = new Size(200, 6);
            // 
            // mnuSearch
            // 
            mnuSearch.Name = "mnuSearch";
            mnuSearch.ShortcutKeys = Keys.Control | Keys.F;
            mnuSearch.Size = new Size(203, 22);
            mnuSearch.Text = "Tìm &kiếm";
            // 
            // mnuRefresh
            // 
            mnuRefresh.Name = "mnuRefresh";
            mnuRefresh.ShortcutKeys = Keys.F5;
            mnuRefresh.Size = new Size(203, 22);
            mnuRefresh.Text = "&Làm mới";
            // 
            // mnuHelp
            // 
            mnuHelp.DropDownItems.AddRange(new ToolStripItem[] { mnuAbout });
            mnuHelp.Name = "mnuHelp";
            mnuHelp.Size = new Size(47, 21);
            mnuHelp.Text = "&Help";
            // 
            // mnuAbout
            // 
            mnuAbout.Name = "mnuAbout";
            mnuAbout.Size = new Size(187, 22);
            mnuAbout.Text = "&Giới thiệu phần mềm";
            // 
            // toolStrip1
            // 
            toolStrip1.BackColor = Color.FromArgb(243, 244, 246);
            toolStrip1.Font = new Font("Segoe UI", 9.5F);
            toolStrip1.GripStyle = ToolStripGripStyle.Hidden;
            toolStrip1.ImageScalingSize = new Size(20, 20);
            toolStrip1.Items.AddRange(new ToolStripItem[] { btnTsOpen, btnTsSave, toolStripSeparator4, btnTsAdd, btnTsEdit, btnTsDelete, btnTsRefresh, toolStripSeparator5, btnTsUploadCover, toolStripSeparator6, lblTsSearch, txtTsKeyword, btnTsSearch, btnTsClearSearch });
            toolStrip1.Location = new Point(0, 25);
            toolStrip1.Name = "toolStrip1";
            toolStrip1.Padding = new Padding(8, 2, 1, 2);
            toolStrip1.Size = new Size(1084, 31);
            toolStrip1.TabIndex = 1;
            toolStrip1.Text = "toolStrip1";
            // 
            // btnTsOpen
            // 
            btnTsOpen.DisplayStyle = ToolStripItemDisplayStyle.ImageAndText;
            btnTsOpen.ImageTransparentColor = Color.Magenta;
            btnTsOpen.Name = "btnTsOpen";
            btnTsOpen.Size = new Size(79, 24);
            btnTsOpen.Text = "Mở file";
            btnTsOpen.ToolTipText = "Mở tệp CSV từ máy tính (Ctrl+O)";
            // 
            // btnTsSave
            // 
            btnTsSave.DisplayStyle = ToolStripItemDisplayStyle.ImageAndText;
            btnTsSave.ImageTransparentColor = Color.Magenta;
            btnTsSave.Name = "btnTsSave";
            btnTsSave.Size = new Size(78, 24);
            btnTsSave.Text = "Lưu file";
            btnTsSave.ToolTipText = "Lưu dữ liệu ra tệp CSV (Ctrl+S)";
            // 
            // toolStripSeparator4
            // 
            toolStripSeparator4.Name = "toolStripSeparator4";
            toolStripSeparator4.Size = new Size(6, 27);
            // 
            // btnTsAdd
            // 
            btnTsAdd.DisplayStyle = ToolStripItemDisplayStyle.ImageAndText;
            btnTsAdd.ImageTransparentColor = Color.Magenta;
            btnTsAdd.Name = "btnTsAdd";
            btnTsAdd.Size = new Size(88, 24);
            btnTsAdd.Text = "Thêm mới";
            btnTsAdd.ToolTipText = "Thêm mới tài liệu sách (Ctrl+N)";
            // 
            // btnTsEdit
            // 
            btnTsEdit.DisplayStyle = ToolStripItemDisplayStyle.ImageAndText;
            btnTsEdit.ImageTransparentColor = Color.Magenta;
            btnTsEdit.Name = "btnTsEdit";
            btnTsEdit.Size = new Size(84, 24);
            btnTsEdit.Text = "Cập nhật";
            btnTsEdit.ToolTipText = "Cập nhật sách đang chọn (Ctrl+U)";
            // 
            // btnTsDelete
            // 
            btnTsDelete.DisplayStyle = ToolStripItemDisplayStyle.ImageAndText;
            btnTsDelete.ImageTransparentColor = Color.Magenta;
            btnTsDelete.Name = "btnTsDelete";
            btnTsDelete.Size = new Size(55, 24);
            btnTsDelete.Text = "Xóa";
            btnTsDelete.ToolTipText = "Xóa sách đang chọn (Delete)";
            // 
            // btnTsRefresh
            // 
            btnTsRefresh.DisplayStyle = ToolStripItemDisplayStyle.ImageAndText;
            btnTsRefresh.ImageTransparentColor = Color.Magenta;
            btnTsRefresh.Name = "btnTsRefresh";
            btnTsRefresh.Size = new Size(81, 24);
            btnTsRefresh.Text = "Làm mới";
            btnTsRefresh.ToolTipText = "Làm mới form và danh sách (F5)";
            // 
            // toolStripSeparator5
            // 
            toolStripSeparator5.Name = "toolStripSeparator5";
            toolStripSeparator5.Size = new Size(6, 27);
            // 
            // btnTsUploadCover
            // 
            btnTsUploadCover.DisplayStyle = ToolStripItemDisplayStyle.ImageAndText;
            btnTsUploadCover.ImageTransparentColor = Color.Magenta;
            btnTsUploadCover.Name = "btnTsUploadCover";
            btnTsUploadCover.Size = new Size(97, 24);
            btnTsUploadCover.Text = "Tải ảnh bìa";
            btnTsUploadCover.ToolTipText = "Chọn hình ảnh bìa cho sách";
            // 
            // toolStripSeparator6
            // 
            toolStripSeparator6.Name = "toolStripSeparator6";
            toolStripSeparator6.Size = new Size(6, 27);
            // 
            // lblTsSearch
            // 
            lblTsSearch.Name = "lblTsSearch";
            lblTsSearch.Size = new Size(63, 24);
            lblTsSearch.Text = "Tìm kiếm:";
            // 
            // txtTsKeyword
            // 
            txtTsKeyword.BorderStyle = BorderStyle.FixedSingle;
            txtTsKeyword.Font = new Font("Segoe UI", 9F);
            txtTsKeyword.Name = "txtTsKeyword";
            txtTsKeyword.Size = new Size(130, 27);
            txtTsKeyword.ToolTipText = "Nhập từ khóa tìm kiếm";
            // 
            // btnTsSearch
            // 
            btnTsSearch.DisplayStyle = ToolStripItemDisplayStyle.Text;
            btnTsSearch.ImageTransparentColor = Color.Magenta;
            btnTsSearch.Name = "btnTsSearch";
            btnTsSearch.Size = new Size(33, 24);
            btnTsSearch.Text = "Tìm";
            // 
            // btnTsClearSearch
            // 
            btnTsClearSearch.DisplayStyle = ToolStripItemDisplayStyle.Text;
            btnTsClearSearch.ImageTransparentColor = Color.Magenta;
            btnTsClearSearch.Name = "btnTsClearSearch";
            btnTsClearSearch.Size = new Size(49, 24);
            btnTsClearSearch.Text = "Bỏ lọc";
            // 
            // pnlHeader
            // 
            pnlHeader.BackColor = Color.FromArgb(24, 76, 120);
            pnlHeader.Controls.Add(lblHeaderSub);
            pnlHeader.Controls.Add(lblHeaderTitle);
            pnlHeader.Dock = DockStyle.Top;
            pnlHeader.Location = new Point(0, 56);
            pnlHeader.Name = "pnlHeader";
            pnlHeader.Size = new Size(1084, 52);
            pnlHeader.TabIndex = 2;
            // 
            // lblHeaderSub
            // 
            lblHeaderSub.Dock = DockStyle.Bottom;
            lblHeaderSub.Font = new Font("Segoe UI", 8.25F, FontStyle.Italic);
            lblHeaderSub.ForeColor = Color.FromArgb(226, 232, 240);
            lblHeaderSub.Location = new Point(0, 31);
            lblHeaderSub.Name = "lblHeaderSub";
            lblHeaderSub.Size = new Size(1084, 21);
            lblHeaderSub.TabIndex = 1;
            lblHeaderSub.Text = "Khai thác System Dialogs (OpenFileDialog, SaveFileDialog) • Quản lý File I/O CSV & Data Binding";
            lblHeaderSub.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // lblHeaderTitle
            // 
            lblHeaderTitle.Dock = DockStyle.Top;
            lblHeaderTitle.Font = new Font("Segoe UI", 13.5F, FontStyle.Bold);
            lblHeaderTitle.ForeColor = Color.White;
            lblHeaderTitle.Location = new Point(0, 0);
            lblHeaderTitle.Name = "lblHeaderTitle";
            lblHeaderTitle.Size = new Size(1084, 32);
            lblHeaderTitle.TabIndex = 0;
            lblHeaderTitle.Text = "QUẢN LÝ TÀI LIỆU SÁCH & XUẤT BÁO CÁO NHÀ SÁCH";
            lblHeaderTitle.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // statusStrip1
            // 
            statusStrip1.BackColor = Color.FromArgb(241, 245, 249);
            statusStrip1.Font = new Font("Segoe UI", 9.25F);
            statusStrip1.ImageScalingSize = new Size(20, 20);
            statusStrip1.Items.AddRange(new ToolStripItem[] { lblTotalTitles, lblTotalQuantity, lblTotalValue, lblStatusMessage, lblClock });
            statusStrip1.Location = new Point(0, 725);
            statusStrip1.Name = "statusStrip1";
            statusStrip1.Padding = new Padding(1, 0, 14, 0);
            statusStrip1.Size = new Size(1084, 26);
            statusStrip1.TabIndex = 3;
            statusStrip1.Text = "statusStrip1";
            // 
            // lblTotalTitles
            // 
            lblTotalTitles.BorderSides = ToolStripStatusLabelBorderSides.Right;
            lblTotalTitles.BorderStyle = Border3DStyle.Etched;
            lblTotalTitles.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            lblTotalTitles.ForeColor = Color.FromArgb(15, 23, 42);
            lblTotalTitles.Name = "lblTotalTitles";
            lblTotalTitles.Size = new Size(130, 21);
            lblTotalTitles.Text = "Tổng số đầu sách: 0";
            // 
            // lblTotalQuantity
            // 
            lblTotalQuantity.BorderSides = ToolStripStatusLabelBorderSides.Right;
            lblTotalQuantity.BorderStyle = Border3DStyle.Etched;
            lblTotalQuantity.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            lblTotalQuantity.ForeColor = Color.FromArgb(15, 23, 42);
            lblTotalQuantity.Name = "lblTotalQuantity";
            lblTotalQuantity.Size = new Size(137, 21);
            lblTotalQuantity.Text = "Tổng số lượng: 0 cuốn";
            // 
            // lblTotalValue
            // 
            lblTotalValue.BorderSides = ToolStripStatusLabelBorderSides.Right;
            lblTotalValue.BorderStyle = Border3DStyle.Etched;
            lblTotalValue.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            lblTotalValue.ForeColor = Color.FromArgb(180, 30, 30);
            lblTotalValue.Name = "lblTotalValue";
            lblTotalValue.Size = new Size(220, 21);
            lblTotalValue.Text = "Tổng giá trị tiền sách trong kho: 0 VNĐ";
            // 
            // lblStatusMessage
            // 
            lblStatusMessage.Font = new Font("Segoe UI", 9F);
            lblStatusMessage.ForeColor = Color.FromArgb(71, 85, 105);
            lblStatusMessage.Name = "lblStatusMessage";
            lblStatusMessage.Size = new Size(544, 21);
            lblStatusMessage.Spring = true;
            lblStatusMessage.Text = "Trạng thái: Sẵn sàng";
            lblStatusMessage.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // lblClock
            // 
            lblClock.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            lblClock.ForeColor = Color.FromArgb(30, 64, 175);
            lblClock.Name = "lblClock";
            lblClock.Size = new Size(230, 21);
            lblClock.Text = "Thời gian hiện tại: 23/10/2026 00:00:00";
            // 
            // pnlMainContainer
            // 
            pnlMainContainer.Controls.Add(grpBookList);
            pnlMainContainer.Controls.Add(pnlSearchFilter);
            pnlMainContainer.Controls.Add(grpBookInfo);
            pnlMainContainer.Dock = DockStyle.Fill;
            pnlMainContainer.Location = new Point(0, 108);
            pnlMainContainer.Name = "pnlMainContainer";
            pnlMainContainer.Padding = new Padding(10, 6, 10, 6);
            pnlMainContainer.Size = new Size(1084, 617);
            pnlMainContainer.TabIndex = 4;
            // 
            // grpBookList
            // 
            grpBookList.Controls.Add(dgvBooks);
            grpBookList.Dock = DockStyle.Fill;
            grpBookList.Font = new Font("Segoe UI", 9.5F, FontStyle.Bold);
            grpBookList.ForeColor = Color.FromArgb(24, 76, 120);
            grpBookList.Location = new Point(10, 321);
            grpBookList.Name = "grpBookList";
            grpBookList.Padding = new Padding(8, 6, 8, 8);
            grpBookList.Size = new Size(1064, 290);
            grpBookList.TabIndex = 2;
            grpBookList.TabStop = false;
            grpBookList.Text = "Danh sách tài liệu sách trong kho (dgvBooks)";
            // 
            // dgvBooks
            // 
            dgvBooks.AllowUserToAddRows = false;
            dgvBooks.AllowUserToDeleteRows = false;
            dgvBooks.BackgroundColor = Color.White;
            dgvBooks.BorderStyle = BorderStyle.Fixed3D;
            dgvBooks.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvBooks.Dock = DockStyle.Fill;
            dgvBooks.Location = new Point(8, 23);
            dgvBooks.MultiSelect = false;
            dgvBooks.Name = "dgvBooks";
            dgvBooks.ReadOnly = true;
            dgvBooks.RowHeadersWidth = 35;
            dgvBooks.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvBooks.Size = new Size(1048, 259);
            dgvBooks.TabIndex = 0;
            // 
            // pnlSearchFilter
            // 
            pnlSearchFilter.BackColor = Color.FromArgb(248, 250, 252);
            pnlSearchFilter.BorderStyle = BorderStyle.FixedSingle;
            pnlSearchFilter.Controls.Add(btnResetFilter);
            pnlSearchFilter.Controls.Add(btnDoSearch);
            pnlSearchFilter.Controls.Add(cboFilterCat);
            pnlSearchFilter.Controls.Add(lblFilter);
            pnlSearchFilter.Controls.Add(txtSearchKeyword);
            pnlSearchFilter.Controls.Add(lblSearch);
            pnlSearchFilter.Dock = DockStyle.Top;
            pnlSearchFilter.Location = new Point(10, 276);
            pnlSearchFilter.Name = "pnlSearchFilter";
            pnlSearchFilter.Size = new Size(1064, 45);
            pnlSearchFilter.TabIndex = 1;
            // 
            // btnResetFilter
            // 
            btnResetFilter.BackColor = Color.FromArgb(100, 116, 139);
            btnResetFilter.Cursor = Cursors.Hand;
            btnResetFilter.FlatStyle = FlatStyle.Flat;
            btnResetFilter.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            btnResetFilter.ForeColor = Color.White;
            btnResetFilter.Location = new Point(782, 8);
            btnResetFilter.Name = "btnResetFilter";
            btnResetFilter.Size = new Size(95, 29);
            btnResetFilter.TabIndex = 5;
            btnResetFilter.Text = "Tất cả";
            btnResetFilter.UseVisualStyleBackColor = false;
            // 
            // btnDoSearch
            // 
            btnDoSearch.BackColor = Color.FromArgb(24, 76, 120);
            btnDoSearch.Cursor = Cursors.Hand;
            btnDoSearch.FlatStyle = FlatStyle.Flat;
            btnDoSearch.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            btnDoSearch.ForeColor = Color.White;
            btnDoSearch.Location = new Point(681, 8);
            btnDoSearch.Name = "btnDoSearch";
            btnDoSearch.Size = new Size(95, 29);
            btnDoSearch.TabIndex = 4;
            btnDoSearch.Text = "Tìm kiếm";
            btnDoSearch.UseVisualStyleBackColor = false;
            // 
            // cboFilterCat
            // 
            cboFilterCat.DropDownStyle = ComboBoxStyle.DropDownList;
            cboFilterCat.Font = new Font("Segoe UI", 9F);
            cboFilterCat.FormattingEnabled = true;
            cboFilterCat.Location = new Point(482, 10);
            cboFilterCat.Name = "cboFilterCat";
            cboFilterCat.Size = new Size(185, 23);
            cboFilterCat.TabIndex = 3;
            // 
            // lblFilter
            // 
            lblFilter.AutoSize = true;
            lblFilter.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            lblFilter.ForeColor = Color.FromArgb(51, 65, 85);
            lblFilter.Location = new Point(388, 14);
            lblFilter.Name = "lblFilter";
            lblFilter.Size = new Size(88, 15);
            lblFilter.TabIndex = 2;
            lblFilter.Text = "Lọc theo thể loại:";
            // 
            // txtSearchKeyword
            // 
            txtSearchKeyword.Font = new Font("Segoe UI", 9F);
            txtSearchKeyword.Location = new Point(116, 10);
            txtSearchKeyword.Name = "txtSearchKeyword";
            txtSearchKeyword.Size = new Size(250, 23);
            txtSearchKeyword.TabIndex = 1;
            // 
            // lblSearch
            // 
            lblSearch.AutoSize = true;
            lblSearch.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            lblSearch.ForeColor = Color.FromArgb(51, 65, 85);
            lblSearch.Location = new Point(12, 14);
            lblSearch.Name = "lblSearch";
            lblSearch.Size = new Size(98, 15);
            lblSearch.TabIndex = 0;
            lblSearch.Text = "Tìm kiếm tài liệu:";
            // 
            // grpBookInfo
            // 
            grpBookInfo.Controls.Add(pnlCoverAction);
            grpBookInfo.Controls.Add(pnlActions);
            grpBookInfo.Controls.Add(txtCoverPath);
            grpBookInfo.Controls.Add(lblCoverPath);
            grpBookInfo.Controls.Add(numQuantity);
            grpBookInfo.Controls.Add(lblQuantity);
            grpBookInfo.Controls.Add(txtPrice);
            grpBookInfo.Controls.Add(lblPrice);
            grpBookInfo.Controls.Add(numPublishYear);
            grpBookInfo.Controls.Add(lblPublishYear);
            grpBookInfo.Controls.Add(cboPublisher);
            grpBookInfo.Controls.Add(lblPublisher);
            grpBookInfo.Controls.Add(cboCategory);
            grpBookInfo.Controls.Add(lblCategory);
            grpBookInfo.Controls.Add(txtAuthor);
            grpBookInfo.Controls.Add(lblAuthor);
            grpBookInfo.Controls.Add(txtTitle);
            grpBookInfo.Controls.Add(lblTitleInput);
            grpBookInfo.Controls.Add(txtBookId);
            grpBookInfo.Controls.Add(lblBookId);
            grpBookInfo.Dock = DockStyle.Top;
            grpBookInfo.Font = new Font("Segoe UI", 9.5F, FontStyle.Bold);
            grpBookInfo.ForeColor = Color.FromArgb(24, 76, 120);
            grpBookInfo.Location = new Point(10, 6);
            grpBookInfo.Name = "grpBookInfo";
            grpBookInfo.Size = new Size(1064, 270);
            grpBookInfo.TabIndex = 0;
            grpBookInfo.TabStop = false;
            grpBookInfo.Text = "Khu vực chi tiết: Thông tin tài liệu sách";
            // 
            // pnlCoverAction
            // 
            pnlCoverAction.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            pnlCoverAction.Controls.Add(btnRemoveImage);
            pnlCoverAction.Controls.Add(btnBrowseImage);
            pnlCoverAction.Controls.Add(picBookCover);
            pnlCoverAction.Location = new Point(885, 20);
            pnlCoverAction.Name = "pnlCoverAction";
            pnlCoverAction.Size = new Size(165, 240);
            pnlCoverAction.TabIndex = 19;
            // 
            // btnRemoveImage
            // 
            btnRemoveImage.BackColor = Color.FromArgb(241, 245, 249);
            btnRemoveImage.Cursor = Cursors.Hand;
            btnRemoveImage.FlatAppearance.BorderColor = Color.FromArgb(203, 213, 225);
            btnRemoveImage.FlatStyle = FlatStyle.Flat;
            btnRemoveImage.Font = new Font("Segoe UI", 8.25F);
            btnRemoveImage.ForeColor = Color.FromArgb(100, 116, 139);
            btnRemoveImage.Location = new Point(15, 210);
            btnRemoveImage.Name = "btnRemoveImage";
            btnRemoveImage.Size = new Size(135, 24);
            btnRemoveImage.TabIndex = 2;
            btnRemoveImage.Text = "Bỏ ảnh";
            btnRemoveImage.UseVisualStyleBackColor = false;
            // 
            // btnBrowseImage
            // 
            btnBrowseImage.BackColor = Color.FromArgb(24, 76, 120);
            btnBrowseImage.Cursor = Cursors.Hand;
            btnBrowseImage.FlatStyle = FlatStyle.Flat;
            btnBrowseImage.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            btnBrowseImage.ForeColor = Color.White;
            btnBrowseImage.Location = new Point(15, 178);
            btnBrowseImage.Name = "btnBrowseImage";
            btnBrowseImage.Size = new Size(135, 28);
            btnBrowseImage.TabIndex = 1;
            btnBrowseImage.Text = "Tải ảnh bìa";
            btnBrowseImage.UseVisualStyleBackColor = false;
            // 
            // picBookCover
            // 
            picBookCover.BackColor = Color.FromArgb(248, 250, 252);
            picBookCover.BorderStyle = BorderStyle.FixedSingle;
            picBookCover.Cursor = Cursors.Hand;
            picBookCover.Location = new Point(15, 5);
            picBookCover.Name = "picBookCover";
            picBookCover.Size = new Size(135, 168);
            picBookCover.SizeMode = PictureBoxSizeMode.Zoom;
            picBookCover.TabIndex = 0;
            picBookCover.TabStop = false;
            // 
            // pnlActions
            // 
            pnlActions.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            pnlActions.Controls.Add(btnAdd);
            pnlActions.Controls.Add(btnEdit);
            pnlActions.Controls.Add(btnDelete);
            pnlActions.Controls.Add(btnReset);
            pnlActions.Controls.Add(btnExportCsv);
            pnlActions.Controls.Add(btnImportCsv);
            pnlActions.Location = new Point(15, 218);
            pnlActions.Name = "pnlActions";
            pnlActions.Size = new Size(850, 42);
            pnlActions.TabIndex = 18;
            // 
            // btnAdd
            // 
            btnAdd.BackColor = Color.FromArgb(34, 139, 34);
            btnAdd.Cursor = Cursors.Hand;
            btnAdd.FlatStyle = FlatStyle.Flat;
            btnAdd.Font = new Font("Segoe UI", 9.5F, FontStyle.Bold);
            btnAdd.ForeColor = Color.White;
            btnAdd.Location = new Point(3, 3);
            btnAdd.Name = "btnAdd";
            btnAdd.Size = new Size(115, 34);
            btnAdd.TabIndex = 0;
            btnAdd.Text = "Thêm mới";
            btnAdd.UseVisualStyleBackColor = false;
            // 
            // btnEdit
            // 
            btnEdit.BackColor = Color.FromArgb(24, 116, 205);
            btnEdit.Cursor = Cursors.Hand;
            btnEdit.FlatStyle = FlatStyle.Flat;
            btnEdit.Font = new Font("Segoe UI", 9.5F, FontStyle.Bold);
            btnEdit.ForeColor = Color.White;
            btnEdit.Location = new Point(124, 3);
            btnEdit.Name = "btnEdit";
            btnEdit.Size = new Size(115, 34);
            btnEdit.TabIndex = 1;
            btnEdit.Text = "Sửa / Cập nhật";
            btnEdit.UseVisualStyleBackColor = false;
            // 
            // btnDelete
            // 
            btnDelete.BackColor = Color.FromArgb(205, 51, 51);
            btnDelete.Cursor = Cursors.Hand;
            btnDelete.FlatStyle = FlatStyle.Flat;
            btnDelete.Font = new Font("Segoe UI", 9.5F, FontStyle.Bold);
            btnDelete.ForeColor = Color.White;
            btnDelete.Location = new Point(245, 3);
            btnDelete.Name = "btnDelete";
            btnDelete.Size = new Size(115, 34);
            btnDelete.TabIndex = 2;
            btnDelete.Text = "Xóa sách";
            btnDelete.UseVisualStyleBackColor = false;
            // 
            // btnReset
            // 
            btnReset.BackColor = Color.FromArgb(100, 116, 139);
            btnReset.Cursor = Cursors.Hand;
            btnReset.FlatStyle = FlatStyle.Flat;
            btnReset.Font = new Font("Segoe UI", 9.5F, FontStyle.Bold);
            btnReset.ForeColor = Color.White;
            btnReset.Location = new Point(366, 3);
            btnReset.Name = "btnReset";
            btnReset.Size = new Size(115, 34);
            btnReset.TabIndex = 3;
            btnReset.Text = "Làm mới";
            btnReset.UseVisualStyleBackColor = false;
            // 
            // btnExportCsv
            // 
            btnExportCsv.BackColor = Color.FromArgb(16, 149, 106);
            btnExportCsv.Cursor = Cursors.Hand;
            btnExportCsv.FlatStyle = FlatStyle.Flat;
            btnExportCsv.Font = new Font("Segoe UI", 9.5F, FontStyle.Bold);
            btnExportCsv.ForeColor = Color.White;
            btnExportCsv.Location = new Point(487, 3);
            btnExportCsv.Name = "btnExportCsv";
            btnExportCsv.Size = new Size(125, 34);
            btnExportCsv.TabIndex = 4;
            btnExportCsv.Text = "Lưu file CSV";
            btnExportCsv.UseVisualStyleBackColor = false;
            // 
            // btnImportCsv
            // 
            btnImportCsv.BackColor = Color.FromArgb(109, 40, 217);
            btnImportCsv.Cursor = Cursors.Hand;
            btnImportCsv.FlatStyle = FlatStyle.Flat;
            btnImportCsv.Font = new Font("Segoe UI", 9.5F, FontStyle.Bold);
            btnImportCsv.ForeColor = Color.White;
            btnImportCsv.Location = new Point(618, 3);
            btnImportCsv.Name = "btnImportCsv";
            btnImportCsv.Size = new Size(125, 34);
            btnImportCsv.TabIndex = 5;
            btnImportCsv.Text = "Mở file CSV";
            btnImportCsv.UseVisualStyleBackColor = false;
            // 
            // txtCoverPath
            // 
            txtCoverPath.BackColor = Color.FromArgb(248, 250, 252);
            txtCoverPath.Font = new Font("Segoe UI", 9F);
            txtCoverPath.Location = new Point(115, 178);
            txtCoverPath.Name = "txtCoverPath";
            txtCoverPath.ReadOnly = true;
            txtCoverPath.Size = new Size(730, 23);
            txtCoverPath.TabIndex = 17;
            // 
            // lblCoverPath
            // 
            lblCoverPath.AutoSize = true;
            lblCoverPath.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point);
            lblCoverPath.ForeColor = Color.FromArgb(30, 41, 59);
            lblCoverPath.Location = new Point(15, 182);
            lblCoverPath.Name = "lblCoverPath";
            lblCoverPath.Size = new Size(71, 15);
            lblCoverPath.TabIndex = 16;
            lblCoverPath.Text = "Tập tin ảnh:";
            // 
            // numQuantity
            // 
            numQuantity.Font = new Font("Segoe UI", 9F);
            numQuantity.Location = new Point(560, 140);
            numQuantity.Maximum = new decimal(new int[] { 1000000, 0, 0, 0 });
            numQuantity.Name = "numQuantity";
            numQuantity.Size = new Size(285, 23);
            numQuantity.TabIndex = 15;
            numQuantity.Value = new decimal(new int[] { 10, 0, 0, 0 });
            // 
            // lblQuantity
            // 
            lblQuantity.AutoSize = true;
            lblQuantity.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point);
            lblQuantity.ForeColor = Color.FromArgb(30, 41, 59);
            lblQuantity.Location = new Point(460, 144);
            lblQuantity.Name = "lblQuantity";
            lblQuantity.Size = new Size(84, 15);
            lblQuantity.TabIndex = 14;
            lblQuantity.Text = "Số lượng tồn:";
            // 
            // txtPrice
            // 
            txtPrice.Font = new Font("Segoe UI", 9F);
            txtPrice.Location = new Point(115, 140);
            txtPrice.Name = "txtPrice";
            txtPrice.Size = new Size(300, 23);
            txtPrice.TabIndex = 13;
            // 
            // lblPrice
            // 
            lblPrice.AutoSize = true;
            lblPrice.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point);
            lblPrice.ForeColor = Color.FromArgb(30, 41, 59);
            lblPrice.Location = new Point(15, 144);
            lblPrice.Name = "lblPrice";
            lblPrice.Size = new Size(89, 15);
            lblPrice.TabIndex = 12;
            lblPrice.Text = "Đơn giá (VNĐ):";
            // 
            // numPublishYear
            // 
            numPublishYear.Font = new Font("Segoe UI", 9F);
            numPublishYear.Location = new Point(560, 102);
            numPublishYear.Maximum = new decimal(new int[] { 2100, 0, 0, 0 });
            numPublishYear.Minimum = new decimal(new int[] { 1900, 0, 0, 0 });
            numPublishYear.Name = "numPublishYear";
            numPublishYear.Size = new Size(285, 23);
            numPublishYear.TabIndex = 11;
            numPublishYear.Value = new decimal(new int[] { 2024, 0, 0, 0 });
            // 
            // lblPublishYear
            // 
            lblPublishYear.AutoSize = true;
            lblPublishYear.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point);
            lblPublishYear.ForeColor = Color.FromArgb(30, 41, 59);
            lblPublishYear.Location = new Point(460, 106);
            lblPublishYear.Name = "lblPublishYear";
            lblPublishYear.Size = new Size(84, 15);
            lblPublishYear.TabIndex = 10;
            lblPublishYear.Text = "Năm xuất bản:";
            // 
            // cboPublisher
            // 
            cboPublisher.DropDownStyle = ComboBoxStyle.DropDownList;
            cboPublisher.Font = new Font("Segoe UI", 9F);
            cboPublisher.FormattingEnabled = true;
            cboPublisher.Location = new Point(560, 64);
            cboPublisher.Name = "cboPublisher";
            cboPublisher.Size = new Size(285, 23);
            cboPublisher.TabIndex = 7;
            // 
            // lblPublisher
            // 
            lblPublisher.AutoSize = true;
            lblPublisher.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point);
            lblPublisher.ForeColor = Color.FromArgb(30, 41, 59);
            lblPublisher.Location = new Point(460, 68);
            lblPublisher.Name = "lblPublisher";
            lblPublisher.Size = new Size(80, 15);
            lblPublisher.TabIndex = 6;
            lblPublisher.Text = "Nhà xuất bản:";
            // 
            // cboCategory
            // 
            cboCategory.DropDownStyle = ComboBoxStyle.DropDownList;
            cboCategory.Font = new Font("Segoe UI", 9F);
            cboCategory.FormattingEnabled = true;
            cboCategory.Location = new Point(560, 26);
            cboCategory.Name = "cboCategory";
            cboCategory.Size = new Size(285, 23);
            cboCategory.TabIndex = 3;
            // 
            // lblCategory
            // 
            lblCategory.AutoSize = true;
            lblCategory.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point);
            lblCategory.ForeColor = Color.FromArgb(30, 41, 59);
            lblCategory.Location = new Point(460, 30);
            lblCategory.Name = "lblCategory";
            lblCategory.Size = new Size(52, 15);
            lblCategory.TabIndex = 2;
            lblCategory.Text = "Thể loại:";
            // 
            // txtAuthor
            // 
            txtAuthor.Font = new Font("Segoe UI", 9F);
            txtAuthor.Location = new Point(115, 102);
            txtAuthor.Name = "txtAuthor";
            txtAuthor.Size = new Size(300, 23);
            txtAuthor.TabIndex = 9;
            // 
            // lblAuthor
            // 
            lblAuthor.AutoSize = true;
            lblAuthor.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point);
            lblAuthor.ForeColor = Color.FromArgb(30, 41, 59);
            lblAuthor.Location = new Point(15, 106);
            lblAuthor.Name = "lblAuthor";
            lblAuthor.Size = new Size(46, 15);
            lblAuthor.TabIndex = 8;
            lblAuthor.Text = "Tác giả:";
            // 
            // txtTitle
            // 
            txtTitle.Font = new Font("Segoe UI", 9F);
            txtTitle.Location = new Point(115, 64);
            txtTitle.Name = "txtTitle";
            txtTitle.Size = new Size(300, 23);
            txtTitle.TabIndex = 5;
            // 
            // lblTitleInput
            // 
            lblTitleInput.AutoSize = true;
            lblTitleInput.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point);
            lblTitleInput.ForeColor = Color.FromArgb(30, 41, 59);
            lblTitleInput.Location = new Point(15, 68);
            lblTitleInput.Name = "lblTitleInput";
            lblTitleInput.Size = new Size(55, 15);
            lblTitleInput.TabIndex = 4;
            lblTitleInput.Text = "Tên sách:";
            // 
            // txtBookId
            // 
            txtBookId.Font = new Font("Segoe UI", 9F);
            txtBookId.Location = new Point(115, 26);
            txtBookId.Name = "txtBookId";
            txtBookId.Size = new Size(300, 23);
            txtBookId.TabIndex = 1;
            // 
            // lblBookId
            // 
            lblBookId.AutoSize = true;
            lblBookId.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point);
            lblBookId.ForeColor = Color.FromArgb(30, 41, 59);
            lblBookId.Location = new Point(15, 30);
            lblBookId.Name = "lblBookId";
            lblBookId.Size = new Size(54, 15);
            lblBookId.TabIndex = 0;
            lblBookId.Text = "Mã sách:";
            // 
            // errorProvider1
            // 
            errorProvider1.ContainerControl = this;
            // 
            // clockTimer
            // 
            clockTimer.Enabled = true;
            clockTimer.Interval = 1000;
            // 
            // frmBookManager
            // 
            AutoScaleDimensions = new SizeF(7F, 17F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.White;
            ClientSize = new Size(1084, 751);
            Controls.Add(pnlMainContainer);
            Controls.Add(statusStrip1);
            Controls.Add(pnlHeader);
            Controls.Add(toolStrip1);
            Controls.Add(menuStrip1);
            Font = new Font("Segoe UI", 9.75F);
            MainMenuStrip = menuStrip1;
            MinimumSize = new Size(980, 680);
            Name = "frmBookManager";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Hệ Thống Quản Lý Tài Liệu Sách & Báo Cáo Nhà Sách";
            menuStrip1.ResumeLayout(false);
            menuStrip1.PerformLayout();
            toolStrip1.ResumeLayout(false);
            toolStrip1.PerformLayout();
            pnlHeader.ResumeLayout(false);
            statusStrip1.ResumeLayout(false);
            statusStrip1.PerformLayout();
            pnlMainContainer.ResumeLayout(false);
            grpBookList.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dgvBooks).EndInit();
            pnlSearchFilter.ResumeLayout(false);
            pnlSearchFilter.PerformLayout();
            grpBookInfo.ResumeLayout(false);
            grpBookInfo.PerformLayout();
            pnlCoverAction.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)picBookCover).EndInit();
            pnlActions.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)numQuantity).EndInit();
            ((System.ComponentModel.ISupportInitialize)numPublishYear).EndInit();
            ((System.ComponentModel.ISupportInitialize)errorProvider1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private MenuStrip menuStrip1;
        private ToolStripMenuItem mnuFile;
        private ToolStripMenuItem mnuOpenCsv;
        private ToolStripMenuItem mnuSaveCsv;
        private ToolStripSeparator toolStripSeparator1;
        private ToolStripMenuItem mnuExportReport;
        private ToolStripSeparator toolStripSeparator2;
        private ToolStripMenuItem mnuExit;
        private ToolStripMenuItem mnuEdit;
        private ToolStripMenuItem mnuAdd;
        private ToolStripMenuItem mnuUpdate;
        private ToolStripMenuItem mnuDelete;
        private ToolStripSeparator toolStripSeparator3;
        private ToolStripMenuItem mnuSearch;
        private ToolStripMenuItem mnuRefresh;
        private ToolStripMenuItem mnuHelp;
        private ToolStripMenuItem mnuAbout;
        private ToolStrip toolStrip1;
        private ToolStripButton btnTsOpen;
        private ToolStripButton btnTsSave;
        private ToolStripSeparator toolStripSeparator4;
        private ToolStripButton btnTsAdd;
        private ToolStripButton btnTsEdit;
        private ToolStripButton btnTsDelete;
        private ToolStripButton btnTsRefresh;
        private ToolStripSeparator toolStripSeparator5;
        private ToolStripButton btnTsUploadCover;
        private ToolStripSeparator toolStripSeparator6;
        private ToolStripLabel lblTsSearch;
        private ToolStripTextBox txtTsKeyword;
        private ToolStripButton btnTsSearch;
        private ToolStripButton btnTsClearSearch;
        private Panel pnlHeader;
        private Label lblHeaderSub;
        private Label lblHeaderTitle;
        private StatusStrip statusStrip1;
        private ToolStripStatusLabel lblTotalTitles;
        private ToolStripStatusLabel lblTotalQuantity;
        private ToolStripStatusLabel lblTotalValue;
        private ToolStripStatusLabel lblStatusMessage;
        private ToolStripStatusLabel lblClock;
        private Panel pnlMainContainer;
        private GroupBox grpBookInfo;
        private Label lblBookId;
        private TextBox txtBookId;
        private Label lblTitleInput;
        private TextBox txtTitle;
        private Label lblAuthor;
        private TextBox txtAuthor;
        private Label lblCategory;
        private ComboBox cboCategory;
        private Label lblPublisher;
        private ComboBox cboPublisher;
        private Label lblPublishYear;
        private NumericUpDown numPublishYear;
        private Label lblPrice;
        private TextBox txtPrice;
        private Label lblQuantity;
        private NumericUpDown numQuantity;
        private Label lblCoverPath;
        private TextBox txtCoverPath;
        private FlowLayoutPanel pnlActions;
        private Button btnAdd;
        private Button btnEdit;
        private Button btnDelete;
        private Button btnReset;
        private Button btnExportCsv;
        private Button btnImportCsv;
        private Panel pnlCoverAction;
        private PictureBox picBookCover;
        private Button btnBrowseImage;
        private Button btnRemoveImage;
        private Panel pnlSearchFilter;
        private Label lblSearch;
        private TextBox txtSearchKeyword;
        private Label lblFilter;
        private ComboBox cboFilterCat;
        private Button btnDoSearch;
        private Button btnResetFilter;
        private GroupBox grpBookList;
        private DataGridView dgvBooks;
        private ErrorProvider errorProvider1;
        private System.Windows.Forms.Timer clockTimer;
    }
}
