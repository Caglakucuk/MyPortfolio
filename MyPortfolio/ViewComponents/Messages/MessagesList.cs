using BusinessLayer.Concrete;
using BusinessLayer.Abstract;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Mvc;

namespace MyPortfolio.ViewComponents.Messages;

public class MessagesList : ViewComponent
{
    private readonly MessagesManager _messagesManager;

    public MessagesList(MessagesManager messagesManager)
    {
        _messagesManager = messagesManager;
    }

    public IViewComponentResult Invoke()
    {
        return View();
    }
}