using System;
using System.ComponentModel;

namespace GymManagementSystem
{
    /// <summary>
    /// Model đại diện cho một Hội viên phòng Gym.
    /// Triển khai INotifyPropertyChanged để hỗ trợ Data Binding 2 chiều với DataGridView / BindingList.
    /// </summary>
    public class GymMember : INotifyPropertyChanged
    {
        private string _memberId = string.Empty;
        private string _fullName = string.Empty;
        private string _phone = string.Empty;
        private string _package = string.Empty;
        private DateTime _startDate = DateTime.Today;
        private decimal _fee;

        public string MemberId
        {
            get => _memberId;
            set
            {
                if (_memberId != value)
                {
                    _memberId = value;
                    OnPropertyChanged(nameof(MemberId));
                }
            }
        }

        public string FullName
        {
            get => _fullName;
            set
            {
                if (_fullName != value)
                {
                    _fullName = value;
                    OnPropertyChanged(nameof(FullName));
                }
            }
        }

        public string Phone
        {
            get => _phone;
            set
            {
                if (_phone != value)
                {
                    _phone = value;
                    OnPropertyChanged(nameof(Phone));
                }
            }
        }

        public string Package
        {
            get => _package;
            set
            {
                if (_package != value)
                {
                    _package = value;
                    OnPropertyChanged(nameof(Package));
                }
            }
        }

        public DateTime StartDate
        {
            get => _startDate;
            set
            {
                if (_startDate != value)
                {
                    _startDate = value;
                    OnPropertyChanged(nameof(StartDate));
                }
            }
        }

        public decimal Fee
        {
            get => _fee;
            set
            {
                if (_fee != value)
                {
                    _fee = value;
                    OnPropertyChanged(nameof(Fee));
                }
            }
        }

        public event PropertyChangedEventHandler? PropertyChanged;

        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
