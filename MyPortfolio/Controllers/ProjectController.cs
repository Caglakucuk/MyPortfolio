using BusinessLayer.Concrete;
using BusinessLayer.ValidationRules;
using EntityLayer.Concrete;
using FluentValidation.Results;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace MyPortfolio.Controllers;

[Authorize]
public class ProjectController : Controller
{
    public readonly ProjectsManager _projectsManager;

    public ProjectController(ProjectsManager projectsManager)
    {
        _projectsManager = projectsManager;
    }
    public IActionResult Index()
    {
        ViewBag.d1 = "Proje Listesi";
        ViewBag.d2 = "Projeler";
        ViewBag.d3 = "Proje Listesi";
        var values = _projectsManager.TGetList();
        return View(values);
    }

    [HttpGet]
    public IActionResult AddProject()
    {
        return View();
    }
    [HttpPost]
    public IActionResult AddProject(Projects p)
    {
        ViewBag.d1 = "Proje Ekle";
        ViewBag.d2 = "Projeler";
        ViewBag.d3 = "Proje Ekle";
        ProjectValidator validations = new ProjectValidator();
        ValidationResult result = validations.Validate(p);
        if (result.IsValid)
        {
            _projectsManager.TAdd(p);
            return RedirectToAction("Index");
        }
        else
        {
            foreach (var item in result.Errors)
            {
                ModelState.AddModelError(item.PropertyName, item.ErrorMessage);
            }
        }

        return View();
    }
    
    public IActionResult DeleteProject(int id)
    {
        var values = _projectsManager.TGetById(id);
        _projectsManager.TDelete(values);
        return RedirectToAction("Index");
    }

    [HttpGet]
    public IActionResult EditProject(int id)
    {
        ViewBag.d1 = "Proje Güncelle";
        ViewBag.d2 = "Projeler";
        ViewBag.d3 = "Proje Güncelle";
        var values = _projectsManager.TGetById(id);
        return View(values);
    }

    [HttpPost]
    public IActionResult EditProject(Projects p)
    {
        
        _projectsManager.TUpdate(p);
        return RedirectToAction("Index");
    }

}