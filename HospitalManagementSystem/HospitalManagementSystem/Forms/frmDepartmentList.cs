using System;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using HospitalManagementSystem.Data;
using HospitalManagementSystem.Models;

namespace HospitalManagementSystem.Forms
{
    public partial class frmDepartmentList : Form
    {
        private readonly BindingSource _bindingSource = new BindingSource();
        private bool _isResetting = false;

        public frmDepartmentList()
        {
            InitializeComponent();
            InitFormComponents();
        }

        #region Khởi tạo Giao diện và Dữ liệu

        private void InitFormComponents()
        {
            PopulateHeadDoctors();
            ConfigureDataGridView();

            _bindingSource.DataSource = HospitalDataStore.Departments;
            dgvDepartments.DataSource = _bindingSource;

            RegisterEvents();

            if (HospitalDataStore.Departments.Count > 0)
            {
                DisplayDepartmentToControls(HospitalDataStore.Departments[0]);
            }
            else
            {
                BtnReset_Click(this, EventArgs.Empty);
            }
        }

        private void PopulateHeadDoctors()
        {
            cboHeadDoctor.Items.Clear();
            foreach (var doc in HospitalDataStore.DoctorNames)
            {
                cboHeadDoctor.Items.Add(doc);
            }
            if (cboHeadDoctor.Items.Count > 0) cboHeadDoctor.SelectedIndex = 0;
        }

        private void ConfigureDataGridView()
        {
            dgvDepartments.AutoGenerateColumns = false;
            dgvDepartments.AllowUserToAddRows = false;
            dgvDepartments.AllowUserToDeleteRows = false;
            dgvDepartments.ReadOnly = true;
            dgvDepartments.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvDepartments.MultiSelect = false;
            dgvDepartments.BackgroundColor = Color.White;
            dgvDepartments.BorderStyle = BorderStyle.Fixed3D;
            dgvDepartments.RowHeadersVisible = false;
            dgvDepartments.EnableHeadersVisualStyles = false;

            dgvDepartments.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(50, 80, 140);
            dgvDepartments.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
            dgvDepartments.ColumnHeadersDefaultCellStyle.Font = new Font("Segoe UI", 9.5F, FontStyle.Bold);
            dgvDepartments.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgvDepartments.ColumnHeadersHeight = 35;

            dgvDepartments.DefaultCellStyle.Font = new Font("Segoe UI", 9F, FontStyle.Regular);
            dgvDepartments.DefaultCellStyle.SelectionBackColor = Color.FromArgb(210, 225, 255);
            dgvDepartments.DefaultCellStyle.SelectionForeColor = Color.Black;
            dgvDepartments.AlternatingRowsDefaultCellStyle.BackColor = Color.FromArgb(248, 250, 255);

            dgvDepartments.Columns.Clear();

            // Cột 1: Mã khoa
            var colId = new DataGridViewTextBoxColumn
            {
                DataPropertyName = "DepartmentId",
                HeaderText = "Mã Khoa",
                Width = 90,
                DefaultCellStyle = { Alignment = DataGridViewContentAlignment.MiddleCenter, Font = new Font("Segoe UI", 9F, FontStyle.Bold) }
            };
            dgvDepartments.Columns.Add(colId);

            // Cột 2: Tên khoa
            var colName = new DataGridViewTextBoxColumn
            {
                DataPropertyName = "DepartmentName",
                HeaderText = "Tên Khoa / Phòng Chuyên môn",
                Width = 240
            };
            dgvDepartments.Columns.Add(colName);

            // Cột 3: Trưởng khoa
            var colHead = new DataGridViewTextBoxColumn
            {
                DataPropertyName = "HeadDoctor",
                HeaderText = "Trưởng khoa",
                Width = 190
            };
            dgvDepartments.Columns.Add(colHead);

            // Cột 4: Vị trí
            var colLoc = new DataGridViewTextBoxColumn
            {
                DataPropertyName = "Location",
                HeaderText = "Vị trí tòa nhà/tầng",
                Width = 160
            };
            dgvDepartments.Columns.Add(colLoc);

            // Cột 5: Chỉ tiêu giường
            var colBeds = new DataGridViewTextBoxColumn
            {
                DataPropertyName = "TotalBeds",
                HeaderText = "Chỉ tiêu giường",
                Width = 110,
                DefaultCellStyle = { Alignment = DataGridViewContentAlignment.MiddleCenter }
            };
            dgvDepartments.Columns.Add(colBeds);

            // Cột 6: Hotline
            var colHotline = new DataGridViewTextBoxColumn
            {
                DataPropertyName = "Hotline",
                HeaderText = "Đường dây nóng / Nội bộ",
                AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill,
                DefaultCellStyle = { Alignment = DataGridViewContentAlignment.MiddleCenter }
            };
            dgvDepartments.Columns.Add(colHotline);
        }

        private void RegisterEvents()
        {
            dgvDepartments.SelectionChanged += DgvDepartments_SelectionChanged;

            btnAdd.Click += BtnAdd_Click;
            btnEdit.Click += BtnEdit_Click;
            btnDelete.Click += BtnDelete_Click;
            btnReset.Click += BtnReset_Click;
            btnAutoId.Click += (s, e) => txtDeptId.Text = GenerateNextDepartmentId();

            btnSearch.Click += BtnSearch_Click;
            btnResetSearch.Click += BtnResetSearch_Click;
            txtSearch.KeyDown += (s, e) => { if (e.KeyCode == Keys.Enter) { e.SuppressKeyPress = true; BtnSearch_Click(s, e); } };

            txtDeptId.TextChanged += (s, e) => errorProvider1.SetError(txtDeptId, string.Empty);
            txtDeptName.TextChanged += (s, e) => errorProvider1.SetError(txtDeptName, string.Empty);

            HospitalDataStore.DataReloaded += HospitalDataStore_DataReloaded;
        }

        private void HospitalDataStore_DataReloaded()
        {
            if (this.IsDisposed) return;
            PopulateHeadDoctors();
            _bindingSource.DataSource = HospitalDataStore.Departments;
            _bindingSource.ResetBindings(false);
            if (HospitalDataStore.Departments.Count > 0)
            {
                DisplayDepartmentToControls(HospitalDataStore.Departments[0]);
            }
        }

        #endregion

        #region Xử lý hiển thị

        private void DgvDepartments_SelectionChanged(object? sender, EventArgs e)
        {
            if (_isResetting) return;

            if (dgvDepartments.CurrentRow?.DataBoundItem is Department dept)
            {
                DisplayDepartmentToControls(dept);
            }
        }

        private void DisplayDepartmentToControls(Department dept)
        {
            txtDeptId.Text = dept.DepartmentId;
            txtDeptName.Text = dept.DepartmentName;

            if (cboHeadDoctor.Items.Contains(dept.HeadDoctor))
                cboHeadDoctor.SelectedItem = dept.HeadDoctor;

            txtLocation.Text = dept.Location;
            nudBeds.Value = Math.Clamp(dept.TotalBeds, nudBeds.Minimum, nudBeds.Maximum);
            txtHotline.Text = dept.Hotline;

            txtDeptId.ReadOnly = true;
            btnAutoId.Enabled = false;
        }

        #endregion

        #region Tác vụ CRUD

        private bool ValidateInput(bool isCreatingNew)
        {
            bool isValid = true;
            errorProvider1.Clear();

            string did = txtDeptId.Text.Trim();
            if (string.IsNullOrWhiteSpace(did))
            {
                errorProvider1.SetError(txtDeptId, "Vui lòng nhập hoặc nhấn 'Tạo mã' để có Mã khoa!");
                isValid = false;
            }
            else if (isCreatingNew && HospitalDataStore.Departments.Any(d => d.DepartmentId.Equals(did, StringComparison.OrdinalIgnoreCase)))
            {
                errorProvider1.SetError(txtDeptId, "Mã khoa này đã tồn tại trong hệ thống!");
                isValid = false;
            }

            if (string.IsNullOrWhiteSpace(txtDeptName.Text.Trim()))
            {
                errorProvider1.SetError(txtDeptName, "Tên khoa/phòng không được để trống!");
                isValid = false;
            }

            return isValid;
        }

        private void BtnAdd_Click(object? sender, EventArgs e)
        {
            if (!ValidateInput(isCreatingNew: true))
            {
                MessageBox.Show("Dữ liệu khoa/phòng chưa hợp lệ! Vui lòng kiểm tra lại.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            var newDept = new Department
            {
                DepartmentId = txtDeptId.Text.Trim().ToUpper(),
                DepartmentName = txtDeptName.Text.Trim(),
                HeadDoctor = cboHeadDoctor.SelectedItem?.ToString() ?? string.Empty,
                Location = txtLocation.Text.Trim(),
                TotalBeds = (int)nudBeds.Value,
                Hotline = txtHotline.Text.Trim()
            };

            HospitalDataStore.Departments.Add(newDept);
            _bindingSource.DataSource = HospitalDataStore.Departments;
            _bindingSource.ResetBindings(false);

            int idx = HospitalDataStore.Departments.IndexOf(newDept);
            if (idx >= 0) _bindingSource.Position = idx;

            MessageBox.Show($"Thêm khoa [{newDept.DepartmentId}] - {newDept.DepartmentName} thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void BtnEdit_Click(object? sender, EventArgs e)
        {
            if (dgvDepartments.CurrentRow?.DataBoundItem is not Department selected)
            {
                MessageBox.Show("Vui lòng chọn khoa/phòng cần cập nhật từ danh sách!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            if (!ValidateInput(isCreatingNew: false))
            {
                MessageBox.Show("Dữ liệu cập nhật chưa hợp lệ!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            selected.DepartmentName = txtDeptName.Text.Trim();
            selected.HeadDoctor = cboHeadDoctor.SelectedItem?.ToString() ?? string.Empty;
            selected.Location = txtLocation.Text.Trim();
            selected.TotalBeds = (int)nudBeds.Value;
            selected.Hotline = txtHotline.Text.Trim();

            _bindingSource.ResetBindings(false);
            MessageBox.Show($"Cập nhật khoa [{selected.DepartmentId}] thành công!", "Thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void BtnDelete_Click(object? sender, EventArgs e)
        {
            if (dgvDepartments.CurrentRow?.DataBoundItem is not Department selected)
            {
                MessageBox.Show("Vui lòng chọn khoa/phòng cần xóa khỏi danh sách!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            // Kiểm tra ràng buộc xem có bệnh nhân đang nằm điều trị tại khoa này không
            int patientCount = HospitalDataStore.Patients.Count(p => p.Department.Equals(selected.DepartmentName, StringComparison.OrdinalIgnoreCase));
            if (patientCount > 0)
            {
                MessageBox.Show(
                    $"Không thể xóa khoa [{selected.DepartmentName}] vì hiện đang có {patientCount} bệnh nhân điều trị!\n" +
                    $"Vui lòng chuyển bệnh nhân sang khoa khác trước khi xóa.",
                    "Ràng buộc nghiệp vụ",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);
                return;
            }

            var res = MessageBox.Show(
                $"Bạn có chắc chắn muốn xóa khoa [{selected.DepartmentId}] - {selected.DepartmentName}?",
                "Xác nhận xóa",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question);

            if (res == DialogResult.Yes)
            {
                HospitalDataStore.Departments.Remove(selected);
                _bindingSource.DataSource = HospitalDataStore.Departments;
                _bindingSource.ResetBindings(false);

                if (HospitalDataStore.Departments.Count > 0)
                {
                    _bindingSource.Position = 0;
                    DisplayDepartmentToControls(HospitalDataStore.Departments[0]);
                }
                else
                {
                    BtnReset_Click(this, EventArgs.Empty);
                }

                MessageBox.Show("Đã xóa khoa thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void BtnReset_Click(object? sender, EventArgs e)
        {
            _isResetting = true;
            try
            {
                errorProvider1.Clear();
                txtDeptId.ReadOnly = false;
                btnAutoId.Enabled = true;

                txtDeptId.Text = GenerateNextDepartmentId();
                txtDeptName.Clear();
                if (cboHeadDoctor.Items.Count > 0) cboHeadDoctor.SelectedIndex = 0;
                txtLocation.Text = "Tòa A - Tầng 1";
                nudBeds.Value = 30;
                txtHotline.Text = "1900-1110";

                dgvDepartments.ClearSelection();
            }
            finally
            {
                _isResetting = false;
            }
        }

        private string GenerateNextDepartmentId()
        {
            int maxId = 0;
            foreach (var d in HospitalDataStore.Departments)
            {
                if (d.DepartmentId.StartsWith("K", StringComparison.OrdinalIgnoreCase))
                {
                    if (int.TryParse(d.DepartmentId.Substring(1), out int num))
                    {
                        if (num > maxId) maxId = num;
                    }
                }
            }
            return $"K{(maxId + 1):D2}";
        }

        #endregion

        #region Tìm kiếm

        private void BtnSearch_Click(object? sender, EventArgs e)
        {
            string keyword = txtSearch.Text.Trim().ToLower();
            if (string.IsNullOrEmpty(keyword))
            {
                _bindingSource.DataSource = HospitalDataStore.Departments;
                _bindingSource.ResetBindings(false);
                return;
            }

            var filtered = HospitalDataStore.Departments.Where(d =>
                d.DepartmentId.ToLower().Contains(keyword) ||
                d.DepartmentName.ToLower().Contains(keyword) ||
                d.HeadDoctor.ToLower().Contains(keyword) ||
                d.Location.ToLower().Contains(keyword)).ToList();

            _bindingSource.DataSource = new BindingList<Department>(filtered);
            _bindingSource.ResetBindings(false);

            if (filtered.Count > 0)
            {
                DisplayDepartmentToControls(filtered[0]);
            }
            else
            {
                MessageBox.Show("Không tìm thấy khoa/phòng phù hợp!", "Kết quả tìm", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void BtnResetSearch_Click(object? sender, EventArgs e)
        {
            txtSearch.Clear();
            _bindingSource.DataSource = HospitalDataStore.Departments;
            _bindingSource.ResetBindings(false);

            if (HospitalDataStore.Departments.Count > 0)
            {
                _bindingSource.Position = 0;
                DisplayDepartmentToControls(HospitalDataStore.Departments[0]);
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
