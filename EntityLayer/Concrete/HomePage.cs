using System.ComponentModel.DataAnnotations;

namespace EntityLayer.Concrete;

public class HomePage
{
    [Key]
    public int id { get; set; }
    public string page_title { get; set; }
    public string title { get; set; }
    public string description { get; set; }
}