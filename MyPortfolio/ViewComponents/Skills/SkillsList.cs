using BusinessLayer.Concrete;
using Microsoft.AspNetCore.Mvc;

namespace MyPortfolio.ViewComponents.Skills;

public class SkillsList : ViewComponent
{
    private readonly SkillsManager _skillsManager; 
    
    public SkillsList(SkillsManager skillsManager)
    {
        _skillsManager = skillsManager;
    }

    public IViewComponentResult Invoke()
    {
        var values = _skillsManager.TGetList();
        return View(values);
    }
}