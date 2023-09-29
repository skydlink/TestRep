using AzureTestMVC.Models;
using Npgsql;
using Dapper;

namespace AzureTestMVC.Repositories
{
    public class EmployeeRepository
    {
        public async Task InsertEmployees(List<Employee> employees)
        {
            using (NpgsqlConnection connection = new NpgsqlConnection("User ID=test_server;Password=redman123$;Host=load-test-server.postgres.database.azure.com;Port=5432;Database=azure_test;Timeout=500;"))
            {
                await connection.OpenAsync();

                using (NpgsqlTransaction transaction = connection.BeginTransaction())
                {
                    string sql = @"INSERT INTO 
                                        public.employee(employee_id, first_name, last_name, birthdate, hire_date, department, job_title, salary, email, phone_number, address, city, state, postal_code, country, emergency_contact_name, emergency_contact_phone, manager_id, marital_status, gender)
	                                VALUES 
                                        (@EmployeeID, @FirstName, @LastName, @Birthdate, @HireDate, @Department, @JobTitle, @Salary, @Email, @PhoneNumber, @Address, @City, @State, @PostalCode, @Country, @EmergencyContactName, @EmergencyContactPhone, @ManagerID, @MaritalStatus, @Gender);";

                    int sqlRowsAffected = await connection.ExecuteAsync(sql, employees);

                    if (sqlRowsAffected <= 0)
                    {
                        throw new Exception("Unable to insert request. Zero rows were inserted.");
                    }

                    await transaction.CommitAsync();
                }

                await connection.CloseAsync();
            }
        }


        public async Task<List<Employee>> GetEmployees()
        {
            List<Employee> employees;

            using (NpgsqlConnection connection = new NpgsqlConnection("User ID=test_server;Password=redman123$;Host=load-test-server.postgres.database.azure.com;Port=5432;Database=azure_test;Timeout=500;"))
            {
                string sql = @"SELECT
    employee_id AS ""EmployeeID"",
    first_name AS ""FirstName"",
    last_name AS ""LastName"",
    birthdate AS ""Birthdate"",
    hire_date AS ""HireDate"",
    department AS ""Department"",
    job_title AS ""JobTitle"",
    salary AS ""Salary"",
    email AS ""Email"",
    phone_number AS ""PhoneNumber"",
    address AS ""Address"",
    city AS ""City"",
    state AS ""State"",
    postal_code AS ""PostalCode"",
    country AS ""Country"",
    emergency_contact_name AS ""EmergencyContactName"",
    emergency_contact_phone AS ""EmergencyContactPhone"",
    manager_id AS ""ManagerID"",
    marital_status AS ""MaritalStatus"",
    gender AS ""Gender""
FROM
    public.employee
LIMIT 1000;";
                employees = (await connection.QueryAsync<Employee>(sql)).ToList();
            }

            return employees;
        }
    }
}
