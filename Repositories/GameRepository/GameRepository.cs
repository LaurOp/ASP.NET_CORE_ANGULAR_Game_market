using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Lab2ProjectWeb.Entities;
using Microsoft.EntityFrameworkCore;
using Proiect.Entities;
using Proiect.Repositories.GenericRepository;

namespace Proiect.Repositories.GameRepository
{
    
    public class GameRepository : GenericRepository<Game>, IGameRepository
    { 
        public GameRepository(ProjectContext context) : base(context) {}

        public async Task<List<Game>> GetAllGamesWithCreator()
        {
            return await _context.Games.Include(a => a.Creator).ToListAsync();
        }

        public async Task<Game> GetByName(string name)
        {
            return await _context.Games.Where(a => a.Name.Equals(name)).FirstOrDefaultAsync();
        }

        public async Task<Game> GetByIdWithAll(int id)
        {
            return await _context.Games.Include(g => g.Creator).Include(g => g.Storyline).Where(g => g.Id == id).FirstOrDefaultAsync();
        }

    }
}
