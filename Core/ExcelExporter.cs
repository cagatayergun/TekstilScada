// Core/ExcelExporter.cs
using ClosedXML.Excel;
using System;
using System.Data;
using System.Windows.Forms;
using TekstilScada.Models;

namespace TekstilScada.Core
{
    public static class ExcelExporter
    {
        public static void ExportDataGridViewToExcel(DataGridView dgv)
        {
            if (dgv.Rows.Count == 0)
            {
                MessageBox.Show("Dışa aktarılacak veri bulunamadı.", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                using (SaveFileDialog sfd = new SaveFileDialog() { Filter = "Excel Workbook|*.xlsx" })
                {
                    if (sfd.ShowDialog() == DialogResult.OK)
                    {
                        using (var workbook = new XLWorkbook())
                        {
                            var worksheet = workbook.Worksheets.Add("Rapor");

                            // Başlıkları yazdır
                            for (int i = 0; i < dgv.Columns.Count; i++)
                            {
                                worksheet.Cell(1, i + 1).Value = dgv.Columns[i].HeaderText;
                            }

                            // Verileri yazdır
                            for (int i = 0; i < dgv.Rows.Count; i++)
                            {
                                for (int j = 0; j < dgv.Columns.Count; j++)
                                {
                                    worksheet.Cell(i + 2, j + 1).Value = dgv.Rows[i].Cells[j].Value?.ToString();
                                }
                            }
                            workbook.SaveAs(sfd.FileName);
                            MessageBox.Show("Rapor başarıyla Excel'e aktarıldı.", "Başarılı", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Excel'e aktarılırken bir hata oluştu: {ex.Message}", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        // YENİ: Detaylı üretim raporunu Excel'e aktaran metot
        public static void ExportProductionDetailToExcel(ProductionReportItem headerData, DataGridView dgvSteps, DataGridView dgvAlarms)
        {
            try
            {
                using (SaveFileDialog sfd = new SaveFileDialog() { Filter = "Excel Workbook|*.xlsx", FileName = $"{headerData.BatchId}_Raporu.xlsx" })
                {
                    if (sfd.ShowDialog() == DialogResult.OK)
                    {
                        using (var workbook = new XLWorkbook())
                        {
                            var worksheet = workbook.Worksheets.Add("Üretim Detay Raporu");

                            // --- Başlık Bilgileri ---
                            worksheet.Cell("A1").Value = "MAKİNA ADI:";
                            worksheet.Cell("B1").Value = headerData.MachineName;
                            worksheet.Cell("A2").Value = "REÇETE ADI:";
                            worksheet.Cell("B2").Value = headerData.RecipeName;
                            worksheet.Cell("A3").Value = "OPERATÖR:";
                            worksheet.Cell("B3").Value = headerData.OperatorName;
                            worksheet.Cell("A4").Value = "BAŞLANGIÇ ZAMANI:";
                            worksheet.Cell("B4").Value = headerData.StartTime;
                            worksheet.Cell("A5").Value = "BİTİŞ ZAMANI:";
                            worksheet.Cell("B5").Value = headerData.EndTime;
                            worksheet.Cell("A6").Value = "TOPLAM SÜRE:";
                            worksheet.Cell("B6").Value = headerData.CycleTime;

                            worksheet.Range("A1:A6").Style.Font.SetBold(true);
                            worksheet.Range("A1:B6").Style.Alignment.SetHorizontal(XLAlignmentHorizontalValues.Left);

                            // --- Adım Detayları Tablosu ---
                            int currentRow = 9;
                            worksheet.Cell(currentRow, 1).Value = "ADIM DETAYLARI";
                            worksheet.Range(currentRow, 1, currentRow, dgvSteps.Columns.Count).Merge().Style.Font.SetBold(true).Fill.SetBackgroundColor(XLColor.LightGray);

                            currentRow++;
                            for (int i = 0; i < dgvSteps.Columns.Count; i++)
                            {
                                worksheet.Cell(currentRow, i + 1).Value = dgvSteps.Columns[i].HeaderText;
                            }
                            worksheet.Row(currentRow).Style.Font.SetBold(true);

                            currentRow++;
                            for (int i = 0; i < dgvSteps.Rows.Count; i++)
                            {
                                for (int j = 0; j < dgvSteps.Columns.Count; j++)
                                {
                                    worksheet.Cell(currentRow + i, j + 1).Value = dgvSteps.Rows[i].Cells[j].Value?.ToString();
                                }
                            }

                            // --- Alarm Tablosu ---
                            currentRow += dgvSteps.Rows.Count + 2; // Arada boşluk bırak
                            worksheet.Cell(currentRow, 1).Value = "PROSES ALARMLARI";
                            worksheet.Range(currentRow, 1, currentRow, dgvAlarms.Columns.Count).Merge().Style.Font.SetBold(true).Fill.SetBackgroundColor(XLColor.LightGray);

                            currentRow++;
                            for (int i = 0; i < dgvAlarms.Columns.Count; i++)
                            {
                                worksheet.Cell(currentRow, i + 1).Value = dgvAlarms.Columns[i].HeaderText;
                            }
                            worksheet.Row(currentRow).Style.Font.SetBold(true);

                            currentRow++;
                            for (int i = 0; i < dgvAlarms.Rows.Count; i++)
                            {
                                for (int j = 0; j < dgvAlarms.Columns.Count; j++)
                                {
                                    worksheet.Cell(currentRow + i, j + 1).Value = dgvAlarms.Rows[i].Cells[j].Value?.ToString();
                                }
                            }

                            worksheet.Columns().AdjustToContents(); // Sütun genişliklerini ayarla
                            workbook.SaveAs(sfd.FileName);
                            MessageBox.Show("Rapor başarıyla Excel'e aktarıldı.", "Başarılı", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Excel'e aktarılırken bir hata oluştu: {ex.Message}", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
