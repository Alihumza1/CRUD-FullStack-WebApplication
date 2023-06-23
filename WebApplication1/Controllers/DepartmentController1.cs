using ClassLibrary2.Entity;
using ClassLibrary2.Repository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.CodeAnalysis;
using System.Runtime.Intrinsics.Arm;
using WebApplication1.Models;

namespace WebApplication1.Controllers
{
    public class DepartmentController1 : Controller
    {
        private readonly IDepartmentRepository _DepartmentRepository;
        public DepartmentController1(IDepartmentRepository repository)
        {
            _DepartmentRepository = repository;
        }
        // GET: DepartmentController1
        public ActionResult Index()
        {
            var department = _DepartmentRepository.GetAllDepartments().Select(e => new DepartmentModel
            {
               Depid=e.Depid,
               Name=e.Name,
               Location=e.Location,
            }).ToList();
            return View(department);
        }
        // GET: DepartmentController1/Details/5
        public ActionResult Details(int id)
        {
            Department department = _DepartmentRepository.GetDepartmentById(id);
            DepartmentModel departmentModel = new DepartmentModel
            {
                Depid = department.Depid,
                Name = department.Name,
                Location = department.Location,
            };
            return View(departmentModel);
        }
        // GET: DepartmentController1/Create
        public IActionResult Create()
        {
            return View();
        }
        // POST: DepartmentController1/Create
        [HttpPost]
        public ActionResult Create(Department add)
        {
            if (ModelState.IsValid)
            {
                var department = new Department
                {
                    Name = add.Name,
                    Location = add.Location,
                };
                _DepartmentRepository.AddDepartments(department);
                return RedirectToAction("Index");
            }
            return RedirectToAction("Create");
        }
        // GET: DepartmentController1/Edit/5
        public ActionResult Edit(int id)
        {
            Department department =_DepartmentRepository.GetDepartmentById(id);
            DepartmentModel departmentModel = new DepartmentModel
            {
                Depid = department.Depid,
                Name = department.Name,
                Location=department.Location,
            };
            return View(departmentModel);
        }
        // POST: DepartmentController1/Edit/5
        [HttpPost]
        public ActionResult Edit(DepartmentModel departmentModel)
        {
            if (ModelState.IsValid)
            {

                var department = _DepartmentRepository.GetDepartmentById(departmentModel.Depid);
                _DepartmentRepository.UpdateDepartments(department);
                return RedirectToAction("Index");
            }
            return RedirectToAction("Edit");
        }
        // GET: DepartmentController1/Delete/5
        public ActionResult Delete(int id)
        {
            Department department = _DepartmentRepository.GetDepartmentById(id);
            DepartmentModel departmentModel = new DepartmentModel
            {
                Depid = department.Depid,
                Name = department.Name,
                Location = department.Location,
            };
            return View(departmentModel);
        }
        // POST: DepartmentController1/Delete/5
        [HttpPost]
        [ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {
            _DepartmentRepository.DeleteDepartments(id);
            return RedirectToAction("Index");
        }
    }
}
