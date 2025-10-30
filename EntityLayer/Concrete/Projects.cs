using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EntityLayer.Concrete;

[Table("Projects")]
public class Projects
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)] 
    public int project_id { get; set; }
    public string title { get; set; }
    public string description { get; set; }
    public string? imageUrl { get; set; }
    public string githubLink { get; set; }
    public string technologies { get; set; }
    
}