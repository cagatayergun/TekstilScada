// Services/FtpService.cs
using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace TekstilScada.Services
{
    public class FtpService
    {
        private readonly string _host;
        private readonly string _username;
        private readonly string _password;

        public FtpService(string host, string username, string password)
        {
            _host = host;
            _username = username;
            _password = password;
        }

        private FtpWebRequest CreateRequest(string method, string path = "")
        {
            var request = (FtpWebRequest)WebRequest.Create($"ftp://{_host}/{path}");
            request.Credentials = new NetworkCredential(_username, _password);
            request.Method = method;
            request.UsePassive = true;
            request.UseBinary = true;
            request.KeepAlive = false;
            return request;
        }

        public async Task<List<string>> ListDirectoryAsync(string remoteDirectory)
        {
            var fileList = new List<string>();
            try
            {
                var request = CreateRequest(WebRequestMethods.Ftp.ListDirectory, remoteDirectory);
                using (var response = (FtpWebResponse)await request.GetResponseAsync())
                using (var stream = response.GetResponseStream())
                using (var reader = new StreamReader(stream))
                {
                    string line;
                    while ((line = await reader.ReadLineAsync()) != null)
                    {
                        fileList.Add(line);
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception($"FTP dizini listelenemedi: {ex.Message}");
            }
            return fileList;
        }

        public async Task<string> DownloadFileAsync(string remoteFilePath)
        {
            try
            {
                var request = CreateRequest(WebRequestMethods.Ftp.DownloadFile, remoteFilePath);
                using (var response = (FtpWebResponse)await request.GetResponseAsync())
                using (var stream = response.GetResponseStream())
                using (var reader = new StreamReader(stream, Encoding.ASCII)) // CSV dosyaları için ASCII
                {
                    return await reader.ReadToEndAsync();
                }
            }
            catch (Exception ex)
            {
                throw new Exception($"FTP dosyası indirilemedi ({remoteFilePath}): {ex.Message}");
            }
        }

        public async Task UploadFileAsync(string remoteFilePath, string fileContent)
        {
            try
            {
                var request = CreateRequest(WebRequestMethods.Ftp.UploadFile, remoteFilePath);
                byte[] fileBytes = Encoding.ASCII.GetBytes(fileContent);
                request.ContentLength = fileBytes.Length;

                using (var requestStream = await request.GetRequestStreamAsync())
                {
                    await requestStream.WriteAsync(fileBytes, 0, fileBytes.Length);
                }

                using (var response = (FtpWebResponse)await request.GetResponseAsync())
                {
                    // Başarılı yükleme durumunu kontrol et
                    if (response.StatusCode != FtpStatusCode.ClosingData)
                    {
                        // İsteğe bağlı olarak loglama yapılabilir.
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception($"FTP dosyası yüklenemedi ({remoteFilePath}): {ex.Message}");
            }
        }
    }
}
