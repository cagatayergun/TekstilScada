// Core/LanguageManager.cs
using System;
using System.Globalization;
using System.Threading;
// YENİ: Ayarlar dosyasına erişim için using ifadesi
using TekstilScada.Properties;

namespace TekstilScada.Core
{
    /// <summary>
    /// Uygulama genelinde dil (kültür) ayarlarını yöneten statik sınıf.
    /// </summary>
    public static class LanguageManager
    {
        /// <summary>
        /// Uygulamanın dili değiştirildiğinde tetiklenir.
        /// Tüm açık formlar bu olaya abone olarak kendi metinlerini güncellemeli.
        /// </summary>
        public static event EventHandler LanguageChanged;

        /// <summary>
        /// Uygulamanın mevcut kullanıcı arayüzü dilini ayarlar.
        /// </summary>
        /// <param name="cultureName">"tr-TR" veya "en-US" gibi bir kültür kodu.</param>
        public static void SetLanguage(string cultureName)
        {
            try
            {
                CultureInfo culture = new CultureInfo(cultureName);
                Thread.CurrentThread.CurrentUICulture = culture;
                Thread.CurrentThread.CurrentCulture = culture;
                Settings.Default.UserLanguage = cultureName;
                Settings.Default.Save(); // Değişiklikleri diske yazar.
                // Dil değişikliğini tüm abonelere bildir.
                LanguageChanged?.Invoke(null, EventArgs.Empty);
            }
            catch (Exception ex)
            {
                // Hatalı bir kültür adı girilirse oluşabilecek hatayı yönet.
                Console.WriteLine($"Dil ayarlanamadı: {ex.Message}");
            }
        }
    }
}
