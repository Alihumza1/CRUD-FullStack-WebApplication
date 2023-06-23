using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary2.Entity
{
    public class Employee
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public int? DepId{ get; set; }
        public string? Manager { get; set; }
        public string? Cnic { get; set; }
        public int Age { get; set; }
        public int Salary { get; set; }
        public Department? Departments { get; set; }
    }
}
