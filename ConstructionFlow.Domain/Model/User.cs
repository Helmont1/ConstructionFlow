using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConstructionFlow.Domain.Model
{
    public class User
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [MaxLength(100)]
        public required string UserName { get; set; }

        [Required]
        public required string UserEmail { get; set; }

        [Required]
        public required string UserPassword { get; set; }

        [Required]
        [MaxLength (14)]
        public required string UserCnpj { get; set; }

        public double? Score { get; set; }
    }
}
