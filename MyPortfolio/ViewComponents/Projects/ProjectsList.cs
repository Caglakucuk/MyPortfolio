using BusinessLayer.Concrete;
using BusinessLayer.Abstract; // Eğer bir arayüzünüz varsa (Örn: IHomePageService)
using Microsoft.AspNetCore.Mvc;

namespace MyPortfolio.ViewComponents.HomePage;

public class ProjectsList : ViewComponent
{
    private readonly ProjectsManager _projectsManager; 
    
    public ProjectsList(ProjectsManager projectsManager)
    {
        _projectsManager = projectsManager;
    }

    public IViewComponentResult Invoke()
    {
        var values = _projectsManager.TGetList();
        return View(values);
    }
}