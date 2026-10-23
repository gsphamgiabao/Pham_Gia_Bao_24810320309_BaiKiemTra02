using System.ComponentModel;

namespace HospitalManagementSystem.Models
{
    /// <summary>
    /// Model đại diện cho một Khoa/Phòng chuyên môn trong bệnh viện.
    /// Triển khai INotifyPropertyChanged để hỗ trợ Data Binding 2 chiều.
    /// </summary>
    public class Department : INotifyPropertyChanged
    {
        private string _departmentId = string.Empty;
        private string _departmentName = string.Empty;
        private string _headDoctor = string.Empty;
        private string _location = string.Empty;
        private int _totalBeds = 30;
        private string _hotline = string.Empty;

        public string DepartmentId
        {
            get => _departmentId;
            set
            {
                if (_departmentId != value)
                {
                    _departmentId = value;
                    OnPropertyChanged(nameof(DepartmentId));
                }
            }
        }

        public string DepartmentName
        {
            get => _departmentName;
            set
            {
                if (_departmentName != value)
                {
                    _departmentName = value;
                    OnPropertyChanged(nameof(DepartmentName));
                }
            }
        }

        public string HeadDoctor
        {
            get => _headDoctor;
            set
            {
                if (_headDoctor != value)
                {
                    _headDoctor = value;
                    OnPropertyChanged(nameof(HeadDoctor));
                }
            }
        }

        public string Location
        {
            get => _location;
            set
            {
                if (_location != value)
                {
                    _location = value;
                    OnPropertyChanged(nameof(Location));
                }
            }
        }

        public int TotalBeds
        {
            get => _totalBeds;
            set
            {
                if (_totalBeds != value)
                {
                    _totalBeds = value;
                    OnPropertyChanged(nameof(TotalBeds));
                }
            }
        }

        public string Hotline
        {
            get => _hotline;
            set
            {
                if (_hotline != value)
                {
                    _hotline = value;
                    OnPropertyChanged(nameof(Hotline));
                }
            }
        }

        public event PropertyChangedEventHandler? PropertyChanged;

        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        public Department Clone()
        {
            return new Department
            {
                DepartmentId = this.DepartmentId,
                DepartmentName = this.DepartmentName,
                HeadDoctor = this.HeadDoctor,
                Location = this.Location,
                TotalBeds = this.TotalBeds,
                Hotline = this.Hotline
            };
        }
    }
}
