using Hangfire;
using Microsoft.AspNetCore.Mvc;
using AzureTestMVC.Models;
using AzureTestMVC.Repositories;

namespace AzureTestMVC.Controllers
{
    public class TestController : Controller
    {
        

        [HttpGet]
        public async Task<IActionResult> PerformTest()
        {
            try
            {
                EmployeeGenerator employeeGenerator = new EmployeeGenerator();
                EmployeeRepository employeeRepository = new EmployeeRepository();
                List<Employee> employees = employeeGenerator.GenerateEmployees(500);
                await employeeRepository.InsertEmployees(employees);

                List<Employee> employeeList = await employeeRepository.GetEmployees();

                return Json(employeeList);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

        }
    }
}
