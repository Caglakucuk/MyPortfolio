using Microsoft.Extensions.Options;
using System.Net;
using System.Net.Mail;
using EntityLayer.Common;
using EntityLayer.Concrete;


public class EmailSenderService
{
    private readonly SmtpSettings _smtpSettings;

    public EmailSenderService(IOptions<SmtpSettings> smtpSettings)
    {
        _smtpSettings = smtpSettings.Value;
    }

    public void SendContactMessage(Messages message)
    {
        // ⚠️ NOT: Eğer Hangfire veritabanına kaydederken 'Subject'i bulamama hatası alırsanız,
        // buradaki 'message.Subject' alanını, EntityLayer.Concrete.Messages sınıfınızdaki
        // doğru alan adı ile değiştirmeyi unutmayın (örneğin message.message_subject).
        
        try
        {
            var mailMessage = new MailMessage();
            mailMessage.To.Add(_smtpSettings.TargetEmail);
            mailMessage.From = new MailAddress(_smtpSettings.Username, message.name); 
            mailMessage.Subject = $"[PORTFOLYO YENİ MESAJ] - Konu: {message.message}";
            mailMessage.IsBodyHtml = true;
            mailMessage.Body = $@"
                <h3>Yeni Portfolyo İletişim Formu Mesajı</h3>
                <hr>
                <p><strong>Gönderen Adı:</strong> {message.name}</p>
                <p><strong>E-Posta:</strong> {message.email}</p>
                <p><strong>Konu:</strong> {message.message}</p>
                <p><strong>Gönderim Tarihi:</strong> {message.datetime.ToString("dd.MM.yyyy HH:mm")}</p>
                <hr>
                <p><strong>Mesaj İçeriği:</strong></p>
                <div style='border: 1px solid #ddd; padding: 15px; background-color: #f9f9f9;'>
                    {message.message}
                </div>
            ";

            var smtpClient = new SmtpClient(_smtpSettings.Host, _smtpSettings.Port)
            {
                Credentials = new NetworkCredential(_smtpSettings.Username, _smtpSettings.Password),
                EnableSsl = _smtpSettings.EnableSSL
            };

            smtpClient.Send(mailMessage);
        }
        catch (Exception ex)
        {
            // Hatanın Hangfire Dashboard'da görünmesi için bu throw edilmeli
            throw new InvalidOperationException($"E-posta gönderimi başarısız oldu: {ex.Message}", ex);
        }
    }
}