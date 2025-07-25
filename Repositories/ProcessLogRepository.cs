// Repositories/ProcessLogRepository.cs
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Text;
using TekstilScada.Models;

namespace TekstilScada.Repositories
{
    public class ProcessLogRepository
    {
        private readonly string _connectionString = "server=localhost;port=3306;database=scada_db;user=user1;password=Cagatay.19;";

        public void LogData(FullMachineStatus status)
        {
            // Batch numarası yoksa veya reçete modunda değilse loglama yapma
            if (string.IsNullOrEmpty(status.BatchNumarasi) || !status.IsInRecipeMode)
            {
                return;
            }

            using (var connection = new MySqlConnection(_connectionString))
            {
                connection.Open();
                string query = "INSERT INTO process_data_log (MachineId, BatchId, LogTimestamp, LiveTemperature, LiveWaterLevel, LiveRpm) VALUES (@MachineId, @BatchId, @LogTimestamp, @LiveTemperature, @LiveWaterLevel, @LiveRpm);";
                var cmd = new MySqlCommand(query, connection);
                cmd.Parameters.AddWithValue("@MachineId", status.MachineId);
                cmd.Parameters.AddWithValue("@BatchId", status.BatchNumarasi);
                cmd.Parameters.AddWithValue("@LogTimestamp", DateTime.Now);
                cmd.Parameters.AddWithValue("@LiveTemperature", status.AnlikSicaklik); // Varsayımsal olarak anlık sıcaklık
                cmd.Parameters.AddWithValue("@LiveWaterLevel", status.AnlikSuSeviyesi);
                cmd.Parameters.AddWithValue("@LiveRpm", status.AnlikDevirRpm);
                cmd.ExecuteNonQuery();
            }
        }

        public List<ProcessDataPoint> GetLogsForBatch(int machineId, string batchId, DateTime? startTime = null, DateTime? endTime = null)
        {
            var dataPoints = new List<ProcessDataPoint>();
            using (var connection = new MySqlConnection(_connectionString))
            {
                connection.Open();
                var queryBuilder = new StringBuilder("SELECT LogTimestamp, LiveTemperature, LiveWaterLevel, LiveRpm FROM process_data_log WHERE MachineId = @MachineId ");

                if (!string.IsNullOrEmpty(batchId))
                {
                    queryBuilder.Append("AND BatchId = @BatchId ");
                }
                if (startTime.HasValue)
                {
                    queryBuilder.Append("AND LogTimestamp >= @StartTime ");
                }
                if (endTime.HasValue)
                {
                    queryBuilder.Append("AND LogTimestamp <= @EndTime ");
                }
                queryBuilder.Append("ORDER BY LogTimestamp;");

                var cmd = new MySqlCommand(queryBuilder.ToString(), connection);
                cmd.Parameters.AddWithValue("@MachineId", machineId);

                if (!string.IsNullOrEmpty(batchId)) cmd.Parameters.AddWithValue("@BatchId", batchId);
                if (startTime.HasValue) cmd.Parameters.AddWithValue("@StartTime", startTime.Value);
                if (endTime.HasValue) cmd.Parameters.AddWithValue("@EndTime", endTime.Value);

                using (var reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        dataPoints.Add(new ProcessDataPoint
                        {
                            Timestamp = reader.GetDateTime("LogTimestamp"),
                            Temperature = reader.GetDecimal("LiveTemperature"),
                            WaterLevel = reader.GetDecimal("LiveWaterLevel"),
                            Rpm = reader.GetInt32("LiveRpm")
                        });
                    }
                }
            }
            return dataPoints;
        }
    }

    // Grafik için veri noktası modeli
    public class ProcessDataPoint
    {
        public DateTime Timestamp { get; set; }
        public decimal Temperature { get; set; }
        public decimal WaterLevel { get; set; }
        public int Rpm { get; set; }
    }
}
