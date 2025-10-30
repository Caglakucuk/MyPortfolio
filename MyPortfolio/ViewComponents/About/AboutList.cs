using BusinessLayer.Concrete;
using BusinessLayer.Abstract; // Eğer bir arayüzünüz varsa (Örn: IHomePageService)
using Microsoft.AspNetCore.Mvc;

namespace MyPortfolio.ViewComponents.HomePage;

public class AboutList : ViewComponent
{
    private readonly AboutManager _aboutManager; 
    
    public AboutList(AboutManager aboutManager)
    {
        _aboutManager = aboutManager;
    }

    public IViewComponentResult Invoke()
    {
        var values = _aboutManager.TGetList();
        return View(values);
    }
}