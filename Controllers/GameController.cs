using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Proiect.Entities;
using Proiect.Entities.DTOs;
using Proiect.Repositories.GameRepository;

namespace Proiect.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GameController : ControllerBase
    {
        private readonly IGameRepository _repository;

        public GameController(IGameRepository repository)
        {
            _repository = repository;
        }


        [HttpGet]
        public async Task<IActionResult> GetAllGames()
        {
            var games = await _repository.GetAllGamesWithCreator();

            var gamesToReturn = new List<GameDTO>();

            foreach (var game in games)
            {
                gamesToReturn.Add(new GameDTO(game));
            }

            return Ok(gamesToReturn);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetGameById(int id)
        {
            var game = await _repository.GetByIdWithAll(id);

            return Ok(new GameDTO(game));
        }


        [HttpPost]
        public async Task<IActionResult> CreateGame(CreateGameDTO dto)
        {
            Game newgame = new Game();
            newgame.Name = dto.Name;
            newgame.Creator = dto.Creator;
            newgame.Price = dto.Price;
            newgame.MinimumAge = dto.MinimumAge;
            newgame.Grade = dto.Grade;
            newgame.Purchases = dto.Purchases;
            newgame.Storyline = dto.Storyline;

            _repository.Create(newgame);    //se executa doar in memorie, trebuie save

            await _repository.SaveAsync();

            return Ok(new GameDTO(newgame));
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteGameById(int id)
        {
            var game = await _repository.GetByIdWithAll(id);
            if (game == null)
            {
                return NotFound("Game does not exist");
            }
            _repository.Delete(game);
            await _repository.SaveAsync();

            return NoContent();
        }
    }
}
