using DataAccessLayer.Concrete;
using Microsoft.AspNetCore.Mvc;

namespace MyPortfolio.ViewComponents.Dashboard;

public class Last5Certificates : ViewComponent
{
    private readonly AppDbContext _context;

    public Last5Certificates(AppDbContext context)
    {
        _context = context;
    }
    
    public IViewComponentResult Invoke()
    {
        var lastFiveCertificates = _context.Sertificate
            .OrderByDescending(s => s.sertificate_id)
            .Take(5)
            .ToList();
        
        return View(lastFiveCertificates);
    }
    
}