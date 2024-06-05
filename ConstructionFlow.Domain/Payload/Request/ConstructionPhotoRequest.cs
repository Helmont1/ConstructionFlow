using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConstructionFlow.Domain.Payload.Request
{
    public class ConstructionPhotoRequest
    {
        public int Id { get; set; }

        public string Photo { get; set; }

        public int ConstructionId { get; set; }
    }
}
