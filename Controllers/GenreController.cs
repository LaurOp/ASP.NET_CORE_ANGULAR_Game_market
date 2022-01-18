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
using Proiect.Repositories.GenreRepository;

namespace Proiect.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GenreController : ControllerBase
    {

        private readonly IGenreRepository _repository;

        public GenreController(IGenreRepository repository)
        {
            _repository = repository;
        }


        [HttpGet]
        [Authorize(Policy = "UserOrAdmin")]
        public async Task<IActionResult> GetAllGenres()
        {
            var genres = await _repository.GetAllGenres();

            var genresToReturn = new List<GenreDTO>();

            foreach (var genre in genres)
            {
                genresToReturn.Add(new GenreDTO(genre));
            }

            return Ok(genresToReturn);
        }

        [HttpGet("{id}")]
        [Authorize(Policy = "UserOrAdmin")]
        public async Task<IActionResult> GetGenreById(int id)
        {
            var genre = await _repository.GetById(id);

            return Ok(new GenreDTO(genre));
        }

        [Route("kids")]
        [HttpGet]
        [Authorize(Policy = "UserOrAdmin")]
        public async Task<IActionResult> GetAllGenresForKids()
        {
            var genres = await _repository.GetAllGenresForKids();

            var genresToReturn = new List<GenreDTO>();

            foreach (var genre in genres)
            {
                genresToReturn.Add(new GenreDTO(genre));
            }

            return Ok(genresToReturn);
        }

        [HttpPost]
        [Authorize(Policy = "Admin")]
        public async Task<IActionResult> CreateGenre(CreateGenreDTO dto)
        {
            Genre newgenre = new Genre();
            newgenre.Description = dto.Description;
            newgenre.ForKids = dto.ForKids;
            newgenre.Name = dto.Name;
            

            _repository.Create(newgenre);

            await _repository.SaveAsync();

            return Ok(new GenreDTO(newgenre));
        }

        [HttpPut("{id}+{forkids}")]
        [Authorize(Policy = "Admin")]
        public async Task<IActionResult> UpdateForkids(int id, bool forkids)
        {
            var newgenre = await _repository.GetById(id);
            newgenre.ForKids = forkids;

            _repository.Update(newgenre);
            await _repository.SaveAsync();
            return Ok(new GenreDTO(newgenre));
        }

        [HttpDelete("{id}")]
        [Authorize(Policy = "Admin")]
        public async Task<IActionResult> DeleteGenreById(int id)
        {
            var genre = await _repository.GetById(id);
            if (genre == null)
            {
                return NotFound("Genre does not exist");
            }
            _repository.Delete(genre);
            await _repository.SaveAsync();

            return NoContent();
        }
    }
}
