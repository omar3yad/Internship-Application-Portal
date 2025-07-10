using InternshipApplication.DTO;
using InternshipApplication.Repositories;
using WebAPIDotNet.Models;

namespace InternshipApplication.Services
{
    public class ApplicationService : IApplicationService
    {
        private readonly IApplicationRepository _repo;
        private readonly IWebHostEnvironment _env;

        public ApplicationService(IApplicationRepository repo, IWebHostEnvironment env)
        {
            _repo = repo;
            _env = env;
        }

        public async Task<IEnumerable<ApplicationDTO>> GetAllAsync()
        {
            var apps = await _repo.GetAllAsync();

            return apps.Select(app => new ApplicationDTO
            {
                Id = app.Id,
                ResumePath = app.ResumePath,
                Status = app.Status,
                SubmittedAt = app.SubmittedAt,
                InternshipTitle = app.Internship?.Title,
                UserName = app.ApplicationUser?.UserName
            }).ToList();
        }

        public async Task<ApplicationDTO> GetByIdAsync(int id)
        {
            var app = await _repo.GetByIdAsync(id);

            if (app == null) return null;

            return new ApplicationDTO
            {
                Id = app.Id,
                ResumePath = app.ResumePath,
                Status = app.Status,
                SubmittedAt = app.SubmittedAt,
                InternshipTitle = app.Internship?.Title,
                UserName = app.ApplicationUser?.UserName
            };
        }

        public async Task<IEnumerable<ApplicationDTO>> GetByUserAsync(string userId)
        {
            var apps = await _repo.GetByUserAsync(userId);

            return apps.Select(app => new ApplicationDTO
            {
                Id = app.Id,
                ResumePath = app.ResumePath,
                Status = app.Status,
                SubmittedAt = app.SubmittedAt,
                InternshipTitle = app.Internship?.Title,
                UserName = app.ApplicationUser?.UserName
            }).ToList();
        }

        public async Task<ApplicationDTO> CreateAsync(string userId, ApplicationCreateDTO dto, string uploadsFolder)
        {
            string resumePath = null;

            if (dto.Resume != null)
            {
                string fileName = $"{Guid.NewGuid()}_{dto.Resume.FileName}";
                string path = Path.Combine(uploadsFolder, fileName);

                using (var stream = new FileStream(path, FileMode.Create))
                {
                    await dto.Resume.CopyToAsync(stream);
                }

                resumePath = $"Uploads/Resumes/{fileName}";
            }

            var app = new Application
            {
                InternshipId = dto.InternshipId,
                ApplicationUserId = userId,
                ResumePath = resumePath,
                Status = "Pending",
                SubmittedAt = DateTime.Now
            };

            var created = await _repo.AddAsync(app);

            return new ApplicationDTO
            {
                Id = created.Id,
                ResumePath = created.ResumePath,
                Status = created.Status,
                SubmittedAt = created.SubmittedAt,
                InternshipTitle = created.Internship?.Title,
                UserName = created.ApplicationUser?.UserName
            };
        }

        public async Task UpdateStatusAsync(int id, string newStatus)
        {
            var app = await _repo.GetByIdAsync(id);
            if (app != null)
            {
                app.Status = newStatus;
                await _repo.UpdateAsync(app);
            }
        }
    }
}
