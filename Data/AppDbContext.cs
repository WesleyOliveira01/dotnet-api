using Microsoft.EntityFrameworkCore;

public class AppDbContext : DbContext
{
    public DbSet<Estudante> estudantes { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseNpgsql(
            "Host=roundhouse.proxy.rlwy.net;Port=13042;Database=railway;Username=postgres;Password=HDNkQdfEJieMnDgWydwWKRbLIOWrMCsW;"
        );
        base.OnConfiguring(optionsBuilder);
    }
}
