// Controllers/MessageController.cs

using BusinessLayer.Concrete;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Mvc;
using System;
using Hangfire;
using Microsoft.AspNetCore.Authorization;


namespace MyPortfolio.Controllers

{
    public class MessageController : Controller
    {
        private readonly MessagesManager _messagesManager;

        public MessageController(MessagesManager messagesManager)
        {
            _messagesManager = messagesManager;
        }

        [HttpPost]
        public IActionResult Index(Messages p) // Form action'ı ile eşleşecek
        {
            // Model validasyonunu kontrol edebilirsiniz (örneğin [Required] alanlar)
            if (ModelState.IsValid)
            {
                p.datetime = DateTime.UtcNow; // ToShortDateString() kullanmak yerine DateTime.Now daha iyi
                p.status = true;
                _messagesManager.TAdd(p);
                BackgroundJob.Enqueue<EmailSenderService>(
                    service => service.SendContactMessage(p) 
                );

                // Başarılı mesajı TempData'ye ekle
                TempData["MessageResult"] = "Mesajınız başarıyla gönderildi! 🚀 Size en kısa sürede dönüş yapacağız.";

                // Post işleminden sonra GET isteğine yönlendir (PRG Deseni: Post/Redirect/Get)
                // Yönlendirme, genellikle formun bulunduğu sayfaya yapılmalıdır.
                // Eğer form ana sayfadaysa, ana sayfaya yönlendirin.
                return RedirectToAction("Index", "Default"); // DefaultController'ın Index action'ına yönlendir

            }
            
            // Eğer validasyon hatası varsa (ModelState.IsValid false ise)
            TempData["MessageResult"] = "Mesaj gönderilirken bir hata oluştu. Lütfen tüm alanları kontrol edin.";
            return RedirectToAction("Index", "Default"); // Tekrar yönlendir (veya formun bulunduğu View'ı döndür)
        }
    }
}