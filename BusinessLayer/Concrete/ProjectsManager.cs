using BusinessLayer.Abstract;
using DataAccessLayer.Abstract;
using EntityLayer.Concrete;

namespace BusinessLayer.Concrete;

public class ProjectsManager : IProjectsService
{
    IProjectsDal _projectsDal;

    public ProjectsManager(IProjectsDal projectsDal)
    {
        _projectsDal = projectsDal;
    }
    public void TAdd(Projects t)
    {
        _projectsDal.Insert(t);
    }

    public void TDelete(Projects t)
    {
        _projectsDal.Delete(t);
    }

    public void TUpdate(Projects t)
    {
        _projectsDal.Update(t);
    }

    public List<Projects> TGetList()
    {
        return _projectsDal.GetList();
    }

    public Projects TGetById(int id)
    {
        return _projectsDal.GetById(id);
    }
}