using System;
using System.Drawing;
using System.Windows.Forms;

namespace HospitalManagementSystem.Forms
{
    public class frmAbout : Form
    {
        public frmAbout()
        {
            InitializeComponent();
        }

        private void InitializeComponent()
        {
            this.Text = "Giới thiệu Hệ thống Quản lý Bệnh viện MDI";
            this.Size = new Size(580, 420);
            this.StartPosition = FormStartPosition.CenterParent;
            this.FormBorderStyle = FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.BackColor = Color.White;

            var pnlTop = new Panel
            {
                Dock = DockStyle.Top,
                Height = 70,
                BackColor = Color.FromArgb(13, 100, 140)
            };

            var lblTitle = new Label
            {
                Text = "HỆ THỐNG QUẢN LÝ BỆNH VIỆN & TRUY XUẤT HỒ SƠ",
                Font = new Font("Segoe UI", 12F, FontStyle.Bold),
                ForeColor = Color.White,
                Dock = DockStyle.Top,
                Height = 35,
                TextAlign = ContentAlignment.MiddleCenter
            };

            var lblSub = new Label
            {
                Text = "BÀI KIỂM TRA 02 - BÀI TẬP 3: KIẾN TRÚC MDI CHUẨN MỰC",
                Font = new Font("Segoe UI", 9F, FontStyle.Regular),
                ForeColor = Color.FromArgb(220, 240, 255),
                Dock = DockStyle.Top,
                Height = 25,
                TextAlign = ContentAlignment.MiddleCenter
            };

            pnlTop.Controls.Add(lblSub);
            pnlTop.Controls.Add(lblTitle);

            var rtbContent = new RichTextBox
            {
                Dock = DockStyle.Fill,
                ReadOnly = true,
                BackColor = Color.White,
                BorderStyle = BorderStyle.None,
                Font = new Font("Segoe UI", 9.5F),
                Padding = new Padding(15)
            };

            rtbContent.Text =
                "1. KIẾN TRÚC HỆ THỐNG:\n" +
                "  • Form Cha MDI (frmHospitalMain): IsMdiContainer = true.\n" +
                "  • Quản lý vòng đời Form con thông qua MdiChildren, ngăn chặn trùng lặp (Duplicate).\n" +
                "  • Đầy đủ tính năng sắp xếp: Cascade, Tile Horizontal, Tile Vertical, Close All.\n\n" +
                "2. CÁC MÔ-ĐUN NGHIỆP VỤ:\n" +
                "  • Hồ sơ Bệnh nhân (frmPatientProfiles): Quản lý bệnh nhân nội trú, trích lục bệnh án.\n" +
                "  • Lịch trực Bác sĩ (frmDoctorSchedule): Phân bổ ca trực, giám sát ca trực khẩn cấp.\n" +
                "  • Danh mục Khoa/Phòng (frmDepartmentList): Tổ chức khoa lâm sàng, giường bệnh.\n\n" +
                "3. PHÍM TẮT ĐIỀU HƯỚNG:\n" +
                "  • Ctrl + P: Mở Hồ sơ Bệnh nhân\n" +
                "  • Ctrl + D: Mở Lịch trực Bác sĩ\n" +
                "  • Ctrl + K: Mở Danh mục Khoa/Phòng\n" +
                "  • Ctrl + R: Nạp lại dữ liệu (Reload)\n" +
                "  • Alt + F4: Thoát hệ thống";

            var pnlBottom = new Panel
            {
                Dock = DockStyle.Bottom,
                Height = 45,
                BackColor = Color.FromArgb(245, 248, 252)
            };

            var btnClose = new Button
            {
                Text = "Đóng",
                DialogResult = DialogResult.OK,
                Size = new Size(90, 30),
                Location = new Point(470, 7),
                BackColor = Color.FromArgb(13, 100, 140),
                ForeColor = Color.White,
                FlatStyle = FlatStyle.Flat,
                Font = new Font("Segoe UI", 9F, FontStyle.Bold)
            };
            pnlBottom.Controls.Add(btnClose);

            this.Controls.Add(rtbContent);
            this.Controls.Add(pnlBottom);
            this.Controls.Add(pnlTop);
            this.AcceptButton = btnClose;
        }
    }
}
