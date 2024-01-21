using System.ComponentModel.DataAnnotations;

namespace TS2210004.Models
{
    public class Employee
    {
        [Key]
        public string EmployeeID { get; set; }

        [Required]
        public string Password { get; set; }
        [Required]
        public string EmployeeName { get; set; }
        public int Age { get; set; }    
        public bool Role { get; set; }
    }
}
