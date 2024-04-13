using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ConstructionFlow.Domain.Payload.Response
{
    public class CustomerResponse
    {
        public int Id { get; set; }


        public string? CustomerCpf { get; set; }


        public string? CustomerCnpj { get; set; }
    }
}