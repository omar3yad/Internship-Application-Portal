using System.ComponentModel.DataAnnotations;

namespace WebAPIDotNet.Models
{
    public class Company
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        public string? ContactEmail { get; set; }

        // Navigation property
        public ICollection<Internship>? Internships { get; set; }
    }
}
