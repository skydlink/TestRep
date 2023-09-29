using AzureTestMVC.Models;

namespace AzureTestMVC.Repositories
{
    public class EmployeeGenerator
    {
        private Random random = new Random();

        public List<Employee> GenerateEmployees(int numberOfEmployees)
        {
            var employees = new List<Employee>();

            for (int i = 0; i < numberOfEmployees; i++)
            {
                var employee = new Employee
                {
                    EmployeeID = Guid.NewGuid(),
                    FirstName = GenerateRandomFirstName(),
                    LastName = GenerateRandomLastName(),
                    Birthdate = GenerateRandomBirthdate(),
                    HireDate = GenerateRandomHireDate(),
                    Department = GenerateRandomDepartment(),
                    JobTitle = GenerateRandomJobTitle(),
                    Salary = GenerateRandomSalary(),
                    Email = GenerateRandomEmail(),
                    PhoneNumber = GenerateRandomPhoneNumber(),
                    Address = GenerateRandomAddress(),
                    City = GenerateRandomCity(),
                    State = GenerateRandomState(),
                    PostalCode = GenerateRandomPostalCode(),
                    Country = GenerateRandomCountry(),
                    EmergencyContactName = GenerateRandomEmergencyContactName(),
                    EmergencyContactPhone = GenerateRandomPhoneNumber(),
                    ManagerID = random.Next(1, numberOfEmployees + 1),
                    MaritalStatus = GenerateRandomMaritalStatus(),
                    Gender = GenerateRandomGender()
                };

                employees.Add(employee);
            }

            return employees;
        }

        private string GenerateRandomFirstName()
        {
            string[] firstNames = { "John", "Jane", "Michael", "Emily", "David", "Sarah", "Robert", "Linda" };
            return firstNames[random.Next(firstNames.Length)];
        }

        private string GenerateRandomLastName()
        {
            string[] lastNames = { "Smith", "Johnson", "Brown", "Lee", "Davis", "Wilson", "Clark", "Taylor" };
            return lastNames[random.Next(lastNames.Length)];
        }

        private DateTime GenerateRandomBirthdate()
        {
            DateTime start = new DateTime(1960, 1, 1);
            int range = (DateTime.Today - start).Days;
            return start.AddDays(random.Next(range));
        }

        private DateTime GenerateRandomHireDate()
        {
            DateTime start = new DateTime(2010, 1, 1);
            int range = (DateTime.Today - start).Days;
            return start.AddDays(random.Next(range));
        }

        private string GenerateRandomDepartment()
        {
            string[] departments = { "HR", "Engineering", "Sales", "Marketing", "Finance" };
            return departments[random.Next(departments.Length)];
        }

        private string GenerateRandomJobTitle()
        {
            string[] jobTitles = { "Manager", "Engineer", "Sales Representative", "Marketing Specialist", "Accountant" };
            return jobTitles[random.Next(jobTitles.Length)];
        }

        private decimal GenerateRandomSalary()
        {
            return Math.Round((decimal)(random.NextDouble() * 50000 + 30000), 2);
        }

        private string GenerateRandomEmail()
        {
            return $"{GenerateRandomFirstName().ToLower()}.{GenerateRandomLastName().ToLower()}@example.com";
        }

        private string GenerateRandomPhoneNumber()
        {
            return $"{random.Next(100, 999)}-{random.Next(100, 999)}-{random.Next(1000, 9999)}";
        }

        private string GenerateRandomAddress()
        {
            return $"{random.Next(100, 999)} {GenerateRandomLastName()} St.";
        }

        private string GenerateRandomCity()
        {
            string[] cities = { "New York", "Los Angeles", "Chicago", "San Francisco", "Boston" };
            return cities[random.Next(cities.Length)];
        }

        private string GenerateRandomState()
        {
            string[] states = { "CA", "NY", "IL", "TX", "FL" };
            return states[random.Next(states.Length)];
        }

        private string GenerateRandomPostalCode()
        {
            return $"{random.Next(10000, 99999)}";
        }

        private string GenerateRandomCountry()
        {
            return "USA";
        }

        private string GenerateRandomEmergencyContactName()
        {
            string[] names = { "Mary", "Richard", "Susan", "William", "Karen" };
            return names[random.Next(names.Length)];
        }

        private string GenerateRandomMaritalStatus()
        {
            string[] statuses = { "Single", "Married", "Divorced", "Widowed" };
            return statuses[random.Next(statuses.Length)];
        }

        private string GenerateRandomGender()
        {
            string[] genders = { "Male", "Female", "Other" };
            return genders[random.Next(genders.Length)];
        }
    }
}
