using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ConstructionFlow.Domain.Payload.Request;

namespace ConstructionFlow.Domain.Payload
{
    public class ConstructionResponseDTO
    {
        
        public int Id { get; set; }

        public StatusRequestDTO ?Status { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }

        public CustomerRequestDTO ?Customer { get; set; }

        public UserRequestDTO ?User { get; set; }
    }
}
