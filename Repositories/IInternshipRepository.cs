using WebAPIDotNet.Models;

namespace InternshipApplication.Repositories
{
    public interface IInternshipRepository
    {
        Task<IEnumerable<Internship>> GetAllAsync();
        Task<Internship> GetByIdAsync(int id);
        Task AddAsync(Internship internship);
        Task SaveChangesAsync();
        void Delete(Internship internship);
    }
}