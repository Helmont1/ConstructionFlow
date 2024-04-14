using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConstructionFlow.Domain.Payload.Util
{
    public class LoginDto
    {
        public string UserEmail { get; set; }
        public string UserPassword { get; set; }
    }
}
