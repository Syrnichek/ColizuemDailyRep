using System.Diagnostics.CodeAnalysis;

namespace ColizeumDaily.Models;

public class UserModel
{
    public int id { get; set; }
    public string Username { get; set; }
    public string? TelegramUsername { get; set; }
    public int DaysStreak { get; set; }
}