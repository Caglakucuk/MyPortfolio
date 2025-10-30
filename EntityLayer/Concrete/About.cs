using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace EntityLayer.Concrete;

[Table("About")]
public class About
{
    [Key]
    public int about_id { get; set; }
    
    public string title { get; set; }
    
    public string description { get; set; }
    
    public string img_url { get; set; }
}