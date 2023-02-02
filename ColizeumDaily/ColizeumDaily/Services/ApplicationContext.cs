using ColizeumDaily.Models;
using Microsoft.EntityFrameworkCore;

namespace ColizeumDaily.Services;

public class ApplicationContext :DbContext
{
    public DbSet<UserModel> users { get; set; } = null!;

    public ApplicationContext(DbContextOptions<ApplicationContext> options)
        : base(options)
    { 
    }
    
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseNpgsql("Host=localhost;Port=5432;Database=ColizeumDailyDb;Username=postgres;Password=1111");
    }
}