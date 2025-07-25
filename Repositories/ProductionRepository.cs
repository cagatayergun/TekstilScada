// Repositories/ProductionRepository.cs
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Text;
using TekstilScada.Models; // BU SATIR EKLENDİ

namespace TekstilScada.Repositories
{
    public class ProductionRepository
    {
        private readonly string _connectionString = "server=localhost;port=3306;database=scada_db;user=user1;password=Cagatay.19;";

        public class ReportFilters
        {
            public DateTime StartTime { get; set; }
            public DateTime EndTime { get; set; }
            public int? MachineId { get; set; }
            public string BatchNo { get; set; }
            public string RecipeName { get; set; }
            public string SiparisNo { get; set; }
            public string MusteriNo { get; set; }
            public string OperatorName { get; set; }
        }

        // ... Bu dosyanın geri kalan tüm metotları aynı kalacak ...
        // (GetProductionReport, StartNewBatch, EndBatch vb.)
        public List<ProductionReportItem> GetProductionReport(ReportFilters filters)
        {
            var reportItems = new List<ProductionReportItem>();
            var queryBuilder = new StringBuilder();

            queryBuilder.Append(@"
                SELECT 
                    m.Id as MachineId,
                    m.MachineName,
                    b.BatchId,
                    b.StartTime,
                    b.EndTime,
                    TIMEDIFF(b.EndTime, b.StartTime) as CycleTime,
                    b.RecipeName,
                    b.OperatorName,
                    b.MusteriNo,
                    b.SiparisNo
                FROM production_batches AS b
                JOIN machines AS m ON b.MachineId = m.Id
            ");

            var whereClauses = new List<string>();
            whereClauses.Add("b.StartTime BETWEEN @StartTime AND @EndTime");
            if (filters.MachineId.HasValue && filters.MachineId > 0) whereClauses.Add("b.MachineId = @MachineId");
            if (!string.IsNullOrEmpty(filters.BatchNo)) whereClauses.Add("b.BatchId LIKE @BatchNo");
            if (!string.IsNullOrEmpty(filters.RecipeName)) whereClauses.Add("b.RecipeName LIKE @RecipeName");
            if (!string.IsNullOrEmpty(filters.SiparisNo)) whereClauses.Add("b.SiparisNo LIKE @SiparisNo");
            if (!string.IsNullOrEmpty(filters.MusteriNo)) whereClauses.Add("b.MusteriNo LIKE @MusteriNo");
            if (!string.IsNullOrEmpty(filters.OperatorName)) whereClauses.Add("b.OperatorName LIKE @OperatorName");

            queryBuilder.Append(" WHERE " + string.Join(" AND ", whereClauses));
            queryBuilder.Append(" ORDER BY b.StartTime DESC;");

            using (var connection = new MySqlConnection(_connectionString))
            {
                connection.Open();
                var cmd = new MySqlCommand(queryBuilder.ToString(), connection);

                cmd.Parameters.AddWithValue("@StartTime", filters.StartTime);
                cmd.Parameters.AddWithValue("@EndTime", filters.EndTime);
                if (filters.MachineId.HasValue && filters.MachineId > 0) cmd.Parameters.AddWithValue("@MachineId", filters.MachineId.Value);
                if (!string.IsNullOrEmpty(filters.BatchNo)) cmd.Parameters.AddWithValue("@BatchNo", $"%{filters.BatchNo}%");
                if (!string.IsNullOrEmpty(filters.RecipeName)) cmd.Parameters.AddWithValue("@RecipeName", $"%{filters.RecipeName}%");
                if (!string.IsNullOrEmpty(filters.SiparisNo)) cmd.Parameters.AddWithValue("@SiparisNo", $"%{filters.SiparisNo}%");
                if (!string.IsNullOrEmpty(filters.MusteriNo)) cmd.Parameters.AddWithValue("@MusteriNo", $"%{filters.MusteriNo}%");
                if (!string.IsNullOrEmpty(filters.OperatorName)) cmd.Parameters.AddWithValue("@OperatorName", $"%{filters.OperatorName}%");

                using (var reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        reportItems.Add(new ProductionReportItem
                        {
                            MachineId = reader.GetInt32("MachineId"),
                            MachineName = reader.GetString("MachineName"),
                            BatchId = reader.GetString("BatchId"),
                            StartTime = reader.GetDateTime("StartTime"),
                            EndTime = reader.IsDBNull(reader.GetOrdinal("EndTime")) ? DateTime.MinValue : reader.GetDateTime("EndTime"),
                            CycleTime = reader.IsDBNull(reader.GetOrdinal("CycleTime"))
                                ? "Devam Ediyor"
                                : reader.GetTimeSpan(reader.GetOrdinal("CycleTime")).ToString(@"hh\:mm\:ss"),
                            RecipeName = reader.IsDBNull(reader.GetOrdinal("RecipeName")) ? "" : reader.GetString("RecipeName"),
                            OperatorName = reader.IsDBNull(reader.GetOrdinal("OperatorName")) ? "" : reader.GetString("OperatorName"),
                            MusteriNo = reader.IsDBNull(reader.GetOrdinal("MusteriNo")) ? "" : reader.GetString("MusteriNo"),
                            SiparisNo = reader.IsDBNull(reader.GetOrdinal("SiparisNo")) ? "" : reader.GetString("SiparisNo")
                        });
                    }
                }
            }
            return reportItems;
        }

        public void StartNewBatch(FullMachineStatus status)
        {
            using (var connection = new MySqlConnection(_connectionString))
            {
                connection.Open();
                string query = "INSERT INTO production_batches (MachineId, BatchId, RecipeName, OperatorName, MusteriNo, SiparisNo, StartTime) VALUES (@MachineId, @BatchId, @RecipeName, @OperatorName, @MusteriNo, @SiparisNo, @StartTime) ON DUPLICATE KEY UPDATE StartTime=@StartTime, EndTime=NULL;";
                var cmd = new MySqlCommand(query, connection);
                cmd.Parameters.AddWithValue("@MachineId", status.MachineId);
                cmd.Parameters.AddWithValue("@BatchId", status.BatchNumarasi);
                cmd.Parameters.AddWithValue("@RecipeName", status.RecipeName);
                cmd.Parameters.AddWithValue("@OperatorName", status.OperatorIsmi);
                cmd.Parameters.AddWithValue("@MusteriNo", status.MusteriNumarasi);
                cmd.Parameters.AddWithValue("@SiparisNo", status.SiparisNumarasi);
                cmd.Parameters.AddWithValue("@StartTime", DateTime.Now);
                cmd.ExecuteNonQuery();
            }
        }

        public void EndBatch(int machineId, string batchId, FullMachineStatus finalStatus)
        {
            using (var connection = new MySqlConnection(_connectionString))
            {
                connection.Open();
                // Sadece EndTime değil, tüm OEE verilerini de güncelle
                string query = @"
                    UPDATE production_batches SET 
                        EndTime = @EndTime,
                        TotalProductionCount = @TotalProductionCount,
                        DefectiveProductionCount = @DefectiveProductionCount,
                        TotalDownTimeSeconds = @TotalDownTimeSeconds,
                        StandardCycleTimeMinutes = @StandardCycleTimeMinutes
                    WHERE 
                        MachineId = @MachineId AND BatchId = @BatchId AND EndTime IS NULL;";

                var cmd = new MySqlCommand(query, connection);
                cmd.Parameters.AddWithValue("@EndTime", DateTime.Now);
                cmd.Parameters.AddWithValue("@MachineId", machineId);
                cmd.Parameters.AddWithValue("@BatchId", batchId);

                // FinalStatus'tan gelen OEE verilerini ekle
                cmd.Parameters.AddWithValue("@TotalProductionCount", finalStatus.TotalProductionCount);
                cmd.Parameters.AddWithValue("@DefectiveProductionCount", finalStatus.DefectiveProductionCount);
                cmd.Parameters.AddWithValue("@TotalDownTimeSeconds", finalStatus.TotalDownTimeSeconds);
                cmd.Parameters.AddWithValue("@StandardCycleTimeMinutes", finalStatus.StandardCycleTimeMinutes);

                cmd.ExecuteNonQuery();
            }
        }

        public void UpdateBatchSummary(int machineId, string batchId, BatchSummaryData summary)
        {
            using (var connection = new MySqlConnection(_connectionString))
            {
                connection.Open();
                string query = @"
                UPDATE production_batches 
                SET 
                    TotalWater = @TotalWater, 
                    TotalElectricity = @TotalElectricity, 
                    TotalSteam = @TotalSteam 
                WHERE 
                    MachineId = @MachineId AND BatchId = @BatchId;";

                var cmd = new MySqlCommand(query, connection);
                cmd.Parameters.AddWithValue("@TotalWater", summary.TotalWater);
                cmd.Parameters.AddWithValue("@TotalElectricity", summary.TotalElectricity);
                cmd.Parameters.AddWithValue("@TotalSteam", summary.TotalSteam);
                cmd.Parameters.AddWithValue("@MachineId", machineId);
                cmd.Parameters.AddWithValue("@BatchId", batchId);
                cmd.ExecuteNonQuery();
            }
        }

        public void LogAllStepDetails(int machineId, string batchId, List<ProductionStepDetail> steps)
        {
            using (var connection = new MySqlConnection(_connectionString))
            {
                connection.Open();
                foreach (var step in steps)
                {
                    string query = @"
                        INSERT INTO production_step_logs 
                        (MachineId, BatchId, StepNumber, TheoreticalTime, WorkingTime, StopTime, DeflectionTime, LogTimestamp) 
                        VALUES 
                        (@MachineId, @BatchId, @StepNumber, @TheoreticalTime, @WorkingTime, @StopTime, @DeflectionTime, @LogTimestamp);";

                    var cmd = new MySqlCommand(query, connection);
                    cmd.Parameters.AddWithValue("@MachineId", machineId);
                    cmd.Parameters.AddWithValue("@BatchId", batchId);
                    cmd.Parameters.AddWithValue("@StepNumber", step.StepNumber);
                    cmd.Parameters.AddWithValue("@TheoreticalTime", step.TheoreticalTime);
                    cmd.Parameters.AddWithValue("@WorkingTime", step.WorkingTime);
                    cmd.Parameters.AddWithValue("@StopTime", step.StopTime);
                    cmd.Parameters.AddWithValue("@DeflectionTime", step.DeflectionTime);
                    cmd.Parameters.AddWithValue("@LogTimestamp", DateTime.Now);
                    cmd.ExecuteNonQuery();
                }
            }
        }

        public List<ProductionStepDetail> GetProductionStepDetails(string batchId, int machineId)
        {
            var details = new List<ProductionStepDetail>();
            using (var connection = new MySqlConnection(_connectionString))
            {
                connection.Open();
                string query = "SELECT * FROM production_step_logs WHERE MachineId = @MachineId AND BatchId = @BatchId ORDER BY StepNumber;";
                var cmd = new MySqlCommand(query, connection);
                cmd.Parameters.AddWithValue("@MachineId", machineId);
                cmd.Parameters.AddWithValue("@BatchId", batchId);

                using (var reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        details.Add(new ProductionStepDetail
                        {
                            StepNumber = reader.GetInt32("StepNumber"),
                            StepName = reader.IsDBNull(reader.GetOrdinal("StepName")) ? "" : reader.GetString("StepName"),
                            TheoreticalTime = reader.IsDBNull(reader.GetOrdinal("TheoreticalTime")) ? "" : reader.GetString("TheoreticalTime"),
                            WorkingTime = reader.IsDBNull(reader.GetOrdinal("WorkingTime")) ? "" : reader.GetString("WorkingTime"),
                            StopTime = reader.IsDBNull(reader.GetOrdinal("StopTime")) ? "" : reader.GetString("StopTime"),
                            DeflectionTime = reader.IsDBNull(reader.GetOrdinal("DeflectionTime")) ? "" : reader.GetString("DeflectionTime")
                        });
                    }
                }
            }
            return details;
        }

        public void LogChemicalConsumption(int machineId, string batchId, List<ChemicalConsumptionData> consumptionData)
        {
            using (var connection = new MySqlConnection(_connectionString))
            {
                connection.Open();
                foreach (var data in consumptionData)
                {
                    string query = @"
                        INSERT INTO production_chemical_logs 
                        (MachineId, BatchId, StepNumber, ChemicalName, AmountLiters) 
                        VALUES 
                        (@MachineId, @BatchId, @StepNumber, @ChemicalName, @AmountLiters);";

                    var cmd = new MySqlCommand(query, connection);
                    cmd.Parameters.AddWithValue("@MachineId", machineId);
                    cmd.Parameters.AddWithValue("@BatchId", batchId);
                    cmd.Parameters.AddWithValue("@StepNumber", data.StepNumber);
                    cmd.Parameters.AddWithValue("@ChemicalName", data.ChemicalName);
                    cmd.Parameters.AddWithValue("@AmountLiters", data.AmountLiters);
                    cmd.ExecuteNonQuery();
                }
            }
        }

        public List<ChemicalConsumptionData> GetChemicalConsumptionForBatch(string batchId, int machineId)
        {
            var consumptionList = new List<ChemicalConsumptionData>();
            using (var connection = new MySqlConnection(_connectionString))
            {
                connection.Open();
                string query = "SELECT StepNumber, ChemicalName, AmountLiters FROM production_chemical_logs WHERE MachineId = @MachineId AND BatchId = @BatchId ORDER BY StepNumber;";
                var cmd = new MySqlCommand(query, connection);
                cmd.Parameters.AddWithValue("@MachineId", machineId);
                cmd.Parameters.AddWithValue("@BatchId", batchId);

                using (var reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        consumptionList.Add(new ChemicalConsumptionData
                        {
                            StepNumber = reader.GetInt32("StepNumber"),
                            ChemicalName = reader.GetString("ChemicalName"),
                            AmountLiters = reader.GetInt16("AmountLiters")
                        });
                    }
                }
            }
            return consumptionList;
        }
    }
}
