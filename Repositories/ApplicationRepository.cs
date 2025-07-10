using InternshipApplication.Data;
using Microsoft.EntityFrameworkCore;
using WebAPIDotNet.Models;

namespace InternshipApplication.Repositories
{
    public class ApplicationRepository : IApplicationRepository
    {
        private readonly ApplicationDbContext _context;

        public ApplicationRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Application>> GetAllAsync()
        {
            return await _context.Applications
                .Include(a => a.Internship)
                .Include(a => a.ApplicationUser)
                .ToListAsync();
        }

        public async Task<Application> GetByIdAsync(int id)
        {
            return await _context.Applications
                .Include(a => a.Internship)
                .Include(a => a.ApplicationUser)
                .FirstOrDefaultAsync(a => a.Id == id);
        }

        public async Task<IEnumerable<Application>> GetByUserAsync(string userId)
        {
            return await _context.Applications
                .Where(a => a.ApplicationUserId == userId)
                .Include(a => a.Internship)
                .ToListAsync();
        }

        public async Task<Application> AddAsync(Application application)
        {
            _context.Applications.Add(application);
            await _context.SaveChangesAsync();
            return application;
        }

        public async Task UpdateAsync(Application application)
        {
            _context.Entry(application).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var app = await _context.Applications.FindAsync(id);
            if (app != null)
            {
                _context.Applications.Remove(app);
                await _context.SaveChangesAsync();
            }
        }
    }
}
