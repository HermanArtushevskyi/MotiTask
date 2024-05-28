using Microsoft.EntityFrameworkCore;

namespace motitask;

public class DBContext : DbContext
{
    public DbSet<Alternative> Alternatives { get; set; }
    public DbSet<Criterion> Criteria { get; set; }
    public DbSet<Mark> Marks { get; set; }
    public DbSet<LPR> LPRs { get; set; }
    public DbSet<Result> Results { get; set; }
    public DbSet<Vector> Vectors { get; set; }
    
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlite(@"Data Source=C:\Users\germa\Desktop\GitHubReps\moti\motitask\motitask\drone.db");
    }
}