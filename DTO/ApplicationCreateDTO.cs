using Microsoft.AspNetCore.Http;
using System.ComponentModel.DataAnnotations;

namespace InternshipApplication.DTO
{
    public class ApplicationCreateDTO
    {
        [Required]
        public int InternshipId { get; set; }

        [Required]
        public IFormFile Resume { get; set; }
    }
}
