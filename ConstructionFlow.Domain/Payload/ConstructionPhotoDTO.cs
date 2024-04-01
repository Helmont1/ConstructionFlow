using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConstructionFlow.Domain.Payload
{
    public class ConstructionPhotoDTO
    {
        public Guid ConstructionPhotoId { get; set; }
        
        public required Byte[] Photo { get; set; }
        
        public required ConstructionDTO Construction { get; set; }
    }
}
