using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConstructionFlow.Domain.Model
{
    public class ConstructionPhoto
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Photo { get; set; }
        [Required]
        public int ConstructionId { get; set; }
        [ForeignKey("ConstructionId")]
        public Construction Construction { get; set; }
    }
}
