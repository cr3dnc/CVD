using CVD.Domain.Entitites;
using Microsoft.EntityFrameworkCore;
namespace CVD.Domain;

public class CvdDbContext : DbContext
{
    public CvdDbContext(DbContextOptions<CvdDbContext> options) : base(options)
    {
    }
    public DbSet<Department> department { get; set; }
    public DbSet<Employee> employee { get; set; }
}