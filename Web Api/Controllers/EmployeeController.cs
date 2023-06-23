using ClassLibrary2.Entity;
using ClassLibrary2.Reposiotory;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Web_Api.Models;
using static ClassLibrary2.Repository.EmployeeRepository;

namespace Web_Api.Controllers
{

    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class EmployeeController : ControllerBase
    {
        private readonly IEmployeeRepository _employeeRepository;
        private readonly ILogger<EmployeeController> _logger;
        public EmployeeController(IEmployeeRepository _employee, ILogger<EmployeeController> logger)
        {
            _employeeRepository = _employee;
            _logger = logger;
        }
        [HttpPost]
        public IActionResult GetEmployee(DataTablesParameters data)
        {

            EmployeeDataTableResult dataTableResult = _employeeRepository.GetData(data.search.value, data.start, data.length, data.columns[data.order[0]?.column ?? 0].data, data.order[0]?.dir ?? "asc");
            // throw new Exception("Error");
            List<EmployeeModel> employeeModels = dataTableResult.Data.Select(employee => new EmployeeModel
            {
                Id = employee.Id,
                Name = employee.Name,
                Manager = employee.Manager,
                DepId = employee.DepId,
                Cnic = employee.Cnic,
                Salary = employee.Salary,
                Age = employee.Age
            }).ToList();
            return Ok(new
            {
                draw = data.draw,
                recordsTotal = dataTableResult.TotalRecords,
                recordsFiltered = dataTableResult.TotalRecords,
                data = employeeModels
            });

        }
        [HttpPost("addEmployee")]
        public IActionResult Post(EmployeeModel employeeModel)
        {

            Employee employee = new Employee();
            employee.Id = employeeModel.Id;
            employee.Name = employeeModel.Name;
            employee.Manager = employeeModel.Manager;
            employee.Age = employeeModel.Age;
            employee.Salary = employeeModel.Salary;
            employee.Cnic = employeeModel.Cnic;
            employee.DepId = employeeModel.DepId;
            _employeeRepository.AddEmployee(employee);
            return Created("", employee);

        }
        [HttpGet("allEmployees")]
        public IActionResult Get()
        {

            return Ok(_employeeRepository.GetAllEmployees());

        }
        [HttpPut("update-Employee-by-id")]
        public IActionResult UpdateById(EmployeeModel employeeModel)
        {

            Employee employee = new Employee();
            employee.Id = employeeModel.Id;
            employee.Name = employeeModel.Name;
            employee.Manager = employeeModel.Manager;
            employee.Age = employeeModel.Age;
            employee.Salary = employeeModel.Salary;
            employee.Cnic = employeeModel.Cnic;
            employee.DepId = employeeModel.DepId;
            _employeeRepository.UpdateEmployee(employee);
            return Ok(employee);

        }
        [HttpDelete("Delete-Employee-by-id/{id}")]
        public IActionResult Delete(int id)
        {

            _employeeRepository.DeleteEmployee(id);
            return Ok();

        }
        [HttpGet("Get-Employee-by-id/{id}")]
        public IActionResult GetbyId(int id)
        {

            Employee employee = _employeeRepository.GetEmployeeById(id);
            EmployeeModel employeeModel = new EmployeeModel
            {
                Id = employee.Id,
                Name = employee.Name,
                Manager = employee.Manager,
                Age = employee.Age,
                DepId = employee.DepId,
                Salary = employee.Salary,
                Cnic = employee.Cnic,
            };

            return Ok(employeeModel);

        }
        [HttpGet("Get-Employee-by-Depid/{id}")]
        public IActionResult Get(int id)
        {

            var employee = _employeeRepository.GetEmployeeByDepId(id);

            return Ok(employee);

        }
    }
}
