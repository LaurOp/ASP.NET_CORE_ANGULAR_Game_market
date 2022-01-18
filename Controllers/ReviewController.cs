using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
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
        [Authorize(Policy = "UserOrAdmin")]
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
        [Authorize(Policy = "UserOrAdmin")]
        public async Task<IActionResult> GetReviewById(int id)
        {
            var Review = await _repository.GetById(id);

            return Ok(new ReviewDTO(Review));
        }

        [HttpGet("author{author}")]
        [Authorize(Policy = "UserOrAdmin")]
        public async Task<IActionResult> GetReviewByAuthor(string author)
        {
            var Review = await _repository.GetByAuthor(author);

            return Ok(new ReviewDTO(Review));
        }

        [HttpPost]
        [Authorize(Policy = "Admin")]
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

        [HttpPut("{id}+")]
        [Authorize(Policy = "User")]
        public async Task<IActionResult> UpdateLikes(int id)
        {
            var newreview = await _repository.GetById(id);
            newreview.likes = newreview.likes - 1;

            _repository.Update(newreview);
            await _repository.SaveAsync();
            return Ok(new ReviewDTO(newreview));
        }

        [HttpPut("{id}-")]
        [Authorize(Policy = "User")]
        public async Task<IActionResult> UpdateDislikes(int id)
        {
            var newreview = await _repository.GetById(id);
            newreview.dislikes = newreview.dislikes - 1;

            _repository.Update(newreview);
            await _repository.SaveAsync();
            return Ok(new ReviewDTO(newreview));
        }

        [HttpDelete("{id}")]
        [Authorize(Policy = "Admin")]
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
