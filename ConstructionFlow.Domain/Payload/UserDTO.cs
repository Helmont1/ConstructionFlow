using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConstructionFlow.Domain.Payload
{
    public class UserDTO
    {
      
        public int Id { get; set; }
        
        public string UserName { get; set; }

        public string UserEmail { get; set; }

        public string UserCnpj { get; set; }
    }
}
