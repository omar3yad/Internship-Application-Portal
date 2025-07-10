using InternshipApplication.DTO;

namespace InternshipApplication.Services
{
    public interface IInternshipService
    {
        Task<IEnumerable<InternshipDTO>> GetAllInternshipsAsync();
        Task<InternshipDTO> GetByIdAsync(int id);
        Task<InternshipDTO> CreateAsync(InternshipCreateDTO dto);
        Task<bool> UpdateAsync(int id, InternshipUpdateDTO dto);
        Task<bool> DeleteAsync(int id);
    }
}
