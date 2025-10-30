using System.Security.Claims;
using DataAccessLayer.Concrete;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using MyPortfolio.Helpers;

namespace MyPortfolio.Controllers;

public class LoginController : Controller
{
    private readonly AppDbContext _context;

    public LoginController(AppDbContext context)
    {
        _context = context;
    }

    [HttpGet]
    public IActionResult Index()
    {
        if (User.Identity.IsAuthenticated)
        {
            return RedirectToAction("Index", "Dashboard");
        }

        return View();
    }

    [HttpPost]
    public async Task<IActionResult> Index(string username, string password)
    {
        var adminUser = _context.Admins.FirstOrDefault(x => x.Username == username);
    
        if (adminUser != null)
        {
            if (PasswordHasher.VerifyPassword(password, adminUser.PasswordHash))
            {
                var claims = new List<Claim>
                {
                    new Claim(ClaimTypes.Name, adminUser.FullName),
                    new Claim(ClaimTypes.Role, "Admin"),
                };
                var identity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);
                var principal = new ClaimsPrincipal(identity);
            
                // 💡 EKLENECEK 1: Oturumu Açma (Cookie oluşturma)
                await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, principal); 
            
                // 💡 EKLENECEK 2: Başarılı yönlendirme (Dashboard'a)
                return RedirectToAction("Index", "Dashboard"); 
            }
        }

        // Bu kısım sadece başarısız girişlerde çalışmalı
        ViewBag.ErrorMessage = "Kullanıcı adı veya şifre yanlış. Lütfen tekrar deneyin.";
        return View();
    }

    [HttpGet]
    public async Task<IActionResult> LogOut()
    {
        await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
        return RedirectToAction("Index", "Home");
    }
}