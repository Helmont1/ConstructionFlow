using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConstructionFlow.Domain.Model
{
    public class Customer
    {
        [Key]
        public int Id { get; set; }

        [MaxLength(11)]
        public string? CustomerCpf { get; set; }

        [MaxLength(14)]
        public string? CustomerCnpj { get; set; }

        public ICollection<Construction> Constructions { get; set; }
    }
}
