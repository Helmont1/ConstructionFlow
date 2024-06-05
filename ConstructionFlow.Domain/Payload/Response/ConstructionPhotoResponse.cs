using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ConstructionFlow.Domain.Payload.Response
{
    public class ConstructionPhotoResponse
    {
        public int Id { get; set; }

        public string? Photo { get; set; }

        public ConstructionResponse? Construction { get; set; }
    }
}