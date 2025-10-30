using BusinessLayer.Concrete;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace MyPortfolio.Controllers;

[Authorize]

public class AboutController : Controller
{
    private readonly AboutManager _aboutManager;

    public AboutController(AboutManager aboutManager)
    {
        _aboutManager = aboutManager;
    }

    public IActionResult Index()
    {
        ViewBag.d1 = "Düzenleme";
        ViewBag.d2 = "Hakkında";
        ViewBag.d3 = "Hakkında Düzenleme";
        return View();
    }

    [HttpGet]
    public IActionResult EditAbout(int id)
    {
        ViewBag.d1 = "Düzenleme";
        ViewBag.d2 = "Hakkında";
        ViewBag.d3 = "Hakkında Düzenleme";
        var values = _aboutManager.TGetById(1);
        return View(values);
    }

    [HttpPost]
    public IActionResult EditAbout(About about)
    {
        _aboutManager.TUpdate(about);
        return RedirectToAction("Index");
    }
}