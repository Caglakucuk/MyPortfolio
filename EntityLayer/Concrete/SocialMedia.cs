using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EntityLayer.Concrete;

[Table("SocialMedia")]
public class SocialMedia
{
    [Key]

    public int socialmedia_id { get; set; }
    
    public string name { get; set; }
    
    public string url { get; set; }
}