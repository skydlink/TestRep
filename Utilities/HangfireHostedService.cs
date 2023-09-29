using AzureTestMVC.Models;
using AzureTestMVC.Repositories;
using Hangfire;

namespace AzureTestMVC.Utilities
{
    public class HangfireHostedService : IHostedService
    {

        public async Task BackgroundJobTodo()
        {
            EmployeeGenerator employeeGenerator = new EmployeeGenerator();
            EmployeeRepository employeeRepository = new EmployeeRepository();
            List<Employee> employees = employeeGenerator.GenerateEmployees(500);
            await employeeRepository.InsertEmployees(employees);
            List<Employee> employeeList = await employeeRepository.GetEmployees();
        }

        public async Task StartAsync(CancellationToken stoppingToken)
        {
            // The code in here will run when the application starts, and block the startup process until finished

            try
            {
                RecurringJob.AddOrUpdate("myrecurringjob5mins", () => BackgroundJobTodo(), Cron.MinuteInterval(5));
                RecurringJob.AddOrUpdate("myrecurringjob10mins", () => BackgroundJobTodo(), Cron.MinuteInterval(10));
            }
            catch (Exception ex)
            {

            }
        }

        public Task StopAsync(CancellationToken stoppingToken)
        {
            // The code in here will run when the application stops
            // In your case, nothing to do
            return Task.CompletedTask;
        }
    }
}
