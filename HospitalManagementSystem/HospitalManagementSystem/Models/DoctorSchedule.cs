using System;
using System.ComponentModel;

namespace HospitalManagementSystem.Models
{
    /// <summary>
    /// Model đại diện cho một Ca trực của Bác sĩ tại bệnh viện.
    /// Triển khai INotifyPropertyChanged để hỗ trợ Data Binding 2 chiều.
    /// </summary>
    public class DoctorSchedule : INotifyPropertyChanged
    {
        private string _scheduleId = string.Empty;
        private string _doctorId = string.Empty;
        private string _doctorName = string.Empty;
        private string _department = string.Empty;
        private DateTime _dutyDate = DateTime.Today;
        private string _shift = "Ca sáng (07:00 - 15:00)";
        private string _dutyRoom = string.Empty;
        private string _role = "Trực chuyên môn";
        private string _note = string.Empty;

        public string ScheduleId
        {
            get => _scheduleId;
            set
            {
                if (_scheduleId != value)
                {
                    _scheduleId = value;
                    OnPropertyChanged(nameof(ScheduleId));
                }
            }
        }

        public string DoctorId
        {
            get => _doctorId;
            set
            {
                if (_doctorId != value)
                {
                    _doctorId = value;
                    OnPropertyChanged(nameof(DoctorId));
                }
            }
        }

        public string DoctorName
        {
            get => _doctorName;
            set
            {
                if (_doctorName != value)
                {
                    _doctorName = value;
                    OnPropertyChanged(nameof(DoctorName));
                }
            }
        }

        public string Department
        {
            get => _department;
            set
            {
                if (_department != value)
                {
                    _department = value;
                    OnPropertyChanged(nameof(Department));
                }
            }
        }

        public DateTime DutyDate
        {
            get => _dutyDate;
            set
            {
                if (_dutyDate != value)
                {
                    _dutyDate = value;
                    OnPropertyChanged(nameof(DutyDate));
                }
            }
        }

        public string Shift
        {
            get => _shift;
            set
            {
                if (_shift != value)
                {
                    _shift = value;
                    OnPropertyChanged(nameof(Shift));
                }
            }
        }

        public string DutyRoom
        {
            get => _dutyRoom;
            set
            {
                if (_dutyRoom != value)
                {
                    _dutyRoom = value;
                    OnPropertyChanged(nameof(DutyRoom));
                }
            }
        }

        public string Role
        {
            get => _role;
            set
            {
                if (_role != value)
                {
                    _role = value;
                    OnPropertyChanged(nameof(Role));
                }
            }
        }

        public string Note
        {
            get => _note;
            set
            {
                if (_note != value)
                {
                    _note = value;
                    OnPropertyChanged(nameof(Note));
                }
            }
        }

        public event PropertyChangedEventHandler? PropertyChanged;

        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        public DoctorSchedule Clone()
        {
            return new DoctorSchedule
            {
                ScheduleId = this.ScheduleId,
                DoctorId = this.DoctorId,
                DoctorName = this.DoctorName,
                Department = this.Department,
                DutyDate = this.DutyDate,
                Shift = this.Shift,
                DutyRoom = this.DutyRoom,
                Role = this.Role,
                Note = this.Note
            };
        }
    }
}
