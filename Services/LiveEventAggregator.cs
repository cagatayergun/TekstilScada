// Services/LiveEventAggregator.cs
using System;
using TekstilScada.Models; // YENİ EKLENTİ: Modelleri kullanmak için bu satır eklendi.

namespace TekstilScada.Services
{
    // Olayları toplayan ve yayınlayan merkezi servis
    public class LiveEventAggregator
    {
        // Singleton deseni: Programda bu sınıftan sadece bir tane olacak
        private static readonly LiveEventAggregator _instance = new LiveEventAggregator();
        public static LiveEventAggregator Instance => _instance;

        // Yeni bir olay geldiğinde tetiklenecek olan event
        public event Action<LiveEvent> OnEventPublished;

        private LiveEventAggregator() { }

        public void Publish(LiveEvent liveEvent)
        {
            // Olayı tüm dinleyicilere yayınla
            OnEventPublished?.Invoke(liveEvent);
        }

        // Yardımcı metotlar
        public void PublishAlarm(string machineName, string message)
        {
            Publish(new LiveEvent { Timestamp = DateTime.Now, Source = machineName, Message = message, Type = EventType.Alarm });
        }
        public void PublishProcessEvent(string machineName, string message)
        {
            Publish(new LiveEvent { Timestamp = DateTime.Now, Source = machineName, Message = message, Type = EventType.Process });
        }
        public void PublishSystemInfo(string message)
        {
            Publish(new LiveEvent { Timestamp = DateTime.Now, Source = "Sistem", Message = message, Type = EventType.SystemInfo });
        }
    }
}