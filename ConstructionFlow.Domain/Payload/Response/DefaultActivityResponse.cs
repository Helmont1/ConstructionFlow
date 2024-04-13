using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ConstructionFlow.Domain.Payload.Response
{
    public class DefaultActivityResponse
    {
        public int Id { get; set; }
        public string Icon { get; set; }
        public string DefaultActivityName { get; set; }
    }
}