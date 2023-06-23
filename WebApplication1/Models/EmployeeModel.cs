using ClassLibrary2.Entity;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace WebApplication1.Models
{
        public class EmployeeModel
        {
        public int Id { get; set; }

        [Required(ErrorMessage = "Name is required.")]
        [StringLength(25, ErrorMessage = "Name must not exceed 25 characters.")]
        [DisplayName("Employee Name :")]
        public string? Name { get; set; }

        [Required(ErrorMessage = "Select Department .")]
        [DisplayName("Department Name :")]
        public int? DepId{ get; set; }

        [Required(ErrorMessage = "CNIC is required.")]
        [StringLength(14, ErrorMessage = "CNIC must not exceed 14 digits.")]
        [DisplayName("Employee CNIC :")]
        public string? Cnic { get; set; }

        [Required(ErrorMessage = "Age is required.")]
        [DisplayName("Employee Age :")]
        public int Age { get; set; }

        [Required(ErrorMessage = "Salary is required.")]
        [DisplayName("Emplopyee Salary :")]
        public int Salary { get; set; }
    } 
}
