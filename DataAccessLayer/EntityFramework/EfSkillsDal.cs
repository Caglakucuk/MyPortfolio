using DataAccessLayer.Abstract;
using DataAccessLayer.Concrete;
using DataAccessLayer.Repository;
using EntityLayer.Concrete;
using Microsoft.EntityFrameworkCore;

namespace DataAccessLayer.EntityFramework;

public class EfSkillsDal : GenericRepository<Skills>, ISkillsDal
{
    public EfSkillsDal(AppDbContext context) : base(context)
    {
        
    }
}