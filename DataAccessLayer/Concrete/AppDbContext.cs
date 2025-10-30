using EntityLayer.Concrete;
using Microsoft.EntityFrameworkCore;

namespace DataAccessLayer.Concrete
{
public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }
    public DbSet<About> Abouts { get; set; }
    public DbSet<Projects> Projects { get; set; }
    public DbSet<Experience> Experiences { get; set; }
    public DbSet<HomePage> HomePages { get; set; }
    public DbSet<Education> Education { get; set; }
    public DbSet<Skills> Skills { get; set; }
    public DbSet<Messages> Messages { get; set; }
    public DbSet<SocialMedia> SocialMedia { get; set; }
    public DbSet<Sertificate> Sertificate { get; set; }
    public DbSet<AdminUser> Admins { get; set; }
    
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        if (!optionsBuilder.IsConfigured)
        {
            optionsBuilder.UseNpgsql("Host=localhost;Port=5432;Database=portfolio_db;Username=postgres;Password=1234");
        }
    }
}
}
