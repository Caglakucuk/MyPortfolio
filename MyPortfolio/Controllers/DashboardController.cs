using DataAccessLayer.Concrete;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using Microsoft.AspNetCore.Authorization;

namespace MyPortfolio.Controllers;

[Authorize]
public class DashboardController : Controller
{
    private readonly AppDbContext _context;

    public DashboardController(AppDbContext context)
    {
        _context = context;
    }

    public IActionResult Index()
    {
        ViewBag.d1 = "İstatistik Sayfası";
        ViewBag.d2 = "İstatistikler";
        ViewBag.d3 = "İstatistik Sayfası";
        return View();
    }

   
}