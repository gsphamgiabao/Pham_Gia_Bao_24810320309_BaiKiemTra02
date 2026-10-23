using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace BookStoreManagement
{
    public partial class frmBookManager : Form
    {
        // 1. Quản lý trạng thái dữ liệu đồng bộ 2 chiều bằng BindingList<T> và BindingSource
        private readonly BindingList<BookModel> _bookList = new BindingList<BookModel>();
        private readonly BindingSource _bindingSource = new BindingSource();

        // Biến cờ kiểm soát trạng thái giao diện và đường dẫn ảnh bìa tạm
        private bool _isResetting = false;
        private string _currentCoverFullPath = string.Empty;

        // Thư mục lưu trữ tài nguyên mẫu của ứng dụng
        private readonly string _sampleDataDir = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "SampleData");
        private readonly string _sampleCoversDir = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "SampleData", "Covers");

        public frmBookManager()
        {
            InitializeComponent();
            InitFormComponents();
        }

        #region Khởi tạo Giao diện và Dữ liệu

        private void InitFormComponents()
        {
            // Thiết lập ComboBox Thể loại và Nhà xuất bản
            PopulateCategoriesAndPublishers();

            // Khởi tạo các biểu tượng Vector vẽ bằng GDI+ cho ToolStrip (không phụ thuộc file ngoài)
            SetupToolStripIcons();

            // Cấu hình DataGridView bằng code chuẩn xác
            ConfigureDataGridView();

            // Tạo thư mục mẫu và nạp dữ liệu ban đầu
            PrepareSampleDirectoriesAndImages();
            SeedInitialData();

            // Thiết lập BindingSource kết nối với BindingList
            _bindingSource.DataSource = _bookList;
            dgvBooks.DataSource = _bindingSource;

            // Đăng ký các sự kiện tương tác
            RegisterEvents();

            // Đồng bộ trạng thái hiển thị ban đầu
            UpdateStatusStrip();
            if (_bookList.Count > 0)
            {
                _bindingSource.Position = 0;
                DisplayBookToControls(_bookList[0]);
            }
            else
            {
                BtnReset_Click(this, EventArgs.Empty);
            }

            lblClock.Text = $"Thời gian hiện tại: {DateTime.Now:dd/MM/yyyy HH:mm:ss}";
        }

        private void PopulateCategoriesAndPublishers()
        {
            // Danh mục thể loại sách
            string[] categories = new[]
            {
                "Công nghệ thông tin",
                "Kinh tế & Quản trị",
                "Kỹ năng sống",
                "Văn học & Nghệ thuật",
                "Khoa học tự nhiên",
                "Ngoại ngữ & Từ điển",
                "Tâm lý giáo dục"
            };

            cboCategory.Items.Clear();
            cboCategory.Items.AddRange(categories);
            cboCategory.SelectedIndex = 0;

            // Bộ lọc thể loại
            cboFilterCat.Items.Clear();
            cboFilterCat.Items.Add("-- Tất cả thể loại --");
            cboFilterCat.Items.AddRange(categories);
            cboFilterCat.SelectedIndex = 0;

            // Danh sách nhà xuất bản
            string[] publishers = new[]
            {
                "NXB Trẻ",
                "NXB Kim Đồng",
                "NXB Giáo Dục",
                "NXB Tổng Hợp TP.HCM",
                "NXB Lao Động",
                "NXB Bách Khoa Hà Nội",
                "NXB Thế Giới"
            };

            cboPublisher.Items.Clear();
            cboPublisher.Items.AddRange(publishers);
            cboPublisher.SelectedIndex = 0;

            // Năm xuất bản
            numPublishYear.Minimum = 1900;
            numPublishYear.Maximum = 2100;
            numPublishYear.Value = DateTime.Today.Year;
        }

        private void ConfigureDataGridView()
        {
            dgvBooks.AutoGenerateColumns = false;
            dgvBooks.Columns.Clear();
            dgvBooks.RowHeadersVisible = true;
            dgvBooks.RowHeadersWidth = 35;
            dgvBooks.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvBooks.MultiSelect = false;
            dgvBooks.ReadOnly = true;
            dgvBooks.AllowUserToAddRows = false;
            dgvBooks.AllowUserToDeleteRows = false;
            dgvBooks.AllowUserToResizeRows = false;
            dgvBooks.RowTemplate.Height = 30;
            dgvBooks.EnableHeadersVisualStyles = false;

            // Định dạng tiêu đề cột bảng
            dgvBooks.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(24, 76, 120);
            dgvBooks.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
            dgvBooks.ColumnHeadersDefaultCellStyle.Font = new Font("Segoe UI", 9.5F, FontStyle.Bold);
            dgvBooks.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgvBooks.ColumnHeadersHeight = 36;

            // Màu xen kẽ dòng (Zebra striping)
            dgvBooks.RowsDefaultCellStyle.BackColor = Color.White;
            dgvBooks.RowsDefaultCellStyle.ForeColor = Color.FromArgb(15, 23, 42);
            dgvBooks.RowsDefaultCellStyle.SelectionBackColor = Color.FromArgb(30, 64, 175);
            dgvBooks.RowsDefaultCellStyle.SelectionForeColor = Color.White;
            dgvBooks.AlternatingRowsDefaultCellStyle.BackColor = Color.FromArgb(248, 250, 252);
            dgvBooks.GridColor = Color.FromArgb(226, 232, 240);

            // Cột 1: Mã sách
            dgvBooks.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "colBookId",
                HeaderText = "Mã sách",
                DataPropertyName = nameof(BookModel.BookId),
                Width = 95,
                DefaultCellStyle = new DataGridViewCellStyle
                {
                    Alignment = DataGridViewContentAlignment.MiddleCenter,
                    Font = new Font("Segoe UI", 9.25F, FontStyle.Bold)
                }
            });

            // Cột 2: Tên sách
            dgvBooks.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "colTitle",
                HeaderText = "Tên tài liệu / Sách",
                DataPropertyName = nameof(BookModel.Title),
                Width = 230,
                DefaultCellStyle = new DataGridViewCellStyle
                {
                    Alignment = DataGridViewContentAlignment.MiddleLeft
                }
            });

            // Cột 3: Tác giả
            dgvBooks.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "colAuthor",
                HeaderText = "Tác giả",
                DataPropertyName = nameof(BookModel.Author),
                Width = 145,
                DefaultCellStyle = new DataGridViewCellStyle
                {
                    Alignment = DataGridViewContentAlignment.MiddleLeft
                }
            });

            // Cột 4: Thể loại
            dgvBooks.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "colCategory",
                HeaderText = "Thể loại",
                DataPropertyName = nameof(BookModel.Category),
                Width = 135,
                DefaultCellStyle = new DataGridViewCellStyle
                {
                    Alignment = DataGridViewContentAlignment.MiddleLeft
                }
            });

            // Cột 5: Nhà xuất bản
            dgvBooks.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "colPublisher",
                HeaderText = "Nhà xuất bản",
                DataPropertyName = nameof(BookModel.Publisher),
                Width = 120,
                DefaultCellStyle = new DataGridViewCellStyle
                {
                    Alignment = DataGridViewContentAlignment.MiddleLeft
                }
            });

            // Cột 6: Năm xuất bản
            dgvBooks.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "colPublishYear",
                HeaderText = "Năm XB",
                DataPropertyName = nameof(BookModel.PublishYear),
                Width = 75,
                DefaultCellStyle = new DataGridViewCellStyle
                {
                    Alignment = DataGridViewContentAlignment.MiddleCenter
                }
            });

            // Cột 7: Đơn giá
            dgvBooks.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "colPrice",
                HeaderText = "Đơn giá",
                DataPropertyName = nameof(BookModel.Price),
                Width = 110,
                DefaultCellStyle = new DataGridViewCellStyle
                {
                    Alignment = DataGridViewContentAlignment.MiddleRight,
                    Format = "#,##0 VNĐ"
                }
            });

            // Cột 8: Số lượng
            dgvBooks.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "colQuantity",
                HeaderText = "Số lượng",
                DataPropertyName = nameof(BookModel.Quantity),
                Width = 85,
                DefaultCellStyle = new DataGridViewCellStyle
                {
                    Alignment = DataGridViewContentAlignment.MiddleCenter,
                    Format = "#,##0"
                }
            });

            // Cột 9: Thành tiền
            dgvBooks.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "colTotalPrice",
                HeaderText = "Thành tiền",
                DataPropertyName = nameof(BookModel.TotalPrice),
                Width = 125,
                DefaultCellStyle = new DataGridViewCellStyle
                {
                    Alignment = DataGridViewContentAlignment.MiddleRight,
                    Font = new Font("Segoe UI", 9.25F, FontStyle.Bold),
                    ForeColor = Color.FromArgb(180, 30, 30),
                    Format = "#,##0 VNĐ"
                }
            });

            // Cột 10: Tên file ảnh (theo yêu cầu: chỉ lưu tên file ảnh hoặc đường dẫn ngắn)
            dgvBooks.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "colCoverFileName",
                HeaderText = "Tập tin ảnh bìa",
                DataPropertyName = nameof(BookModel.CoverFileName),
                Width = 140,
                DefaultCellStyle = new DataGridViewCellStyle
                {
                    Alignment = DataGridViewContentAlignment.MiddleLeft,
                    ForeColor = Color.FromArgb(71, 85, 105)
                }
            });
        }

        private void RegisterEvents()
        {
            // Đồng bộ khi chọn dòng DataGridView
            dgvBooks.SelectionChanged += DgvBooks_SelectionChanged;

            // Các nút thao tác dữ liệu
            btnAdd.Click += BtnAdd_Click;
            btnEdit.Click += BtnEdit_Click;
            btnDelete.Click += BtnDelete_Click;
            btnReset.Click += BtnReset_Click;
            btnExportCsv.Click += (s, e) => ExportToCsvFile();
            btnImportCsv.Click += (s, e) => ImportFromCsvFile();

            // MenuStrip items
            mnuAdd.Click += BtnAdd_Click;
            mnuUpdate.Click += BtnEdit_Click;
            mnuDelete.Click += BtnDelete_Click;
            mnuRefresh.Click += BtnReset_Click;
            mnuSearch.Click += (s, e) => txtSearchKeyword.Focus();
            mnuOpenCsv.Click += (s, e) => ImportFromCsvFile();
            mnuSaveCsv.Click += (s, e) => ExportToCsvFile();
            mnuExportReport.Click += (s, e) => ExportToCsvFile();
            mnuExit.Click += (s, e) => Close();
            mnuAbout.Click += MnuAbout_Click;

            // ToolStrip items
            btnTsAdd.Click += BtnAdd_Click;
            btnTsEdit.Click += BtnEdit_Click;
            btnTsDelete.Click += BtnDelete_Click;
            btnTsRefresh.Click += BtnReset_Click;
            btnTsOpen.Click += (s, e) => ImportFromCsvFile();
            btnTsSave.Click += (s, e) => ExportToCsvFile();
            btnTsUploadCover.Click += BtnBrowseImage_Click;
            btnTsSearch.Click += (s, e) => ApplySearchFilter(txtTsKeyword.Text);
            btnTsClearSearch.Click += (s, e) => { txtTsKeyword.Clear(); ApplySearchFilter(string.Empty); };
            txtTsKeyword.KeyDown += (s, e) => { if (e.KeyCode == Keys.Enter) ApplySearchFilter(txtTsKeyword.Text); };

            // Thao tác ảnh bìa
            btnBrowseImage.Click += BtnBrowseImage_Click;
            btnRemoveImage.Click += BtnRemoveImage_Click;
            picBookCover.DoubleClick += BtnBrowseImage_Click;

            // Tìm kiếm và lọc
            btnDoSearch.Click += (s, e) => ApplySearchFilter(txtSearchKeyword.Text);
            btnResetFilter.Click += BtnResetFilter_Click;
            txtSearchKeyword.KeyDown += (s, e) => { if (e.KeyCode == Keys.Enter) ApplySearchFilter(txtSearchKeyword.Text); };
            cboFilterCat.SelectedIndexChanged += (s, e) => ApplySearchFilter(txtSearchKeyword.Text);

            // Timer đồng hồ
            clockTimer.Tick += (s, e) => lblClock.Text = $"Thời gian hiện tại: {DateTime.Now:dd/MM/yyyy HH:mm:ss}";

            // Tự động xóa ErrorProvider khi người dùng sửa đúng
            txtBookId.TextChanged += (s, e) => { if (!string.IsNullOrWhiteSpace(txtBookId.Text)) errorProvider1.SetError(txtBookId, string.Empty); };
            txtTitle.TextChanged += (s, e) => { if (!string.IsNullOrWhiteSpace(txtTitle.Text)) errorProvider1.SetError(txtTitle, string.Empty); };
            txtAuthor.TextChanged += (s, e) => { if (!string.IsNullOrWhiteSpace(txtAuthor.Text)) errorProvider1.SetError(txtAuthor, string.Empty); };
            txtPrice.TextChanged += (s, e) =>
            {
                string clean = txtPrice.Text.Trim().Replace(",", "").Replace(".", "");
                if (decimal.TryParse(clean, out decimal val) && val >= 0)
                {
                    errorProvider1.SetError(txtPrice, string.Empty);
                }
            };
        }

        #endregion

        #region Xử lý Ảnh Bìa Sách (OpenFileDialog & GDI+)

        /// <summary>
        /// Yêu cầu 1: Thao tác Ảnh bìa (OpenFileDialog): Khi bấm [Tải ảnh bìa], hiển thị hộp thoại
        /// chọn file ảnh (*.png, *.jpg). Nạp ảnh lên PictureBox và lưu đường dẫn file vào đối tượng sách.
        /// </summary>
        private void BtnBrowseImage_Click(object? sender, EventArgs e)
        {
            using (var ofd = new OpenFileDialog())
            {
                ofd.Title = "Chọn ảnh bìa sách (OpenFileDialog)";
                ofd.Filter = "Tập tin hình ảnh (*.png;*.jpg;*.jpeg;*.bmp;*.webp)|*.png;*.jpg;*.jpeg;*.bmp;*.webp|Tất cả tập tin (*.*)|*.*";
                ofd.FilterIndex = 1;
                ofd.InitialDirectory = Directory.Exists(_sampleCoversDir) ? _sampleCoversDir : Environment.GetFolderPath(Environment.SpecialFolder.MyPictures);

                if (ofd.ShowDialog(this) == DialogResult.OK)
                {
                    LoadAndSetCoverImage(ofd.FileName);
                    lblStatusMessage.Text = $"Đã tải ảnh bìa: {Path.GetFileName(ofd.FileName)}";
                }
            }
        }

        private void BtnRemoveImage_Click(object? sender, EventArgs e)
        {
            _currentCoverFullPath = string.Empty;
            txtCoverPath.Text = string.Empty;
            SetCoverPlaceholder();
            lblStatusMessage.Text = "Đã bỏ ảnh bìa của sách.";
        }

        /// <summary>
        /// Đọc ảnh an toàn qua MemoryStream để không bao giờ khóa file trên ổ đĩa.
        /// </summary>
        private void LoadAndSetCoverImage(string filePath)
        {
            if (string.IsNullOrWhiteSpace(filePath) || !File.Exists(filePath))
            {
                // Thử tìm trong thư mục Covers nếu là tên file ngắn
                string fallbackPath = Path.Combine(_sampleCoversDir, Path.GetFileName(filePath));
                if (File.Exists(fallbackPath))
                {
                    filePath = fallbackPath;
                }
                else
                {
                    _currentCoverFullPath = string.Empty;
                    txtCoverPath.Text = string.Empty;
                    SetCoverPlaceholder();
                    return;
                }
            }

            try
            {
                byte[] imageBytes = File.ReadAllBytes(filePath);
                using (var ms = new MemoryStream(imageBytes))
                {
                    Image original = Image.FromStream(ms);
                    Bitmap newBmp = new Bitmap(original);

                    picBookCover.Image?.Dispose();
                    picBookCover.Image = newBmp;
                }

                _currentCoverFullPath = filePath;
                txtCoverPath.Text = Path.GetFileName(filePath);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Không thể nạp file hình ảnh:\n{ex.Message}", "Lỗi ảnh", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                SetCoverPlaceholder();
            }
        }

        /// <summary>
        /// Vẽ hình ảnh placeholder trực quan khi chưa có ảnh bìa
        /// </summary>
        private void SetCoverPlaceholder()
        {
            picBookCover.Image?.Dispose();
            Bitmap bmp = new Bitmap(135, 168);
            using (Graphics g = Graphics.FromImage(bmp))
            {
                g.SmoothingMode = SmoothingMode.AntiAlias;
                g.Clear(Color.FromArgb(248, 250, 252));

                // Viền khung sách
                using (Pen borderPen = new Pen(Color.FromArgb(203, 213, 225), 1.5f))
                {
                    borderPen.DashStyle = DashStyle.Dash;
                    g.DrawRectangle(borderPen, 6, 6, 122, 155);
                }

                // Biểu tượng sách
                using (Brush iconBrush = new SolidBrush(Color.FromArgb(148, 163, 184)))
                {
                    g.FillRectangle(iconBrush, 40, 45, 55, 45);
                    using (Pen spinePen = new Pen(Color.White, 2f))
                    {
                        g.DrawLine(spinePen, 67, 45, 67, 90);
                    }
                }

                // Chữ thông báo
                using (Font textFont = new Font("Segoe UI", 8.5F, FontStyle.Regular))
                using (Brush textBrush = new SolidBrush(Color.FromArgb(100, 116, 139)))
                using (StringFormat sf = new StringFormat { Alignment = StringAlignment.Center, LineAlignment = StringAlignment.Center })
                {
                    g.DrawString("Chưa có ảnh bìa\n[Nhấn Tải ảnh]", textFont, textBrush, new RectangleF(10, 100, 115, 45), sf);
                }
            }

            picBookCover.Image = bmp;
        }

        #endregion

        #region Yêu cầu 2: Xuất / Nhập Dữ liệu CSV (SaveFileDialog / OpenFileDialog)

        /// <summary>
        /// Yêu cầu 2a: Xuất dữ liệu: Bấm Lưu file CSV, mở SaveFileDialog cho người dùng chọn
        /// nơi lưu file .csv. Duyệt danh sách sách và ghi dữ liệu phân cách bằng dấu phẩy.
        /// </summary>
        private void ExportToCsvFile()
        {
            if (_bookList.Count == 0)
            {
                MessageBox.Show("Danh sách tài liệu sách hiện tại đang trống. Không có dữ liệu để xuất báo cáo!",
                                "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            using (var sfd = new SaveFileDialog())
            {
                sfd.Title = "Lưu file báo cáo tài liệu sách (SaveFileDialog)";
                sfd.Filter = "Tập tin CSV (*.csv)|*.csv|Tập tin Text (*.txt)|*.txt|Tất cả tập tin (*.*)|*.*";
                sfd.FilterIndex = 1;
                sfd.FileName = $"BaoCao_NhaSach_{DateTime.Now:yyyyMMdd_HHmmss}.csv";
                sfd.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);

                if (sfd.ShowDialog(this) == DialogResult.OK)
                {
                    try
                    {
                        // Ghi file với UTF-8 có BOM (Encoding.UTF8) để Excel mở tiếng Việt không bị lỗi font
                        using (var sw = new StreamWriter(sfd.FileName, false, new UTF8Encoding(true)))
                        {
                            // 1. Dòng tiêu đề cột
                            sw.WriteLine("Mã sách,Tên tài liệu,Tác giả,Thể loại,Nhà xuất bản,Năm XB,Đơn giá,Số lượng,Thành tiền,Ảnh bìa");

                            // 2. Dữ liệu từng cuốn sách
                            foreach (var book in _bookList)
                            {
                                string row = string.Format(CultureInfo.InvariantCulture,
                                    "{0},{1},{2},{3},{4},{5},{6},{7},{8},{9}",
                                    EscapeCsv(book.BookId),
                                    EscapeCsv(book.Title),
                                    EscapeCsv(book.Author),
                                    EscapeCsv(book.Category),
                                    EscapeCsv(book.Publisher),
                                    book.PublishYear,
                                    book.Price,
                                    book.Quantity,
                                    book.TotalPrice,
                                    EscapeCsv(book.CoverFileName));
                                sw.WriteLine(row);
                            }

                            // 3. Dòng tổng kết báo cáo nhà sách
                            int sumQty = _bookList.Sum(b => b.Quantity);
                            decimal sumValue = _bookList.Sum(b => b.TotalPrice);
                            sw.WriteLine(string.Format(CultureInfo.InvariantCulture,
                                "TỔNG CỘNG ({0} đầu sách),,,,,,0,{1},{2},",
                                _bookList.Count, sumQty, sumValue));
                        }

                        lblStatusMessage.Text = $"Đã xuất thành công {_bookList.Count} đầu sách ra tệp: {Path.GetFileName(sfd.FileName)}";

                        var openConfirm = MessageBox.Show(
                            $"Xuất dữ liệu ra file CSV thành công!\n\nĐường dẫn: {sfd.FileName}\n\nBạn có muốn mở tập tin vừa xuất không?",
                            "Xuất CSV thành công",
                            MessageBoxButtons.YesNo,
                            MessageBoxIcon.Information);

                        if (openConfirm == DialogResult.Yes)
                        {
                            Process.Start(new ProcessStartInfo(sfd.FileName) { UseShellExecute = true });
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show($"Lỗi khi ghi tệp CSV:\n{ex.Message}", "Lỗi xuất file", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }

        /// <summary>
        /// Yêu cầu 2b: Mở dữ liệu: Bấm Mở file CSV, mở OpenFileDialog chọn file .csv.
        /// Tiến hành đọc từng dòng, parse dữ liệu thành danh sách BookModel và nạp vào BindingList<T>.
        /// </summary>
        private void ImportFromCsvFile()
        {
            using (var ofd = new OpenFileDialog())
            {
                ofd.Title = "Mở tệp CSV dữ liệu sách (OpenFileDialog)";
                ofd.Filter = "Tập tin CSV (*.csv)|*.csv|Tập tin Text (*.txt)|*.txt|Tất cả tập tin (*.*)|*.*";
                ofd.FilterIndex = 1;
                ofd.InitialDirectory = Directory.Exists(_sampleDataDir) ? _sampleDataDir : Environment.GetFolderPath(Environment.SpecialFolder.Desktop);

                if (ofd.ShowDialog(this) == DialogResult.OK)
                {
                    try
                    {
                        var parsedBooks = new List<BookModel>();
                        string[] lines = File.ReadAllLines(ofd.FileName, Encoding.UTF8);

                        if (lines.Length == 0)
                        {
                            MessageBox.Show("Tập tin CSV rỗng!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            return;
                        }

                        int startLine = 0;
                        // Kiểm tra nếu dòng 1 là Header tiêu đề
                        if (lines[0].Contains("Mã") || lines[0].Contains("BookId") || lines[0].Contains("Tên"))
                        {
                            startLine = 1;
                        }

                        for (int i = startLine; i < lines.Length; i++)
                        {
                            string line = lines[i].Trim();
                            if (string.IsNullOrWhiteSpace(line)) continue;

                            // Bỏ qua dòng tổng cộng nếu có
                            if (line.StartsWith("TỔNG CỘNG", StringComparison.OrdinalIgnoreCase) ||
                                line.StartsWith("Tổng cộng", StringComparison.OrdinalIgnoreCase))
                            {
                                continue;
                            }

                            List<string> cols = ParseCsvRow(line);
                            if (cols.Count >= 7)
                            {
                                string bookId = cols[0].Trim();
                                string title = cols.Count > 1 ? cols[1].Trim() : string.Empty;
                                string author = cols.Count > 2 ? cols[2].Trim() : string.Empty;
                                string category = cols.Count > 3 ? cols[3].Trim() : "Công nghệ thông tin";
                                string publisher = cols.Count > 4 ? cols[4].Trim() : "NXB Trẻ";

                                int.TryParse(cols.Count > 5 ? cols[5].Trim() : "", out int publishYear);
                                if (publishYear < 1900 || publishYear > 2100) publishYear = DateTime.Today.Year;

                                decimal.TryParse(cols.Count > 6 ? cols[6].Trim() : "0", NumberStyles.Any, CultureInfo.InvariantCulture, out decimal price);
                                if (price == 0 && cols.Count > 6)
                                {
                                    decimal.TryParse(cols[6].Trim().Replace(".", "").Replace(",", ""), out price);
                                }

                                int quantity = 1;
                                if (cols.Count > 7)
                                {
                                    int.TryParse(cols[7].Trim(), out quantity);
                                }

                                string coverPath = cols.Count > 9 ? cols[9].Trim() : (cols.Count > 8 ? cols[8].Trim() : "");

                                // Nếu coverPath chỉ là tên file ảnh, liên kết với thư mục ảnh mẫu nếu tồn tại
                                if (!string.IsNullOrEmpty(coverPath) && !File.Exists(coverPath))
                                {
                                    string fullCandidate = Path.Combine(_sampleCoversDir, coverPath);
                                    if (File.Exists(fullCandidate)) coverPath = fullCandidate;
                                }

                                if (!string.IsNullOrWhiteSpace(bookId) && !string.IsNullOrWhiteSpace(title))
                                {
                                    parsedBooks.Add(new BookModel(bookId, title, author, category, publisher, publishYear, price, quantity, coverPath));
                                }
                            }
                        }

                        if (parsedBooks.Count == 0)
                        {
                            MessageBox.Show("Không đọc được dữ liệu sách hợp lệ nào từ tệp CSV đã chọn!",
                                            "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            return;
                        }

                        // Hỏi người dùng chế độ nhập: Thay thế hay Nạp nối tiếp
                        bool replaceExisting = true;
                        if (_bookList.Count > 0)
                        {
                            var confirmResult = MessageBox.Show(
                                $"Tìm thấy {parsedBooks.Count} sách trong file CSV.\n\n" +
                                "• Chọn [Yes] để THAY THẾ toàn bộ danh sách hiện tại.\n" +
                                "• Chọn [No] để NẠP THÊM (NỐI TIẾP) vào danh sách cũ.",
                                "Tùy chọn nạp dữ liệu",
                                MessageBoxButtons.YesNoCancel,
                                MessageBoxIcon.Question);

                            if (confirmResult == DialogResult.Cancel) return;
                            replaceExisting = (confirmResult == DialogResult.Yes);
                        }

                        if (replaceExisting)
                        {
                            _bookList.Clear();
                        }

                        int importedCount = 0;
                        foreach (var b in parsedBooks)
                        {
                            // Tránh trùng mã sách khi nạp thêm
                            if (_bookList.Any(x => x.BookId.Equals(b.BookId, StringComparison.OrdinalIgnoreCase)))
                            {
                                b.BookId = GenerateNextBookId();
                            }
                            _bookList.Add(b);
                            importedCount++;
                        }

                        UpdateStatusStrip();
                        if (_bookList.Count > 0)
                        {
                            _bindingSource.Position = 0;
                            DisplayBookToControls(_bookList[0]);
                        }

                        lblStatusMessage.Text = $"Nhập thành công {importedCount} sách từ: {Path.GetFileName(ofd.FileName)}";
                        MessageBox.Show($"Đã nạp thành công {importedCount} đầu sách vào hệ thống từ tệp CSV!",
                                        "Nhập dữ liệu thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show($"Lỗi khi đọc file CSV:\n{ex.Message}", "Lỗi mở file", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }

        /// <summary>
        /// Xử lý escape ký tự theo chuẩn CSV RFC 4180
        /// </summary>
        private static string EscapeCsv(string text)
        {
            if (string.IsNullOrEmpty(text)) return string.Empty;
            if (text.Contains(",") || text.Contains("\"") || text.Contains("\n") || text.Contains("\r"))
            {
                return "\"" + text.Replace("\"", "\"\"") + "\"";
            }
            return text;
        }

        /// <summary>
        /// Phân tích dòng CSV chuẩn, hỗ trợ các trường bọc trong dấu nháy kép có chứa dấu phẩy
        /// </summary>
        private static List<string> ParseCsvRow(string line)
        {
            var result = new List<string>();
            var current = new StringBuilder();
            bool inQuotes = false;

            for (int i = 0; i < line.Length; i++)
            {
                char c = line[i];

                if (c == '\"')
                {
                    if (inQuotes && i + 1 < line.Length && line[i + 1] == '\"')
                    {
                        current.Append('\"');
                        i++; // Nhảy qua dấu nháy kép escape
                    }
                    else
                    {
                        inQuotes = !inQuotes;
                    }
                }
                else if (c == ',' && !inQuotes)
                {
                    result.Add(current.ToString());
                    current.Clear();
                }
                else
                {
                    current.Append(c);
                }
            }

            result.Add(current.ToString());
            return result;
        }

        #endregion

        #region Yêu cầu 3: Tự động Cập nhật StatusStrip

        /// <summary>
        /// Yêu cầu 3: Mỗi khi danh sách có biến động (Thêm/Sửa/Xóa/Import),
        /// tự động tính toán lại và cập nhật tổng số lượng sách và tổng giá trị kho lên StatusStrip.
        /// </summary>
        private void UpdateStatusStrip()
        {
            int totalTitles = _bookList.Count;
            int totalQuantity = _bookList.Sum(b => b.Quantity);
            decimal totalValue = _bookList.Sum(b => b.TotalPrice);

            lblTotalTitles.Text = $"Tổng số đầu sách: {totalTitles}";
            lblTotalQuantity.Text = $"Tổng số lượng: {totalQuantity:N0} cuốn";
            lblTotalValue.Text = $"Tổng giá trị tiền sách trong kho: {totalValue:N0} VNĐ";
        }

        #endregion

        #region Thao tác Dữ liệu CRUD (Thêm, Sửa, Xóa, Làm mới)

        private void BtnAdd_Click(object? sender, EventArgs e)
        {
            if (!ValidateInputs(isAdding: true)) return;

            string feeClean = txtPrice.Text.Trim().Replace(",", "").Replace(".", "");
            decimal.TryParse(feeClean, out decimal price);

            var newBook = new BookModel(
                bookId: txtBookId.Text.Trim().ToUpper(),
                title: txtTitle.Text.Trim(),
                author: txtAuthor.Text.Trim(),
                category: cboCategory.SelectedItem?.ToString() ?? "Công nghệ thông tin",
                publisher: cboPublisher.SelectedItem?.ToString() ?? "NXB Trẻ",
                publishYear: (int)numPublishYear.Value,
                price: price,
                quantity: (int)numQuantity.Value,
                coverPath: _currentCoverFullPath
            );

            _bookList.Add(newBook);
            UpdateStatusStrip();

            _bindingSource.Position = _bookList.IndexOf(newBook);
            lblStatusMessage.Text = $"Đã thêm mới thành công sách [{newBook.BookId} - {newBook.Title}].";

            MessageBox.Show($"Thêm mới sách [{newBook.BookId} - {newBook.Title}] thành công!",
                            "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void BtnEdit_Click(object? sender, EventArgs e)
        {
            if (dgvBooks.CurrentRow == null || _bindingSource.Current is not BookModel selectedBook)
            {
                MessageBox.Show("Vui lòng chọn một cuốn sách trong bảng danh sách để cập nhật!",
                                "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (!ValidateInputs(isAdding: false)) return;

            string feeClean = txtPrice.Text.Trim().Replace(",", "").Replace(".", "");
            decimal.TryParse(feeClean, out decimal price);

            selectedBook.Title = txtTitle.Text.Trim();
            selectedBook.Author = txtAuthor.Text.Trim();
            selectedBook.Category = cboCategory.SelectedItem?.ToString() ?? selectedBook.Category;
            selectedBook.Publisher = cboPublisher.SelectedItem?.ToString() ?? selectedBook.Publisher;
            selectedBook.PublishYear = (int)numPublishYear.Value;
            selectedBook.Price = price;
            selectedBook.Quantity = (int)numQuantity.Value;
            selectedBook.CoverPath = _currentCoverFullPath;

            _bindingSource.ResetBindings(false);
            dgvBooks.Refresh();
            UpdateStatusStrip();

            lblStatusMessage.Text = $"Đã cập nhật thông tin sách [{selectedBook.BookId}].";
            MessageBox.Show($"Cập nhật thông tin sách [{selectedBook.BookId} - {selectedBook.Title}] thành công!",
                            "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void BtnDelete_Click(object? sender, EventArgs e)
        {
            if (dgvBooks.CurrentRow == null || _bindingSource.Current is not BookModel selectedBook)
            {
                MessageBox.Show("Vui lòng chọn một cuốn sách cần xóa trong bảng danh sách!",
                                "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            var confirmResult = MessageBox.Show(
                $"Bạn có chắc chắn muốn xóa tài liệu sách sau khỏi hệ thống?\n\n" +
                $"• Mã sách: {selectedBook.BookId}\n" +
                $"• Tên sách: {selectedBook.Title}\n" +
                $"• Tác giả: {selectedBook.Author}\n" +
                $"• Giá trị tồn: {selectedBook.TotalPrice:N0} VNĐ",
                "Xác nhận xóa tài liệu",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question);

            if (confirmResult == DialogResult.Yes)
            {
                string deletedId = selectedBook.BookId;
                _bookList.Remove(selectedBook);
                UpdateStatusStrip();

                if (_bookList.Count == 0)
                {
                    BtnReset_Click(this, EventArgs.Empty);
                }
                else
                {
                    DgvBooks_SelectionChanged(this, EventArgs.Empty);
                }

                lblStatusMessage.Text = $"Đã xóa thành công sách [{deletedId}].";
                MessageBox.Show($"Đã xóa sách [{deletedId}] thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void BtnReset_Click(object? sender, EventArgs e)
        {
            _isResetting = true;
            try
            {
                errorProvider1.Clear();
                txtBookId.Text = GenerateNextBookId();
                txtBookId.ReadOnly = false;
                txtTitle.Clear();
                txtAuthor.Clear();
                cboCategory.SelectedIndex = 0;
                cboPublisher.SelectedIndex = 0;
                numPublishYear.Value = DateTime.Today.Year;
                txtPrice.Text = "0";
                numQuantity.Value = 10;
                txtCoverPath.Clear();
                _currentCoverFullPath = string.Empty;
                SetCoverPlaceholder();

                lblStatusMessage.Text = "Đã làm mới form nhập liệu. Sẵn sàng thêm mới sách.";
                txtTitle.Focus();
            }
            finally
            {
                _isResetting = false;
            }
        }

        private void DgvBooks_SelectionChanged(object? sender, EventArgs e)
        {
            if (_isResetting) return;

            if (dgvBooks.CurrentRow != null && _bindingSource.Current is BookModel currentBook)
            {
                DisplayBookToControls(currentBook);
            }
        }

        private void DisplayBookToControls(BookModel book)
        {
            errorProvider1.Clear();
            txtBookId.Text = book.BookId;
            txtBookId.ReadOnly = true; // Khóa mã sách khi đang xem dòng
            txtTitle.Text = book.Title;
            txtAuthor.Text = book.Author;

            int catIndex = cboCategory.FindStringExact(book.Category);
            cboCategory.SelectedIndex = catIndex >= 0 ? catIndex : 0;

            int pubIndex = cboPublisher.FindStringExact(book.Publisher);
            cboPublisher.SelectedIndex = pubIndex >= 0 ? pubIndex : 0;

            numPublishYear.Value = Math.Clamp(book.PublishYear, numPublishYear.Minimum, numPublishYear.Maximum);
            txtPrice.Text = book.Price.ToString("N0");
            numQuantity.Value = Math.Clamp(book.Quantity, numQuantity.Minimum, numQuantity.Maximum);

            _currentCoverFullPath = book.CoverPath;
            txtCoverPath.Text = book.CoverFileName;

            LoadAndSetCoverImage(book.CoverPath);
            lblStatusMessage.Text = $"Đang xem chi tiết sách: [{book.BookId} - {book.Title}]";
        }

        private bool ValidateInputs(bool isAdding)
        {
            bool isValid = true;
            errorProvider1.Clear();

            // 1. Kiểm tra Mã sách
            string id = txtBookId.Text.Trim();
            if (string.IsNullOrWhiteSpace(id))
            {
                errorProvider1.SetError(txtBookId, "Mã sách không được để trống!");
                isValid = false;
            }
            else if (isAdding && _bookList.Any(b => b.BookId.Equals(id, StringComparison.OrdinalIgnoreCase)))
            {
                errorProvider1.SetError(txtBookId, $"Mã sách '{id}' đã tồn tại! Vui lòng chọn mã khác.");
                isValid = false;
            }

            // 2. Kiểm tra Tên sách
            if (string.IsNullOrWhiteSpace(txtTitle.Text))
            {
                errorProvider1.SetError(txtTitle, "Tên tài liệu / Sách không được để trống!");
                isValid = false;
            }

            // 3. Kiểm tra Tác giả
            if (string.IsNullOrWhiteSpace(txtAuthor.Text))
            {
                errorProvider1.SetError(txtAuthor, "Tên tác giả không được để trống!");
                isValid = false;
            }

            // 4. Kiểm tra Đơn giá
            string feeClean = txtPrice.Text.Trim().Replace(",", "").Replace(".", "");
            if (string.IsNullOrWhiteSpace(feeClean) || !decimal.TryParse(feeClean, out decimal price) || price < 0)
            {
                errorProvider1.SetError(txtPrice, "Đơn giá sách phải là số dương hợp lệ (>= 0 VNĐ)!");
                isValid = false;
            }

            // 5. Kiểm tra Số lượng
            if (numQuantity.Value < 0)
            {
                errorProvider1.SetError(numQuantity, "Số lượng sách tồn kho không được âm!");
                isValid = false;
            }

            return isValid;
        }

        private string GenerateNextBookId()
        {
            int maxNum = 0;
            foreach (var b in _bookList)
            {
                if (b.BookId.StartsWith("MS", StringComparison.OrdinalIgnoreCase))
                {
                    string numPart = b.BookId.Substring(2);
                    if (int.TryParse(numPart, out int n) && n > maxNum)
                    {
                        maxNum = n;
                    }
                }
            }
            return $"MS{(maxNum + 1):D3}";
        }

        #endregion

        #region Tìm kiếm và Lọc dữ liệu

        private void ApplySearchFilter(string keyword)
        {
            keyword = keyword.Trim().ToLower();
            string selectedCat = cboFilterCat.SelectedIndex > 0 ? cboFilterCat.SelectedItem?.ToString() ?? "" : "";

            var filtered = _bookList.Where(b =>
            {
                bool matchKeyword = string.IsNullOrEmpty(keyword) ||
                                    b.BookId.ToLower().Contains(keyword) ||
                                    b.Title.ToLower().Contains(keyword) ||
                                    b.Author.ToLower().Contains(keyword) ||
                                    b.Publisher.ToLower().Contains(keyword);

                bool matchCategory = string.IsNullOrEmpty(selectedCat) ||
                                     b.Category.Equals(selectedCat, StringComparison.OrdinalIgnoreCase);

                return matchKeyword && matchCategory;
            }).ToList();

            _bindingSource.DataSource = new BindingList<BookModel>(filtered);
            dgvBooks.Refresh();

            lblStatusMessage.Text = $"Kết quả tìm kiếm: Tìm thấy {filtered.Count} cuốn sách phù hợp.";
            if (filtered.Count > 0)
            {
                DisplayBookToControls(filtered[0]);
            }
        }

        private void BtnResetFilter_Click(object? sender, EventArgs e)
        {
            txtSearchKeyword.Clear();
            txtTsKeyword.Clear();
            cboFilterCat.SelectedIndex = 0;
            _bindingSource.DataSource = _bookList;
            dgvBooks.Refresh();
            UpdateStatusStrip();
            lblStatusMessage.Text = "Đã hiển thị toàn bộ danh sách sách.";
            if (_bookList.Count > 0)
            {
                DisplayBookToControls(_bookList[0]);
            }
        }

        #endregion

        #region Dữ liệu mẫu & Chuẩn bị Thư mục

        private void PrepareSampleDirectoriesAndImages()
        {
            try
            {
                if (!Directory.Exists(_sampleDataDir)) Directory.CreateDirectory(_sampleDataDir);
                if (!Directory.Exists(_sampleCoversDir)) Directory.CreateDirectory(_sampleCoversDir);

                // Tạo một số ảnh bìa mẫu đẹp mắt bằng GDI+ lưu vào thư mục Covers
                CreateSampleCoverImage("csharp_prog.jpg", "Lập Trình C#\nNâng Cao", Color.FromArgb(24, 76, 120), Color.White);
                CreateSampleCoverImage("winforms_app.jpg", "Phát Triển\nWindows Forms", Color.FromArgb(16, 149, 106), Color.White);
                CreateSampleCoverImage("clean_code.jpg", "Nghệ Thuật\nClean Code", Color.FromArgb(180, 83, 9), Color.White);
                CreateSampleCoverImage("kinh_te.jpg", "Kinh Tế Học\nỨng Dụng", Color.FromArgb(109, 40, 217), Color.White);
                CreateSampleCoverImage("dac_nhan_tam.jpg", "Đắc Nhân Tâm\n& Kỹ Năng", Color.FromArgb(190, 24, 93), Color.White);

                // Tạo file CSV mẫu để người dùng có thể test tính năng Mở CSV ngay
                string sampleCsvPath = Path.Combine(_sampleDataDir, "DanhSachSach_Mau.csv");
                if (!File.Exists(sampleCsvPath))
                {
                    using (var sw = new StreamWriter(sampleCsvPath, false, new UTF8Encoding(true)))
                    {
                        sw.WriteLine("Mã sách,Tên tài liệu,Tác giả,Thể loại,Nhà xuất bản,Năm XB,Đơn giá,Số lượng,Thành tiền,Ảnh bìa");
                        sw.WriteLine("MS001,Lập Trình C# Toàn Tập & WinForms,Phạm Gia Bảo,Công nghệ thông tin,NXB Bách Khoa Hà Nội,2024,185000,45,8325000,csharp_prog.jpg");
                        sw.WriteLine("MS002,Phát Triển Ứng Dụng Desktop Hiện Đại,Nguyễn Văn An,Công nghệ thông tin,NXB Thông tin & Truyền thông,2023,160000,30,4800000,winforms_app.jpg");
                        sw.WriteLine("MS003,Nghệ Thuật Lập Trình Sạch (Clean Code),Robert C. Martin,Công nghệ thông tin,NXB Trẻ,2022,220000,25,5500000,clean_code.jpg");
                        sw.WriteLine("MS004,Kinh Tế Học Dành Cho Nhà Quản Trị,Trần Thị Bình,Kinh tế & Quản trị,NXB Tổng Hợp TP.HCM,2024,145000,50,7250000,kinh_te.jpg");
                        sw.WriteLine("MS005,Đắc Nhân Tâm - Nghệ Thuật Thu Phục Lòng Người,Dale Carnegie,Kỹ năng sống,NXB Lao Động,2023,98000,80,7840000,dac_nhan_tam.jpg");
                        sw.WriteLine("TỔNG CỘNG (5 đầu sách),,,,,,0,230,33715000,");
                    }
                }
            }
            catch
            {
                // Bỏ qua lỗi I/O nếu không có quyền ghi thư mục mẫu
            }
        }

        private void CreateSampleCoverImage(string fileName, string title, Color bgColor, Color textColor)
        {
            string filePath = Path.Combine(_sampleCoversDir, fileName);
            if (File.Exists(filePath)) return;

            using (Bitmap bmp = new Bitmap(200, 280))
            using (Graphics g = Graphics.FromImage(bmp))
            {
                g.SmoothingMode = SmoothingMode.AntiAlias;
                g.Clear(bgColor);

                // Khung viền mỹ thuật
                using (Pen borderPen = new Pen(Color.FromArgb(240, 240, 240), 3f))
                {
                    g.DrawRectangle(borderPen, 10, 10, 180, 260);
                }

                // Tiêu đề sách
                using (Font font = new Font("Segoe UI", 12F, FontStyle.Bold))
                using (Brush brush = new SolidBrush(textColor))
                using (StringFormat sf = new StringFormat { Alignment = StringAlignment.Center, LineAlignment = StringAlignment.Center })
                {
                    g.DrawString(title, font, brush, new RectangleF(15, 60, 170, 90), sf);
                }

                // Nhãn nhà sách
                using (Font subFont = new Font("Segoe UI", 8F, FontStyle.Italic))
                using (Brush subBrush = new SolidBrush(Color.FromArgb(220, 220, 220)))
                using (StringFormat sf = new StringFormat { Alignment = StringAlignment.Center, LineAlignment = StringAlignment.Center })
                {
                    g.DrawString("NHÀ SÁCH TRI THỨC\nPHIÊN BẢN ĐẶC BIỆT", subFont, subBrush, new RectangleF(15, 200, 170, 40), sf);
                }

                bmp.Save(filePath, System.Drawing.Imaging.ImageFormat.Jpeg);
            }
        }

        private void SeedInitialData()
        {
            _bookList.Clear();

            string cover1 = Path.Combine(_sampleCoversDir, "csharp_prog.jpg");
            string cover2 = Path.Combine(_sampleCoversDir, "winforms_app.jpg");
            string cover3 = Path.Combine(_sampleCoversDir, "clean_code.jpg");
            string cover4 = Path.Combine(_sampleCoversDir, "kinh_te.jpg");
            string cover5 = Path.Combine(_sampleCoversDir, "dac_nhan_tam.jpg");

            _bookList.Add(new BookModel("MS001", "Lập Trình C# Toàn Tập & WinForms", "Phạm Gia Bảo", "Công nghệ thông tin", "NXB Bách Khoa Hà Nội", 2024, 185000, 45, cover1));
            _bookList.Add(new BookModel("MS002", "Phát Triển Ứng Dụng Desktop Hiện Đại", "Nguyễn Văn An", "Công nghệ thông tin", "NXB Thông tin & Truyền thông", 2023, 160000, 30, cover2));
            _bookList.Add(new BookModel("MS003", "Nghệ Thuật Lập Trình Sạch (Clean Code)", "Robert C. Martin", "Công nghệ thông tin", "NXB Trẻ", 2022, 220000, 25, cover3));
            _bookList.Add(new BookModel("MS004", "Kinh Tế Học Dành Cho Nhà Quản Trị", "Trần Thị Bình", "Kinh tế & Quản trị", "NXB Tổng Hợp TP.HCM", 2024, 145000, 50, cover4));
            _bookList.Add(new BookModel("MS005", "Đắc Nhân Tâm - Nghệ Thuật Giao Tiếp", "Dale Carnegie", "Kỹ năng sống", "NXB Lao Động", 2023, 98000, 80, cover5));
        }

        #endregion

        #region Tạo Biểu Tượng Vector GDI+ Cho ToolStrip

        private void SetupToolStripIcons()
        {
            btnTsOpen.Image = CreateVectorIcon(IconType.Open);
            btnTsSave.Image = CreateVectorIcon(IconType.Save);
            btnTsAdd.Image = CreateVectorIcon(IconType.Add);
            btnTsEdit.Image = CreateVectorIcon(IconType.Edit);
            btnTsDelete.Image = CreateVectorIcon(IconType.Delete);
            btnTsRefresh.Image = CreateVectorIcon(IconType.Refresh);
            btnTsUploadCover.Image = CreateVectorIcon(IconType.Picture);

            mnuOpenCsv.Image = btnTsOpen.Image;
            mnuSaveCsv.Image = btnTsSave.Image;
            mnuExportReport.Image = btnTsSave.Image;
            mnuAdd.Image = btnTsAdd.Image;
            mnuUpdate.Image = btnTsEdit.Image;
            mnuDelete.Image = btnTsDelete.Image;
            mnuRefresh.Image = btnTsRefresh.Image;
        }

        private enum IconType
        {
            Open,
            Save,
            Add,
            Edit,
            Delete,
            Refresh,
            Picture
        }

        private static Bitmap CreateVectorIcon(IconType type)
        {
            Bitmap bmp = new Bitmap(18, 18);
            using (Graphics g = Graphics.FromImage(bmp))
            {
                g.SmoothingMode = SmoothingMode.AntiAlias;
                g.Clear(Color.Transparent);

                switch (type)
                {
                    case IconType.Open:
                        // Biểu tượng Folder mở
                        using (Brush fBrush = new SolidBrush(Color.FromArgb(234, 179, 8)))
                        {
                            g.FillRectangle(fBrush, 2, 5, 14, 10);
                        }
                        using (Brush tabBrush = new SolidBrush(Color.FromArgb(202, 138, 4)))
                        {
                            g.FillRectangle(tabBrush, 2, 2, 6, 4);
                        }
                        break;

                    case IconType.Save:
                        // Biểu tượng đĩa mềm Floppy
                        using (Brush sBrush = new SolidBrush(Color.FromArgb(37, 99, 235)))
                        {
                            g.FillRectangle(sBrush, 2, 2, 14, 14);
                        }
                        using (Brush wBrush = new SolidBrush(Color.White))
                        {
                            g.FillRectangle(wBrush, 4, 3, 10, 5);
                            g.FillRectangle(wBrush, 5, 10, 8, 6);
                        }
                        break;

                    case IconType.Add:
                        // Dấu cộng xanh lá
                        using (Pen p = new Pen(Color.FromArgb(22, 163, 74), 3f))
                        {
                            g.DrawLine(p, 9, 2, 9, 16);
                            g.DrawLine(p, 2, 9, 16, 9);
                        }
                        break;

                    case IconType.Edit:
                        // Biểu tượng cây bút chì
                        using (Pen p = new Pen(Color.FromArgb(37, 99, 235), 2.5f))
                        {
                            g.DrawLine(p, 3, 15, 15, 3);
                            g.DrawLine(p, 2, 16, 5, 16);
                            g.DrawLine(p, 2, 16, 2, 13);
                        }
                        break;

                    case IconType.Delete:
                        // Biểu tượng thùng rác / dấu X đỏ
                        using (Pen p = new Pen(Color.FromArgb(220, 38, 38), 3f))
                        {
                            g.DrawLine(p, 3, 3, 15, 15);
                            g.DrawLine(p, 15, 3, 3, 15);
                        }
                        break;

                    case IconType.Refresh:
                        // Mũi tên xoay tròn xanh
                        using (Pen p = new Pen(Color.FromArgb(71, 85, 105), 2f))
                        {
                            g.DrawArc(p, 2, 2, 14, 14, 45, 270);
                        }
                        using (Brush b = new SolidBrush(Color.FromArgb(71, 85, 105)))
                        {
                            Point[] arrow = new[] { new Point(14, 2), new Point(16, 8), new Point(10, 6) };
                            g.FillPolygon(b, arrow);
                        }
                        break;

                    case IconType.Picture:
                        // Biểu tượng hình ảnh
                        using (Brush bg = new SolidBrush(Color.FromArgb(14, 165, 233)))
                        {
                            g.FillRectangle(bg, 2, 2, 14, 14);
                        }
                        using (Brush sun = new SolidBrush(Color.Yellow))
                        {
                            g.FillEllipse(sun, 4, 4, 3, 3);
                        }
                        using (Brush mountain = new SolidBrush(Color.White))
                        {
                            Point[] pts = new[] { new Point(3, 15), new Point(8, 8), new Point(12, 12), new Point(15, 15) };
                            g.FillPolygon(mountain, pts);
                        }
                        break;
                }
            }
            return bmp;
        }

        #endregion

        #region Trợ giúp & Giới thiệu

        private void MnuAbout_Click(object? sender, EventArgs e)
        {
            MessageBox.Show(
                "HỆ THỐNG QUẢN LÝ TÀI LIỆU SÁCH & BÁO CÁO NHÀ SÁCH\n\n" +
                "• Bài tập kiểm tra 02: System Dialogs & File I/O\n" +
                "• Lập trình viên: Phạm Gia Bảo\n" +
                "• Nền tảng: .NET 10.0 Windows Forms (C#)\n\n" +
                "Tính năng chính:\n" +
                "- Khai thác OpenFileDialog tải ảnh bìa và nạp file CSV dữ liệu.\n" +
                "- Khai thác SaveFileDialog xuất báo cáo danh sách sách ra file CSV chuẩn UTF-8 (Excel tương thích 100%).\n" +
                "- Quản lý trạng thái trực quan qua MenuStrip, ToolStrip và StatusStrip tự động.",
                "Giới thiệu phần mềm",
                MessageBoxButtons.OK,
                MessageBoxIcon.Information);
        }

        #endregion
    }
}
