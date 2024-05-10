using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ConstructionFlow.Domain.Payload.Request;
using ConstructionFlow.Domain.Payload.Response;

namespace ConstructionFlow.Domain.Payload
{
    public class ConstructionResponse
    {
        
        public int Id { get; set; }

        public StatusResponse? Status { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }

        public CustomerResponse? Customer { get; set; }

        public UserResponse? User { get; set; }
        public string Title { get; set; }
        public string Search { get; set; }
    }
}
