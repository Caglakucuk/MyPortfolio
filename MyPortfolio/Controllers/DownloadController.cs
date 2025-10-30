// Örnek: DownloadController.cs
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Hosting; // IWebHostEnvironment'ı kullanmak için

public class DownloadController : Controller
{
    private readonly IWebHostEnvironment _env;

    public DownloadController(IWebHostEnvironment env)
    {
        _env = env;
    }

    public IActionResult DownloadCv()
    {
        var fileName = "cagla_kucuk_cv.pdf";
        var filePath = Path.Combine(_env.ContentRootPath, "PrivateFiles", fileName); 
        
        if (!System.IO.File.Exists(filePath))
        {
            return NotFound("İstenen dosya bulunamadı.");
        }

        var fileBytes = System.IO.File.ReadAllBytes(filePath);
        var mimeType = "application/pdf"; // PDF dosyası için MIME tipi

        // Dosyayı kullanıcıya indirme olarak gönderir
        return File(fileBytes, mimeType, "Cagla_Kucuk_CV.pdf");
    }
}