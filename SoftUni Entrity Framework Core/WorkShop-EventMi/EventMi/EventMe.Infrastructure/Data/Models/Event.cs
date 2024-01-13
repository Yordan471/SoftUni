using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventMe.Infrastructure.Data.Models
{

    /// <summary>
    /// Събитие
    /// </summary>
    [Comment("Събитие")]
    public class Event
    {
        /// <summary>
        /// Идентификатор на събитие
        /// </summary>
        [Comment("Идентификатор на събитие")]
        [Key]
        public int Id { get; set; }

        /// <summary>
        /// Име на събитието
        /// </summary>
        [Required]
        [Comment("Име на събитието")]
        [StringLength(50)]
        public string Name { get; set; } = null!; // това е зло! Прави се required property

        /// <summary>
        /// Начало на събитието
        /// </summary>
        [Required]
        [Comment("Начало на събитието")]
        public DateTime Start { get; set; }

        /// <summary>
        /// Край на събитието
        /// </summary>
        [Required]
        [Comment("Край на събитието")]
        public DateTime End { get; set; }

        /// <summary>
        /// Адрес
        /// </summary>
        public Address Address { get; set; }
    }
}
