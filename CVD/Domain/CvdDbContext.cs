using CVD.Domain.Entitites;
using CVD.Extensions.Database;
using Microsoft.EntityFrameworkCore;
namespace CVD.Domain;

public class CvdDbContext : DbContext
{
    public CvdDbContext(DbContextOptions<CvdDbContext> options) : base(options)
    {
    }
    public DbSet<Department> department { get; set; }
    public DbSet<Employee> employee { get; set; }
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        new DbInitializer(modelBuilder).Seed();
    }
}