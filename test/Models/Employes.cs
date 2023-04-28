using System.ComponentModel.DataAnnotations;

namespace test.Models
{
    public class Employes
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string EmployeeName { get; set; }
        [Required]
        public int? EmployeePhone { get; set; }
        public string? EmployeeEmail { get; set; }
        public int? EmployeeAge { get; set; }


        public decimal? EmployeeSalary { get; set; }
    }
}
