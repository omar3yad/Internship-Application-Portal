using InternshipApplication.DTO;
using InternshipApplication.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace WebAPIDotNet.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class InternshipsController : ControllerBase
    {
        private readonly IInternshipService _internshipService;

        public InternshipsController(IInternshipService internshipService)
        {
            _internshipService = internshipService;
        }
        [HttpGet]//api/Internships
        public async Task<ActionResult<IEnumerable<InternshipDTO>>> GetAll()
        {
            var internships = await _internshipService.GetAllInternshipsAsync();
            return Ok(internships);
        }

        // GET: api/Internships/5
        [HttpGet("{id}")]
        public async Task<ActionResult<InternshipDTO>> GetById(int id)
        {
            var internship = await _internshipService.GetByIdAsync(id);
            if (internship == null)
                return NotFound();
            return Ok(internship);
        }

        [HttpPost]
         [Authorize(Roles = "HR")]
        public async Task<ActionResult<InternshipDTO>> Create([FromBody] InternshipCreateDTO dto)
        {
            var createdInternship = await _internshipService.CreateAsync(dto);
            return CreatedAtAction(nameof(GetById), new { id = createdInternship.Id }, createdInternship);
        }

        [HttpPut("{id}")]
         [Authorize(Roles = "HR")]
        public async Task<IActionResult> Update(int id, [FromBody] InternshipUpdateDTO dto)
        {
            var updated = await _internshipService.UpdateAsync(id, dto);

            if (!updated)
                return NotFound();

            return NoContent();
        }

        [HttpDelete("{id}")]
        [Authorize(Roles = "HR")]
        public async Task<IActionResult> Delete(int id)
        {
            var deleted = await _internshipService.DeleteAsync(id);

            if (!deleted)
                return NotFound();

            return NoContent();
        }

    }
}