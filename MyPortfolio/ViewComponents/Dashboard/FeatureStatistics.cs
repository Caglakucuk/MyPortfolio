using Microsoft.AspNetCore.Mvc;

namespace MyPortfolio.ViewComponents.Dashboard;
using DataAccessLayer.Concrete;
public class FeatureStatistics : ViewComponent
{
 private readonly AppDbContext _context;

 public FeatureStatistics(AppDbContext context)
 {
  _context = context ;
 }
 public IViewComponentResult Invoke()
 {
  ViewBag.v1 = _context.Skills.Count();
  ViewBag.v2 = _context.Messages.Where(x=> x.status == false).Count();
  ViewBag.v3 = _context.Messages.Where(x=> x.status == true).Count();
  ViewBag.v4 = _context.Experiences.Count();
  return View();
 }
}
