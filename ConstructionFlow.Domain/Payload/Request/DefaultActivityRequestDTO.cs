using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConstructionFlow.Domain.Payload.Request
{
    public class DefaultActivityRequestDTO
    {
        public int Id { get; set; }
        public string Icon { get; set; }
        public string DefaultActivityName { get; set; }
    }
}
