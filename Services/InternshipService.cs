using InternshipApplication.DTO;
using InternshipApplication.Repositories;
using WebAPIDotNet.Models;

namespace InternshipApplication.Services
{
    public class InternshipService : IInternshipService
    {
        private readonly IInternshipRepository _repository;

        public InternshipService(IInternshipRepository repository)
        {
            _repository = repository;
        }

        public async Task<IEnumerable<InternshipDTO>> GetAllInternshipsAsync()
        {
            var internships = await _repository.GetAllAsync();

            return internships.Select(i => new InternshipDTO
            {
                Id = i.Id,
                Title = i.Title,
                Description = i.Description,
                Location = i.Location,
                Status = i.Status,
                CompanyId = i.CompanyId,
                PostedAt = i.PostedAt
            }).ToList();
        }
        public async Task<InternshipDTO> GetByIdAsync(int id)
        {
            var internship = await _repository.GetByIdAsync(id);

            if (internship == null)
                return null;

            return new InternshipDTO
            {
                Id = internship.Id,
                Title = internship.Title,
                Description = internship.Description,
                Location = internship.Location,
                Status = internship.Status,
                CompanyId = internship.CompanyId,
                PostedAt = internship.PostedAt
            };
        }

        public async Task<InternshipDTO> CreateAsync(InternshipCreateDTO dto)
        {
            var internship = new Internship
            {
                Title = dto.Title,
                Description = dto.Description,
                Location = dto.Location,
                Status = dto.Status,
                CompanyId = dto.CompanyId,
                PostedAt = DateTime.Now
            };

            await _repository.AddAsync(internship);
            await _repository.SaveChangesAsync();

            // تحويل إلى DTO للرجوع فيه
            return new InternshipDTO
            {
                Id = internship.Id,
                Title = internship.Title,
                Description = internship.Description,
                Location = internship.Location,
                Status = internship.Status,
                CompanyId = internship.CompanyId,
                PostedAt = internship.PostedAt
            };
        }

        public async Task<bool> UpdateAsync(int id, InternshipUpdateDTO dto)
        {
            var internship = await _repository.GetByIdAsync(id);
            if (internship == null)
                return false;

            internship.Title = dto.Title;
            internship.Description = dto.Description;
            internship.Location = dto.Location;
            internship.Status = dto.Status;

            await _repository.SaveChangesAsync();
            return true;
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var internship = await _repository.GetByIdAsync(id);
            if (internship == null)
                return false;

            _repository.Delete(internship);
            await _repository.SaveChangesAsync();
            return true;
        }

    }
}
