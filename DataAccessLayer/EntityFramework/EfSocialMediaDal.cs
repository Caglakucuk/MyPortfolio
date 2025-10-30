using DataAccessLayer.Abstract;
using DataAccessLayer.Concrete;
using DataAccessLayer.Repository;
using EntityLayer.Concrete;

namespace DataAccessLayer.EntityFramework;

public class EfSocialMediaDal :GenericRepository<SocialMedia>, ISocialMediaDal
{
    public EfSocialMediaDal(AppDbContext context) : base(context)
    {
        
    }
}