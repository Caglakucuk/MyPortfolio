using BusinessLayer.Abstract;
using DataAccessLayer.Abstract;
using EntityLayer.Concrete;

namespace BusinessLayer.Concrete;

public class SkillsManager : ISkillsService
{
    ISkillsDal _skillsDal;

    public SkillsManager(ISkillsDal skillsDal)
    {
        _skillsDal = skillsDal;
    }
    
    public void TAdd(Skills t)
    {
        _skillsDal.Insert(t);
    }

    public void TDelete(Skills t)
    {
        _skillsDal.Delete(t);
    }

    public void TUpdate(Skills t)
    {
        _skillsDal.Update(t);
    }

    public List<Skills> TGetList()
    {
        return _skillsDal.GetList();
    }

    public Skills TGetById(int id)
    {
        return _skillsDal.GetById(id);
    }
}