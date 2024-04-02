﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConstructionFlow.Domain.Payload
{
    public class UserDTO
    {
      
        public Guid UserId { get; set; }
        
        public required string UserName { get; set; }

        public required string UserEmail { get; set; }

        public required string UserCnpj { get; set; }
    }
}
