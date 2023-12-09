using System.ComponentModel.DataAnnotations;
using static TeisterMask.Utilities.GlobalConstants;

namespace TeisterMask.Data.Models
{
    public class Employee
    {
        public Employee() 
        {
            EmployeesTasks = new HashSet<EmployeeTask>();
        }

        [Key]
        public int Id { get; set; }

        [Required]
        [StringLength(EmployeeUsernameLengthMax)]
        public string UserName { get; set; } = null!;

        public string? Email { get; set; }

        [Required]
        public string Phone { get; set; } = null!;

        public virtual ICollection<EmployeeTask> EmployeesTasks { get; set; }
    }
}
