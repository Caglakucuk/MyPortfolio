using BusinessLayer.Concrete;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Linq;

[Authorize]
public class MessagesController : Controller
{
    // Bağımlılığı Manager ile değiştiriyoruz
    private readonly MessagesManager _messagesManager;

    public MessagesController(MessagesManager messagesManager)
    {
        _messagesManager = messagesManager;
    }

    // Mesaj Listesi Sayfası
    [HttpGet]
    public IActionResult Index()
    {
        var messages = _messagesManager.TGetList()
            .OrderByDescending(m => m.message_id)
            .ToList();
            
        return View(messages);
    }
    
    // Mesaj Detay Sayfası
    [HttpGet]
    public IActionResult MessageDetail(int id)
    {
        var message = _messagesManager.TGetById(id);
        
        if (message == null)
        {
            return NotFound();
        }
        
        return View(message);
    }
    
    // Mesaj Silme İşlemi
    [HttpPost]
    public IActionResult DeleteMessage(int id)
    {
        var message = _messagesManager.TGetById(id);
        
        if (message != null)
        {
            _messagesManager.TDelete(message);
        }
        
        return RedirectToAction("Index");
    }
}