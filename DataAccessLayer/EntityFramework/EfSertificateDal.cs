using DataAccessLayer.Abstract;
using DataAccessLayer.Concrete;
using DataAccessLayer.Repository;
using EntityLayer.Concrete;
using Microsoft.EntityFrameworkCore;

namespace DataAccessLayer.EntityFramework;

public class EfSertificateDal : GenericRepository<Sertificate> ,ISertificateDal
{
    public EfSertificateDal(AppDbContext context) : base(context)
    {
        
    }
}