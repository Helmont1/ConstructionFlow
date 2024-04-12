using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConstructionFlow.Domain.Payload.Util
{
    public class UserLoginDTO
    {
        public int Id { get; set; }

        public string UserName { get; set; }

        public string UserEmail { get; set; }
        public string UserPassword { get; set; }

        public string UserCnpj { get; set; }
    }

}
