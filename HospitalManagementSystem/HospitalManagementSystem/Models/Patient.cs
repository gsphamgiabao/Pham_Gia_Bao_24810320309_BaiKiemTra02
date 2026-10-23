using System;
using System.ComponentModel;

namespace HospitalManagementSystem.Models
{
    /// <summary>
    /// Model đại diện cho một Hồ sơ Bệnh nhân & Bệnh án tại bệnh viện.
    /// Triển khai INotifyPropertyChanged để hỗ trợ Data Binding 2 chiều với DataGridView / BindingList.
    /// </summary>
    public class Patient : INotifyPropertyChanged
    {
        private string _patientId = string.Empty;
        private string _fullName = string.Empty;
        private string _gender = "Nam";
        private DateTime _dateOfBirth = new DateTime(1990, 1, 1);
        private string _phone = string.Empty;
        private string _address = string.Empty;
        private string _department = "Khoa Cấp cứu";
        private string _bedNumber = "P101-G01";
        private DateTime _admissionDate = DateTime.Today;
        private string _doctorInCharge = string.Empty;
        private string _diagnosis = string.Empty;
        private string _treatmentStatus = "Đang điều trị";

        public string PatientId
        {
            get => _patientId;
            set
            {
                if (_patientId != value)
                {
                    _patientId = value;
                    OnPropertyChanged(nameof(PatientId));
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

        public string Gender
        {
            get => _gender;
            set
            {
                if (_gender != value)
                {
                    _gender = value;
                    OnPropertyChanged(nameof(Gender));
                }
            }
        }

        public DateTime DateOfBirth
        {
            get => _dateOfBirth;
            set
            {
                if (_dateOfBirth != value)
                {
                    _dateOfBirth = value;
                    OnPropertyChanged(nameof(DateOfBirth));
                    OnPropertyChanged(nameof(Age));
                }
            }
        }

        public int Age
        {
            get
            {
                int age = DateTime.Today.Year - _dateOfBirth.Year;
                if (_dateOfBirth.Date > DateTime.Today.AddYears(-age))
                {
                    age--;
                }
                return Math.Max(0, age);
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

        public string Address
        {
            get => _address;
            set
            {
                if (_address != value)
                {
                    _address = value;
                    OnPropertyChanged(nameof(Address));
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

        public string BedNumber
        {
            get => _bedNumber;
            set
            {
                if (_bedNumber != value)
                {
                    _bedNumber = value;
                    OnPropertyChanged(nameof(BedNumber));
                }
            }
        }

        public DateTime AdmissionDate
        {
            get => _admissionDate;
            set
            {
                if (_admissionDate != value)
                {
                    _admissionDate = value;
                    OnPropertyChanged(nameof(AdmissionDate));
                }
            }
        }

        public string DoctorInCharge
        {
            get => _doctorInCharge;
            set
            {
                if (_doctorInCharge != value)
                {
                    _doctorInCharge = value;
                    OnPropertyChanged(nameof(DoctorInCharge));
                }
            }
        }

        public string Diagnosis
        {
            get => _diagnosis;
            set
            {
                if (_diagnosis != value)
                {
                    _diagnosis = value;
                    OnPropertyChanged(nameof(Diagnosis));
                }
            }
        }

        public string TreatmentStatus
        {
            get => _treatmentStatus;
            set
            {
                if (_treatmentStatus != value)
                {
                    _treatmentStatus = value;
                    OnPropertyChanged(nameof(TreatmentStatus));
                }
            }
        }

        public event PropertyChangedEventHandler? PropertyChanged;

        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        public Patient Clone()
        {
            return new Patient
            {
                PatientId = this.PatientId,
                FullName = this.FullName,
                Gender = this.Gender,
                DateOfBirth = this.DateOfBirth,
                Phone = this.Phone,
                Address = this.Address,
                Department = this.Department,
                BedNumber = this.BedNumber,
                AdmissionDate = this.AdmissionDate,
                DoctorInCharge = this.DoctorInCharge,
                Diagnosis = this.Diagnosis,
                TreatmentStatus = this.TreatmentStatus
            };
        }
    }
}
