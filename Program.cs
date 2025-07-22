// Program.cs
using System;
using System.Windows.Forms;
using TekstilScada.UI; // LoginForm'a eri�mek i�in eklendi

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

            // YEN�: Program ba�lang�� mant��� g�ncellendi.

            // 1. Login formunu olu�tur ve g�ster.
            using (var loginForm = new LoginForm())
            {
                // E�er kullan�c� "Giri� Yap" butonuna basarsa (DialogResult.OK),
                // ve giri� ba�ar�l� olursa, ana formu a�.
                if (loginForm.ShowDialog() == DialogResult.OK)
                {
                    // Giri� ba�ar�l� oldu�u i�in ana formu �al��t�r.
                    Application.Run(new MainForm());
                }
                // E�er kullan�c� "�ptal" butonuna basarsa veya formu kapat�rsa,
                // uygulama sessizce kapan�r.
            }
        }
    }
}
