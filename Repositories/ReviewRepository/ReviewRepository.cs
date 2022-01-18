using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Lab2ProjectWeb.Entities;
using Microsoft.EntityFrameworkCore;
using Proiect.Entities;
using Proiect.Repositories.GenericRepository;

namespace Proiect.Repositories.ReviewRepository
{
    public class ReviewRepository : GenericRepository<Review>, IReviewRepository
    {
        public ReviewRepository(ProjectContext context) : base(context) { }

        public async Task<List<Review>> GetAllReviews()
        {
            return await _context.Reviews.ToListAsync();
        }

        public async Task<Review> GetByAuthor(string author)
        {
            return await _context.Reviews.Where(r => r.Author == author).FirstOrDefaultAsync();
        }

        public async Task<Review> GetById(int id)
        {
            return await _context.Reviews.Where(r => r.Id == id).FirstOrDefaultAsync();
        }
    }
}
