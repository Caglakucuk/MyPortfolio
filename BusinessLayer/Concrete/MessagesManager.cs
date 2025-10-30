using BusinessLayer.Abstract;
using DataAccessLayer.Abstract;

namespace BusinessLayer.Concrete;

public class MessagesManager : IMessagesService
{
    IMessagesDal _messagesDal;

    public MessagesManager(IMessagesDal messagesDal)
    {
        _messagesDal = messagesDal;
    }
    public void TAdd(Messages t)
    {
        _messagesDal.Insert(t);
    }

    public void TDelete(Messages t)
    {
        _messagesDal.Delete(t);
    }

    public void TUpdate(Messages t)
    {
        _messagesDal.Update(t);
    }

    public List<Messages> TGetList()
    {
        return _messagesDal.GetList();
    }

    public Messages TGetById(int id)
    {
        return _messagesDal.GetById(id);
    }
}