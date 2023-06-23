using ClassLibrary2.Entity;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace WebApplication1.Models
{
    public class DepartmentModel
    {
        [DisplayName("Department ID :")]
        public int Depid { get; set; }

        [Required(ErrorMessage = "Department Name is required.")]
        [StringLength(25, ErrorMessage = "Department Name must not exceed 25 characters.")]
        [DisplayName("Department Name :")]
        public string? Name { get; set; }

        [Required(ErrorMessage = "Location is required.")]
        [StringLength(25, ErrorMessage = "Location must not exceed 25 characters.")]
        [DisplayName("Department Location:")]
        public string? Location { get; set; }
      

    }
}
