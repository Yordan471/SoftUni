using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VaporStore.Data.Models;
using Newtonsoft.Json;

namespace VaporStore.DataProcessor.ImportDto
{
    internal class ImportJsonGameDto
    {
        [Required]
        public string Name { get; set; } = null!;

        [Required]
        [Range(0, (double)Decimal.MaxValue)]
        public decimal Price { get; set; }

        [Required]
        public string ReleaseDate { get; set; } = null!;

        [Required]
        public string Developer { get; set; } = null!;

        [Required]
        public string Genre { get; set; } = null!;

        [Required]
        public string[] Tags { get; set; } = null!;
    }
}
