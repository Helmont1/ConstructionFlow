using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConstructionFlow.Domain.Payload.Request
{
    public class ConstructionRequest
    {

        public int Id { get; set; }

        public int StatusId { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }

        public int CustomerId { get; set; }

        public int UserId { get; set; }
        public string Title { get; set; }
        public string? Search { get; set; }

        public string Budget { get; set; }
    }
}
