using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace PhotoGallery
{
    public partial class Form1 : Form
    {
        // قائمة لحفظ مسارات الصور
        private List<string> images = new List<string>();
        // مؤشر الصورة الحالية
        private int currentIndex = 0;

        public Form1()
        {
            InitializeComponent();
            // تحميل الصور من مجلد الصور في نفس المسار
            LoadImages();
            ShowImage();
        }

        // تحميل كل الصور من مجلد الصور
        private void LoadImages()
        {
            string folder = System.IO.Path.Combine(Application.StartupPath, "Images");
            if (!System.IO.Directory.Exists(folder))
                System.IO.Directory.CreateDirectory(folder);

            // جلب كل الصور ذات الامتدادات المعروفة
            string[] files = System.IO.Directory.GetFiles(folder, "*.*", System.IO.SearchOption.AllDirectories);
            foreach (var file in files)
            {
                if (file.EndsWith(".jpg") || file.EndsWith(".png") || file.EndsWith(".jpeg") || file.EndsWith(".bmp"))
                    images.Add(file);
            }

            // إذا لم توجد صور، أضف صورة افتراضية
            if (images.Count == 0)
            {
                images.Add(System.IO.Path.Combine(folder, "default.jpg"));
            }
        }

        // عرض الصورة الحالية
        private void ShowImage()
        {
            if (images.Count == 0) return;

            try
            {
                pictureBox1.Image = Image.FromFile(images[currentIndex]);
            }
            catch
            {
                pictureBox1.Image = null;
            }
        }

        // زر الصورة التالية
        private void btnNext_Click(object sender, EventArgs e)
        {
            if (images.Count == 0) return;
            currentIndex = (currentIndex + 1) % images.Count;
            ShowImage();
        }

        // زر الصورة السابقة
        private void btnPrev_Click(object sender, EventArgs e)
        {
            if (images.Count == 0) return;
            currentIndex = (currentIndex - 1 + images.Count) % images.Count;
            ShowImage();
        }

        // زر التكبير
        private void btnZoomIn_Click(object sender, EventArgs e)
        {
            if (pictureBox1.Image == null) return;
            pictureBox1.Width = (int)(pictureBox1.Width * 1.2);
            pictureBox1.Height = (int)(pictureBox1.Height * 1.2);
        }

        // زر التصغير
        private void btnZoomOut_Click(object sender, EventArgs e)
        {
            if (pictureBox1.Image == null) return;
            pictureBox1.Width = (int)(pictureBox1.Width / 1.2);
            pictureBox1.Height = (int)(pictureBox1.Height / 1.2);
        }
    }
}