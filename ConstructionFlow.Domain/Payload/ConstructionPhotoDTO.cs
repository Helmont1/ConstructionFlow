using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConstructionFlow.Domain.Payload
{
    public class ConstructionPhotoDTO
    {
        public int Id { get; set; }
        
        public  byte[] Photo { get; set; }
        
        public int ConstructionId { get; set; }
    }
}
