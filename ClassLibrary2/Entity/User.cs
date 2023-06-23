using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary2.Entity
{
    public class User
    {
        [Key]
        public int Id { get; set; }
        public String? UserName { get; set; }
       public String? PassWord { get; set; }
    }
}
