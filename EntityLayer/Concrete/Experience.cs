using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EntityLayer.Concrete;

[Table("Experience")]
public class Experience
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)] 
    public int experience_id { get; set; }
    public string company_name{ get; set; }
    public string role{ get; set; }
    public DateTime start_date{ get; set; }
    public DateTime end_date{ get; set; }
}