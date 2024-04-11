using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConstructionFlow.Domain.Payload
{
    public class ConstructionResponseDTO
    {
        
        public int Id { get; set; }

        public StatusDTO ?Status { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }

        public CustomerDTO ?Customer { get; set; }

        public UserDTO ?User { get; set; }
    }
}
