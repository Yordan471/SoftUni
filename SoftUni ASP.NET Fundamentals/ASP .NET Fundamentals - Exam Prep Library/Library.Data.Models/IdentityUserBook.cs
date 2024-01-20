using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.Data.Models
{
    public class IdentityUserBook
    {
        /// <summary>
        /// Collector Identifier
        /// </summary>
        [Required]
        public string CollectorId { get; set; } = null!;

        /// <summary>
        /// Contains information about the Collector
        /// </summary>
        public IdentityUser Collector { get; set; }

        /// <summary>
        /// Book Identifier
        /// </summary>
        [Required]
        public int BookId { get; set; }

        /// <summary>
        /// Contains information about the Book
        /// </summary>
        [ForeignKey(nameof(BookId))]
        public Book Book { get; set; }
    }
}
