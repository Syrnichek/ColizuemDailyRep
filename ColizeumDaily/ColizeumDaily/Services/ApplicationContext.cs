using ColizeumDaily.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;

namespace ColizeumDaily.Services;

public class ApplicationContext :DbContext
{
    public DbSet<UserModel> Users { get; set; } = null!;

    public ApplicationContext()
    {
        Database.EnsureCreated();
    }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseNpgsql("Host=localhost;Port=5433;Database=usersdb;Username=postgres;Password=1111");
    }
}