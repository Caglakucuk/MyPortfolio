using BusinessLayer.Concrete;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace MyPortfolio.Controllers;
[Authorize]
public class SertificateController : Controller
{
    private readonly SertificateManager _sertificateManager;

    public SertificateController(SertificateManager sertificateManager)
    {
        _sertificateManager = sertificateManager;
    }

    public IActionResult Index()
    {
        ViewBag.d1 = "Sertifika Listesi";
        ViewBag.d2 = "Sertifikalar";
        ViewBag.d3 = "Sertifika Listesi";
        var values = _sertificateManager.TGetList();
        return View(values);
    }

    [HttpGet]
    public IActionResult AddSertificate()
    {
        ViewBag.d1 = "Sertifika Ekleme";
        ViewBag.d2 = "Seritifikalar";
        ViewBag.d3 = "Sertifika Ekleme";
        return View();
    }

    [HttpPost]
    public IActionResult AddSertificate(Sertificate sertificate)
    {
        _sertificateManager.TAdd(sertificate);
        return RedirectToAction("Index");
    }

    public IActionResult DeleteSertificate(int id)
    {
        var values = _sertificateManager.TGetById(id);
        _sertificateManager.TDelete(values);
        return RedirectToAction("Index");
    }

    [HttpGet]
    public IActionResult EditSertificate(int id)
    {
        ViewBag.d1 = "Sertifika Güncelle";
        ViewBag.d2 = "Sertifikaler";
        ViewBag.d3 = "Sertifika Güncelle";
        var values = _sertificateManager.TGetById(id);
        return View(values);
    }

    [HttpPost]
    public IActionResult EditSertificate(Sertificate sertificate)
    {
        
        _sertificateManager.TUpdate(sertificate);
        return RedirectToAction("Index");
    }
}