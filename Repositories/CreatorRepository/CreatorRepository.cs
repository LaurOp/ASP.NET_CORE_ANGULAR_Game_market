using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Proiect.Data;
using Proiect.Entities;
using Proiect.Repositories.GenericRepository;

namespace Proiect.Repositories.CreatorRepository
{
    public class CreatorRepository : GenericRepository<Creator>, ICreatorRepository
    {
        public CreatorRepository(ProjectContext context) : base(context) {}

        public async Task<Creator> GetByName(string name)
        {
            return await _context.Creators.Where(a => a.Name.Equals(name)).FirstOrDefaultAsync();
        }

        public async Task<List<Creator>> GetAllCreators()
        {
            return await _context.Creators.ToListAsync();
        }

        public async Task<Creator> GetById(int id)
        {
            return await _context.Creators.Where(c => c.Id == id).FirstOrDefaultAsync();
        }
    }
}
