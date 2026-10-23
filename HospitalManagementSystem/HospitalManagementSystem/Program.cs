using System;
using System.IO;
using System.Windows.Forms;
using HospitalManagementSystem.Forms;

namespace HospitalManagementSystem
{
    internal static class Program
    {
        /// <summary>
        /// Điểm khởi chạy chính của ứng dụng Quản lý Bệnh viện & Truy xuất Hồ sơ Bệnh án MDI.
        /// </summary>
        [STAThread]
        static void Main(string[] args)
        {
            ApplicationConfiguration.Initialize();

            if (args.Length > 0 && args[0] == "/capture")
            {
                CaptureScreenshots();
                return;
            }

            Application.Run(new frmHospitalMain());
        }

        private static void CaptureScreenshots()
        {
            using (var form = new frmHospitalMain())
            {
                form.Size = new System.Drawing.Size(1280, 800);
                form.Show();
                Application.DoEvents();
                System.Threading.Thread.Sleep(800);
                Application.DoEvents();

                string dir = @"D:\Test\BaiKiemTra02\screenshots";
                Directory.CreateDirectory(dir);

                using (var bmp = new System.Drawing.Bitmap(form.Width, form.Height))
                {
                    form.DrawToBitmap(bmp, new System.Drawing.Rectangle(0, 0, form.Width, form.Height));
                    bmp.Save(Path.Combine(dir, "HospitalManagementSystem.PNG"), System.Drawing.Imaging.ImageFormat.Png);
                }

                form.OpenChildForm<frmDoctorSchedule>();
                form.LayoutMdi(MdiLayout.Cascade);
                Application.DoEvents();
                System.Threading.Thread.Sleep(600);
                Application.DoEvents();

                using (var bmp2 = new System.Drawing.Bitmap(form.Width, form.Height))
                {
                    form.DrawToBitmap(bmp2, new System.Drawing.Rectangle(0, 0, form.Width, form.Height));
                    bmp2.Save(Path.Combine(dir, "HospitalManagementSystem1.PNG"), System.Drawing.Imaging.ImageFormat.Png);
                }
            }
            Console.WriteLine("Screenshots captured successfully!");
        }
    }
}