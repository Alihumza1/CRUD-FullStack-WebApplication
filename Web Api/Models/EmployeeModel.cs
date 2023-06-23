namespace Web_Api.Models
{
    public class EmployeeModel
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public string? Manager { get; set; }
        public int? DepId { get; set; }
        public string? Cnic { get; set; }
        public int Age { get; set; }
        public int Salary { get; set; }
    }
}
