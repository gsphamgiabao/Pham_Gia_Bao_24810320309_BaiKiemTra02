using System;
using System.Drawing;
using System.Drawing.Drawing2D;

namespace HospitalManagementSystem.Utils
{
    /// <summary>
    /// Lớp tiện ích sinh Icon vector chất lượng cao bằng GDI+.
    /// Giúp ứng dụng hoạt động 100% độc lập, không phụ thuộc file icon ngoài,
    /// tránh lỗi thiếu resource và hỗ trợ độ phân giải cao.
    /// </summary>
    public static class IconHelper
    {
        public static Bitmap CreatePatientIcon(int size = 16)
        {
            Bitmap bmp = new Bitmap(size, size);
            using (Graphics g = Graphics.FromImage(bmp))
            {
                g.SmoothingMode = SmoothingMode.AntiAlias;
                // Đầu người
                using (Brush b = new SolidBrush(Color.FromArgb(13, 110, 253)))
                {
                    g.FillEllipse(b, size * 0.3f, size * 0.1f, size * 0.4f, size * 0.4f);
                }
                // Thân người
                using (Brush b = new SolidBrush(Color.FromArgb(13, 110, 253)))
                {
                    g.FillPie(b, size * 0.15f, size * 0.45f, size * 0.7f, size * 0.7f, 180, 180);
                }
                // Chữ thập y tế đỏ góc phải
                using (Brush b = new SolidBrush(Color.FromArgb(220, 53, 69)))
                {
                    float cw = size * 0.35f;
                    float ch = size * 0.35f;
                    float cx = size * 0.6f;
                    float cy = size * 0.6f;
                    float bar = size * 0.1f;
                    g.FillRectangle(b, cx + (cw - bar) / 2, cy, bar, ch);
                    g.FillRectangle(b, cx, cy + (ch - bar) / 2, cw, bar);
                }
            }
            return bmp;
        }

        public static Bitmap CreateDoctorIcon(int size = 16)
        {
            Bitmap bmp = new Bitmap(size, size);
            using (Graphics g = Graphics.FromImage(bmp))
            {
                g.SmoothingMode = SmoothingMode.AntiAlias;
                // Mũ y tế / Đầu bác sĩ
                using (Brush b = new SolidBrush(Color.FromArgb(32, 201, 151)))
                {
                    g.FillEllipse(b, size * 0.28f, size * 0.1f, size * 0.44f, size * 0.4f);
                    g.FillPie(b, size * 0.12f, size * 0.48f, size * 0.76f, size * 0.7f, 180, 180);
                }
                // Ống nghe / Dấu chữ thập xanh
                using (Pen p = new Pen(Color.FromArgb(13, 110, 253), Math.Max(1.5f, size * 0.1f)))
                {
                    g.DrawArc(p, size * 0.22f, size * 0.45f, size * 0.56f, size * 0.4f, 0, 180);
                }
            }
            return bmp;
        }

        public static Bitmap CreateDepartmentIcon(int size = 16)
        {
            Bitmap bmp = new Bitmap(size, size);
            using (Graphics g = Graphics.FromImage(bmp))
            {
                g.SmoothingMode = SmoothingMode.AntiAlias;
                // Tòa nhà bệnh viện
                using (Brush b = new SolidBrush(Color.FromArgb(108, 117, 125)))
                {
                    g.FillRectangle(b, size * 0.2f, size * 0.25f, size * 0.6f, size * 0.7f);
                }
                // Chữ thập y tế trên đỉnh
                using (Brush b = new SolidBrush(Color.FromArgb(220, 53, 69)))
                {
                    float bar = size * 0.12f;
                    g.FillRectangle(b, size * 0.44f, size * 0.05f, bar, size * 0.35f);
                    g.FillRectangle(b, size * 0.32f, size * 0.16f, size * 0.36f, bar);
                }
                // Cửa sổ
                using (Brush b = new SolidBrush(Color.FromArgb(255, 235, 59)))
                {
                    float w = size * 0.12f;
                    g.FillRectangle(b, size * 0.3f, size * 0.4f, w, w);
                    g.FillRectangle(b, size * 0.58f, size * 0.4f, w, w);
                    g.FillRectangle(b, size * 0.3f, size * 0.6f, w, w);
                    g.FillRectangle(b, size * 0.58f, size * 0.6f, w, w);
                }
            }
            return bmp;
        }

        public static Bitmap CreateReloadIcon(int size = 16)
        {
            Bitmap bmp = new Bitmap(size, size);
            using (Graphics g = Graphics.FromImage(bmp))
            {
                g.SmoothingMode = SmoothingMode.AntiAlias;
                using (Pen p = new Pen(Color.FromArgb(25, 135, 84), Math.Max(2f, size * 0.14f)))
                {
                    g.DrawArc(p, size * 0.15f, size * 0.15f, size * 0.7f, size * 0.7f, 40, 280);
                }
                // Mũi tên
                using (Brush b = new SolidBrush(Color.FromArgb(25, 135, 84)))
                {
                    PointF[] arrow = new PointF[]
                    {
                        new PointF(size * 0.85f, size * 0.35f),
                        new PointF(size * 0.65f, size * 0.35f),
                        new PointF(size * 0.85f, size * 0.15f)
                    };
                    g.FillPolygon(b, arrow);
                }
            }
            return bmp;
        }

        public static Bitmap CreateCascadeIcon(int size = 16)
        {
            Bitmap bmp = new Bitmap(size, size);
            using (Graphics g = Graphics.FromImage(bmp))
            {
                g.SmoothingMode = SmoothingMode.AntiAlias;
                // Cửa sổ sau
                using (Pen p = new Pen(Color.FromArgb(108, 117, 125), 1.5f))
                using (Brush b = new SolidBrush(Color.FromArgb(230, 235, 245)))
                {
                    g.FillRectangle(b, size * 0.1f, size * 0.1f, size * 0.55f, size * 0.55f);
                    g.DrawRectangle(p, size * 0.1f, size * 0.1f, size * 0.55f, size * 0.55f);
                }
                // Cửa sổ trước
                using (Pen p = new Pen(Color.FromArgb(13, 110, 253), 1.5f))
                using (Brush b = new SolidBrush(Color.White))
                {
                    g.FillRectangle(b, size * 0.35f, size * 0.35f, size * 0.55f, size * 0.55f);
                    g.DrawRectangle(p, size * 0.35f, size * 0.35f, size * 0.55f, size * 0.55f);
                }
            }
            return bmp;
        }

        public static Bitmap CreateTileHorizontalIcon(int size = 16)
        {
            Bitmap bmp = new Bitmap(size, size);
            using (Graphics g = Graphics.FromImage(bmp))
            {
                g.SmoothingMode = SmoothingMode.AntiAlias;
                using (Pen p = new Pen(Color.FromArgb(13, 110, 253), 1.5f))
                using (Brush b = new SolidBrush(Color.FromArgb(235, 245, 255)))
                {
                    g.FillRectangle(b, size * 0.1f, size * 0.12f, size * 0.8f, size * 0.33f);
                    g.DrawRectangle(p, size * 0.1f, size * 0.12f, size * 0.8f, size * 0.33f);

                    g.FillRectangle(b, size * 0.1f, size * 0.55f, size * 0.8f, size * 0.33f);
                    g.DrawRectangle(p, size * 0.1f, size * 0.55f, size * 0.8f, size * 0.33f);
                }
            }
            return bmp;
        }

        public static Bitmap CreateTileVerticalIcon(int size = 16)
        {
            Bitmap bmp = new Bitmap(size, size);
            using (Graphics g = Graphics.FromImage(bmp))
            {
                g.SmoothingMode = SmoothingMode.AntiAlias;
                using (Pen p = new Pen(Color.FromArgb(13, 110, 253), 1.5f))
                using (Brush b = new SolidBrush(Color.FromArgb(235, 245, 255)))
                {
                    g.FillRectangle(b, size * 0.12f, size * 0.1f, size * 0.33f, size * 0.8f);
                    g.DrawRectangle(p, size * 0.12f, size * 0.1f, size * 0.33f, size * 0.8f);

                    g.FillRectangle(b, size * 0.55f, size * 0.1f, size * 0.33f, size * 0.8f);
                    g.DrawRectangle(p, size * 0.55f, size * 0.1f, size * 0.33f, size * 0.8f);
                }
            }
            return bmp;
        }

        public static Bitmap CreateCloseAllIcon(int size = 16)
        {
            Bitmap bmp = new Bitmap(size, size);
            using (Graphics g = Graphics.FromImage(bmp))
            {
                g.SmoothingMode = SmoothingMode.AntiAlias;
                // Khung cửa sổ
                using (Pen p = new Pen(Color.FromArgb(108, 117, 125), 1.5f))
                {
                    g.DrawRectangle(p, size * 0.1f, size * 0.15f, size * 0.8f, size * 0.7f);
                }
                // Dấu X đỏ
                using (Pen p = new Pen(Color.FromArgb(220, 53, 69), 2f))
                {
                    g.DrawLine(p, size * 0.28f, size * 0.32f, size * 0.72f, size * 0.68f);
                    g.DrawLine(p, size * 0.72f, size * 0.32f, size * 0.28f, size * 0.68f);
                }
            }
            return bmp;
        }

        public static Bitmap CreateLogoutIcon(int size = 16)
        {
            Bitmap bmp = new Bitmap(size, size);
            using (Graphics g = Graphics.FromImage(bmp))
            {
                g.SmoothingMode = SmoothingMode.AntiAlias;
                using (Pen p = new Pen(Color.FromArgb(253, 126, 20), 1.8f))
                {
                    // Cửa sổ mở
                    g.DrawLine(p, size * 0.5f, size * 0.15f, size * 0.15f, size * 0.15f);
                    g.DrawLine(p, size * 0.15f, size * 0.15f, size * 0.15f, size * 0.85f);
                    g.DrawLine(p, size * 0.15f, size * 0.85f, size * 0.5f, size * 0.85f);
                    // Mũi tên đi ra
                    g.DrawLine(p, size * 0.35f, size * 0.5f, size * 0.85f, size * 0.5f);
                    g.DrawLine(p, size * 0.65f, size * 0.3f, size * 0.85f, size * 0.5f);
                    g.DrawLine(p, size * 0.65f, size * 0.7f, size * 0.85f, size * 0.5f);
                }
            }
            return bmp;
        }

        public static Bitmap CreateExitIcon(int size = 16)
        {
            Bitmap bmp = new Bitmap(size, size);
            using (Graphics g = Graphics.FromImage(bmp))
            {
                g.SmoothingMode = SmoothingMode.AntiAlias;
                using (Pen p = new Pen(Color.FromArgb(220, 53, 69), 2f))
                {
                    g.DrawArc(p, size * 0.18f, size * 0.18f, size * 0.64f, size * 0.64f, -60, 300);
                    g.DrawLine(p, size * 0.5f, size * 0.1f, size * 0.5f, size * 0.45f);
                }
            }
            return bmp;
        }

        public static Bitmap CreateAboutIcon(int size = 16)
        {
            Bitmap bmp = new Bitmap(size, size);
            using (Graphics g = Graphics.FromImage(bmp))
            {
                g.SmoothingMode = SmoothingMode.AntiAlias;
                using (Brush b = new SolidBrush(Color.FromArgb(13, 110, 253)))
                {
                    g.FillEllipse(b, size * 0.1f, size * 0.1f, size * 0.8f, size * 0.8f);
                }
                using (Brush b = new SolidBrush(Color.White))
                {
                    g.FillEllipse(b, size * 0.42f, size * 0.25f, size * 0.16f, size * 0.16f);
                    g.FillRectangle(b, size * 0.42f, size * 0.45f, size * 0.16f, size * 0.32f);
                }
            }
            return bmp;
        }
    }
}
