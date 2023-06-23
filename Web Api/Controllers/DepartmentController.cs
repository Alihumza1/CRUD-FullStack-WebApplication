using ClassLibrary2.Entity;
using ClassLibrary2.Reposiotory;
using ClassLibrary2.Repository;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Web_Api.Models;
using static ClassLibrary2.Repository.DepartmentRepository;

namespace Web_Api.Controllers
{

    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class DepartmentController : ControllerBase
    {
        private readonly IDepartmentRepository _departmentRepository;
        private readonly ILogger<DepartmentController> _logger;
        public DepartmentController(IDepartmentRepository repository, ILogger<DepartmentController> logger)
        {
            _departmentRepository = repository;
            _logger = logger;
        }
        [HttpPost]
        public IActionResult PostDepartment(DataTablesParameters data)
        {

            DepartmentDataTableResult dataTableResult = _departmentRepository.GetData(data.search.value, data.start, data.length, data.columns[data.order[0]?.column ?? 0].data, data.order[0]?.dir ?? "asc");
            List<DepartmentModel> departmentModels = dataTableResult.Data.Select(department => new DepartmentModel
            {
                Depid = department.Depid,
                Name = department.Name,
                HeadName = department.HeadName,
                Location = department.Location,
            }).ToList();
            return Ok(new
            {
                draw = data.draw,
                recordsTotal = dataTableResult.TotalRecords,
                recordsFiltered = dataTableResult.TotalRecords,
                data = departmentModels
            });

        }
        [HttpPost("addDepartment")]
        public IActionResult Post(DepartmentModel departmentModel)
        {

            Department department = new Department();
            department.Depid = departmentModel.Depid;
            department.Name = departmentModel.Name;
            department.HeadName = departmentModel.HeadName;
            department.Location = departmentModel.Location;
            _departmentRepository.AddDepartments(department);
            return Created("", department);

        }
        [HttpGet("allDepartments")]
        public IActionResult Get()
        {

            return Ok(_departmentRepository.GetAllDepartments());

        }
        [HttpPut("update-Department-by-id")]
        public IActionResult Put(DepartmentModel departmentModel)
        {

            Department department = new Department();
            department.Depid = departmentModel.Depid;
            department.Name = departmentModel.Name;
            department.HeadName = departmentModel.HeadName;
            department.Location = departmentModel.Location;
            _departmentRepository.UpdateDepartments(department);
            return Ok(department);

        }
        [HttpDelete("Delete-Department-by-id/{Depid}")]
        public IActionResult Delete(int Depid)
        {

            _departmentRepository.DeleteDepartments(Depid);
            return Ok();

        }
        [HttpGet("Get-Department-by-id/{Depid}")]
        public IActionResult Getbyid(int Depid)
        {

            Department department = _departmentRepository.GetDepartmentById(Depid);
            DepartmentModel departmentModel = new DepartmentModel
            {
                Depid = department.Depid,
                Name = department.Name,
                HeadName = department.HeadName,
                Location = department.Location,
            };
            return Ok(departmentModel);

        }
    }
}
