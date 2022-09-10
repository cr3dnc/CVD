using CVD.Domain.Entitites;
using Microsoft.EntityFrameworkCore;

namespace CVD.Extensions.Database;

public class DbInitializer
{
    private readonly ModelBuilder modelBuilder;

    public DbInitializer(ModelBuilder modelBuilder)
    {
        this.modelBuilder = modelBuilder;
    }

    public void Seed()
    {
        modelBuilder.Entity<Department>().HasData(
            new Department(){ id = 1, name = "D1" },
            new Department(){ id = 2, name = "D2" },
            new Department(){ id = 3, name = "D3" }
        );
        modelBuilder.Entity<Employee>().HasData(
            new Employee(){ id = 1, department_id = 1, chief_id = 5,name = "John", salary = 100 },
            new Employee(){ id = 2, department_id = 1, chief_id = 5,name = "Misha", salary = 600 },
            new Employee(){ id = 3, department_id = 2, chief_id = 6,name = "Eugen", salary = 300 },
            new Employee(){ id = 4, department_id = 2, chief_id = 6,name = "Tolya", salary = 400 },
            new Employee(){ id = 5, department_id = 3, chief_id = 7,name = "Stepan", salary = 500 },
            new Employee(){ id = 6, department_id = 3, chief_id = 7,name = "Alex", salary = 1000 },
            new Employee(){ id = 7, department_id = 3, chief_id = null,name = "Ivan", salary = 1100 }
        );
    }
}