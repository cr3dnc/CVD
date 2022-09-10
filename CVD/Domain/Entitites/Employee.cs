namespace CVD.Domain.Entitites;

public class Employee
{
    public int id { get; set; }
    public Department department_ { get; set; }
    public int? chief_id { get; set; }
    public string name { get; set; }
    public int salary { get; set; }
}