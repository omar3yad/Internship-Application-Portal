using InternshipApplication.DTO;
using InternshipApplication.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace WebAPIDotNet.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ApplicationController : ControllerBase
    {
        private readonly IApplicationService _service;
        private readonly IWebHostEnvironment _env;

        public ApplicationController(IApplicationService service, IWebHostEnvironment env)
        {
            _service = service;
            _env = env;
        }

        // GET: api/Application
        [HttpGet]
        [Authorize(Roles = "Admin,HR")]
        public async Task<IActionResult> GetAll()
        {
            var apps = await _service.GetAllAsync();
            return Ok(apps);
        }

        // GET: api/Application/{id}
        [HttpGet("{id}")]
        [Authorize]
        public async Task<IActionResult> GetById(int id)
        {
            var app = await _service.GetByIdAsync(id);
            if (app == null)
                return NotFound();
            return Ok(app);
        }

        // GET: api/Application/MyApplications
        [HttpGet("MyApplications")]
        [Authorize(Roles = "Student")]
        public async Task<IActionResult> GetByCurrentUser()
        {
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            var apps = await _service.GetByUserAsync(userId);
            return Ok(apps);
        }

        // POST: api/Application
        [HttpPost]
        [Authorize(Roles = "Student")]
        public async Task<IActionResult> Create([FromForm] ApplicationCreateDTO dto)
        {
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            var uploadsFolder = Path.Combine(_env.WebRootPath, "Uploads", "Resumes");

            if (!Directory.Exists(uploadsFolder))
            {
                Directory.CreateDirectory(uploadsFolder);
            }

            var created = await _service.CreateAsync(userId, dto, uploadsFolder);
            return Ok(created);
        }

        // PUT: api/Application/5/status?newStatus=Accepted
        [HttpPut("{id}/status")]
        [Authorize(Roles = "Admin,HR")]
        public async Task<IActionResult> UpdateStatus(int id, [FromQuery] string newStatus)
        {
            await _service.UpdateStatusAsync(id, newStatus);
            return NoContent();
        }
    }
}
