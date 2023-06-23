using ClassLibrary2.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary2.InitialMigration
{
    public static class DataSeed
    {
        public static void SeedData(DbContextcs dbContext)
        {
            if (!dbContext.Departments.Any())
            {
                // Seed department data
                var departments = new[]
                {
                    new Department {  Name = "Jane Smith", HeadName = " Smith", Location = "Lahore" },
                };
                dbContext.Departments.AddRange(departments);
                dbContext.SaveChanges();
            }
            if (!dbContext.Employees.Any())
            {
                // Seed employee data
                var employees = new[]
                {
                    new Employee { Name = "John Doe", DepId = 7, Manager = "Jane Smith", Cnic = "12345678901234", Age = 30, Salary = 50000},
                };
                dbContext.Employees.AddRange(employees);
                dbContext.SaveChanges();
            }
            if (!dbContext.User.Any())
            {
                // Seed user data
                var user = new[]
                {
                    new User {  UserName = "alihumza792@gmail.com", PassWord = "Ali2538@"},
                };
                dbContext.User.AddRange(user);
                dbContext.SaveChanges();
            }
        }
    }
}
