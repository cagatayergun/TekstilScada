using FubarDev.FtpServer;
using FubarDev.FtpServer.AccountManagement;
using FubarDev.FtpServer.FileSystem.DotNet;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.IO;
using System.Security.Claims;
using System.Security.Principal;
using System.Threading;
using System.Threading.Tasks;
using TekstilScada.Services;
using TekstilScada.Models;
namespace TekstilScada.Services
{
    public class FtpServerService
    {
        private readonly ServiceProvider _serviceProvider;
        private IFtpServerHost _ftpServerHost;
        private CancellationTokenSource _cancellationTokenSource;

        public FtpServerService()
        {
            var services = new ServiceCollection();

            string rootPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "FtpRecipes");
            if (!Directory.Exists(rootPath))
            {
                Directory.CreateDirectory(rootPath);
            }

            // Kendi kullanıcı doğrulama sistemimizi (IMembershipProvider) ekle.
            services.AddSingleton<IMembershipProvider, CustomMembershipProvider>();

            // Gerekli temel FTP servislerini ve dosya sistemini ekle.
            services.AddFtpServer(builder => builder
                .UseDotNetFileSystem());

            // Sunucu ve Port ayarlarını yap.
            services.Configure<FtpServerOptions>(options =>
            {
                options.ServerAddress = "0.0.0.0";
                options.Port = 21;
            });

            // Dosya sistemi için kök dizini ayarla.
            services.Configure<DotNetFileSystemOptions>(options => options.RootPath = rootPath);

            _serviceProvider = services.BuildServiceProvider();
        }

        public async Task StartAsync()
        {
            if (_ftpServerHost != null) return;

            try
            {
                // YENİ LOG: Sunucuyu başlatma denemesi loglandı.
                LiveEventAggregator.Instance.Publish(new LiveEvent
                {
                    Type = EventType.SystemInfo,
                    Source = "FTP Server",
                    Message = "Sunucu başlatılıyor..."
                });

                _ftpServerHost = _serviceProvider.GetRequiredService<IFtpServerHost>();
                _cancellationTokenSource = new CancellationTokenSource();
                await _ftpServerHost.StartAsync(_cancellationTokenSource.Token);

                // YENİ LOG: Başarılı başlatma loglandı.
                LiveEventAggregator.Instance.Publish(new LiveEvent
                {
                    Type = EventType.SystemSuccess, // Başarı mesajı için tipi değiştirildi.
                    Source = "FTP Server",
                    Message = "Sunucu başarıyla başlatıldı. Adres: 34.59.65.254:21"
                });
            }
            catch (Exception ex)
            {
                // YENİ LOG: Başlatma hatası detaylı loglandı.
                LiveEventAggregator.Instance.Publish(new LiveEvent
                {
                    Type = EventType.SystemWarning,
                    Source = "FTP Server",
                    Message = $"Sunucu başlatılamadı: {ex.Message}"
                });
            }
        }

        public async Task StopAsync()
        {
            if (_ftpServerHost == null) return;

            try
            {
                // YENİ LOG: Sunucuyu durdurma denemesi loglandı.
                LiveEventAggregator.Instance.Publish(new LiveEvent
                {
                    Type = EventType.SystemInfo,
                    Source = "FTP Server",
                    Message = "Sunucu durduruluyor..."
                });

                if (_cancellationTokenSource != null)
                {
                    _cancellationTokenSource.Cancel();
                }
                await _ftpServerHost.StopAsync();
                _ftpServerHost = null;

                // YENİ LOG: Başarılı durdurma loglandı.
                LiveEventAggregator.Instance.Publish(new LiveEvent
                {
                    Type = EventType.SystemInfo,
                    Source = "FTP Server",
                    Message = "Sunucu başarıyla durduruldu."
                });
            }
            catch (Exception ex)
            {
                // YENİ LOG: Durdurma hatası detaylı loglandı.
                LiveEventAggregator.Instance.Publish(new LiveEvent
                {
                    Type = EventType.SystemWarning,
                    Source = "FTP Server",
                    Message = $"Sunucu durdurulurken hata: {ex.Message}"
                });
            }
        }
    }

    public class CustomMembershipProvider : IMembershipProvider
    {
        public Task<MemberValidationResult> ValidateUserAsync(string username, string password)
        {
            if (string.Equals(username, "yilmakls", StringComparison.OrdinalIgnoreCase) &&
                string.Equals(password, "345965254", StringComparison.Ordinal))
            {
                var user = new FtpUser(username);
                return Task.FromResult(new MemberValidationResult(MemberValidationStatus.AuthenticatedUser, (ClaimsPrincipal)user));
            }

            return Task.FromResult(new MemberValidationResult(MemberValidationStatus.InvalidLogin));
        }
    }

    public class FtpUser : ClaimsPrincipal, IFtpUser
    {
        public FtpUser(string name)
        {
            Name = name;
            var identity = new GenericIdentity(name, "FTP");
            AddIdentity(new ClaimsIdentity(identity));
        }

        public string Name { get; }
        public bool IsInGroup(string groupName) => true;
    }
}