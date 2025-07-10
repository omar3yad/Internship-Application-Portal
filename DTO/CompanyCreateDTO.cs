using System.ComponentModel.DataAnnotations;

namespace InternshipApplication.DTO
{
    public class CompanyCreateDTO
    {
        [Required]
        public string Name { get; set; }

        [Required]
        [EmailAddress]
        public string ContactEmail { get; set; }
    }
}
