using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Lab2ProjectWeb.Entities;
using Microsoft.EntityFrameworkCore;
using Proiect.Entities;
using Proiect.Repositories.GenericRepository;
using Proiect.Repositories.StorylineRepository; // ??

namespace Proiect.Repositories.StorylineRepository
{
    public class StorylineRepository : GenericRepository<Storyline>, IStorylineRepository
    {
        public StorylineRepository(ProjectContext context) : base(context) { }

        public async Task<List<Storyline>> GetAllStorylines()
        {
             return await _context.Storylines.ToListAsync();
        }

        public async Task<Storyline> GetByGameId(int id)
        {
            return await _context.Storylines.Where(s => s.GameId == id).FirstOrDefaultAsync();
        }

        public async Task<Storyline> GetById(int id)
        {
            return await _context.Storylines.Where(s => s.Id == id).FirstOrDefaultAsync();
        }
    }
}
