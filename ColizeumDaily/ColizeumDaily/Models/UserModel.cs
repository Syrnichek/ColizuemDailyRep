namespace ColizeumDaily.Models;

public class UserModel
{
    public int id { get; set; }
    public string username { get; set; }
    public string? telegramusername { get; set; }
    
    public int daysstreak { get; set; }
    
    public DateTime visitdate { get; set; }
}