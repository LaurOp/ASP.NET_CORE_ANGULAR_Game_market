using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Proiect.Entities;
using Proiect.Repositories.GenericRepository;

namespace Proiect.Repositories.ReviewRepository
{
    public interface IReviewRepository : IGenericRepository<Review>
    {
        Task<Review> GetByAuthor(string author);
        Task<List<Review>> GetAllReviews();
        Task<Review> GetById(int id);
    }
}
