using System.ComponentModel.DataAnnotations;

namespace EntityLayer.Concrete;

// Sadece tek admin kullanıcısını tutmak için basit bir yapı
public class AdminUser
{
    [Key]
    public int AdminID { get; set; }
    
    [StringLength(50)]
    public string Username { get; set; }
    
    [StringLength(100)] 
    public string PasswordHash { get; set; }
    
    [StringLength(20)]
    public string Role { get; set; } = "Admin"; 
    
    [StringLength(100)]
    public string FullName { get; set; }
}