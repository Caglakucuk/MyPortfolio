using BusinessLayer.Concrete;
using Microsoft.AspNetCore.Mvc;

namespace MyPortfolio.ViewComponents.Skills;

public class SocialMediaList : ViewComponent
{
    private readonly SocialMediaManager _socialmediaManager; 
    
    public SocialMediaList(SocialMediaManager socialmediaManager)
    {
        _socialmediaManager = socialmediaManager;
    }

    public IViewComponentResult Invoke()
    {
        var values = _socialmediaManager.TGetList();
        return View(values);
    }
}