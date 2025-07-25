using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using TekstilScada.Models;

namespace TekstilScada.Repositories
{
    public class DashboardRepository
    {
        private readonly string _connectionString = "server=localhost;port=3306;database=scada_db;user=user1;password=Cagatay.19;";

        public List<OeeData> GetOeeReport(DateTime startTime, DateTime endTime, int? machineId)
        {
            var oeeList = new List<OeeData>();
            using (var connection = new MySqlConnection(_connectionString))
            {
                connection.Open();
                // Sadece tamamlanmış batch'leri alıyoruz
                string query = @"
                    SELECT 
                        m.MachineName,
                        b.BatchId,
                        b.TotalProductionCount,
                        b.DefectiveProductionCount,
                        b.TotalDownTimeSeconds,
                        b.StandardCycleTimeMinutes,
                        TIME_TO_SEC(TIMEDIFF(b.EndTime, b.StartTime)) as PlannedTimeInSeconds
                    FROM production_batches AS b
                    JOIN machines AS m ON b.MachineId = m.Id
                    WHERE 
                        b.StartTime BETWEEN @StartTime AND @EndTime AND b.EndTime IS NOT NULL " +
                    (machineId.HasValue ? "AND b.MachineId = @MachineId " : "") +
                    "ORDER BY m.MachineName;";

                var cmd = new MySqlCommand(query, connection);
                cmd.Parameters.AddWithValue("@StartTime", startTime);
                cmd.Parameters.AddWithValue("@EndTime", endTime);
                if (machineId.HasValue)
                {
                    cmd.Parameters.AddWithValue("@MachineId", machineId.Value);
                }

                using (var reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        double plannedTime = reader.GetDouble("PlannedTimeInSeconds");
                        double downTime = reader.GetDouble("TotalDownTimeSeconds");
                        double runTime = plannedTime - downTime;

                        int totalCount = reader.GetInt32("TotalProductionCount");
                        int defectiveCount = reader.GetInt32("DefectiveProductionCount");
                        int goodCount = totalCount - defectiveCount;

                        double standardCycleTime = reader.GetDouble("StandardCycleTimeMinutes") * 60; // saniyeye çevir

                        // 1. Availability (Kullanılabilirlik)
                        double availability = (plannedTime > 0) ? (runTime / plannedTime) * 100 : 0;

                        // 2. Performance (Performans)
                        double performance = (runTime > 0 && totalCount > 0) ? (standardCycleTime * totalCount) / runTime * 100 : 0;

                        // 3. Quality (Kalite)
                        double quality = (totalCount > 0) ? ((double)goodCount / totalCount) * 100 : 0;

                        // OEE
                        double oee = (availability / 100) * (performance / 100) * (quality / 100) * 100;

                        oeeList.Add(new OeeData
                        {
                            MachineName = reader.GetString("MachineName"),
                            BatchId = reader.GetString("BatchId"),
                            Availability = Math.Max(0, availability), // Negatif sonuçları engelle
                            Performance = Math.Max(0, performance),
                            Quality = Math.Max(0, quality),
                            OEE = Math.Max(0, oee)
                        });
                    }
                }
            }
            return oeeList;
        }

        // Bu metot şimdilik kullanılmıyor, olduğu gibi bırakabiliriz.
        public List<ProductionStepDetail> GetRecipeStepAnalysis(string recipeName)
        {
            var analysis = new List<ProductionStepDetail>();
            analysis.Add(new ProductionStepDetail { StepNumber = 1, StepName = "Su Alma", WorkingTime = "00:10:05", StopTime = "00:00:30" });
            analysis.Add(new ProductionStepDetail { StepNumber = 2, StepName = "Isıtma", WorkingTime = "00:25:15", StopTime = "00:01:00" });
            return analysis;
        }
    }
}