using BusinessLayer.Concrete;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Mvc;
using System;
using Microsoft.AspNetCore.Authorization;

namespace MyPortfolio.Controllers;

[Authorize]
public class ExperienceController : Controller
{
    private readonly ExperienceManager _experienceManager;

    public ExperienceController(ExperienceManager experienceManager)
    {
        _experienceManager = experienceManager;
    }

    public IActionResult Index()
    {
        ViewBag.d1 = "Deneyim Listesi";
        ViewBag.d2 = "Deneyimler";
        ViewBag.d3 = "Deneyim Listesi";
        var values = _experienceManager.TGetList();
        return View(values);
    }

    [HttpGet]
    public IActionResult AddExperience()
    {
        ViewBag.d1 = "Deneyim Ekleme";
        ViewBag.d2 = "Deneyimler";
        ViewBag.d3 = "Deneyimler Ekleme";
        return View();
    }

    [HttpPost]
    public IActionResult AddExperience(Experience experience)
    {
        experience.start_date = DateTime.SpecifyKind(experience.start_date, DateTimeKind.Utc);
        experience.end_date = DateTime.SpecifyKind(experience.end_date, DateTimeKind.Utc);
        
        _experienceManager.TAdd(experience);
        return RedirectToAction("Index");
    }

    public IActionResult DeleteExperience(int id)
    {
        var values = _experienceManager.TGetById(id);
        _experienceManager.TDelete(values);
        return RedirectToAction("Index");
    }

    [HttpGet]
    public IActionResult EditExperience(int id)
    {
        ViewBag.d1 = "Deneyim Güncelle";
        ViewBag.d2 = "Deneyimler";
        ViewBag.d3 = "Deneyim Güncelle";
        var values = _experienceManager.TGetById(id);
        return View(values);
    }

    [HttpPost]
    public IActionResult EditExperience(Experience experience)
    {
        // HasValue kaldırıldı. Doğrudan Kind bilgisini ayarlıyoruz.
        experience.start_date = DateTime.SpecifyKind(experience.start_date, DateTimeKind.Utc);
        experience.end_date = DateTime.SpecifyKind(experience.end_date, DateTimeKind.Utc);
        
        _experienceManager.TUpdate(experience);
        return RedirectToAction("Index");
    }
}