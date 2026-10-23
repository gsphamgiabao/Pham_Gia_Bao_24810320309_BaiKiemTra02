using System;
using System.Collections.Generic;
using System.ComponentModel;
using HospitalManagementSystem.Models;

namespace HospitalManagementSystem.Data
{
    /// <summary>
    /// Kho dữ liệu dùng chung (In-Memory Data Store) cho toàn bộ hệ thống bệnh viện MDI.
    /// Cho phép các Form con (Hồ sơ Bệnh nhân, Lịch trực Bác sĩ, Danh mục Khoa/Phòng) 
    /// đồng bộ dữ liệu theo thời gian thực và hỗ trợ tính năng Nạp lại dữ liệu (Reload Data).
    /// </summary>
    public static class HospitalDataStore
    {
        public static BindingList<Patient> Patients { get; private set; } = new BindingList<Patient>();
        public static BindingList<DoctorSchedule> Schedules { get; private set; } = new BindingList<DoctorSchedule>();
        public static BindingList<Department> Departments { get; private set; } = new BindingList<Department>();

        public static List<string> DoctorNames { get; private set; } = new List<string>
        {
            "BS. CKII Nguyễn Văn An",
            "PGS.TS Trần Minh Đức",
            "TS.BS Lê Quang Vinh",
            "BSCKII Phạm Hồng Mai",
            "ThS.BS Hoàng Thu Hằng",
            "BSCKII Vũ Đình Toàn",
            "ThS.BS Nguyễn Thị Lan",
            "BS. Đỗ Tuấn Nghĩa"
        };

        public static event Action? DataReloaded;

        static HospitalDataStore()
        {
            ReloadAllData();
        }

        /// <summary>
        /// Nạp lại toàn bộ dữ liệu mẫu ban đầu và kích hoạt sự kiện DataReloaded
        /// </summary>
        public static void ReloadAllData()
        {
            // 1. Nạp danh mục Khoa/Phòng
            Departments.Clear();
            Departments.Add(new Department { DepartmentId = "K01", DepartmentName = "Khoa Cấp cứu & Hồi sức tích cực", HeadDoctor = "BS. CKII Nguyễn Văn An", Location = "Tòa A - Tầng 1", TotalBeds = 40, Hotline = "1900-1111" });
            Departments.Add(new Department { DepartmentId = "K02", DepartmentName = "Khoa Tim mạch Can thiệp", HeadDoctor = "PGS.TS Trần Minh Đức", Location = "Tòa B - Tầng 3", TotalBeds = 50, Hotline = "1900-1112" });
            Departments.Add(new Department { DepartmentId = "K03", DepartmentName = "Khoa Ngoại Thần kinh & Chấn thương", HeadDoctor = "TS.BS Lê Quang Vinh", Location = "Tòa B - Tầng 4", TotalBeds = 45, Hotline = "1900-1113" });
            Departments.Add(new Department { DepartmentId = "K04", DepartmentName = "Khoa Nội Tiêu hóa & Gan mật", HeadDoctor = "BSCKII Phạm Hồng Mai", Location = "Tòa C - Tầng 2", TotalBeds = 35, Hotline = "1900-1114" });
            Departments.Add(new Department { DepartmentId = "K05", DepartmentName = "Khoa Nhi Tổng hợp", HeadDoctor = "ThS.BS Hoàng Thu Hằng", Location = "Tòa C - Tầng 3", TotalBeds = 60, Hotline = "1900-1115" });
            Departments.Add(new Department { DepartmentId = "K06", DepartmentName = "Khoa Sản - Phụ khoa", HeadDoctor = "BSCKII Vũ Đình Toàn", Location = "Tòa A - Tầng 2", TotalBeds = 55, Hotline = "1900-1116" });

            // 2. Nạp danh sách Bệnh nhân & Hồ sơ Bệnh án
            Patients.Clear();
            Patients.Add(new Patient
            {
                PatientId = "BN001",
                FullName = "Trần Văn Hùng",
                Gender = "Nam",
                DateOfBirth = new DateTime(1985, 4, 12),
                Phone = "0912345678",
                Address = "Số 45 Tràng Tiền, Hoàn Kiếm, Hà Nội",
                Department = "Khoa Cấp cứu & Hồi sức tích cực",
                BedNumber = "P101-G01",
                AdmissionDate = DateTime.Today.AddDays(-3),
                DoctorInCharge = "BS. CKII Nguyễn Văn An",
                Diagnosis = "Đột quỵ thiếu máu não thoáng qua (TIA), tăng huyết áp độ 2",
                TreatmentStatus = "Đang điều trị"
            });

            Patients.Add(new Patient
            {
                PatientId = "BN002",
                FullName = "Nguyễn Thị Mai",
                Gender = "Nữ",
                DateOfBirth = new DateTime(1992, 8, 25),
                Phone = "0987654321",
                Address = "12 Lạch Tray, Ngô Quyền, Hải Phòng",
                Department = "Khoa Tim mạch Can thiệp",
                BedNumber = "P302-G04",
                AdmissionDate = DateTime.Today.AddDays(-2),
                DoctorInCharge = "PGS.TS Trần Minh Đức",
                Diagnosis = "Cơn đau thắt ngực không ổn định, nghi ngờ hẹp mạch vành",
                TreatmentStatus = "Chờ phẫu thuật"
            });

            Patients.Add(new Patient
            {
                PatientId = "BN003",
                FullName = "Lê Văn Khoa",
                Gender = "Nam",
                DateOfBirth = new DateTime(1978, 11, 3),
                Phone = "0905112233",
                Address = "88 Nguyễn Tri Phương, Hải Châu, Đà Nẵng",
                Department = "Khoa Ngoại Thần kinh & Chấn thương",
                BedNumber = "P405-G02",
                AdmissionDate = DateTime.Today.AddDays(-5),
                DoctorInCharge = "TS.BS Lê Quang Vinh",
                Diagnosis = "Thoát vị đĩa đệm cột sống thắt lưng L4-L5 chèn ép rễ thần kinh",
                TreatmentStatus = "Đang điều trị"
            });

            Patients.Add(new Patient
            {
                PatientId = "BN004",
                FullName = "Phạm Thu Thảo",
                Gender = "Nữ",
                DateOfBirth = new DateTime(2001, 2, 14),
                Phone = "0934567890",
                Address = "Khu đô thị Bắc Từ Sơn, Bắc Ninh",
                Department = "Khoa Nội Tiêu hóa & Gan mật",
                BedNumber = "P204-G05",
                AdmissionDate = DateTime.Today.AddDays(-8),
                DoctorInCharge = "BSCKII Phạm Hồng Mai",
                Diagnosis = "Viêm loét dạ dày tá tràng thể hoạt động, Hp dương tính",
                TreatmentStatus = "Đã xuất viện"
            });

            Patients.Add(new Patient
            {
                PatientId = "BN005",
                FullName = "Đặng Gia Huy",
                Gender = "Nam",
                DateOfBirth = new DateTime(2018, 6, 30),
                Phone = "0978998877",
                Address = "Toà S2.03 Vinhomes Ocean Park, Gia Lâm, Hà Nội",
                Department = "Khoa Nhi Tổng hợp",
                BedNumber = "P308-G01",
                AdmissionDate = DateTime.Today.AddDays(-1),
                DoctorInCharge = "ThS.BS Hoàng Thu Hằng",
                Diagnosis = "Viêm phế quản co thắt cấp tính kèm sốt cao co giật",
                TreatmentStatus = "Đang điều trị"
            });

            Patients.Add(new Patient
            {
                PatientId = "BN006",
                FullName = "Vũ Thị Hương",
                Gender = "Nữ",
                DateOfBirth = new DateTime(1989, 12, 5),
                Phone = "0943221100",
                Address = "Phố Nối, Mỹ Hào, Hưng Yên",
                Department = "Khoa Sản - Phụ khoa",
                BedNumber = "P202-G03",
                AdmissionDate = DateTime.Today.AddDays(-4),
                DoctorInCharge = "BSCKII Vũ Đình Toàn",
                Diagnosis = "Thai kỳ tuần thứ 37, tiền sản giật nhẹ cần theo dõi huyết áp",
                TreatmentStatus = "Đang điều trị"
            });

            Patients.Add(new Patient
            {
                PatientId = "BN007",
                FullName = "Hoàng Minh Tuấn",
                Gender = "Nam",
                DateOfBirth = new DateTime(1965, 9, 17),
                Phone = "0918776655",
                Address = "Bãi Cháy, Hạ Long, Quảng Ninh",
                Department = "Khoa Cấp cứu & Hồi sức tích cực",
                BedNumber = "P102-G02",
                AdmissionDate = DateTime.Today,
                DoctorInCharge = "ThS.BS Nguyễn Thị Lan",
                Diagnosis = "Đa chấn thương phần mềm do tai nạn giao thông, theo dõi chấn thương sọ não",
                TreatmentStatus = "Đang điều trị"
            });

            Patients.Add(new Patient
            {
                PatientId = "BN008",
                FullName = "Bùi Ngọc Linh",
                Gender = "Nữ",
                DateOfBirth = new DateTime(1995, 3, 28),
                Phone = "0966443322",
                Address = "Phường Trần Hưng Đạo, TP Thái Bình",
                Department = "Khoa Tim mạch Can thiệp",
                BedNumber = "P301-G03",
                AdmissionDate = DateTime.Today.AddDays(-14),
                DoctorInCharge = "BS. Đỗ Tuấn Nghĩa",
                Diagnosis = "Rối loạn nhịp tim nhanh kịch phát trên thất đã triệt đốt thành công",
                TreatmentStatus = "Đã xuất viện"
            });

            // 3. Nạp danh sách Lịch trực Bác sĩ
            Schedules.Clear();
            Schedules.Add(new DoctorSchedule
            {
                ScheduleId = "LT001",
                DoctorId = "BS01",
                DoctorName = "BS. CKII Nguyễn Văn An",
                Department = "Khoa Cấp cứu & Hồi sức tích cực",
                DutyDate = DateTime.Today,
                Shift = "Ca sáng (07:00 - 15:00)",
                DutyRoom = "Phòng Cấp cứu 1 - Tòa A",
                Role = "Trưởng kíp trực",
                Note = "Chịu trách nhiệm toàn bộ ca trực cấp cứu, hội chẩn liên viện"
            });

            Schedules.Add(new DoctorSchedule
            {
                ScheduleId = "LT002",
                DoctorId = "BS07",
                DoctorName = "ThS.BS Nguyễn Thị Lan",
                Department = "Khoa Cấp cứu & Hồi sức tích cực",
                DutyDate = DateTime.Today,
                Shift = "Ca sáng (07:00 - 15:00)",
                DutyRoom = "Phòng Khám sàng lọc A1",
                Role = "Bác sĩ thường trực",
                Note = "Phân luồng và tiếp đón ban đầu bệnh nhân cấp cứu"
            });

            Schedules.Add(new DoctorSchedule
            {
                ScheduleId = "LT003",
                DoctorId = "BS02",
                DoctorName = "PGS.TS Trần Minh Đức",
                Department = "Khoa Tim mạch Can thiệp",
                DutyDate = DateTime.Today,
                Shift = "Ca chiều (15:00 - 23:00)",
                DutyRoom = "Phòng Can thiệp Tim mạch DSA",
                Role = "Trực chuyên môn",
                Note = "Sẵn sàng chụp nong mạch vành cấp cứu"
            });

            Schedules.Add(new DoctorSchedule
            {
                ScheduleId = "LT004",
                DoctorId = "BS03",
                DoctorName = "TS.BS Lê Quang Vinh",
                Department = "Khoa Ngoại Thần kinh & Chấn thương",
                DutyDate = DateTime.Today,
                Shift = "Ca đêm (23:00 - 07:00)",
                DutyRoom = "Phòng Phẫu thuật Cấp cứu B2",
                Role = "Trực phẫu thuật viên chính",
                Note = "Kíp trực mổ phiên đêm và cấp cứu ngoại viện"
            });

            Schedules.Add(new DoctorSchedule
            {
                ScheduleId = "LT005",
                DoctorId = "BS05",
                DoctorName = "ThS.BS Hoàng Thu Hằng",
                Department = "Khoa Nhi Tổng hợp",
                DutyDate = DateTime.Today.AddDays(1),
                Shift = "Ca sáng (07:00 - 15:00)",
                DutyRoom = "Phòng Khám Nhi - P103 Tòa C",
                Role = "Bác sĩ chuyên khoa",
                Note = "Khám bệnh nhân ngoại trú và hội chẩn nội trú Nhi"
            });

            Schedules.Add(new DoctorSchedule
            {
                ScheduleId = "LT006",
                DoctorId = "BS06",
                DoctorName = "BSCKII Vũ Đình Toàn",
                Department = "Khoa Sản - Phụ khoa",
                DutyDate = DateTime.Today.AddDays(1),
                Shift = "Ca đêm (23:00 - 07:00)",
                DutyRoom = "Phòng Đỡ đẻ & Cấp cứu Sản",
                Role = "Trưởng kíp trực",
                Note = "Điều hành ca sinh mổ cấp cứu ban đêm"
            });

            // Kích hoạt thông báo nạp dữ liệu cho các Form
            DataReloaded?.Invoke();
        }
    }
}
