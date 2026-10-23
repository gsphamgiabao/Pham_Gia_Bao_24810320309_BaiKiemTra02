using System;
using System.ComponentModel;
using System.IO;

namespace BookStoreManagement
{
    /// <summary>
    /// Model đại diện cho một tài liệu / đầu sách trong kho nhà sách.
    /// Triển khai INotifyPropertyChanged để hỗ trợ Data Binding 2 chiều với DataGridView / BindingList.
    /// </summary>
    public class BookModel : INotifyPropertyChanged
    {
        private string _bookId = string.Empty;
        private string _title = string.Empty;
        private string _author = string.Empty;
        private string _category = string.Empty;
        private string _publisher = string.Empty;
        private int _publishYear = DateTime.Today.Year;
        private decimal _price = 0;
        private int _quantity = 1;
        private string _coverPath = string.Empty;

        public BookModel()
        {
        }

        public BookModel(string bookId, string title, string author, string category, 
                         string publisher, int publishYear, decimal price, int quantity, string coverPath = "")
        {
            _bookId = bookId;
            _title = title;
            _author = author;
            _category = category;
            _publisher = publisher;
            _publishYear = publishYear;
            _price = price;
            _quantity = quantity;
            _coverPath = coverPath;
        }

        /// <summary>
        /// Mã sách (Khóa chính, ví dụ: MS001, MS002)
        /// </summary>
        public string BookId
        {
            get => _bookId;
            set
            {
                if (_bookId != value)
                {
                    _bookId = value;
                    OnPropertyChanged(nameof(BookId));
                }
            }
        }

        /// <summary>
        /// Tên / Tiêu đề sách
        /// </summary>
        public string Title
        {
            get => _title;
            set
            {
                if (_title != value)
                {
                    _title = value;
                    OnPropertyChanged(nameof(Title));
                }
            }
        }

        /// <summary>
        /// Tác giả sách
        /// </summary>
        public string Author
        {
            get => _author;
            set
            {
                if (_author != value)
                {
                    _author = value;
                    OnPropertyChanged(nameof(Author));
                }
            }
        }

        /// <summary>
        /// Thể loại sách
        /// </summary>
        public string Category
        {
            get => _category;
            set
            {
                if (_category != value)
                {
                    _category = value;
                    OnPropertyChanged(nameof(Category));
                }
            }
        }

        /// <summary>
        /// Nhà xuất bản
        /// </summary>
        public string Publisher
        {
            get => _publisher;
            set
            {
                if (_publisher != value)
                {
                    _publisher = value;
                    OnPropertyChanged(nameof(Publisher));
                }
            }
        }

        /// <summary>
        /// Năm xuất bản
        /// </summary>
        public int PublishYear
        {
            get => _publishYear;
            set
            {
                if (_publishYear != value)
                {
                    _publishYear = value;
                    OnPropertyChanged(nameof(PublishYear));
                }
            }
        }

        /// <summary>
        /// Đơn giá sách (VNĐ)
        /// </summary>
        public decimal Price
        {
            get => _price;
            set
            {
                if (_price != value)
                {
                    _price = value;
                    OnPropertyChanged(nameof(Price));
                    OnPropertyChanged(nameof(TotalPrice));
                }
            }
        }

        /// <summary>
        /// Số lượng sách trong kho
        /// </summary>
        public int Quantity
        {
            get => _quantity;
            set
            {
                if (_quantity != value)
                {
                    _quantity = value;
                    OnPropertyChanged(nameof(Quantity));
                    OnPropertyChanged(nameof(TotalPrice));
                }
            }
        }

        /// <summary>
        /// Thành tiền / Tổng giá trị tồn kho của đầu sách = Đơn giá * Số lượng
        /// </summary>
        public decimal TotalPrice => _price * _quantity;

        /// <summary>
        /// Đường dẫn đầy đủ hoặc tương đối của file ảnh bìa sách
        /// </summary>
        public string CoverPath
        {
            get => _coverPath;
            set
            {
                if (_coverPath != value)
                {
                    _coverPath = value;
                    OnPropertyChanged(nameof(CoverPath));
                    OnPropertyChanged(nameof(CoverFileName));
                }
            }
        }

        /// <summary>
        /// Tên file ảnh bìa (hoặc đường dẫn ngắn) để hiển thị trên DataGridView
        /// theo yêu cầu: "DataGridView (dgvBooks) hiển thị danh sách sách (chỉ lưu tên file ảnh hoặc đường dẫn ngắn)"
        /// </summary>
        public string CoverFileName
        {
            get
            {
                if (string.IsNullOrWhiteSpace(_coverPath))
                    return "Chưa có ảnh";

                try
                {
                    return Path.GetFileName(_coverPath);
                }
                catch
                {
                    return _coverPath;
                }
            }
        }

        public event PropertyChangedEventHandler? PropertyChanged;

        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        /// <summary>
        /// Tạo bản sao độc lập của đối tượng
        /// </summary>
        public BookModel Clone()
        {
            return new BookModel
            {
                BookId = this.BookId,
                Title = this.Title,
                Author = this.Author,
                Category = this.Category,
                Publisher = this.Publisher,
                PublishYear = this.PublishYear,
                Price = this.Price,
                Quantity = this.Quantity,
                CoverPath = this.CoverPath
            };
        }
    }
}
