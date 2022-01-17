using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Proiect.Entities;
using Proiect.Repositories.GenericRepository;

namespace Proiect.Repositories.StorylineRepository
{
    public interface IStorylineRepository : IGenericRepository<Storyline>
    {
        Task<Storyline> GetByGameId(int id);
        Task<List<Storyline>> GetAllStorylines();
        Task<Storyline> GetById(int id);
    }
}
