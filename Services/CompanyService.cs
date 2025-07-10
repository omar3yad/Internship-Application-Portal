using InternshipApplication.DTO;
using InternshipApplication.Repositories;
using WebAPIDotNet.Models;

namespace InternshipApplication.Services
{
    public class CompanyService : ICompanyService
    {
        private readonly ICompanyRepository _repo;

        public CompanyService(ICompanyRepository repo)
        {
            _repo = repo;
        }

        public async Task<IEnumerable<CompanyDTO>> GetAllAsync()
        {
            var companies = await _repo.GetAllAsync();
            return companies.Select(c => new CompanyDTO
            {
                Id = c.Id,
                Name = c.Name,
                ContactEmail = c.ContactEmail
            }).ToList();
        }

        public async Task<CompanyDTO> GetByIdAsync(int id)
        {
            var c = await _repo.GetByIdAsync(id);
            if (c == null) return null;

            return new CompanyDTO
            {
                Id = c.Id,
                Name = c.Name,
                ContactEmail = c.ContactEmail
            };
        }

        public async Task<CompanyDTO> CreateAsync(CompanyCreateDTO dto)
        {
            var company = new Company
            {
                Name = dto.Name,
                ContactEmail = dto.ContactEmail
            };

            var created = await _repo.AddAsync(company);

            return new CompanyDTO
            {
                Id = created.Id,
                Name = created.Name,
                ContactEmail = created.ContactEmail
            };
        }

        public async Task UpdateAsync(int id, CompanyCreateDTO dto)
        {
            var existing = await _repo.GetByIdAsync(id);
            if (existing != null)
            {
                existing.Name = dto.Name;
                existing.ContactEmail = dto.ContactEmail;
                await _repo.UpdateAsync(existing);
            }
        }

        public async Task DeleteAsync(int id)
        {
            await _repo.DeleteAsync(id);
        }
    }
}
