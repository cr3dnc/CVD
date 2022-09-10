using System.Data;
using System.Text;
using CVD.Interfaces.Repositories;
using CVD.Models.EmployeeModels;
using CVD.Extensions.AppSettings;
using Dapper;
using Microsoft.Extensions.Options;
using Npgsql;

namespace CVD.Repositories;

public class CvdRepository:ICvdRepository
{
    private readonly ConnectionOptions _connectionOptions;

    public CvdRepository(IOptions<ConnectionOptions> options)
    {
        _connectionOptions = options.Value;
    }
    public List<SalarySumModel> GetSalarySum(bool withChief)
    {
        using (IDbConnection db = new NpgsqlConnection(_connectionOptions.CvdWebApiConnection))
        {
            var query = new StringBuilder();
            query.Append("SELECT dep2.name as Department, dep1.salary FROM (SELECT SUM(salary) AS salary, employee.department_id");
            query.Append(" FROM employee LEFT JOIN department ON employee.department_id = department.id");
            query.Append(withChief == true
                ? " WHERE employee.chief_id IS NOT NULL"
                : " WHERE employee.chief_id IS NULL");
            query.Append(" GROUP BY department_id) dep1");
            query.Append(" LEFT JOIN department AS dep2 ON dep1.department_id = dep2.id");
            return db.Query<SalarySumModel>(query.ToString()).ToList();
        }
    }
    public string GetDepartmentWithMaxSalary()
    {
        using (IDbConnection db = new NpgsqlConnection(_connectionOptions.CvdWebApiConnection))
        {
            return db.Query<string>("SELECT d.name FROM employee " +
                                    "JOIN department as d ON employee.department_id = d.id " +
                                    "WHERE salary = ( SELECT MAX(salary) FROM employee )").FirstOrDefault();
        }
    }
    public List<ChiefSalaryModel> GetChiefSalary()
    {
        using (IDbConnection db = new NpgsqlConnection(_connectionOptions.CvdWebApiConnection))
        {
            return db.Query<ChiefSalaryModel>("SELECT chief_id , name, salary From employee WHERE chief_id IS NOT NULL ORDER BY salary DESC").ToList();
        }
    }
}