using System.ComponentModel.DataAnnotations.Schema;

namespace CVD.Domain.Entitites;

public class Employee
{
    public int id { get; set; }
    public int department_id { get; set; }
    [ForeignKey("department_id")]
    public Department department { get; set; }
    public int? chief_id { get; set; }
    public string name { get; set; }
    public int salary { get; set; }
}