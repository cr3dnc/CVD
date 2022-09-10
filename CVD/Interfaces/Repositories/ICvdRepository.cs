using CVD.Models.EmployeeModels;

namespace CVD.Interfaces.Repositories;

public interface ICvdRepository
{
    List<SalarySumModel> GetSalarySum(bool withChief);
    string GetDepartmentWithMaxSalary();
    List<ChiefSalaryModel> GetChiefSalary();
}