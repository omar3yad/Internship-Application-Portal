using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using static System.Net.Mime.MediaTypeNames;

namespace WebAPIDotNet.Models
{
    public class Internship
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string Title { get; set; }

        public string? Description { get; set; }

        public string? Location { get; set; }

        public DateTime? PostedAt { get; set; } = DateTime.UtcNow;

        public string? Status { get; set; } // Active, Inactive, etc.

        [ForeignKey("Company")]
        public int CompanyId { get; set; }

        public Company? Company { get; set; }

        // Navigation
        public ICollection<Application>? Applications { get; set; }
    }
}
