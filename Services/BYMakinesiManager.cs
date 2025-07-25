// Services/BYMakinesiManager.cs
using HslCommunication;
using HslCommunication.Profinet.LSIS;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TekstilScada.Models; // BU SATIR EKLENDİ

namespace TekstilScada.Services
{
    // BatchSummaryData ve ChemicalConsumptionData sınıfları buradan SİLİNDİ.

    public class BYMakinesiManager : IPlcManager
    {
        private readonly LSFastEnet _plcClient;
        public string IpAddress { get; private set; }

        public BYMakinesiManager(string ipAddress, int port)
        {
            _plcClient = new LSFastEnet(ipAddress, port);
            this.IpAddress = ipAddress;
            _plcClient.ReceiveTimeOut = 5000;
        }

        // ... Bu dosyanın geri kalan tüm metotları aynı kalacak ...
        // (Connect, Disconnect, ReadLiveStatusData, WriteRecipeToPlcAsync vb.)

        public OperateResult Connect()
        {
            Debug.WriteLine($"[{DateTime.Now:HH:mm:ss}] {IpAddress} (BY) -> Bağlantı deneniyor...");
            var result = _plcClient.ConnectServer();
            if (result.IsSuccess)
                Debug.WriteLine($"[{DateTime.Now:HH:mm:ss}] {IpAddress} (BY) -> Bağlantı BAŞARILI.");
            else
                Debug.WriteLine($"[{DateTime.Now:HH:mm:ss}] {IpAddress} (BY) -> Bağlantı BAŞARISIZ: {result.Message}");
            return result;
        }

        public OperateResult Disconnect()
        {
            return _plcClient.ConnectClose();
        }
        private OperateResult<string> ReadStringFromWords(string address, ushort wordLength)
        {
            // Veriyi önce ham word dizisi olarak oku
            var readResult = _plcClient.ReadInt16(address, wordLength);
            if (!readResult.IsSuccess)
            {
                // Hata durumunda, hangi adreste sorun olduğunu belirterek geri dön
                return OperateResult.CreateFailedResult<string>(new OperateResult($"Adres bloğu okunamadı: {address}, Hata: {readResult.Message}"));
            }

            try
            {
                // Okunan word dizisini byte dizisine çevir
                byte[] byteData = new byte[readResult.Content.Length * 2];
                Buffer.BlockCopy(readResult.Content, 0, byteData, 0, byteData.Length);

                // Byte dizisini ASCII metne çevir ve gereksiz karakterleri temizle
                string value = Encoding.ASCII.GetString(byteData).Trim('\0', ' ');
                return OperateResult.CreateSuccessResult(value);
            }
            catch (Exception ex)
            {
                return new OperateResult<string>($"String dönüşümü sırasında hata: {ex.Message}");
            }
        }
        public OperateResult<FullMachineStatus> ReadLiveStatusData()
        {
            try
            {
                var status = new FullMachineStatus();

                var adimNoResult = _plcClient.ReadInt16("D70");
                if (!adimNoResult.IsSuccess) return OperateResult.CreateFailedResult<FullMachineStatus>(adimNoResult);
                status.AktifAdimNo = adimNoResult.Content;
                Debug.WriteLine($"1");
                var receteModuResult = _plcClient.ReadBool("KX30D");
                if (!receteModuResult.IsSuccess) return OperateResult.CreateFailedResult<FullMachineStatus>(receteModuResult);
                status.IsInRecipeMode = receteModuResult.Content;
                Debug.WriteLine($"2");
                var pauseResult = _plcClient.ReadBool("MX1015");
                if (!pauseResult.IsSuccess) return OperateResult.CreateFailedResult<FullMachineStatus>(pauseResult);
                status.IsPaused = pauseResult.Content;
                Debug.WriteLine($"3");
                var alarmNoResult = _plcClient.ReadInt16("D3604");
                if (!alarmNoResult.IsSuccess) return OperateResult.CreateFailedResult<FullMachineStatus>(alarmNoResult);
                status.ActiveAlarmNumber = alarmNoResult.Content;
                status.HasActiveAlarm = alarmNoResult.Content > 0;
                Debug.WriteLine($"4");
                var suSeviyesiResult = _plcClient.ReadInt16("D6002");
                if (!suSeviyesiResult.IsSuccess) return OperateResult.CreateFailedResult<FullMachineStatus>(suSeviyesiResult);
                status.AnlikSuSeviyesi = suSeviyesiResult.Content;
                Debug.WriteLine($"5");
                var devirResult = _plcClient.ReadInt16("D6007");
                if (!devirResult.IsSuccess) return OperateResult.CreateFailedResult<FullMachineStatus>(devirResult);
                status.AnlikDevirRpm = devirResult.Content;
                Debug.WriteLine($"6");
                var sicaklikResult = _plcClient.ReadInt16("D4980");
                if (!sicaklikResult.IsSuccess) return OperateResult.CreateFailedResult<FullMachineStatus>(sicaklikResult);
                status.AnlikSicaklik = sicaklikResult.Content;
                Debug.WriteLine($"7");
                var yuzdeResult = _plcClient.ReadInt16("D7752");
                if (!yuzdeResult.IsSuccess) return OperateResult.CreateFailedResult<FullMachineStatus>(yuzdeResult);
                status.ProsesYuzdesi = yuzdeResult.Content;
                Debug.WriteLine($"8");
                var makineTipiResult = ReadStringFromWords("D6100", 10);
                if (!makineTipiResult.IsSuccess) return OperateResult.CreateFailedResult<FullMachineStatus>(makineTipiResult);
                status.MakineTipi = makineTipiResult.Content;
                Debug.WriteLine($"9");
                var siparisNoResult = ReadStringFromWords("D6110", 10);
                if (!siparisNoResult.IsSuccess) return OperateResult.CreateFailedResult<FullMachineStatus>(siparisNoResult);
                status.SiparisNumarasi = siparisNoResult.Content;
                Debug.WriteLine($"10");
                var musteriNoResult = ReadStringFromWords("D6120", 10);
                if (!musteriNoResult.IsSuccess) return OperateResult.CreateFailedResult<FullMachineStatus>(musteriNoResult);
                status.MusteriNumarasi = musteriNoResult.Content;
                Debug.WriteLine($"11");
                var batchNoResult = ReadStringFromWords("D6130", 10);
                if (!batchNoResult.IsSuccess) return OperateResult.CreateFailedResult<FullMachineStatus>(batchNoResult);
                status.BatchNumarasi = batchNoResult.Content;
                Debug.WriteLine($"12");
                // 10 karakter = 5 word
                var operatorResult = ReadStringFromWords("D6460", 5);
                if (!operatorResult.IsSuccess) return OperateResult.CreateFailedResult<FullMachineStatus>(operatorResult);
                status.OperatorIsmi = operatorResult.Content;
                Debug.WriteLine($"13");
                var recipeNameResult = ReadStringFromWords("D2550", 5);
                if (!recipeNameResult.IsSuccess) return OperateResult.CreateFailedResult<FullMachineStatus>(recipeNameResult);
                status.RecipeName = recipeNameResult.Content;

                var suResult = _plcClient.ReadInt16("D7702");
                if (!suResult.IsSuccess) return OperateResult.CreateFailedResult<FullMachineStatus>(suResult);
                status.SuMiktari = suResult.Content;

                var elektrikResult = _plcClient.ReadInt16("D7720");
                if (!elektrikResult.IsSuccess) return OperateResult.CreateFailedResult<FullMachineStatus>(elektrikResult);
                status.ElektrikHarcama = elektrikResult.Content;

                var buharResult = _plcClient.ReadInt16("D7744");
                if (!buharResult.IsSuccess) return OperateResult.CreateFailedResult<FullMachineStatus>(buharResult);
                status.BuharHarcama = buharResult.Content;

                status.ConnectionState = ConnectionStatus.Connected;
                return OperateResult.CreateSuccessResult(status);

                // --- YENİ: OEE VERİLERİNİ OKUMA ---
                var isProductionResult = _plcClient.ReadBool("M2501");
                if (!isProductionResult.IsSuccess) return OperateResult.CreateFailedResult<FullMachineStatus>(isProductionResult);
                status.IsMachineInProduction = isProductionResult.Content;

                var downTimeResult = _plcClient.ReadInt32("D7764"); // 32-bit (Double Word)
                if (!downTimeResult.IsSuccess) return OperateResult.CreateFailedResult<FullMachineStatus>(downTimeResult);
                status.TotalDownTimeSeconds = downTimeResult.Content;

                var cycleTimeResult = _plcClient.ReadInt16("D6411"); // 16-bit (Word)
                if (!cycleTimeResult.IsSuccess) return OperateResult.CreateFailedResult<FullMachineStatus>(cycleTimeResult);
                status.StandardCycleTimeMinutes = cycleTimeResult.Content;

                var totalProdResult = _plcClient.ReadInt16("D7768"); // 16-bit (Word)
                if (!totalProdResult.IsSuccess) return OperateResult.CreateFailedResult<FullMachineStatus>(totalProdResult);
                status.TotalProductionCount = totalProdResult.Content;

                var defectiveProdResult = _plcClient.ReadInt16("D7770"); // 16-bit (Word)
                if (!defectiveProdResult.IsSuccess) return OperateResult.CreateFailedResult<FullMachineStatus>(defectiveProdResult);
                status.DefectiveProductionCount = defectiveProdResult.Content;
            }
            catch (Exception ex)
            {
                return new OperateResult<FullMachineStatus>($"Okuma sırasında istisna oluştu: {ex.Message}");
            }
        }
        public Task<OperateResult> AcknowledgeAlarm()
        {
            // TODO: BYMakinesi için alarm onaylama bitini (örn: M100) true yapacak kodu yaz.
            // Şimdilik NotImplementedException fırlatıyoruz.
            throw new NotImplementedException("BYMakinesi için alarm onaylama henüz implemente edilmedi.");
        }
        public async Task<OperateResult> WriteRecipeToPlcAsync(ScadaRecipe recipe, int? recipeSlot = null)
        {
            if (recipe.Steps.Count != 98) return new OperateResult("Reçete 98 adım olmalıdır.");

            short[] fullRecipeData = new short[2450];
            foreach (var step in recipe.Steps)
            {
                int offset = (step.StepNumber - 1) * 25;
                if (offset + step.StepDataWords.Length <= fullRecipeData.Length)
                {
                    Array.Copy(step.StepDataWords, 0, fullRecipeData, offset, step.StepDataWords.Length);
                }
            }

            ushort chunkSize = 100;
            for (int i = 0; i < fullRecipeData.Length; i += chunkSize)
            {
                string currentAddress = $"D{100 + i}";
                short[] chunk = fullRecipeData.Skip(i).Take(chunkSize).ToArray();
                var writeResult = await Task.Run(() => _plcClient.Write(currentAddress, chunk));
                if (!writeResult.IsSuccess)
                {
                    return new OperateResult($"Reçete yazma hatası. Adres: {currentAddress}, Hata: {writeResult.Message}");
                }
            }

            byte[] recipeNameBytes = Encoding.ASCII.GetBytes(recipe.RecipeName.PadRight(10, ' ').Substring(0, 10));
            var nameWriteResult = await Task.Run(() => _plcClient.Write("D2550", recipeNameBytes));
            if (!nameWriteResult.IsSuccess)
            {
                return new OperateResult($"Reçete ismi yazma hatası: {nameWriteResult.Message}");
            }

            return OperateResult.CreateSuccessResult();
        }

        public async Task<OperateResult<short[]>> ReadRecipeFromPlcAsync()
        {
            short[] fullRecipeData = new short[2450];
            ushort chunkSize = 60;

            for (int i = 0; i < fullRecipeData.Length; i += chunkSize)
            {
                string currentAddress = $"D{100 + i}";
                ushort readLength = (ushort)Math.Min(chunkSize, fullRecipeData.Length - i);

                var readResult = await Task.Run(() => _plcClient.ReadInt16(currentAddress, readLength));
                if (!readResult.IsSuccess)
                {
                    return OperateResult.CreateFailedResult<short[]>(new OperateResult($"Reçete okunurken hata oluştu. Adres: {currentAddress}, Hata: {readResult.Message}"));
                }

                int lengthToCopy = Math.Min(readLength, readResult.Content.Length);
                Array.Copy(readResult.Content, 0, fullRecipeData, i, lengthToCopy);

                await Task.Delay(20);
            }

            return OperateResult.CreateSuccessResult(fullRecipeData);
        }

        public async Task<OperateResult<List<PlcOperator>>> ReadPlcOperatorsAsync()
        {
            var readResult = await Task.Run(() => _plcClient.ReadInt16("D7500", 60));
            if (!readResult.IsSuccess)
            {
                return OperateResult.CreateFailedResult<List<PlcOperator>>(readResult);
            }

            var operators = new List<PlcOperator>();
            var rawData = readResult.Content;

            for (int i = 0; i < 5; i++)
            {
                int offset = i * 12;
                byte[] nameBytes = new byte[20];
                Buffer.BlockCopy(rawData, offset * 2, nameBytes, 0, 20);
                string name = Encoding.ASCII.GetString(nameBytes).Trim('\0', ' ');

                operators.Add(new PlcOperator
                {
                    SlotIndex = i,
                    Name = name,
                    UserId = rawData[offset + 10],
                    Password = rawData[offset + 11]
                });
            }

            return OperateResult.CreateSuccessResult(operators);
        }

        public async Task<OperateResult> WritePlcOperatorAsync(PlcOperator plcOperator)
        {
            string startAddress = $"D{7500 + plcOperator.SlotIndex * 12}";
            byte[] dataToWrite = new byte[24];
            byte[] nameBytes = Encoding.ASCII.GetBytes(plcOperator.Name.PadRight(20).Substring(0, 20));
            Buffer.BlockCopy(nameBytes, 0, dataToWrite, 0, 20);
            BitConverter.GetBytes(plcOperator.UserId).CopyTo(dataToWrite, 20);
            BitConverter.GetBytes(plcOperator.Password).CopyTo(dataToWrite, 22);
            var writeResult = await Task.Run(() => _plcClient.Write(startAddress, dataToWrite));
            return writeResult;
        }

        public async Task<OperateResult<PlcOperator>> ReadSinglePlcOperatorAsync(int slotIndex)
        {
            string startAddress = $"D{7500 + slotIndex * 12}";

            var readResult = await Task.Run(() => _plcClient.ReadInt16(startAddress, 12));
            if (!readResult.IsSuccess)
            {
                return OperateResult.CreateFailedResult<PlcOperator>(readResult);
            }

            var rawData = readResult.Content;
            byte[] nameBytes = new byte[20];
            Buffer.BlockCopy(rawData, 0, nameBytes, 0, 20);
            string name = Encoding.ASCII.GetString(nameBytes).Trim('\0', ' ');

            var plcOperator = new PlcOperator
            {
                SlotIndex = slotIndex,
                Name = name,
                UserId = rawData[10],
                Password = rawData[11]
            };

            return OperateResult.CreateSuccessResult(plcOperator);
        }

        public async Task<OperateResult<BatchSummaryData>> ReadBatchSummaryDataAsync()
        {
            try
            {
                var summary = new BatchSummaryData();
                var waterResult = await Task.Run(() => _plcClient.ReadInt16("D7702"));
                if (!waterResult.IsSuccess) return OperateResult.CreateFailedResult<BatchSummaryData>(waterResult);
                summary.TotalWater = waterResult.Content;
                var electricityResult = await Task.Run(() => _plcClient.ReadInt16("D7720"));
                if (!electricityResult.IsSuccess) return OperateResult.CreateFailedResult<BatchSummaryData>(electricityResult);
                summary.TotalElectricity = electricityResult.Content;
                var steamResult = await Task.Run(() => _plcClient.ReadInt16("D7744"));
                if (!steamResult.IsSuccess) return OperateResult.CreateFailedResult<BatchSummaryData>(steamResult);
                summary.TotalSteam = steamResult.Content;
                return OperateResult.CreateSuccessResult(summary);
            }
            catch (Exception ex)
            {
                return new OperateResult<BatchSummaryData>($"Özet verileri okunurken istisna oluştu: {ex.Message}");
            }
        }

        public async Task<OperateResult<List<ChemicalConsumptionData>>> ReadChemicalConsumptionDataAsync()
        {
            var consumptionList = new List<ChemicalConsumptionData>();
            try
            {
                var namesResult = await Task.Run(() => _plcClient.ReadInt16("D6201", 90));
                if (!namesResult.IsSuccess) return OperateResult.CreateFailedResult<List<ChemicalConsumptionData>>(namesResult);

                var litersResult = await Task.Run(() => _plcClient.ReadInt16("D6351", 30));
                if (!litersResult.IsSuccess) return OperateResult.CreateFailedResult<List<ChemicalConsumptionData>>(litersResult);

                var stepsResult = await Task.Run(() => _plcClient.ReadInt16("D7250", 30));
                if (!stepsResult.IsSuccess) return OperateResult.CreateFailedResult<List<ChemicalConsumptionData>>(stepsResult);

                for (int i = 0; i < 30; i++)
                {
                    if (stepsResult.Content[i] > 0)
                    {
                        byte[] nameBytes = new byte[6];
                        Buffer.BlockCopy(namesResult.Content, i * 3 * 2, nameBytes, 0, 6);
                        string chemicalName = System.Text.Encoding.ASCII.GetString(nameBytes).Trim('\0', ' ');

                        consumptionList.Add(new ChemicalConsumptionData
                        {
                            StepNumber = stepsResult.Content[i],
                            ChemicalName = chemicalName,
                            AmountLiters = litersResult.Content[i]
                        });
                    }
                }
                return OperateResult.CreateSuccessResult(consumptionList);
            }
            catch (Exception ex)
            {
                return new OperateResult<List<ChemicalConsumptionData>>($"Kimyasal tüketim verileri okunurken hata: {ex.Message}");
            }
        }

        public async Task<OperateResult<List<ProductionStepDetail>>> ReadStepAnalysisDataAsync()
        {
            var stepDetails = new List<ProductionStepDetail>();
            try
            {
                var readResult = await Task.Run(() => _plcClient.ReadInt16("D6500", 392));
                if (!readResult.IsSuccess)
                {
                    return OperateResult.CreateFailedResult<List<ProductionStepDetail>>(readResult);
                }

                var rawData = readResult.Content;

                for (int i = 0; i < 98; i++)
                {
                    int offset = i * 4;
                    var step = new ProductionStepDetail
                    {
                        StepNumber = i + 1,
                        TheoreticalTime = rawData[offset].ToString(),
                        WorkingTime = rawData[offset + 1].ToString(),
                        StopTime = rawData[offset + 2].ToString(),
                        DeflectionTime = rawData[offset + 3].ToString()
                    };
                    stepDetails.Add(step);
                }

                return OperateResult.CreateSuccessResult(stepDetails);
            }
            catch (Exception ex)
            {
                return new OperateResult<List<ProductionStepDetail>>($"Adım analiz verileri okunurken hata: {ex.Message}");
            }
        }
        // YENİ: PLC'deki OEE sayaçlarını sıfırlayan metot
        public async Task<OperateResult> ResetOeeCountersAsync()
        {
            // D7764 (Duruş Süresi) adresine 0 yaz
            var downTimeResetResult = await Task.Run(() => _plcClient.Write("D7764", 0));
            if (!downTimeResetResult.IsSuccess)
            {
                return new OperateResult($"Duruş süresi sayacı sıfırlanamadı: {downTimeResetResult.Message}");
            }

            // D7770 (Hatalı Üretim) adresine 0 yaz
            var defectiveResetResult = await Task.Run(() => _plcClient.Write("D7770", 0));
            if (!defectiveResetResult.IsSuccess)
            {
                return new OperateResult($"Hatalı üretim sayacı sıfırlanamadı: {defectiveResetResult.Message}");
            }

            return OperateResult.CreateSuccessResult();
        }
        // YENİ: PLC'deki üretim sayacını bir artıran metot
        public async Task<OperateResult> IncrementProductionCounterAsync()
        {
            // D7768 adresindeki mevcut değeri oku
            var readResult = await Task.Run(() => _plcClient.ReadInt16("D7768"));
            if (!readResult.IsSuccess)
            {
                return new OperateResult($"Üretim sayacı okunamadı: {readResult.Message}");
            }

            // Değeri bir artır ve geri yaz
            short newCount = (short)(readResult.Content + 1);
            var writeResult = await Task.Run(() => _plcClient.Write("D7768", newCount));

            return writeResult;
        }
    }
}
