using System;
using System.Windows.Forms;

namespace PhotoGallery
{
    static class Program
    {
        /// <summary>
        /// نقطة الدخول الرئيسية للتطبيق.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Form1());
        }
    }
}