using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EntityLayer.Concrete;

[Table("Sertificate")]
public class Sertificate
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)] 

    public int sertificate_id { get; set; }
    public string sertificate_name { get; set; }
    public string company  { get; set; }
    public string img_url { get; set; }
}