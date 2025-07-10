using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebAPIDotNet.Models
{
    public class Application
    {
        [Key]
        public int Id { get; set; }

        [ForeignKey("Internship")]
        public int InternshipId { get; set; }

        public Internship? Internship { get; set; }

        [ForeignKey("ApplicationUser")]
        public string ApplicationUserId { get; set; }

        public ApplicationUser? ApplicationUser { get; set; }

        public string? ResumePath { get; set; }

        public string Status { get; set; } = "Pending"; // Pending, Reviewed, Accepted, Rejected

        public DateTime SubmittedAt { get; set; } = DateTime.UtcNow;
    }
}
