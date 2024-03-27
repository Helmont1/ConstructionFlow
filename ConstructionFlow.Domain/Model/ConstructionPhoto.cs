using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConstructionFlow.Domain.Model
{
    public class ConstructionPhoto
    {
        [Key]
        public Guid ConstructionPhotoId { get; set; }
        [Required]
        public required Byte[] Photo { get; set; }
        [Required]
        public required Construction Construction { get; set; }
    }
}
