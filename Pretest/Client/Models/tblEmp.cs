using System.ComponentModel.DataAnnotations;

namespace Client.Models
{
    public class tblEmp
    {
        [Key]
        [MaxLength(10)]
        public string EmpID { get; set; }

        [MaxLength(20)]
        public string? FirstName { get; set; }

        [MaxLength(20)]
        public string? LastName { get; set; }

        [MaxLength(20)]
        public string? Password { get; set; }

        public float Salary { get; set; }
    }
}
