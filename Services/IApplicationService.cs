using InternshipApplication.DTO;

namespace InternshipApplication.Services
{
    public interface IApplicationService
    {
        Task<IEnumerable<ApplicationDTO>> GetAllAsync();
        Task<ApplicationDTO> GetByIdAsync(int id);
        Task<IEnumerable<ApplicationDTO>> GetByUserAsync(string userId);
        Task<ApplicationDTO> CreateAsync(string userId, ApplicationCreateDTO dto, string uploadsFolder);
        Task UpdateStatusAsync(int id, string newStatus);
    }
}
