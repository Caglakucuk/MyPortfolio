using DataAccessLayer.Abstract;
using DataAccessLayer.Concrete;
using DataAccessLayer.Repository;
using EntityLayer.Concrete;
using Microsoft.EntityFrameworkCore;

namespace DataAccessLayer.EntityFramework;

public class EfExperienceDal : GenericRepository<Experience>, IExperienceDal
{
    public EfExperienceDal(AppDbContext context) : base(context)
    {
        
    }
}