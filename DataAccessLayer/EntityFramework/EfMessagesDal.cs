using DataAccessLayer.Abstract;
using DataAccessLayer.Concrete;
using DataAccessLayer.Repository;
using Microsoft.EntityFrameworkCore;

namespace DataAccessLayer.EntityFramework;

public class EfMessagesDal : GenericRepository<Messages>, IMessagesDal
{
    public EfMessagesDal(AppDbContext context) : base(context)
    {
        
    }
}