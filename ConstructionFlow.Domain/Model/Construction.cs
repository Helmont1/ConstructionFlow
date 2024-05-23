using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ConstructionFlow.Domain.Model
{
    public class Construction
    {
        [Key]
        public int Id { get; set; }

        [Required (ErrorMessage = "Status is required")]
        public int StatusId { get; set; }
        [ForeignKey("StatusId")]
        public Status Status { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }

        [Required (ErrorMessage = "Customer is required")]
        public int CustomerId { get; set; }
        [ForeignKey("CustomerId")]
        public Customer Customer { get; set; }

        [Required (ErrorMessage = "User is required")]
        public int UserId { get; set; }
        [ForeignKey("UserId")]
        public User User { get; set; }

        [Required (ErrorMessage = "Title is required")]
        public string Title { get; set; }

        public string? Search { get; set; }

        [Required (ErrorMessage = "Budget is required")]
        public string Budget { get; set; }
    }
}