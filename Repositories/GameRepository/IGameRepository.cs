using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Proiect.Entities;
using Proiect.Repositories.GenericRepository;

namespace Proiect.Repositories.GameRepository
{
    public interface IGameRepository : IGenericRepository<Game>
    {
        Task<Game> GetByName(string name);
        Task<List<Game>> GetAllGamesWithCreator();
        Task<Game> GetByIdWithAll(int id);
    }
}
