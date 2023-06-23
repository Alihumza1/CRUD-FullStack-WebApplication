using ClassLibrary2.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static ClassLibrary2.Repository.DepartmentRepository;

namespace ClassLibrary2.Repository
{
        public interface IDepartmentRepository
        {
            List<Department> GetAllDepartments();
            Department GetDepartmentById(int id);
            Department AddDepartments(Department department);
            void UpdateDepartments(Department updateDepartment);
            void DeleteDepartments(int id);
            DepartmentDataTableResult GetData(string search, int start, int length, string columnOrder, string modelOrder);
    }
}
