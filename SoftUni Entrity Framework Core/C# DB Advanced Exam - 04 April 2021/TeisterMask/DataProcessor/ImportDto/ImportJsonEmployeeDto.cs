using System.ComponentModel.DataAnnotations;
using TeisterMask.Data.Models;
using static TeisterMask.Utilities.GlobalConstants;

namespace TeisterMask.DataProcessor.ImportDto
{
    public class ImportJsonEmployeeDto
    {
        [Required]
        [MaxLength(EmployeeUsernameLengthMax)]
        [MinLength(EmployeeUsernameLengthMin)]
        [RegularExpression(EmployeeUsernameRegularExpressionValidation)]
        public string Username { get; set; } = null!;

        [EmailAddress]
        public string Email { get; set; }

        [Required]
        [RegularExpression(EmployeePhoneRegularExpressionValidation)]
        public string Phone { get; set; } = null!;

        public virtual int[] Tasks { get; set; }
    }
}
