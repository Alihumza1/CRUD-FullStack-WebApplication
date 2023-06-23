using ClassLibrary2.Entity;
using ClassLibrary2.Reposiotory;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary2.Repository
{
    public class DepartmentRepository : IDepartmentRepository
    {
        private DbContextcs Db;
        public DepartmentRepository(DbContextcs dbContextcs)
        {
            Db = dbContextcs;
        }
        public List<Department> GetAllDepartments()
        {
            var department = Db.Departments.ToList();
            return department;
        }
        public Department GetDepartmentById(int id)
        {
            var department = Db.Departments.FirstOrDefault(o => o.Depid == id);
            return department;
        }
        public Department AddDepartments(Department department)
        {
            Db.Departments.Add(department);
            Db.SaveChanges();
            return department;
        }
        public void DeleteDepartments(int id)
        { 
            var department = GetDepartmentById(id);
            Db.Departments.Remove(department);
            Db.SaveChanges();
         }
        public void UpdateDepartments(Department updateDepartment)
        {
            Db.Departments.Update(updateDepartment);
            Db.SaveChanges();
        }
        public class DepartmentDataTableResult
        {
            public List<Department>? Data { get; set; }
            public int TotalRecords { get; set; }
        }
        public DepartmentDataTableResult GetData(string search, int start, int length, string columnOrder, string modelOrder)
        {
            IQueryable<Department> departmentsQuery= Db.Departments;

            if (!string.IsNullOrEmpty(search))
            {
                departmentsQuery = departmentsQuery.Where(x => x.Name.Contains(search));
            }
            if (columnOrder != null)
            {
                switch (columnOrder)
                {
                    case "name":
                        if (!string.IsNullOrEmpty(modelOrder) && modelOrder == "desc")
                        {
                            departmentsQuery = departmentsQuery.OrderByDescending(x => x.Name);
                        }
                        else
                        {
                            departmentsQuery = departmentsQuery.OrderBy(x => x.Name);
                        }
                        break;
                    case "location":
                        if (!string.IsNullOrEmpty(modelOrder) && modelOrder == "desc")
                        {
                            departmentsQuery = departmentsQuery.OrderByDescending(x => x.Location);
                        }
                        else
                        {
                            departmentsQuery = departmentsQuery.OrderBy(x => x.Location);
                        }
                        break;
                    default:
                        if (!string.IsNullOrEmpty(modelOrder) && modelOrder == "desc")
                        {
                            departmentsQuery = departmentsQuery.OrderByDescending(x => x.Name);
                        }
                        else
                        {
                            departmentsQuery = departmentsQuery.OrderBy(x => x.Name);
                        }
                        break;
                }
            }
            int TotalCount = departmentsQuery.Count();
            List<Department> departments =  departmentsQuery
               .Skip(start)
               .Take(length)
               .ToList();
            return new DepartmentDataTableResult
            {
                Data = departments,
                TotalRecords = TotalCount
            };
        }
    }
}
