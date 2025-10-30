using System.ComponentModel.DataAnnotations;

public class Messages
{
    [Key]
    public int message_id { get; set; }
    public string name { get; set; }
    public string email { get; set; }
    public string message { get; set; }
    public DateTime datetime { get; set; }
    public bool status { get; set; }
}