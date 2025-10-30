using BusinessLayer.Concrete;
using BusinessLayer.Abstract; // Eğer bir arayüzünüz varsa (Örn: IHomePageService)
using Microsoft.AspNetCore.Mvc;

namespace MyPortfolio.ViewComponents.HomePage;

public class SertificateList : ViewComponent
{
    private readonly SertificateManager _sertificateManager; 
    
    public SertificateList(SertificateManager sertificateManager)
    {
        _sertificateManager = sertificateManager;
    }

    public IViewComponentResult Invoke()
    {
        var values = _sertificateManager.TGetList();
        return View(values);
    }
}