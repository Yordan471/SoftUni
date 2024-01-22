using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
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
        [Comment("Collector Identifier")]
        [Required]
        public string CollectorId { get; set; } = null!;

        [Comment("Contains information about the Collector")]
        [ForeignKey(nameof(CollectorId))]
        public IdentityUser Collector { get; set; } = null!;

        [Comment("Book Identifier")]
        [Required]
        public int BookId { get; set; }

        [Comment("Contains information about the Book")]
        [ForeignKey(nameof(BookId))]
        public Book Book { get; set; } = null!;
    }
}
