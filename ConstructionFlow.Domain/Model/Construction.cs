using System.ComponentModel.DataAnnotations;

namespace ConstructionFlow.Domain.Model
{
    public class Construction
    {
        [Key]
        public Guid ConstructionId { get; set; }

        [Required]
        public required Status Status { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }

        [Required]
        public required Customer Customer { get; set; }

        [Required]
        public required User User { get; set; }
    }
}