using System.ComponentModel.DataAnnotations;

namespace EntityLayer.Concrete;

public class Education
{
    [Key]
    public int education_id { get; set; }
    public string school_name { get; set; }
    public DateTime start_date { get; set; }
    public DateTime end_date { get; set; }
    
}