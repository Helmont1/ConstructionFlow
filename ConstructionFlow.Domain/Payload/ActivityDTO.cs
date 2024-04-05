using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConstructionFlow.Domain.Payload
{
    public class ActivityDTO
    {
        public int Id { get; set; }
        
        public double Budget { get; set; }

        public int StatusId { get; set; }
        public int ConstructionId { get; set; }

        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public int? DefaultActivityId { get; set; }

        public int Order {  get; set; }

    }
}
