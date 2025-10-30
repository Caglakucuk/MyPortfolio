using BusinessLayer.Concrete;
using BusinessLayer.Abstract; // Eğer bir arayüzünüz varsa (Örn: IHomePageService)
using Microsoft.AspNetCore.Mvc;

namespace MyPortfolio.ViewComponents.HomePage;

public class ExperiencesList : ViewComponent
{
    private readonly ExperienceManager _experienceManager; 
    
    public ExperiencesList(ExperienceManager experienceManager)
    {
        _experienceManager = experienceManager;
    }

    public IViewComponentResult Invoke()
    {
        var values = _experienceManager.TGetList();
        return View(values);
    }
}