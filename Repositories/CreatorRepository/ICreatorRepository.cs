using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Proiect.Entities;
using Proiect.Repositories.GenericRepository;

namespace Proiect.Repositories.CreatorRepository
{
    public interface ICreatorRepository : IGenericRepository<Creator>
    {
        Task<Creator> GetByName(string name);
        Task<List<Creator>> GetAllCreators();
        Task<Creator> GetById(int id);
        
    }
}
