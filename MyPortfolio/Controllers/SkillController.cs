using BusinessLayer.Concrete;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace MyPortfolio.Controllers;
[Authorize]
public class SkillController : Controller
{
    private readonly SkillsManager _skillsManager;

    public SkillController(SkillsManager skillsManager)
    {
        _skillsManager = skillsManager;
    }

    public IActionResult Index()
    {
        ViewBag.d1 = "Yetenek Listesi";
        ViewBag.d2 = "Yetenekler";
        ViewBag.d3 = "Yetenek Listesi";
        var skills = _skillsManager.TGetList();
        return View(skills);
    }

    [HttpGet]
    public IActionResult AddSkill()
    {
        ViewBag.d1 = "Yetenek Ekleme";
        ViewBag.d2 = "Yetenekler";
        ViewBag.d3 = "Yetenek Ekleme";
        return View();
    }

    [HttpPost]
    public IActionResult AddSkill(Skills skill)
    {
        _skillsManager.TAdd(skill);
        return RedirectToAction("Index");
    }
    public IActionResult DeleteSkill(int id)
    {
        var values = _skillsManager.TGetById(id);
        _skillsManager.TDelete(values);
        return RedirectToAction("Index");
    }
    [HttpGet]
    public IActionResult EditSkill(int id)
    {
        ViewBag.d1 = "Yetenek Güncelle";
        ViewBag.d2 = "Yetenekler";
        ViewBag.d3 = "Yetenek Güncelle";
        var values = _skillsManager.TGetById(id);
        return View(values);
    }

    [HttpPost]
    public IActionResult EditSkill(Skills skill)
    {
        _skillsManager.TUpdate(skill);
        return RedirectToAction("Index");
    }
}