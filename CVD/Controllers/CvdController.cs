using CVD.Interfaces.Services;
using Microsoft.AspNetCore.Mvc;

namespace CVD.Controllers;

[ApiController]
[Route("[controller]")]
public class CvdController : Controller
{
    private readonly ICvdService _cvdService;

    public CvdController(ICvdService cvdService)
    {
        _cvdService = cvdService;
    }

    [HttpGet("GetSalarySum")]
    public IActionResult GetSalarySum(bool withChief)
    {
        var salarySum = _cvdService.GetSalarySum(withChief);
        return Ok(salarySum);
    }
    [HttpGet("GetDepartmentWithMaxSalary")]
    public IActionResult GetDepartmentWithMaxSalary()
    {
        var maxSalary = _cvdService.GetDepartmentWithMaxSalary();
        return Ok(maxSalary);
    }
    [HttpGet("GetChiefSalary")]
    public IActionResult GetChiefSalary()
    {
        var chiefSalary = _cvdService.GetChiefSalary();
        return Ok(chiefSalary);
    }
}