using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ConstructionFlow.Domain.Payload.Response
{
    public class StatusResponse
    {
        public int Id { get; set; }

        public string StatusName { get; set; }
    }
}