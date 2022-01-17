using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Proiect.Entities;
using Proiect.Entities.DTOs;
using Proiect.Repositories.GameRepository;
using Proiect.Repositories.ReviewRepository;

namespace Proiect.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ReviewController : ControllerBase
    {

        private readonly IReviewRepository _repository;

        public ReviewController(IReviewRepository repository)
        {
            _repository = repository;
        }


        [HttpGet]
        public async Task<IActionResult> GetAllReviews()
        {
            var Reviews = await _repository.GetAllReviews();

            var ReviewsToReturn = new List<ReviewDTO>();

            foreach (var Review in Reviews)
            {
                ReviewsToReturn.Add(new ReviewDTO(Review));
            }

            return Ok(ReviewsToReturn);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetReviewById(int id)
        {
            var Review = await _repository.GetById(id);

            return Ok(new ReviewDTO(Review));
        }

        [HttpGet("author{author}")]
        public async Task<IActionResult> GetReviewByAuthor(string author)
        {
            var Review = await _repository.GetByAuthor(author);

            return Ok(new ReviewDTO(Review));
        }

        [HttpPost]
        public async Task<IActionResult> CreateReview(CreateReviewDTO dto)
        {
            Review newReview = new Review();
            newReview.Author = dto.Author;
            newReview.Text = dto.Text;
            newReview.likes = dto.likes;
            newReview.dislikes = dto.dislikes;
            newReview.GameId = dto.GameId;
            newReview.Game = dto.Game;

            _repository.Create(newReview); 

            await _repository.SaveAsync();

            return Ok(new ReviewDTO(newReview));
        }

        [HttpPut("{id}+{likes}")]
        public async Task<IActionResult> UpdateLikes(int id, int likes)
        {
            var newreview = await _repository.GetById(id);
            newreview.likes = likes;

            _repository.Update(newreview);
            await _repository.SaveAsync();
            return Ok(new ReviewDTO(newreview));
        }

        [HttpPut("{id}-{dislikes}")]
        public async Task<IActionResult> UpdateGrade(int id, int dislikes)
        {
            var newreview = await _repository.GetById(id);
            newreview.dislikes =dislikes;

            _repository.Update(newreview);
            await _repository.SaveAsync();
            return Ok(new ReviewDTO(newreview));
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteReviewById(int id)
        {
            var Review = await _repository.GetById(id);
            if (Review == null)
            {
                return NotFound("Review does not exist");
            }
            _repository.Delete(Review);
            await _repository.SaveAsync();

            return NoContent();
        }
    }
}
