using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using TekstilScada.Models;

namespace TekstilScada.Repositories
{
    /// <summary>
    /// OEE ve diğer dashboard verileri için özel sorguları yönetir.
    /// </summary>
    public class DashboardRepository
    {
        private readonly string _connectionString = "server=localhost;port=3306;database=scada_db;user=user1;password=Cagatay.19;";

        public List<OeeData> GetOeeReport(DateTime startTime, DateTime endTime, int? machineId)
        {
            // Bu, karmaşık bir SQL sorgusu gerektiren gelişmiş bir özelliktir.
            // Şimdilik konsepti göstermek için örnek veriler döndürüyoruz.
            // Gerçek implementasyonda, bu metot veritabanından veri çekip OEE hesaplamalıdır.
            var report = new List<OeeData>();
            report.Add(new OeeData { MachineName = "Makine 1", BatchId = "B001", Availability = 95.5, Performance = 98.2, Quality = 99.0, OEE = 92.8 });
            report.Add(new OeeData { MachineName = "Makine 2", BatchId = "B002", Availability = 91.0, Performance = 95.0, Quality = 99.5, OEE = 85.9 });
            return report;
        }

        public List<ProductionStepDetail> GetRecipeStepAnalysis(string recipeName)
        {
            var analysis = new List<ProductionStepDetail>();
            // Bu da karmaşık bir sorgu gerektirir. Örnek veri döndürüyoruz.
            analysis.Add(new ProductionStepDetail { StepNumber = 1, StepName = "Su Alma", WorkingTime = "00:10:05", StopTime = "00:00:30" });
            analysis.Add(new ProductionStepDetail { StepNumber = 2, StepName = "Isıtma", WorkingTime = "00:25:15", StopTime = "00:01:00" });
            return analysis;
        }
    }
}
