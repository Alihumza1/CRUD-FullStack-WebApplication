  
using ClassLibrary2.Entity;
using System;
using System.Collections.Generic;
using System.Text;
using static ClassLibrary2.Repository.EmployeeRepository;

namespace ClassLibrary2.Reposiotory
{
  public  interface IEmployeeRepository
    {
        List<Employee> GetAllEmployees();
        Employee GetEmployeeById(int id);
        Employee AddEmployee(Employee employee);
        Employee GetEmployeeByDepId(int  id);
        void UpdateEmployee(Employee updateEmployee);
        void DeleteEmployee(int id);
        EmployeeDataTableResult GetData(string search, int start, int length, string columnOrder, string modelOrder);   
    }
}
