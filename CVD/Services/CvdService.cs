using CVD.Interfaces.Repositories;
using CVD.Interfaces.Services;
using CVD.Models.EmployeeModels;

namespace CVD.Services;

public class CvdService:ICvdService
{
    private readonly ICvdRepository _cvdRepository;
    public CvdService(ICvdRepository cvdRepository)
    {
        _cvdRepository = cvdRepository;
    }

    public List<SalarySumModel> GetSalarySum(bool withChief)
    {
        var salarySum = _cvdRepository.GetSalarySum(withChief);
        return salarySum;
    }

    public string GetDepartmentWithMaxSalary()
    {
        var maxSalary = _cvdRepository.GetDepartmentWithMaxSalary();
        return maxSalary;
    }

    public List<ChiefSalaryModel> GetChiefSalary()
    {
        var chiefSalary = _cvdRepository.GetChiefSalary();
        return chiefSalary;
    }
}