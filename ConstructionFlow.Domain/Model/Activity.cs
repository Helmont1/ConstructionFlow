using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConstructionFlow.Domain.Model
{
    public class Activity
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public double Budget { get; set; }
        [Required]
        public int StatusId { get; set; }

        [Required]
        [ForeignKey("StatusId")]
        public Status Status { get; set; }
        [Required]
        public int ConstructionId { get; set; }
        [Required]
        [ForeignKey("ConstructionId")]
        public Construction Construction { get; set; }

        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public int? DefaultActivityId { get; set; }
        [ForeignKey("DefaultActivityId")]
        public DefaultActivity? DefaultActivity { get; set; }

        [Required]
        public int Order { get; set; }

    }
}
