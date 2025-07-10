using System;
using InternshipApplication.Data;
using Microsoft.EntityFrameworkCore;
using WebAPIDotNet.Models;

namespace InternshipApplication.Repositories
{
    public class InternshipRepository : IInternshipRepository
    {
        private readonly ApplicationDbContext _context;

        public InternshipRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Internship>> GetAllAsync()
        {
            return await _context.Internships
                .Include(i => i.Company)
                .ToListAsync();
        }
        public async Task<Internship> GetByIdAsync(int id)
        {
            return await _context.Internships
                .Include(i => i.Company)
                .FirstOrDefaultAsync(i => i.Id == id);
        }

        public async Task AddAsync(Internship internship)
        {
            await _context.Internships.AddAsync(internship);
        }


        public async Task SaveChangesAsync()
        {
            await _context.SaveChangesAsync();
        }
        public void Delete(Internship internship)
        {
            _context.Internships.Remove(internship);
        }

    }

}
