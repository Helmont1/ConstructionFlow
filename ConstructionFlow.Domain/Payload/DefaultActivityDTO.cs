using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConstructionFlow.Domain.Payload
{
    public class DefaultActivityDTO
    {
        public Guid DefaultActivityId { get; set; }
        public required string Icon { get; set; }
        public required string DefaultActivityName { get; set; }
    }
}
