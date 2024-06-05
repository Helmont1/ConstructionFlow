using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ConstructionFlow.Domain.Payload.Response
{
    public class ActivityResponse
    {
        public int Id { get; set; }

        public double Budget { get; set; }

        public StatusResponse? Status { get; set; }
        public ConstructionResponse? Construction { get; set; }

        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public DefaultActivityResponse? DefaultActivity { get; set; }

        public int Order { get; set; }

        public string? ActivityName { get; set; }

        public string? Icon { get; set; }

        public double? UsedMaterial { get; set; }

        public double? WastedMaterial { get; set; }
    }
}