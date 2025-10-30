using DataAccessLayer.Concrete;
using Microsoft.AspNetCore.Mvc;

namespace MyPortfolio.ViewComponents.Dashboard;

public class MessageList : ViewComponent
{
    private readonly AppDbContext _context;

    public MessageList(AppDbContext context)
    {
        _context = context;
    }
    
    public IViewComponentResult Invoke()
    {
        var lastFiveMessages = _context.Messages
            .OrderByDescending(m => m.message_id)
            .Take(5)
            .ToList();
        return View(lastFiveMessages);
    }
}