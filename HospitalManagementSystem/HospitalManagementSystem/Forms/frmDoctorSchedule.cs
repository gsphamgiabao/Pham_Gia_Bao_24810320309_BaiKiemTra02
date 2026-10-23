using System;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using HospitalManagementSystem.Data;
using HospitalManagementSystem.Models;

namespace HospitalManagementSystem.Forms
{
    public partial class frmDoctorSchedule : Form
    {
        private readonly BindingSource _bindingSource = new BindingSource();
        private bool _isResetting = false;

        public frmDoctorSchedule()
        {
            InitializeComponent();
            InitFormComponents();
        }

        #region Khởi tạo Giao diện và Dữ liệu

        private void InitFormComponents()
        {
            PopulateComboBoxes();
            ConfigureDataGridView();

            _bindingSource.DataSource = HospitalDataStore.Schedules;
            dgvSchedules.DataSource = _bindingSource;

            RegisterEvents();

            if (HospitalDataStore.Schedules.Count > 0)
            {
                DisplayScheduleToControls(HospitalDataStore.Schedules[0]);
            }
            else
            {
                BtnReset_Click(this, EventArgs.Empty);
            }
        }

        private void PopulateComboBoxes()
        {
            // Bác sĩ
            cboDoctor.Items.Clear();
            foreach (var doc in HospitalDataStore.DoctorNames)
            {
                cboDoctor.Items.Add(doc);
            }
            if (cboDoctor.Items.Count > 0) cboDoctor.SelectedIndex = 0;

            // Khoa
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

            // Ca trực
            string[] shifts =
            {
                "Ca sáng (07:00 - 15:00)",
                "Ca chiều (15:00 - 23:00)",
                "Ca đêm (23:00 - 07:00)"
            };
            cboShift.Items.Clear();
            cboShift.Items.AddRange(shifts);
            cboShift.SelectedIndex = 0;

            // Vai trò trực
            string[] roles =
            {
                "Trưởng kíp trực",
                "Trực chuyên môn",
                "Bác sĩ thường trực",
                "Bác sĩ phẫu thuật chính",
                "Bác sĩ hỗ trợ"
            };
            cboRole.Items.Clear();
            cboRole.Items.AddRange(roles);
            cboRole.SelectedIndex = 0;
        }

        private void ConfigureDataGridView()
        {
            dgvSchedules.AutoGenerateColumns = false;
            dgvSchedules.AllowUserToAddRows = false;
            dgvSchedules.AllowUserToDeleteRows = false;
            dgvSchedules.ReadOnly = true;
            dgvSchedules.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvSchedules.MultiSelect = false;
            dgvSchedules.BackgroundColor = Color.White;
            dgvSchedules.BorderStyle = BorderStyle.Fixed3D;
            dgvSchedules.RowHeadersVisible = false;
            dgvSchedules.EnableHeadersVisualStyles = false;

            dgvSchedules.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(16, 120, 95);
            dgvSchedules.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
            dgvSchedules.ColumnHeadersDefaultCellStyle.Font = new Font("Segoe UI", 9.5F, FontStyle.Bold);
            dgvSchedules.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgvSchedules.ColumnHeadersHeight = 35;

            dgvSchedules.DefaultCellStyle.Font = new Font("Segoe UI", 9F, FontStyle.Regular);
            dgvSchedules.DefaultCellStyle.SelectionBackColor = Color.FromArgb(200, 240, 230);
            dgvSchedules.DefaultCellStyle.SelectionForeColor = Color.Black;
            dgvSchedules.AlternatingRowsDefaultCellStyle.BackColor = Color.FromArgb(246, 252, 250);

            dgvSchedules.Columns.Clear();

            // Cột 1: Mã ca
            var colId = new DataGridViewTextBoxColumn
            {
                DataPropertyName = "ScheduleId",
                HeaderText = "Mã ca",
                Width = 85,
                DefaultCellStyle = { Alignment = DataGridViewContentAlignment.MiddleCenter, Font = new Font("Segoe UI", 9F, FontStyle.Bold) }
            };
            dgvSchedules.Columns.Add(colId);

            // Cột 2: Bác sĩ trực
            var colDoc = new DataGridViewTextBoxColumn
            {
                DataPropertyName = "DoctorName",
                HeaderText = "Bác sĩ trực",
                Width = 180
            };
            dgvSchedules.Columns.Add(colDoc);

            // Cột 3: Khoa công tác
            var colDept = new DataGridViewTextBoxColumn
            {
                DataPropertyName = "Department",
                HeaderText = "Khoa / Đơn vị trực",
                Width = 190
            };
            dgvSchedules.Columns.Add(colDept);

            // Cột 4: Ngày trực
            var colDate = new DataGridViewTextBoxColumn
            {
                DataPropertyName = "DutyDate",
                HeaderText = "Ngày trực",
                Width = 100,
                DefaultCellStyle = { Alignment = DataGridViewContentAlignment.MiddleCenter, Format = "dd/MM/yyyy" }
            };
            dgvSchedules.Columns.Add(colDate);

            // Cột 5: Ca trực
            var colShift = new DataGridViewTextBoxColumn
            {
                DataPropertyName = "Shift",
                HeaderText = "Ca trực",
                Width = 170,
                DefaultCellStyle = { Alignment = DataGridViewContentAlignment.MiddleCenter }
            };
            dgvSchedules.Columns.Add(colShift);

            // Cột 6: Phòng trực
            var colRoom = new DataGridViewTextBoxColumn
            {
                DataPropertyName = "DutyRoom",
                HeaderText = "Phòng trực",
                Width = 150
            };
            dgvSchedules.Columns.Add(colRoom);

            // Cột 7: Vai trò
            var colRole = new DataGridViewTextBoxColumn
            {
                DataPropertyName = "Role",
                HeaderText = "Vai trò",
                Width = 140,
                DefaultCellStyle = { Alignment = DataGridViewContentAlignment.MiddleCenter }
            };
            dgvSchedules.Columns.Add(colRole);

            // Cột 8: Ghi chú
            var colNote = new DataGridViewTextBoxColumn
            {
                DataPropertyName = "Note",
                HeaderText = "Nhiệm vụ / Ghi chú ca trực",
                AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
            };
            dgvSchedules.Columns.Add(colNote);
        }

        private void RegisterEvents()
        {
            dgvSchedules.SelectionChanged += DgvSchedules_SelectionChanged;
            dgvSchedules.CellFormatting += DgvSchedules_CellFormatting;

            btnAdd.Click += BtnAdd_Click;
            btnEdit.Click += BtnEdit_Click;
            btnDelete.Click += BtnDelete_Click;
            btnReset.Click += BtnReset_Click;
            btnAutoId.Click += (s, e) => txtScheduleId.Text = GenerateNextScheduleId();

            chkFilterDate.CheckedChanged += (s, e) => dtpFilterDate.Enabled = chkFilterDate.Checked;
            btnFilter.Click += BtnFilter_Click;
            btnResetFilter.Click += BtnResetFilter_Click;

            txtScheduleId.TextChanged += (s, e) => errorProvider1.SetError(txtScheduleId, string.Empty);
            txtDutyRoom.TextChanged += (s, e) => errorProvider1.SetError(txtDutyRoom, string.Empty);

            HospitalDataStore.DataReloaded += HospitalDataStore_DataReloaded;
        }

        private void HospitalDataStore_DataReloaded()
        {
            if (this.IsDisposed) return;
            PopulateComboBoxes();
            _bindingSource.DataSource = HospitalDataStore.Schedules;
            _bindingSource.ResetBindings(false);
            if (HospitalDataStore.Schedules.Count > 0)
            {
                DisplayScheduleToControls(HospitalDataStore.Schedules[0]);
            }
        }

        #endregion

        #region Xử lý hiển thị

        private void DgvSchedules_SelectionChanged(object? sender, EventArgs e)
        {
            if (_isResetting) return;

            if (dgvSchedules.CurrentRow?.DataBoundItem is DoctorSchedule schedule)
            {
                DisplayScheduleToControls(schedule);
            }
        }

        private void DisplayScheduleToControls(DoctorSchedule schedule)
        {
            txtScheduleId.Text = schedule.ScheduleId;

            if (cboDoctor.Items.Contains(schedule.DoctorName))
                cboDoctor.SelectedItem = schedule.DoctorName;

            if (cboDepartment.Items.Contains(schedule.Department))
                cboDepartment.SelectedItem = schedule.Department;

            if (schedule.DutyDate >= dtpDutyDate.MinDate && schedule.DutyDate <= dtpDutyDate.MaxDate)
                dtpDutyDate.Value = schedule.DutyDate;

            if (cboShift.Items.Contains(schedule.Shift))
                cboShift.SelectedItem = schedule.Shift;

            txtDutyRoom.Text = schedule.DutyRoom;

            if (cboRole.Items.Contains(schedule.Role))
                cboRole.SelectedItem = schedule.Role;

            txtNote.Text = schedule.Note;

            txtScheduleId.ReadOnly = true;
            btnAutoId.Enabled = false;
        }

        private void DgvSchedules_CellFormatting(object? sender, DataGridViewCellFormattingEventArgs e)
        {
            if (e.RowIndex < 0 || e.RowIndex >= dgvSchedules.Rows.Count) return;

            if (dgvSchedules.Columns[e.ColumnIndex].DataPropertyName == "Shift" && e.Value != null)
            {
                string shift = e.Value.ToString() ?? string.Empty;
                if (shift.Contains("đêm", StringComparison.OrdinalIgnoreCase))
                {
                    e.CellStyle.ForeColor = Color.FromArgb(220, 53, 69); // Đỏ cảnh báo ca đêm
                    e.CellStyle.Font = new Font(dgvSchedules.Font, FontStyle.Bold);
                }
                else if (shift.Contains("chiều", StringComparison.OrdinalIgnoreCase))
                {
                    e.CellStyle.ForeColor = Color.FromArgb(253, 126, 20); // Cam
                }
                else
                {
                    e.CellStyle.ForeColor = Color.FromArgb(16, 120, 95); // Xanh ngọc
                }
            }
        }

        #endregion

        #region Tác vụ CRUD

        private bool ValidateInput(bool isCreatingNew)
        {
            bool isValid = true;
            errorProvider1.Clear();

            string sid = txtScheduleId.Text.Trim();
            if (string.IsNullOrWhiteSpace(sid))
            {
                errorProvider1.SetError(txtScheduleId, "Vui lòng nhập hoặc nhấn 'Tạo mã' để có Mã ca trực!");
                isValid = false;
            }
            else if (isCreatingNew && HospitalDataStore.Schedules.Any(s => s.ScheduleId.Equals(sid, StringComparison.OrdinalIgnoreCase)))
            {
                errorProvider1.SetError(txtScheduleId, "Mã ca trực này đã tồn tại trong hệ thống!");
                isValid = false;
            }

            if (string.IsNullOrWhiteSpace(txtDutyRoom.Text.Trim()))
            {
                errorProvider1.SetError(txtDutyRoom, "Vui lòng nhập Phòng trực / Địa điểm phân công!");
                isValid = false;
            }

            return isValid;
        }

        private void BtnAdd_Click(object? sender, EventArgs e)
        {
            if (!ValidateInput(isCreatingNew: true))
            {
                MessageBox.Show("Dữ liệu ca trực chưa hợp lệ! Vui lòng kiểm tra lại.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            var newSchedule = new DoctorSchedule
            {
                ScheduleId = txtScheduleId.Text.Trim().ToUpper(),
                DoctorId = "BS" + (cboDoctor.SelectedIndex + 1).ToString("D2"),
                DoctorName = cboDoctor.SelectedItem?.ToString() ?? string.Empty,
                Department = cboDepartment.SelectedItem?.ToString() ?? string.Empty,
                DutyDate = dtpDutyDate.Value.Date,
                Shift = cboShift.SelectedItem?.ToString() ?? "Ca sáng (07:00 - 15:00)",
                DutyRoom = txtDutyRoom.Text.Trim(),
                Role = cboRole.SelectedItem?.ToString() ?? "Trực chuyên môn",
                Note = txtNote.Text.Trim()
            };

            HospitalDataStore.Schedules.Add(newSchedule);
            _bindingSource.DataSource = HospitalDataStore.Schedules;
            _bindingSource.ResetBindings(false);

            int idx = HospitalDataStore.Schedules.IndexOf(newSchedule);
            if (idx >= 0) _bindingSource.Position = idx;

            MessageBox.Show($"Thêm lịch trực [{newSchedule.ScheduleId}] cho {newSchedule.DoctorName} thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void BtnEdit_Click(object? sender, EventArgs e)
        {
            if (dgvSchedules.CurrentRow?.DataBoundItem is not DoctorSchedule selected)
            {
                MessageBox.Show("Vui lòng chọn ca trực cần chỉnh sửa từ bảng!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            if (!ValidateInput(isCreatingNew: false))
            {
                MessageBox.Show("Dữ liệu ca trực chưa hợp lệ!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            selected.DoctorName = cboDoctor.SelectedItem?.ToString() ?? string.Empty;
            selected.Department = cboDepartment.SelectedItem?.ToString() ?? string.Empty;
            selected.DutyDate = dtpDutyDate.Value.Date;
            selected.Shift = cboShift.SelectedItem?.ToString() ?? "Ca sáng (07:00 - 15:00)";
            selected.DutyRoom = txtDutyRoom.Text.Trim();
            selected.Role = cboRole.SelectedItem?.ToString() ?? "Trực chuyên môn";
            selected.Note = txtNote.Text.Trim();

            _bindingSource.ResetBindings(false);
            MessageBox.Show($"Cập nhật ca trực [{selected.ScheduleId}] thành công!", "Thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void BtnDelete_Click(object? sender, EventArgs e)
        {
            if (dgvSchedules.CurrentRow?.DataBoundItem is not DoctorSchedule selected)
            {
                MessageBox.Show("Vui lòng chọn ca trực cần hủy khỏi bảng!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            var res = MessageBox.Show(
                $"Bạn có chắc chắn muốn hủy ca trực:\n\n" +
                $"• Mã ca: {selected.ScheduleId}\n" +
                $"• Bác sĩ: {selected.DoctorName}\n" +
                $"• Ngày trực: {selected.DutyDate:dd/MM/yyyy} ({selected.Shift})\n\n" +
                $"Hành động này không thể hoàn tác!",
                "Xác nhận hủy phân công ca trực",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question);

            if (res == DialogResult.Yes)
            {
                HospitalDataStore.Schedules.Remove(selected);
                _bindingSource.DataSource = HospitalDataStore.Schedules;
                _bindingSource.ResetBindings(false);

                if (HospitalDataStore.Schedules.Count > 0)
                {
                    _bindingSource.Position = 0;
                    DisplayScheduleToControls(HospitalDataStore.Schedules[0]);
                }
                else
                {
                    BtnReset_Click(this, EventArgs.Empty);
                }

                MessageBox.Show("Đã hủy ca trực thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void BtnReset_Click(object? sender, EventArgs e)
        {
            _isResetting = true;
            try
            {
                errorProvider1.Clear();
                txtScheduleId.ReadOnly = false;
                btnAutoId.Enabled = true;

                txtScheduleId.Text = GenerateNextScheduleId();
                if (cboDoctor.Items.Count > 0) cboDoctor.SelectedIndex = 0;
                if (cboDepartment.Items.Count > 0) cboDepartment.SelectedIndex = 0;
                dtpDutyDate.Value = DateTime.Today;
                if (cboShift.Items.Count > 0) cboShift.SelectedIndex = 0;
                txtDutyRoom.Text = "Phòng Cấp cứu 1 - Tòa A";
                if (cboRole.Items.Count > 0) cboRole.SelectedIndex = 0;
                txtNote.Clear();

                dgvSchedules.ClearSelection();
            }
            finally
            {
                _isResetting = false;
            }
        }

        private string GenerateNextScheduleId()
        {
            int maxId = 0;
            foreach (var s in HospitalDataStore.Schedules)
            {
                if (s.ScheduleId.StartsWith("LT", StringComparison.OrdinalIgnoreCase))
                {
                    if (int.TryParse(s.ScheduleId.Substring(2), out int num))
                    {
                        if (num > maxId) maxId = num;
                    }
                }
            }
            return $"LT{(maxId + 1):D3}";
        }

        #endregion

        #region Bộ lọc ca trực

        private void BtnFilter_Click(object? sender, EventArgs e)
        {
            string selectedDept = cboFilterDept.SelectedItem?.ToString() ?? "--- Tất cả Khoa ---";
            bool filterDate = chkFilterDate.Checked;
            DateTime targetDate = dtpFilterDate.Value.Date;

            var filtered = HospitalDataStore.Schedules.Where(s =>
            {
                bool matchDept = selectedDept == "--- Tất cả Khoa ---"
                    || s.Department.Equals(selectedDept, StringComparison.OrdinalIgnoreCase);

                bool matchDate = !filterDate || s.DutyDate.Date == targetDate;

                return matchDept && matchDate;
            }).ToList();

            _bindingSource.DataSource = new BindingList<DoctorSchedule>(filtered);
            _bindingSource.ResetBindings(false);

            if (filtered.Count > 0)
            {
                DisplayScheduleToControls(filtered[0]);
            }
            else
            {
                MessageBox.Show("Không tìm thấy ca trực nào phù hợp với bộ lọc!", "Kết quả lọc", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void BtnResetFilter_Click(object? sender, EventArgs e)
        {
            chkFilterDate.Checked = false;
            cboFilterDept.SelectedIndex = 0;

            _bindingSource.DataSource = HospitalDataStore.Schedules;
            _bindingSource.ResetBindings(false);

            if (HospitalDataStore.Schedules.Count > 0)
            {
                _bindingSource.Position = 0;
                DisplayScheduleToControls(HospitalDataStore.Schedules[0]);
            }
        }

        #endregion

        protected override void OnFormClosing(FormClosingEventArgs e)
        {
            base.OnFormClosing(e);
            HospitalDataStore.DataReloaded -= HospitalDataStore_DataReloaded;
        }
    }
}
