using DataAccessLayer.Abstract;
using DataAccessLayer.Concrete;
using DataAccessLayer.Repository;
using EntityLayer.Concrete;

namespace DataAccessLayer.EntityFramework;

public class EfProjectsDal : GenericRepository<Projects> , IProjectsDal
{
    public EfProjectsDal(AppDbContext context) : base(context)
    {
        
    }
}