﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConstructionFlow.Domain.Payload
{
    public class StatusDTO
    {
        
        public Guid StatusId { get; set; }

        public required string StatusName { get; set; }
    }
}