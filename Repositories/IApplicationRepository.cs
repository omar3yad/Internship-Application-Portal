using WebAPIDotNet.Models;

namespace InternshipApplication.Repositories
{
    public interface IApplicationRepository
    {
        Task<IEnumerable<Application>> GetAllAsync();
        Task<Application> GetByIdAsync(int id);
        Task<IEnumerable<Application>> GetByUserAsync(string userId);
        Task<Application> AddAsync(Application application);
        Task UpdateAsync(Application application);
        Task DeleteAsync(int id);
    }
}
