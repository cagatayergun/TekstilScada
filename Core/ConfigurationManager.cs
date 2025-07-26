namespace TekstilScada.Core
{
    public static class AppConfig
    {
        // Bu bilgileri gelecekte bir App.config veya appsettings.json dosyasından okuyabilirsiniz.
        public static string ConnectionString { get; } = "server=localhost;port=3306;database=scada_db;user=user1;password=Cagatay.19;";
    }
}