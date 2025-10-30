using DataAccessLayer.Abstract;
using DataAccessLayer.Concrete;
using DataAccessLayer.Repository;
using EntityLayer.Concrete;

namespace DataAccessLayer.EntityFramework;

public class EfEducationDal : GenericRepository<Education> , IEducationDal
{
    public EfEducationDal(AppDbContext context) : base(context)
    {
    }
}