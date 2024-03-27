using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConstructionFlow.Domain.Model
{
    public class Status
    {
        [Key]
        public Guid StatusId { get; set; }

        [Required]
        public required string StatusName { get; set; }
    }
}
