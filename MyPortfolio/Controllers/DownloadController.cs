using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Hosting;
using System.IO; // System.IO.File işlemleri için

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
        
        // DÜZELTME: Dosyayı wwwroot klasöründe ara.
        // Dosyanın wwwroot/cagla_kucuk_cv.pdf konumunda olduğunu varsayarız.
        var filePath = Path.Combine(_env.WebRootPath, fileName); 
        
        if (!System.IO.File.Exists(filePath))
        {
            // Debug için nerede aradığını görelim.
            // Bu sadece yerel test için faydalıdır.
            // return NotFound($"Dosya bulunamadı. Aranan yol: {filePath}");
            return NotFound("İstenen dosya bulunamadı.");
        }

        var fileStream = new FileStream(filePath, FileMode.Open, FileAccess.Read);
        var mimeType = "application/pdf";

        // FileStream'i indirme olarak gönderir, bu genellikle ReadAllBytes'tan daha verimlidir.
        return File(fileStream, mimeType, "Cagla_Kucuk_CV.pdf");
    }
}