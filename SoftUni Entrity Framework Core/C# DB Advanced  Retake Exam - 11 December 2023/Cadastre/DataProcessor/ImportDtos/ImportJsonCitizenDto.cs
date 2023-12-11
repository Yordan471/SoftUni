using Cadastre.Data.Enumerations;
using Cadastre.Data.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cadastre.DataProcessor.ImportDtos
{
    public class ImportJsonCitizenDto
    {
        [Required]
        [MaxLength(30)]
        [MinLength(2)]
        public string FirstName { get; set; } = null!;

        [Required]
        [MaxLength(30)]
        [MinLength(2)]
        public string LastName { get; set; } = null!;

        [Required]
        public string BirthDate { get; set; } = null!;

        [Required]
        public string MaritalStatus { get; set; } = null!;

        public virtual int[] Properties { get; set; }
    }
}
