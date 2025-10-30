using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EntityLayer.Concrete;

[Table("Skills")]
public class Skills
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)] 
    public int skill_id { get; set; }
    public string skill_name { get; set; }
    public int level { get; set; }
}