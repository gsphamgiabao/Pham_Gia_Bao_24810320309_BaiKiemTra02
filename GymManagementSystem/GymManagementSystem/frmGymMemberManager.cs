using System;
using System.ComponentModel;
using System.Drawing;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace GymManagementSystem
{
    public partial class frmGymMemberManager : Form
    {
        // 1. Quản lý trạng thái dữ liệu đồng bộ 2 chiều bằng BindingList<T> và BindingSource
        private readonly BindingList<GymMember> _memberList = new BindingList<GymMember>();
        private readonly BindingSource _bindingSource = new BindingSource();
        private bool _isResetting = false;

        public frmGymMemberManager()
        {
            InitializeComponent();
            InitDataAndBindings();
        }

        /// <summary>
        /// Khởi tạo dữ liệu ban đầu, cấu hình DataGridView bằng code và thiết lập Binding
        /// </summary>
        private void InitDataAndBindings()
        {
            // Cấu hình các mục cho ComboBox gói tập
            cboPackage.Items.Clear();
            cboPackage.Items.Add("Theo tháng");
            cboPackage.Items.Add("6 tháng");
            cboPackage.Items.Add("1 năm");
            cboPackage.SelectedIndex = 0;

            // Định dạng DateTimePicker hiển thị ngày tháng năm chuẩn Việt Nam
            dtpStartDate.Format = DateTimePickerFormat.Custom;
            dtpStartDate.CustomFormat = "dd/MM/yyyy";
            dtpStartDate.Value = DateTime.Today;

            // 1. Cấu hình DataGridView HOÀN TOÀN BẰNG CODE (AutoGenerateColumns = false)
            ConfigureDataGridView();

            // Nạp dữ liệu mẫu ban đầu để kiểm thử
            SeedInitialData();

            // Thiết lập BindingSource kết nối với BindingList
            _bindingSource.DataSource = _memberList;
            dgvMembers.DataSource = _bindingSource;

            // Đăng ký các sự kiện tương tác
            dgvMembers.SelectionChanged += DgvMembers_SelectionChanged;
            dgvMembers.CellFormatting += DgvMembers_CellFormatting;

            btnAdd.Click += BtnAdd_Click;
            btnEdit.Click += BtnEdit_Click;
            btnDelete.Click += BtnDelete_Click;
            btnReset.Click += BtnReset_Click;

            cboPackage.SelectedIndexChanged += CboPackage_SelectedIndexChanged;

            // Tự động xóa lỗi ErrorProvider khi người dùng nhập dữ liệu hợp lệ
            txtFullName.TextChanged += (s, e) =>
            {
                if (!string.IsNullOrWhiteSpace(txtFullName.Text) && Regex.IsMatch(txtFullName.Text.Trim(), @"^[\p{L}\s]+$"))
                {
                    errorProvider1.SetError(txtFullName, string.Empty);
                }
            };

            txtPhone.TextChanged += (s, e) =>
            {
                if (Regex.IsMatch(txtPhone.Text.Trim(), @"^\d{10}$"))
                {
                    errorProvider1.SetError(txtPhone, string.Empty);
                }
            };

            txtFee.TextChanged += (s, e) =>
            {
                string feeClean = txtFee.Text.Trim().Replace(",", "").Replace(".", "");
                if (long.TryParse(feeClean, out long feeVal) && feeVal > 0)
                {
                    errorProvider1.SetError(txtFee, string.Empty);
                }
            };

            // Cập nhật trạng thái và hiển thị dữ liệu dòng đầu tiên (nếu có)
            UpdateStatus();
            if (_memberList.Count > 0)
            {
                _bindingSource.Position = 0;
                DisplayMemberToControls(_memberList[0]);
            }
            else
            {
                BtnReset_Click(this, EventArgs.Empty);
            }
        }

        #region 1. Thiết lập Grid bằng Code

        /// <summary>
        /// Yêu cầu 1 & 3: Tuyệt đối không dùng giao diện design để tự sinh cột.
        /// Khai báo và cấu hình DataGridView chuẩn hoàn toàn bằng code (AutoGenerateColumns = false).
        /// Gán DataPropertyName chính xác với property của class Model.
        /// </summary>
        private void ConfigureDataGridView()
        {
            dgvMembers.AutoGenerateColumns = false;
            dgvMembers.Columns.Clear();

            // Cấu hình hiển thị và chế độ chọn
            dgvMembers.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvMembers.MultiSelect = false;
            dgvMembers.ReadOnly = true;
            dgvMembers.AllowUserToAddRows = false;
            dgvMembers.AllowUserToDeleteRows = false;
            dgvMembers.AllowUserToResizeRows = false;
            dgvMembers.RowHeadersVisible = false;
            dgvMembers.BackgroundColor = Color.White;
            dgvMembers.BorderStyle = BorderStyle.Fixed3D;
            dgvMembers.EnableHeadersVisualStyles = false;
            dgvMembers.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.EnableResizing;
            dgvMembers.ColumnHeadersHeight = 36;
            dgvMembers.RowTemplate.Height = 30;

            // Định dạng tiêu đề cột
            dgvMembers.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(24, 76, 120);
            dgvMembers.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
            dgvMembers.ColumnHeadersDefaultCellStyle.Font = new Font("Segoe UI", 9.75F, FontStyle.Bold);
            dgvMembers.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;

            // Định dạng dòng xen kẽ và dòng được chọn
            dgvMembers.AlternatingRowsDefaultCellStyle.BackColor = Color.FromArgb(246, 249, 252);
            dgvMembers.DefaultCellStyle.SelectionBackColor = Color.FromArgb(41, 128, 185);
            dgvMembers.DefaultCellStyle.SelectionForeColor = Color.White;
            dgvMembers.DefaultCellStyle.Font = new Font("Segoe UI", 9.75F, FontStyle.Regular);

            // Cột 1: Mã HV
            var colMemberId = new DataGridViewTextBoxColumn
            {
                Name = "colMemberId",
                HeaderText = "Mã HV",
                DataPropertyName = nameof(GymMember.MemberId),
                Width = 95
            };
            colMemberId.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgvMembers.Columns.Add(colMemberId);

            // Cột 2: Tên hội viên
            var colFullName = new DataGridViewTextBoxColumn
            {
                Name = "colFullName",
                HeaderText = "Tên hội viên",
                DataPropertyName = nameof(GymMember.FullName),
                AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
            };
            colFullName.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dgvMembers.Columns.Add(colFullName);

            // Cột 3: SĐT
            var colPhone = new DataGridViewTextBoxColumn
            {
                Name = "colPhone",
                HeaderText = "SĐT",
                DataPropertyName = nameof(GymMember.Phone),
                Width = 120
            };
            colPhone.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgvMembers.Columns.Add(colPhone);

            // Cột 4: Gói tập
            var colPackage = new DataGridViewTextBoxColumn
            {
                Name = "colPackage",
                HeaderText = "Gói tập",
                DataPropertyName = nameof(GymMember.Package),
                Width = 120
            };
            colPackage.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgvMembers.Columns.Add(colPackage);

            // Cột 5: Ngày ĐK (định dạng dd/MM/yyyy)
            var colStartDate = new DataGridViewTextBoxColumn
            {
                Name = "colStartDate",
                HeaderText = "Ngày ĐK",
                DataPropertyName = nameof(GymMember.StartDate),
                Width = 120
            };
            colStartDate.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            colStartDate.DefaultCellStyle.Format = "dd/MM/yyyy";
            dgvMembers.Columns.Add(colStartDate);

            // Cột 6: Phí dịch vụ (định dạng N0)
            var colFee = new DataGridViewTextBoxColumn
            {
                Name = "colFee",
                HeaderText = "Phí dịch vụ",
                DataPropertyName = nameof(GymMember.Fee),
                Width = 140
            };
            colFee.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            colFee.DefaultCellStyle.Format = "N0";
            dgvMembers.Columns.Add(colFee);
        }

        /// <summary>
        /// Định dạng hiển thị đơn vị tiền tệ trên lưới cho cột Phí dịch vụ
        /// </summary>
        private void DgvMembers_CellFormatting(object? sender, DataGridViewCellFormattingEventArgs e)
        {
            if (e.RowIndex < 0 || e.Value == null) return;

            if (dgvMembers.Columns[e.ColumnIndex].Name == "colFee")
            {
                if (e.Value is decimal decFee)
                {
                    e.Value = decFee.ToString("N0") + " VNĐ";
                    e.FormattingApplied = true;
                }
            }
        }

        #endregion

        #region 2. Kiểm tra hợp lệ (ErrorProvider)

        /// <summary>
        /// Kiểm tra tính hợp lệ của dữ liệu nhập trên form bằng ErrorProvider:
        /// - Tên hội viên không được để trống hoặc chứa ký tự đặc biệt.
        /// - Số điện thoại phải đúng 10 chữ số.
        /// - Phí dịch vụ phải là số nguyên dương.
        /// </summary>
        private bool ValidateInputs()
        {
            errorProvider1.Clear();
            bool isValid = true;

            // 1. Kiểm tra Tên hội viên
            string fullName = txtFullName.Text.Trim();
            if (string.IsNullOrWhiteSpace(fullName))
            {
                errorProvider1.SetError(txtFullName, "Họ và tên không được để trống.");
                isValid = false;
            }
            else if (!Regex.IsMatch(fullName, @"^[\p{L}\s]+$"))
            {
                errorProvider1.SetError(txtFullName, "Họ và tên không được chứa ký tự đặc biệt hoặc chữ số.");
                isValid = false;
            }

            // 2. Kiểm tra Số điện thoại: đúng 10 chữ số
            string phone = txtPhone.Text.Trim();
            if (string.IsNullOrWhiteSpace(phone))
            {
                errorProvider1.SetError(txtPhone, "Số điện thoại không được để trống.");
                isValid = false;
            }
            else if (!Regex.IsMatch(phone, @"^\d{10}$"))
            {
                errorProvider1.SetError(txtPhone, "Số điện thoại phải đúng 10 chữ số.");
                isValid = false;
            }

            // 3. Kiểm tra Gói tập
            if (cboPackage.SelectedIndex < 0 || string.IsNullOrWhiteSpace(cboPackage.Text))
            {
                errorProvider1.SetError(cboPackage, "Vui lòng chọn gói tập.");
                isValid = false;
            }

            // 4. Kiểm tra Phí dịch vụ: số nguyên dương
            string feeRaw = txtFee.Text.Trim().Replace(",", "").Replace(".", "");
            if (string.IsNullOrWhiteSpace(feeRaw))
            {
                errorProvider1.SetError(txtFee, "Phí dịch vụ không được để trống.");
                isValid = false;
            }
            else if (!long.TryParse(feeRaw, out long feeVal) || feeVal <= 0)
            {
                errorProvider1.SetError(txtFee, "Phí dịch vụ phải là số nguyên dương (> 0).");
                isValid = false;
            }

            return isValid;
        }

        #endregion

        #region 3. Đồng bộ Data Binding 2 chiều & Chức năng Nghiệp vụ

        /// <summary>
        /// Tự động sinh mã hội viên kế tiếp dạng HV001, HV002...
        /// </summary>
        private string GenerateNextMemberId()
        {
            int maxId = 0;
            foreach (var m in _memberList)
            {
                if (!string.IsNullOrWhiteSpace(m.MemberId) && m.MemberId.StartsWith("HV", StringComparison.OrdinalIgnoreCase))
                {
                    string numPart = m.MemberId.Substring(2);
                    if (int.TryParse(numPart, out int num) && num > maxId)
                    {
                        maxId = num;
                    }
                }
            }
            return $"HV{(maxId + 1):D3}";
        }

        /// <summary>
        /// Yêu cầu: Khi chọn một dòng trên dgvMembers, toàn bộ thông tin hội viên lập tức được điền vào các Control tương ứng trên Form.
        /// </summary>
        private void DgvMembers_SelectionChanged(object? sender, EventArgs e)
        {
            if (_isResetting) return;

            if (dgvMembers.CurrentRow != null && dgvMembers.CurrentRow.DataBoundItem is GymMember member)
            {
                errorProvider1.Clear();
                DisplayMemberToControls(member);
            }
        }

        /// <summary>
        /// Điền dữ liệu từ đối tượng hội viên vào các Control trên Form
        /// </summary>
        private void DisplayMemberToControls(GymMember member)
        {
            txtMemberId.Text = member.MemberId;
            txtFullName.Text = member.FullName;
            txtPhone.Text = member.Phone;

            int index = cboPackage.FindStringExact(member.Package);
            if (index >= 0)
            {
                cboPackage.SelectedIndex = index;
            }
            else
            {
                cboPackage.Text = member.Package;
            }

            dtpStartDate.Value = member.StartDate;
            txtFee.Text = member.Fee.ToString("0");
        }

        /// <summary>
        /// Chức năng Thêm mới: Kiểm tra dữ liệu, tự sinh mã HV và thêm vào BindingList<T>
        /// </summary>
        private void BtnAdd_Click(object? sender, EventArgs e)
        {
            if (!ValidateInputs())
            {
                MessageBox.Show("Vui lòng kiểm tra lại các trường thông tin có báo lỗi đỏ!", "Lỗi nhập liệu", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            string newId = GenerateNextMemberId();
            string feeRaw = txtFee.Text.Trim().Replace(",", "").Replace(".", "");
            decimal fee = decimal.Parse(feeRaw);

            var newMember = new GymMember
            {
                MemberId = newId,
                FullName = txtFullName.Text.Trim(),
                Phone = txtPhone.Text.Trim(),
                Package = cboPackage.SelectedItem?.ToString() ?? cboPackage.Text,
                StartDate = dtpStartDate.Value.Date,
                Fee = fee
            };

            // Thêm vào BindingList<T>, lưới tự động cập nhật ngay
            _memberList.Add(newMember);
            UpdateStatus();

            // Định vị chọn ngay dòng mới thêm
            _bindingSource.Position = _memberList.IndexOf(newMember);

            MessageBox.Show($"Thêm mới hội viên [{newMember.MemberId} - {newMember.FullName}] thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        /// <summary>
        /// Yêu cầu: Khi bấm Sửa thông tin, dữ liệu thay đổi trên Control phải tự động đồng bộ xuống BindingList<T>
        /// và cập nhật ngay lên lưới mà không cần nạp lại danh sách.
        /// </summary>
        private void BtnEdit_Click(object? sender, EventArgs e)
        {
            if (dgvMembers.CurrentRow == null || dgvMembers.CurrentRow.DataBoundItem is not GymMember selectedMember)
            {
                MessageBox.Show("Vui lòng chọn một hội viên trên lưới để sửa thông tin!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (!ValidateInputs())
            {
                MessageBox.Show("Vui lòng kiểm tra lại các trường thông tin có báo lỗi đỏ!", "Lỗi nhập liệu", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            string feeRaw = txtFee.Text.Trim().Replace(",", "").Replace(".", "");
            decimal fee = decimal.Parse(feeRaw);

            // Đồng bộ dữ liệu từ các Control xuống trực tiếp đối tượng trong BindingList<T>
            // Nhờ GymMember triển khai INotifyPropertyChanged, BindingList<T> tự động phát hiện thay đổi
            // và DataGridView cập nhật ngay lập tức mà KHÔNG CẦN nạp lại danh sách.
            selectedMember.FullName = txtFullName.Text.Trim();
            selectedMember.Phone = txtPhone.Text.Trim();
            selectedMember.Package = cboPackage.SelectedItem?.ToString() ?? cboPackage.Text;
            selectedMember.StartDate = dtpStartDate.Value.Date;
            selectedMember.Fee = fee;

            // Kích hoạt làm tươi dòng hiện tại trên BindingSource để đảm bảo đồng bộ hoàn hảo
            _bindingSource.ResetCurrentItem();

            MessageBox.Show($"Cập nhật thông tin hội viên [{selectedMember.MemberId}] thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        /// <summary>
        /// Yêu cầu: Khi xóa, hiển thị MessageBox xác nhận (Yes/No) loại cảnh báo (MessageBoxIcon.Warning).
        /// </summary>
        private void BtnDelete_Click(object? sender, EventArgs e)
        {
            if (dgvMembers.CurrentRow == null || dgvMembers.CurrentRow.DataBoundItem is not GymMember selectedMember)
            {
                MessageBox.Show("Vui lòng chọn một hội viên trên lưới để xóa!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            DialogResult result = MessageBox.Show(
                $"Bạn có chắc chắn muốn xóa hội viên [{selectedMember.MemberId} - {selectedMember.FullName}] không?",
                "Xác nhận xóa",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Warning
            );

            if (result == DialogResult.Yes)
            {
                _memberList.Remove(selectedMember);
                UpdateStatus();
                BtnReset_Click(sender, e);
                MessageBox.Show("Đã xóa hội viên thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        /// <summary>
        /// Chức năng Làm mới: Xóa trắng form, tạo sẵn mã hội viên tiếp theo và đặt con trỏ vào ô Họ tên
        /// </summary>
        private void BtnReset_Click(object? sender, EventArgs e)
        {
            _isResetting = true;
            try
            {
                errorProvider1.Clear();
                dgvMembers.ClearSelection();

                // Tự động sinh mã HV tiếp theo
                txtMemberId.Text = GenerateNextMemberId();
                txtFullName.Clear();
                txtPhone.Clear();

                if (cboPackage.Items.Count > 0)
                {
                    cboPackage.SelectedIndex = 0;
                }

                dtpStartDate.Value = DateTime.Today;
                txtFee.Text = GetDefaultFeeForPackage(cboPackage.Text).ToString("0");

                txtFullName.Focus();
            }
            finally
            {
                _isResetting = false;
            }
        }

        /// <summary>
        /// Tự động gợi ý mức phí theo gói tập khi người dùng thay đổi gói
        /// </summary>
        private void CboPackage_SelectedIndexChanged(object? sender, EventArgs e)
        {
            if (_isResetting || dgvMembers.SelectedRows.Count == 0)
            {
                txtFee.Text = GetDefaultFeeForPackage(cboPackage.Text).ToString("0");
            }
        }

        /// <summary>
        /// Mức phí gợi ý mặc định theo gói tập
        /// </summary>
        private decimal GetDefaultFeeForPackage(string package)
        {
            return package switch
            {
                "Theo tháng" => 500000m,
                "6 tháng" => 2700000m,
                "1 năm" => 5000000m,
                _ => 500000m
            };
        }

        /// <summary>
        /// Cập nhật thanh trạng thái
        /// </summary>
        private void UpdateStatus()
        {
            lblStatus.Text = $"Tổng số hội viên: {_memberList.Count} | Trạng thái: Sẵn sàng";
        }

        /// <summary>
        /// Dữ liệu mẫu ban đầu
        /// </summary>
        private void SeedInitialData()
        {
            _memberList.Add(new GymMember
            {
                MemberId = "HV001",
                FullName = "Nguyễn Văn An",
                Phone = "0912345678",
                Package = "1 năm",
                StartDate = new DateTime(2026, 1, 15),
                Fee = 5000000m
            });

            _memberList.Add(new GymMember
            {
                MemberId = "HV002",
                FullName = "Trần Thị Bình",
                Phone = "0987654321",
                Package = "6 tháng",
                StartDate = new DateTime(2026, 2, 20),
                Fee = 2700000m
            });

            _memberList.Add(new GymMember
            {
                MemberId = "HV003",
                FullName = "Lê Hoàng Nam",
                Phone = "0903123456",
                Package = "Theo tháng",
                StartDate = new DateTime(2026, 3, 10),
                Fee = 500000m
            });
        }

        #endregion
    }
}
