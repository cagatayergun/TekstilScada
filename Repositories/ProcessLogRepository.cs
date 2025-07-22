// Repositories/ProcessLogRepository.cs
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
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

        public List<ProcessDataPoint> GetLogsForBatch(int machineId, string batchId)
        {
            var dataPoints = new List<ProcessDataPoint>();
            using (var connection = new MySqlConnection(_connectionString))
            {
                connection.Open();
                string query = "SELECT LogTimestamp, LiveTemperature, LiveWaterLevel, LiveRpm FROM process_data_log WHERE MachineId = @MachineId AND BatchId = @BatchId ORDER BY LogTimestamp;";
                var cmd = new MySqlCommand(query, connection);
                cmd.Parameters.AddWithValue("@MachineId", machineId);
                cmd.Parameters.AddWithValue("@BatchId", batchId);

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
