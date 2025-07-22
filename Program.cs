// Program.cs
using System;
using System.Windows.Forms;
using TekstilScada.UI; // LoginForm'a eriþmek için eklendi

namespace TekstilScada
{
    internal static class Program
    {
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            // YENÝ: Program baþlangýç mantýðý güncellendi.

            // 1. Login formunu oluþtur ve göster.
            using (var loginForm = new LoginForm())
            {
                // Eðer kullanýcý "Giriþ Yap" butonuna basarsa (DialogResult.OK),
                // ve giriþ baþarýlý olursa, ana formu aç.
                if (loginForm.ShowDialog() == DialogResult.OK)
                {
                    // Giriþ baþarýlý olduðu için ana formu çalýþtýr.
                    Application.Run(new MainForm());
                }
                // Eðer kullanýcý "Ýptal" butonuna basarsa veya formu kapatýrsa,
                // uygulama sessizce kapanýr.
            }
        }
    }
}
