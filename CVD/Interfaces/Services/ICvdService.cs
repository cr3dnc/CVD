using CVD.Models.EmployeeModels;

namespace CVD.Interfaces.Services;

public interface ICvdService
{
    List<SalarySumModel> GetSalarySum(bool withChief);
    string GetDepartmentWithMaxSalary();
    List<ChiefSalaryModel> GetChiefSalary();
}