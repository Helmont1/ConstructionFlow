using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConstructionFlow.Domain.Model
{
    public class Activity
    {
        [Key]
        public Guid ActivityId { get; set; }
        
        [Required]
        public double Budget { get; set; }

        [Required]
        public required Status Status { get; set; }
        [Required]
        public required Construction Construction { get; set; }

        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public DefaultActivity? DefaultActivity { get; set; }

        [Required]
        public required int Order {  get; set; }

    }
}
