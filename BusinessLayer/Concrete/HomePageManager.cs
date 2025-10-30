using BusinessLayer.Abstract;
using DataAccessLayer.Abstract;
using EntityLayer.Concrete;

namespace BusinessLayer.Concrete;

public class HomePageManager : IHomePageService
{
    IHomePageDal _homePageDal;

    public HomePageManager(IHomePageDal homePageDal)
    {
        _homePageDal = homePageDal;
    }
    public void TAdd(HomePage t)
    {
        _homePageDal.Insert(t);
    }

    public void TDelete(HomePage t)
    {
        _homePageDal.Delete(t);
    }

    public void TUpdate(HomePage t)
    {
        _homePageDal.Update(t);
    }

    public List<HomePage> TGetList()
    {
        return _homePageDal.GetList();
    }

    public HomePage TGetById(int id)
    {
        return _homePageDal.GetById(id);
    }
}