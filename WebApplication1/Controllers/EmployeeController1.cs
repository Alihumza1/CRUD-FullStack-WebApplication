using ClassLibrary2.Reposiotory;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebApplication1.Models;
using ClassLibrary2;
using ClassLibrary2.Entity;
using Microsoft.EntityFrameworkCore;
using ClassLibrary2.Repository;
using Newtonsoft.Json;
using System.Linq;
using NuGet.Protocol.Core.Types;
using static ClassLibrary2.Repository.EmployeeRepository;

namespace WebApplication1.Controllers
{
    public class EmployeeController1 : Controller
    {
        private readonly IEmployeeRepository _employeeRepository;
        private readonly IDepartmentRepository _departmentRepository;
        public EmployeeController1(IEmployeeRepository employee, IDepartmentRepository department)
        {
            _employeeRepository = employee;
            _departmentRepository = department;
        }
        [HttpPost]
        public ActionResult GetEmployee(DataTablesParamentors data)
        {
             EmployeeDataTableResult dataTableResult = _employeeRepository.GetData(data.Search.value, data.start, data.length, data.columns[data.order[0]?.column ?? 0].data, data.order[0]?.dir??"asc");
        List<EmployeeModel> employeeModels = dataTableResult.Data.Select(e => new EmployeeModel
        {
        Id = e.Id,
        Name = e.Name,
        DepId = e.DepId,
        Cnic = e.Cnic,
        Salary = e.Salary,
        Age = e.Age
         }).ToList();

         return Json(new
        {
        draw = data.draw,
        //recordsTotal = dataTableResult.TotalRecords,
       // recordsFiltered = dataTableResult.TotalRecords,
        data = employeeModels
         });
         }
        // GET: EmployeeController1
        public ActionResult Index()
        {
            var employees = _employeeRepository.GetAllEmployees().Select(e => new EmployeeModel
            {
                Id = e.Id,
                Name = e.Name,
                DepId = e.DepId,
                Cnic = e.Cnic,
                Salary = e.Salary,
                Age = e.Age
            }).ToList();

            return View(employees);
        }
        // GET: EmployeeController1/Create
        public ActionResult Create()
        {
            var dep = _departmentRepository.GetAllDepartments().Select(e => new DepartmentModel
            {
                Depid = e.Depid,
                Name = e.Name,
                Location = e.Location,
            }).ToList();
            ViewBag.Departments = dep;
            return View();
        }
        // POST: EmployeeController1/Create
        [HttpPost]
        public  ActionResult Create(EmployeeModel employeeModel)
        {
            if (ModelState.IsValid)
            {
                Employee employee = new Employee
                {
                    Name = employeeModel.Name,
                    Age = employeeModel.Age,
                    DepId = employeeModel.DepId,
                    Cnic = employeeModel.Cnic,
                    Salary = employeeModel.Salary,
                };
                _employeeRepository.AddEmployee(employee);
                return RedirectToAction("Index");
            }
           
            return RedirectToAction("Create");
        }
        // GET: EmployeeController1/Edit/5
        [HttpGet]
        public ActionResult Edit(int id)
        {
            Employee employee= _employeeRepository.GetEmployeeById(id);
            EmployeeModel employeeModel= new EmployeeModel{
                Id=employee.Id,
                Name = employee.Name,
                Age = employee.Age,
                DepId = employee.DepId,
                Salary= employee.Salary,
                Cnic= employee.Cnic,
            };
            var dep = _departmentRepository.GetAllDepartments().Select(e => new DepartmentModel
            {
                Depid = e.Depid,
                Name = e.Name,
                Location = e.Location,
            }).ToList();
            ViewBag.Departments = dep;
            return View(employeeModel);
        }
        // POST: EmployeeController1/Edit/5
        [HttpPost]
        public ActionResult Edit(EmployeeModel employeeModel)
        {
            if (ModelState.IsValid)
            {
               Employee employee=new Employee{ 
               Id=employeeModel.Id,
               Name=employeeModel.Name,
               Age=employeeModel.Age,
               DepId=employeeModel.DepId,
               Salary=employeeModel.Salary,
               Cnic=employeeModel.Cnic,
               };
                
                _employeeRepository.UpdateEmployee(employee);
                return RedirectToAction("Index");
            }
            return RedirectToAction("Edit");
        }     
        // POST: EmployeeController1/Delete/5
        [HttpPost]
        public ActionResult Delete(int id)
        {
           
            _employeeRepository.DeleteEmployee(id);
            return Json(new { success = true });
        }
    }
}
