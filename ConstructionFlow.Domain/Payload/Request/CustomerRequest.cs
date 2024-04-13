using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConstructionFlow.Domain.Payload.Request
{
    public class CustomerRequest
    {
        public int Id { get; set; }


        public string? CustomerCpf { get; set; }


        public string? CustomerCnpj { get; set; }
    }
}

