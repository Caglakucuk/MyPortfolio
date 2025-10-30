using DataAccessLayer.Concrete;
using Microsoft.AspNetCore.Mvc;

namespace MyPortfolio.ViewComponents.Dashboard;

public class Last5Projects : ViewComponent
{
    private readonly AppDbContext _context;

    public Last5Projects(AppDbContext context)
    {
        _context = context;
    }
    
    public IViewComponentResult Invoke()
    {
        var lastFiveProjects = _context.Projects
            .OrderByDescending(p => p.project_id)
            .Take(5)
            .ToList();
        
        return View(lastFiveProjects);
    }
    
}