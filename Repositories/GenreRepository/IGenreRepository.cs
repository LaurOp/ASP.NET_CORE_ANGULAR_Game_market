using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Proiect.Entities;
using Proiect.Repositories.GenericRepository;

namespace Proiect.Repositories.GenreRepository
{
    public interface IGenreRepository : IGenericRepository<Genre>
    {
        Task<Genre> GetByName(string name);
        Task<List<Genre>> GetAllGenres();
        Task<List<Genre>> GetAllGenresForKids();
        Task<Genre> GetById(int id);

    }
}
