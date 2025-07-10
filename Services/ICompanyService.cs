using InternshipApplication.DTO;

namespace InternshipApplication.Services
{
    public interface ICompanyService
    {
        Task<IEnumerable<CompanyDTO>> GetAllAsync();
        Task<CompanyDTO> GetByIdAsync(int id);
        Task<CompanyDTO> CreateAsync(CompanyCreateDTO dto);
        Task UpdateAsync(int id, CompanyCreateDTO dto);
        Task DeleteAsync(int id);
    }
}
