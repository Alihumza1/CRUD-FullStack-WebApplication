using ClassLibrary2.Entity;
using ClassLibrary2.Reposiotory;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Nodes;
using System.Threading.Tasks;

namespace ClassLibrary2.Repository
{
    public class EmployeeRepository : IEmployeeRepository
    {
        private readonly DbContextcs db;
        public EmployeeRepository(DbContextcs contextcs)
        {
            db = contextcs;
        }
        public List<Employee> GetAllEmployees()
        {
            var employee = db.Employees.ToList();
            return employee;
        }
        public Employee GetEmployeeById(int id)
        {
            var employee = db.Employees.FirstOrDefault(z => z.Id == id);
            return employee;
        }
        public Employee GetEmployeeByDepId(int id)
        {
            var employee = db.Employees.Where(z => z.DepId == id).FirstOrDefault();
            return employee;
        }
        public Employee AddEmployee(Employee employee)
        {
            db.Employees.Add(employee);
            db.SaveChanges();
            return employee;
        }
        public void DeleteEmployee(int id)
        {
           
            var employee = GetEmployeeById(id);
            db.Employees.Remove(employee);
            db.SaveChanges();       
        }
        public void UpdateEmployee(Employee updateEmployee)
        {
            
            db.Employees.Update(updateEmployee);
            db.SaveChanges();
        }
        public class EmployeeDataTableResult
        {
            public List<Employee>? Data { get; set; }
            public int TotalRecords { get; set; }
        }
        public EmployeeDataTableResult GetData(string search, int start, int length , string columnOrder, string modelOrder)
        {
            IQueryable<Employee> EmployeesQuery = db.Employees;

            if (!string.IsNullOrEmpty(search))
            {
                EmployeesQuery = EmployeesQuery.Where(x => x.Name.Contains(search));
            }
            if (columnOrder!=null)
            {
                switch (columnOrder)
                {
                    case "name":
                        if (!string.IsNullOrEmpty(modelOrder) && modelOrder =="desc")
                        {
                            EmployeesQuery = EmployeesQuery.OrderByDescending(x => x.Name);
                        }
                        else
                        {
                            EmployeesQuery = EmployeesQuery.OrderBy(x => x.Name);
                        }
                        break;
                    case "salary":
                        if (!string.IsNullOrEmpty(modelOrder) && modelOrder == "desc")
                        {
                            EmployeesQuery = EmployeesQuery.OrderByDescending(x => x.Salary);
                        }
                        else
                        {
                            EmployeesQuery = EmployeesQuery.OrderBy(x => x.Salary);
                        }
                        break;
                    default:
                        if (!string.IsNullOrEmpty(modelOrder) && modelOrder == "desc")
                        {
                            EmployeesQuery = EmployeesQuery.OrderByDescending(x => x.Name);
                        }
                        else
                        {
                            EmployeesQuery = EmployeesQuery.OrderBy(x => x.Name);
                        }
                        break;
                }
            }
            int TotalCount = EmployeesQuery.Count();
            List<Employee> employees = EmployeesQuery
               .Skip(start)
               .Take(length)
               .ToList();
            return new EmployeeDataTableResult
            {
                Data = employees,
                TotalRecords = TotalCount
            };
        }
    }
}
