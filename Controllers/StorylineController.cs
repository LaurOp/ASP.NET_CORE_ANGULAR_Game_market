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
using Proiect.Repositories.StorylineRepository;

namespace Proiect.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StorylineController : ControllerBase
    {

        private readonly IStorylineRepository _repository;

        public StorylineController(IStorylineRepository repository)
        {
            _repository = repository;
        }


        [HttpGet]
        [Authorize(Policy = "UserOrAdmin")]
        public async Task<IActionResult> GetAllStorylines()
        {
            var Storylines = await _repository.GetAllStorylines();

            var StorylinesToReturn = new List<StorylineDTO>();

            foreach (var Storyline in Storylines)
            {
                StorylinesToReturn.Add(new StorylineDTO(Storyline));
            }

            return Ok(StorylinesToReturn);
        }

        [HttpGet("{id}")]
        [Authorize(Policy = "UserOrAdmin")]
        public async Task<IActionResult> GetStorylineById(int id)
        {
            var Storyline = await _repository.GetById(id);

            return Ok(new StorylineDTO(Storyline));
        }

        [HttpGet("game{id}")]
        [Authorize(Policy = "UserOrAdmin")]
        public async Task<IActionResult> GetStorylineByGameId(int id)
        {
            var Storyline = await _repository.GetByGameId(id);

            return Ok(new StorylineDTO(Storyline));
        }

        [HttpPost]
        [Authorize(Policy = "Admin")]
        public async Task<IActionResult> CreateStoryline(CreateStorylineDTO dto)
        {
            Storyline newStoryline = new Storyline();
            newStoryline.Text = dto.Text;
            newStoryline.Playtime = dto.Playtime;
            newStoryline.GameId = dto.GameId;
            newStoryline.Game = dto.Game;

            _repository.Create(newStoryline);

            await _repository.SaveAsync();

            return Ok(new StorylineDTO(newStoryline));
        }

        [HttpPut("{id}+{playtime}")]
        [Authorize(Policy = "Admin")]
        public async Task<IActionResult> UpdatePlaytime(int id, int playtime)
        {
            var newstoryline = await _repository.GetById(id);
            newstoryline.Playtime = playtime;

            _repository.Update(newstoryline);
            await _repository.SaveAsync();
            return Ok(new StorylineDTO(newstoryline));
        }

        [HttpDelete("{id}")]
        [Authorize(Policy = "Admin")]
        public async Task<IActionResult> DeleteStorylineById(int id)
        {
            var Storyline = await _repository.GetById(id);
            if (Storyline == null)
            {
                return NotFound("Storyline does not exist");
            }
            _repository.Delete(Storyline);
            await _repository.SaveAsync();

            return NoContent();
        }

    }
}
