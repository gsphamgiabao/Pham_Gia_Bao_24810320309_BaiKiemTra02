using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using HospitalManagementSystem.Data;
using HospitalManagementSystem.Models;

namespace HospitalManagementSystem.Forms
{
    public partial class frmPatientProfiles : Form
    {
        private readonly BindingSource _bindingSource = new BindingSource();
        private bool _isResetting = false;

        public frmPatientProfiles()
        {
            InitializeComponent();
            InitFormComponents();
        }

        #region Khởi tạo Giao diện và Dữ liệu

        private void InitFormComponents()
        {
            // 1. Cấu hình các ComboBox dữ liệu danh mục
            PopulateComboBoxes();

            // 2. Cấu hình DataGridView bằng code chuyên nghiệp
            ConfigureDataGridView();

            // 3. Liên kết BindingSource với kho dữ liệu chung
            _bindingSource.DataSource = HospitalDataStore.Patients;
            dgvPatients.DataSource = _bindingSource;

            // 4. Đăng ký các sự kiện tương tác
            RegisterEvents();

            // 5. Cập nhật thống kê ban đầu và hiển thị dòng đầu tiên nếu có
            UpdateStatistics();
            if (HospitalDataStore.Patients.Count > 0)
            {
                DisplayPatientToControls(HospitalDataStore.Patients[0]);
            }
            else
            {
                BtnReset_Click(this, EventArgs.Empty);
            }
        }

        private void PopulateComboBoxes()
        {
            // Giới tính
            cboGender.Items.Clear();
            cboGender.Items.Add("Nam");
            cboGender.Items.Add("Nữ");
            cboGender.SelectedIndex = 0;

            // Khoa điều trị
            cboDepartment.Items.Clear();
            cboFilterDept.Items.Clear();
            cboFilterDept.Items.Add("--- Tất cả Khoa ---");

            foreach (var dept in HospitalDataStore.Departments)
            {
                cboDepartment.Items.Add(dept.DepartmentName);
                cboFilterDept.Items.Add(dept.DepartmentName);
            }
            if (cboDepartment.Items.Count > 0) cboDepartment.SelectedIndex = 0;
            cboFilterDept.SelectedIndex = 0;

            // Bác sĩ điều trị
            cboDoctor.Items.Clear();
            foreach (var doc in HospitalDataStore.DoctorNames)
            {
                cboDoctor.Items.Add(doc);
            }
            if (cboDoctor.Items.Count > 0) cboDoctor.SelectedIndex = 0;

            // Tình trạng điều trị
            string[] statuses = { "Đang điều trị", "Chờ phẫu thuật", "Đã xuất viện", "Chuyển viện" };
            cboTreatmentStatus.Items.Clear();
            cboTreatmentStatus.Items.AddRange(statuses);
            cboTreatmentStatus.SelectedIndex = 0;

            cboFilterStatus.Items.Clear();
            cboFilterStatus.Items.Add("--- Tất cả Tình trạng ---");
            cboFilterStatus.Items.AddRange(statuses);
            cboFilterStatus.SelectedIndex = 0;
        }

        private void ConfigureDataGridView()
        {
            dgvPatients.AutoGenerateColumns = false;
            dgvPatients.AllowUserToAddRows = false;
            dgvPatients.AllowUserToDeleteRows = false;
            dgvPatients.ReadOnly = true;
            dgvPatients.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvPatients.MultiSelect = false;
            dgvPatients.BackgroundColor = Color.White;
            dgvPatients.BorderStyle = BorderStyle.Fixed3D;
            dgvPatients.RowHeadersVisible = false;
            dgvPatients.EnableHeadersVisualStyles = false;

            // Header Style
            dgvPatients.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(13, 100, 140);
            dgvPatients.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
            dgvPatients.ColumnHeadersDefaultCellStyle.Font = new Font("Segoe UI", 9.5F, FontStyle.Bold);
            dgvPatients.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgvPatients.ColumnHeadersHeight = 35;

            // Default Row Style & Alternating
            dgvPatients.DefaultCellStyle.Font = new Font("Segoe UI", 9F, FontStyle.Regular);
            dgvPatients.DefaultCellStyle.SelectionBackColor = Color.FromArgb(200, 230, 255);
            dgvPatients.DefaultCellStyle.SelectionForeColor = Color.Black;
            dgvPatients.AlternatingRowsDefaultCellStyle.BackColor = Color.FromArgb(246, 250, 255);

            dgvPatients.Columns.Clear();

            // Cột 1: Mã BN
            var colId = new DataGridViewTextBoxColumn
            {
                DataPropertyName = "PatientId",
                HeaderText = "Mã BN",
                Width = 85,
                DefaultCellStyle = { Alignment = DataGridViewContentAlignment.MiddleCenter, Font = new Font("Segoe UI", 9F, FontStyle.Bold) }
            };
            dgvPatients.Columns.Add(colId);

            // Cột 2: Họ và Tên
            var colName = new DataGridViewTextBoxColumn
            {
                DataPropertyName = "FullName",
                HeaderText = "Họ và Tên",
                Width = 150
            };
            dgvPatients.Columns.Add(colName);

            // Cột 3: Giới tính
            var colGender = new DataGridViewTextBoxColumn
            {
                DataPropertyName = "Gender",
                HeaderText = "Phái",
                Width = 65,
                DefaultCellStyle = { Alignment = DataGridViewContentAlignment.MiddleCenter }
            };
            dgvPatients.Columns.Add(colGender);

            // Cột 4: Tuổi
            var colAge = new DataGridViewTextBoxColumn
            {
                DataPropertyName = "Age",
                HeaderText = "Tuổi",
                Width = 55,
                DefaultCellStyle = { Alignment = DataGridViewContentAlignment.MiddleCenter }
            };
            dgvPatients.Columns.Add(colAge);

            // Cột 5: SĐT
            var colPhone = new DataGridViewTextBoxColumn
            {
                DataPropertyName = "Phone",
                HeaderText = "Số ĐT",
                Width = 100,
                DefaultCellStyle = { Alignment = DataGridViewContentAlignment.MiddleCenter }
            };
            dgvPatients.Columns.Add(colPhone);

            // Cột 6: Khoa điều trị
            var colDept = new DataGridViewTextBoxColumn
            {
                DataPropertyName = "Department",
                HeaderText = "Khoa điều trị",
                Width = 180
            };
            dgvPatients.Columns.Add(colDept);

            // Cột 7: Phòng - Giường
            var colBed = new DataGridViewTextBoxColumn
            {
                DataPropertyName = "BedNumber",
                HeaderText = "Phòng-Giường",
                Width = 110,
                DefaultCellStyle = { Alignment = DataGridViewContentAlignment.MiddleCenter }
            };
            dgvPatients.Columns.Add(colBed);

            // Cột 8: Ngày nhập viện
            var colAdmDate = new DataGridViewTextBoxColumn
            {
                DataPropertyName = "AdmissionDate",
                HeaderText = "Ngày NV",
                Width = 95,
                DefaultCellStyle = { Alignment = DataGridViewContentAlignment.MiddleCenter, Format = "dd/MM/yyyy" }
            };
            dgvPatients.Columns.Add(colAdmDate);

            // Cột 9: Bác sĩ điều trị
            var colDoc = new DataGridViewTextBoxColumn
            {
                DataPropertyName = "DoctorInCharge",
                HeaderText = "Bác sĩ điều trị",
                Width = 160
            };
            dgvPatients.Columns.Add(colDoc);

            // Cột 10: Tình trạng
            var colStatus = new DataGridViewTextBoxColumn
            {
                DataPropertyName = "TreatmentStatus",
                HeaderText = "Tình trạng Đ/t",
                Width = 120,
                DefaultCellStyle = { Alignment = DataGridViewContentAlignment.MiddleCenter }
            };
            dgvPatients.Columns.Add(colStatus);

            // Cột 11: Chẩn đoán
            var colDiag = new DataGridViewTextBoxColumn
            {
                DataPropertyName = "Diagnosis",
                HeaderText = "Chẩn đoán ban đầu / Bệnh án",
                AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
            };
            dgvPatients.Columns.Add(colDiag);
        }

        private void RegisterEvents()
        {
            dgvPatients.SelectionChanged += DgvPatients_SelectionChanged;
            dgvPatients.CellFormatting += DgvPatients_CellFormatting;

            btnAdd.Click += BtnAdd_Click;
            btnEdit.Click += BtnEdit_Click;
            btnDelete.Click += BtnDelete_Click;
            btnReset.Click += BtnReset_Click;
            btnAutoId.Click += (s, e) => txtPatientId.Text = GenerateNextPatientId();
            btnViewRecord.Click += BtnViewRecord_Click;

            btnSearch.Click += BtnSearch_Click;
            btnResetFilter.Click += BtnResetFilter_Click;
            txtSearchKeyword.KeyDown += (s, e) => { if (e.KeyCode == Keys.Enter) { e.SuppressKeyPress = true; BtnSearch_Click(s, e); } };

            // Tự động xóa lỗi khi người dùng nhập dữ liệu
            txtPatientId.TextChanged += (s, e) => errorProvider1.SetError(txtPatientId, string.Empty);
            txtFullName.TextChanged += (s, e) => errorProvider1.SetError(txtFullName, string.Empty);
            txtPhone.TextChanged += (s, e) => errorProvider1.SetError(txtPhone, string.Empty);

            // Lắng nghe sự kiện Nạp lại dữ liệu toàn cục
            HospitalDataStore.DataReloaded += HospitalDataStore_DataReloaded;
        }

        private void HospitalDataStore_DataReloaded()
        {
            if (this.IsDisposed) return;
            PopulateComboBoxes();
            _bindingSource.DataSource = HospitalDataStore.Patients;
            _bindingSource.ResetBindings(false);
            UpdateStatistics();
            if (HospitalDataStore.Patients.Count > 0)
            {
                DisplayPatientToControls(HospitalDataStore.Patients[0]);
            }
        }

        #endregion

        #region Xử lý hiển thị và Data Binding

        private void DgvPatients_SelectionChanged(object? sender, EventArgs e)
        {
            if (_isResetting) return;

            if (dgvPatients.CurrentRow?.DataBoundItem is Patient patient)
            {
                DisplayPatientToControls(patient);
            }
        }

        private void DisplayPatientToControls(Patient patient)
        {
            txtPatientId.Text = patient.PatientId;
            txtFullName.Text = patient.FullName;
            cboGender.SelectedItem = patient.Gender;

            if (patient.DateOfBirth >= dtpDob.MinDate && patient.DateOfBirth <= dtpDob.MaxDate)
            {
                dtpDob.Value = patient.DateOfBirth;
            }

            txtPhone.Text = patient.Phone;
            txtAddress.Text = patient.Address;

            if (cboDepartment.Items.Contains(patient.Department))
                cboDepartment.SelectedItem = patient.Department;

            txtBedNumber.Text = patient.BedNumber;

            if (patient.AdmissionDate >= dtpAdmissionDate.MinDate && patient.AdmissionDate <= dtpAdmissionDate.MaxDate)
            {
                dtpAdmissionDate.Value = patient.AdmissionDate;
            }

            if (cboDoctor.Items.Contains(patient.DoctorInCharge))
                cboDoctor.SelectedItem = patient.DoctorInCharge;

            if (cboTreatmentStatus.Items.Contains(patient.TreatmentStatus))
                cboTreatmentStatus.SelectedItem = patient.TreatmentStatus;

            txtDiagnosis.Text = patient.Diagnosis;

            // Khi đang chọn bệnh nhân có sẵn, khóa ô Mã BN để tránh sửa khóa chính
            txtPatientId.ReadOnly = true;
            btnAutoId.Enabled = false;
        }

        private void DgvPatients_CellFormatting(object? sender, DataGridViewCellFormattingEventArgs e)
        {
            if (e.RowIndex < 0 || e.RowIndex >= dgvPatients.Rows.Count) return;

            // Highlight cột Tình trạng
            if (dgvPatients.Columns[e.ColumnIndex].DataPropertyName == "TreatmentStatus" && e.Value != null)
            {
                string status = e.Value.ToString() ?? string.Empty;
                switch (status)
                {
                    case "Đang điều trị":
                        e.CellStyle.ForeColor = Color.FromArgb(25, 135, 84); // Xanh lá
                        e.CellStyle.Font = new Font(dgvPatients.Font, FontStyle.Bold);
                        break;
                    case "Chờ phẫu thuật":
                        e.CellStyle.ForeColor = Color.FromArgb(253, 126, 20); // Cam
                        e.CellStyle.Font = new Font(dgvPatients.Font, FontStyle.Bold);
                        break;
                    case "Đã xuất viện":
                        e.CellStyle.ForeColor = Color.FromArgb(108, 117, 125); // Xám
                        break;
                    case "Chuyển viện":
                        e.CellStyle.ForeColor = Color.FromArgb(111, 66, 193); // Tím
                        e.CellStyle.Font = new Font(dgvPatients.Font, FontStyle.Bold);
                        break;
                }
            }
        }

        private void UpdateStatistics()
        {
            var list = HospitalDataStore.Patients;
            int total = list.Count;
            int treating = list.Count(p => p.TreatmentStatus == "Đang điều trị");
            int waiting = list.Count(p => p.TreatmentStatus == "Chờ phẫu thuật");
            int discharged = list.Count(p => p.TreatmentStatus == "Đã xuất viện");

            lblStatTotal.Text = $"Tổng số hồ sơ: {total} ca";
            lblStatTreating.Text = $"Đang điều trị: {treating} ca";
            lblStatWaiting.Text = $"Chờ phẫu thuật: {waiting} ca";
            lblStatDischarged.Text = $"Đã xuất viện: {discharged} ca";
        }

        #endregion

        #region Các Tác vụ CRUD Hồ sơ Bệnh nhân

        private bool ValidateInput(bool isCreatingNew)
        {
            bool isValid = true;
            errorProvider1.Clear();

            // 1. Kiểm tra Mã BN
            string pid = txtPatientId.Text.Trim();
            if (string.IsNullOrWhiteSpace(pid))
            {
                errorProvider1.SetError(txtPatientId, "Vui lòng nhập hoặc nhấn 'Tạo mã' để có Mã bệnh nhân!");
                isValid = false;
            }
            else if (isCreatingNew && HospitalDataStore.Patients.Any(p => p.PatientId.Equals(pid, StringComparison.OrdinalIgnoreCase)))
            {
                errorProvider1.SetError(txtPatientId, "Mã bệnh nhân này đã tồn tại trong hệ thống!");
                isValid = false;
            }

            // 2. Kiểm tra Họ và Tên
            string name = txtFullName.Text.Trim();
            if (string.IsNullOrWhiteSpace(name))
            {
                errorProvider1.SetError(txtFullName, "Họ và tên bệnh nhân không được để trống!");
                isValid = false;
            }
            else if (name.Length < 2)
            {
                errorProvider1.SetError(txtFullName, "Họ và tên bệnh nhân phải có ít nhất 2 ký tự!");
                isValid = false;
            }

            // 3. Kiểm tra Số điện thoại
            string phone = txtPhone.Text.Trim();
            if (string.IsNullOrWhiteSpace(phone))
            {
                errorProvider1.SetError(txtPhone, "Vui lòng nhập số điện thoại liên hệ!");
                isValid = false;
            }
            else if (!Regex.IsMatch(phone, @"^(0|\+84)[0-9]{9,10}$"))
            {
                errorProvider1.SetError(txtPhone, "Số điện thoại không hợp lệ (Phải là 10-11 số, bắt đầu bằng 0 hoặc +84)!");
                isValid = false;
            }

            // 4. Kiểm tra Ngày sinh
            if (dtpDob.Value.Date > DateTime.Today)
            {
                errorProvider1.SetError(dtpDob, "Ngày sinh không được vượt quá ngày hiện tại!");
                isValid = false;
            }

            // 5. Kiểm tra Ngày nhập viện
            if (dtpAdmissionDate.Value.Date > DateTime.Today)
            {
                errorProvider1.SetError(dtpAdmissionDate, "Ngày nhập viện không thể ở tương lai!");
                isValid = false;
            }

            return isValid;
        }

        private void BtnAdd_Click(object? sender, EventArgs e)
        {
            if (!ValidateInput(isCreatingNew: true))
            {
                MessageBox.Show("Dữ liệu nhập chưa hợp lệ! Vui lòng kiểm tra các vị trí báo lỗi màu đỏ.", "Thông báo kiểm tra dữ liệu", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            var newPatient = new Patient
            {
                PatientId = txtPatientId.Text.Trim().ToUpper(),
                FullName = txtFullName.Text.Trim(),
                Gender = cboGender.SelectedItem?.ToString() ?? "Nam",
                DateOfBirth = dtpDob.Value.Date,
                Phone = txtPhone.Text.Trim(),
                Address = txtAddress.Text.Trim(),
                Department = cboDepartment.SelectedItem?.ToString() ?? string.Empty,
                BedNumber = txtBedNumber.Text.Trim(),
                AdmissionDate = dtpAdmissionDate.Value.Date,
                DoctorInCharge = cboDoctor.SelectedItem?.ToString() ?? string.Empty,
                TreatmentStatus = cboTreatmentStatus.SelectedItem?.ToString() ?? "Đang điều trị",
                Diagnosis = txtDiagnosis.Text.Trim()
            };

            HospitalDataStore.Patients.Add(newPatient);

            // Đồng bộ dữ liệu hiển thị
            _bindingSource.DataSource = HospitalDataStore.Patients;
            _bindingSource.ResetBindings(false);
            UpdateStatistics();

            // Chọn ngay dòng vừa thêm
            int index = HospitalDataStore.Patients.IndexOf(newPatient);
            if (index >= 0)
            {
                _bindingSource.Position = index;
            }

            MessageBox.Show($"Thêm hồ sơ bệnh nhân [{newPatient.PatientId}] - {newPatient.FullName} thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void BtnEdit_Click(object? sender, EventArgs e)
        {
            if (dgvPatients.CurrentRow?.DataBoundItem is not Patient selectedPatient)
            {
                MessageBox.Show("Vui lòng chọn một hồ sơ bệnh nhân từ danh sách để cập nhật!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            if (!ValidateInput(isCreatingNew: false))
            {
                MessageBox.Show("Dữ liệu cập nhật chưa hợp lệ! Vui lòng kiểm tra các vị trí cảnh báo.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            selectedPatient.FullName = txtFullName.Text.Trim();
            selectedPatient.Gender = cboGender.SelectedItem?.ToString() ?? "Nam";
            selectedPatient.DateOfBirth = dtpDob.Value.Date;
            selectedPatient.Phone = txtPhone.Text.Trim();
            selectedPatient.Address = txtAddress.Text.Trim();
            selectedPatient.Department = cboDepartment.SelectedItem?.ToString() ?? string.Empty;
            selectedPatient.BedNumber = txtBedNumber.Text.Trim();
            selectedPatient.AdmissionDate = dtpAdmissionDate.Value.Date;
            selectedPatient.DoctorInCharge = cboDoctor.SelectedItem?.ToString() ?? string.Empty;
            selectedPatient.TreatmentStatus = cboTreatmentStatus.SelectedItem?.ToString() ?? "Đang điều trị";
            selectedPatient.Diagnosis = txtDiagnosis.Text.Trim();

            _bindingSource.ResetBindings(false);
            UpdateStatistics();

            MessageBox.Show($"Cập nhật hồ sơ bệnh nhân [{selectedPatient.PatientId}] thành công!", "Thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void BtnDelete_Click(object? sender, EventArgs e)
        {
            if (dgvPatients.CurrentRow?.DataBoundItem is not Patient selectedPatient)
            {
                MessageBox.Show("Vui lòng chọn hồ sơ bệnh nhân cần xóa khỏi danh sách!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            var dialogResult = MessageBox.Show(
                $"Bạn có chắc chắn muốn xóa vĩnh viễn hồ sơ bệnh nhân:\n\n" +
                $"• Mã BN: {selectedPatient.PatientId}\n" +
                $"• Họ tên: {selectedPatient.FullName}\n" +
                $"• Khoa điều trị: {selectedPatient.Department}\n\n" +
                $"Hành động này không thể hoàn tác!",
                "Xác nhận xóa hồ sơ bệnh án",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question);

            if (dialogResult == DialogResult.Yes)
            {
                HospitalDataStore.Patients.Remove(selectedPatient);
                _bindingSource.DataSource = HospitalDataStore.Patients;
                _bindingSource.ResetBindings(false);
                UpdateStatistics();

                if (HospitalDataStore.Patients.Count > 0)
                {
                    _bindingSource.Position = 0;
                    DisplayPatientToControls(HospitalDataStore.Patients[0]);
                }
                else
                {
                    BtnReset_Click(this, EventArgs.Empty);
                }

                MessageBox.Show("Đã xóa hồ sơ bệnh nhân thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void BtnReset_Click(object? sender, EventArgs e)
        {
            _isResetting = true;
            try
            {
                errorProvider1.Clear();
                txtPatientId.ReadOnly = false;
                btnAutoId.Enabled = true;

                txtPatientId.Text = GenerateNextPatientId();
                txtFullName.Clear();
                if (cboGender.Items.Count > 0) cboGender.SelectedIndex = 0;
                dtpDob.Value = new DateTime(1990, 1, 1);
                txtPhone.Clear();
                txtAddress.Clear();
                if (cboDepartment.Items.Count > 0) cboDepartment.SelectedIndex = 0;
                txtBedNumber.Text = "P101-G01";
                dtpAdmissionDate.Value = DateTime.Today;
                if (cboDoctor.Items.Count > 0) cboDoctor.SelectedIndex = 0;
                if (cboTreatmentStatus.Items.Count > 0) cboTreatmentStatus.SelectedIndex = 0;
                txtDiagnosis.Clear();

                dgvPatients.ClearSelection();
                txtFullName.Focus();
            }
            finally
            {
                _isResetting = false;
            }
        }

        private string GenerateNextPatientId()
        {
            int maxId = 0;
            foreach (var p in HospitalDataStore.Patients)
            {
                if (p.PatientId.StartsWith("BN", StringComparison.OrdinalIgnoreCase))
                {
                    if (int.TryParse(p.PatientId.Substring(2), out int num))
                    {
                        if (num > maxId) maxId = num;
                    }
                }
            }
            return $"BN{(maxId + 1):D3}";
        }

        #endregion

        #region Tìm kiếm và Lọc dữ liệu

        private void BtnSearch_Click(object? sender, EventArgs e)
        {
            string keyword = txtSearchKeyword.Text.Trim().ToLower();
            string selectedDept = cboFilterDept.SelectedItem?.ToString() ?? "--- Tất cả Khoa ---";
            string selectedStatus = cboFilterStatus.SelectedItem?.ToString() ?? "--- Tất cả Tình trạng ---";

            var filtered = HospitalDataStore.Patients.Where(p =>
            {
                // Kiểm tra từ khóa (Mã BN, Họ tên, SĐT)
                bool matchKeyword = string.IsNullOrEmpty(keyword)
                    || p.PatientId.ToLower().Contains(keyword)
                    || p.FullName.ToLower().Contains(keyword)
                    || p.Phone.Contains(keyword);

                // Kiểm tra Khoa
                bool matchDept = selectedDept == "--- Tất cả Khoa ---"
                    || p.Department.Equals(selectedDept, StringComparison.OrdinalIgnoreCase);

                // Kiểm tra Tình trạng
                bool matchStatus = selectedStatus == "--- Tất cả Tình trạng ---"
                    || p.TreatmentStatus.Equals(selectedStatus, StringComparison.OrdinalIgnoreCase);

                return matchKeyword && matchDept && matchStatus;
            }).ToList();

            _bindingSource.DataSource = new BindingList<Patient>(filtered);
            _bindingSource.ResetBindings(false);

            if (filtered.Count > 0)
            {
                DisplayPatientToControls(filtered[0]);
            }
            else
            {
                MessageBox.Show("Không tìm thấy hồ sơ bệnh nhân nào phù hợp với điều kiện lọc!", "Kết quả tìm kiếm", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void BtnResetFilter_Click(object? sender, EventArgs e)
        {
            txtSearchKeyword.Clear();
            cboFilterDept.SelectedIndex = 0;
            cboFilterStatus.SelectedIndex = 0;

            _bindingSource.DataSource = HospitalDataStore.Patients;
            _bindingSource.ResetBindings(false);

            if (HospitalDataStore.Patients.Count > 0)
            {
                _bindingSource.Position = 0;
                DisplayPatientToControls(HospitalDataStore.Patients[0]);
            }
        }

        #endregion

        #region Trích lục Bệnh án (Xem chi tiết)

        private void BtnViewRecord_Click(object? sender, EventArgs e)
        {
            if (dgvPatients.CurrentRow?.DataBoundItem is not Patient patient)
            {
                MessageBox.Show("Vui lòng chọn một hồ sơ bệnh nhân để trích lục bệnh án!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            string recordDetails =
                $"========================================================\n" +
                $"           BỆNH VIỆN ĐA KHOA TRUNG TÂM\n" +
                $"         TRÍCH LỤC HỒ SƠ BỆNH ÁN NỘI TRÚ\n" +
                $"========================================================\n\n" +
                $"1. THÔNG TIN HÀNH CHÍNH:\n" +
                $"   • Mã Bệnh nhân: {patient.PatientId}\n" +
                $"   • Họ và tên: {patient.FullName.ToUpper()}\n" +
                $"   • Giới tính: {patient.Gender}       | Tuổi: {patient.Age} (Sinh ngày: {patient.DateOfBirth:dd/MM/yyyy})\n" +
                $"   • Số điện thoại: {patient.Phone}\n" +
                $"   • Địa chỉ liên hệ: {patient.Address}\n\n" +
                $"2. THÔNG TIN NHẬP VIỆN & ĐIỀU TRỊ:\n" +
                $"   • Ngày nhập viện: {patient.AdmissionDate:dd/MM/yyyy}\n" +
                $"   • Khoa điều trị: {patient.Department}\n" +
                $"   • Phòng / Giường bệnh: {patient.BedNumber}\n" +
                $"   • Bác sĩ điều trị phụ trách: {patient.DoctorInCharge}\n" +
                $"   • Tình trạng hiện tại: {patient.TreatmentStatus}\n\n" +
                $"3. CHẨN ĐOÁN Y KHOA & TIẾN TRÌNH BỆNH ÁN:\n" +
                $"   • Chẩn đoán: {patient.Diagnosis}\n\n" +
                $"========================================================\n" +
                $"Ngày trích xuất: {DateTime.Now:dd/MM/yyyy HH:mm:ss}\n" +
                $"BÁC SĨ ĐIỀU TRỊ XÁC NHẬN:\n" +
                $"   {patient.DoctorInCharge}\n" +
                $"========================================================";

            MessageBox.Show(recordDetails, $"Trích lục Hồ sơ Bệnh án - [{patient.PatientId}]", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        #endregion

        protected override void OnFormClosing(FormClosingEventArgs e)
        {
            base.OnFormClosing(e);
            HospitalDataStore.DataReloaded -= HospitalDataStore_DataReloaded;
        }
    }
}
