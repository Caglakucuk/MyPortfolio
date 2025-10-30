using DataAccessLayer.Abstract;
using DataAccessLayer.Concrete;
using DataAccessLayer.Repository;
using EntityLayer.Concrete;

namespace DataAccessLayer.EntityFramework;

public class EfHomePageDal : GenericRepository<HomePage>, IHomePageDal
{
    public EfHomePageDal(AppDbContext context) : base(context)
    {
    }
}