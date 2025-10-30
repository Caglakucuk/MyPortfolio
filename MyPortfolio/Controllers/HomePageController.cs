using BusinessLayer.Concrete;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace MyPortfolio.Controllers;

[Authorize]

public class HomePageController : Controller
{
   private readonly HomePageManager _homePageManager;

   public HomePageController(HomePageManager homePageManager)
   {
       _homePageManager = homePageManager;
   }
    public IActionResult Index()
    {
        return View();
    }
    [HttpGet]
    public IActionResult EditHomePage(int id)
    {
        ViewBag.d1 = "Düzenleme";
        ViewBag.d2 = "Ana Sayfa";
        ViewBag.d3 = "Ana Sayfası";
        var values = _homePageManager.TGetById(1);
        return View(values);
    }

    [HttpPost]
    public IActionResult EditHomePage(HomePage homepage)
    {
        _homePageManager.TUpdate(homepage);
        return RedirectToAction("Index");
    }
}