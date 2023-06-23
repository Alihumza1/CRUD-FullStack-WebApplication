// See https://aka.ms/new-console-template for more information
using ClassLibrary2.Repository;

EmployeeRep employeeRepository = new EmployeeRep();
var emp = employeeRepository.GetAllEmployees();
Console.WriteLine(emp);