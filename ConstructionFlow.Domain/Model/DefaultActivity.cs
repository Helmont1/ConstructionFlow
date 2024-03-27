using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConstructionFlow.Domain.Model
{
    public class DefaultActivity
    {
        [Key]
        public Guid DefaultActivityId { get; set; }

        [Required]
        public required string Icon { get; set; }

        [Required]
        public required string DefaultActivityName { get; set; }
    }
}
