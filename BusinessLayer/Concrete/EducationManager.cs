using BusinessLayer.Abstract;
using DataAccessLayer.Abstract;
using EntityLayer.Concrete;

namespace BusinessLayer.Concrete;

public class EducationManager : IEducationService
{
    IEducationDal _educationDal;

    public EducationManager(IEducationDal educationDal)
    {
        _educationDal = educationDal;
    }
    public void TAdd(Education t)
    {
        _educationDal.Insert(t);
    }

    public void TDelete(Education t)
    {
        _educationDal.Delete(t);
    }

    public void TUpdate(Education t)
    {
        _educationDal.Update(t);
    }

    public List<Education> TGetList()
    {
        return _educationDal.GetList();
    }

    public Education TGetById(int id)
    {
        return _educationDal.GetById(id);
    }
}