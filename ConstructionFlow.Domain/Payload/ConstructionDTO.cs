using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConstructionFlow.Domain.Payload
{
    public class ConstructionDTO
    {
        
        public Guid ConstructionId { get; set; }

        public required StatusDTO Status { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }

        public required CustomerDTO Customer { get; set; }

        public required UserDTO User { get; set; }
    }
}
