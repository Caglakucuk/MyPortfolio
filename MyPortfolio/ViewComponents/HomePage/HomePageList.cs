using BusinessLayer.Concrete;
using BusinessLayer.Abstract; // Eğer bir arayüzünüz varsa (Örn: IHomePageService)
using Microsoft.AspNetCore.Mvc;

namespace MyPortfolio.ViewComponents.HomePage;

public class HomePageList : ViewComponent
{
    private readonly HomePageManager _homepageManager; 
    
    public HomePageList(HomePageManager homepageManager)
    {
        _homepageManager = homepageManager;
    }

    public IViewComponentResult Invoke()
    {
        var values = _homepageManager.TGetList();
        return View(values);
    }
}