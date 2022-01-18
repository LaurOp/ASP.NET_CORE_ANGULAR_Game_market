using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Lab2ProjectWeb.Entities;
using Microsoft.EntityFrameworkCore;
using Proiect.Entities;
using Proiect.Repositories.GenericRepository;

namespace Proiect.Repositories.GenreRepository
{
    public class GenreRepository : GenericRepository<Genre>, IGenreRepository
    {
        public GenreRepository(ProjectContext context) : base(context) { }

        public async Task<List<Genre>> GetAllGenres()
        {
            return await _context.Genres.ToListAsync();
        }

        public async Task<List<Genre>> GetAllGenresForKids()
        {
            return await _context.Genres.Where(g => g.ForKids == true).ToListAsync();
        }

        public async Task<Genre> GetById(int id)
        {
            return await _context.Genres.Where(g => g.Id == id).FirstOrDefaultAsync();
        }

        public async Task<Genre> GetByName(string name)
        {
            return await _context.Genres.Where(g => g.Name == name).FirstOrDefaultAsync();
        }
    }
}
