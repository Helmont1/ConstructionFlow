using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConstructionFlow.Domain.Payload
{
    public class ActivityDTO
    {
        public Guid ActivityId { get; set; }
        
        public double Budget { get; set; }

        public required StatusDTO Status { get; set; }
        public required ConstructionDTO Construction { get; set; }

        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public DefaultActivityDTO? DefaultActivity { get; set; }

        public required int Order {  get; set; }

    }
}
