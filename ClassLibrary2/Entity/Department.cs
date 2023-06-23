using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary2.Entity
{
public class Department
    {
        public int Depid { get; set; }
        public string? Name { get; set; }
        public string? HeadName { get; set; }
        public string? Location { get; set; }
        public virtual ICollection<Employee>? Employees { get; set; }
    }
}
