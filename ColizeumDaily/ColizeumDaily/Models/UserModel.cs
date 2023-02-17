using System.ComponentModel.DataAnnotations;

namespace ColizeumDaily.Models;

public class UserModel
{
    public int id { get; set; }
    
    [Phone]
    public int usernumber { get; set; }
    
    public string? telegramusername { get; set; }

    public int nightpacksstreak { get; set; }

    public int daysstreak { get; set; }
    
    public DateTime visitdate { get; set; }
}