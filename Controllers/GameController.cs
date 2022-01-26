using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Cors;
using Proiect.Entities;
using Proiect.Entities.DTOs;
using Proiect.Repositories.CreatorRepository;
using Proiect.Repositories.GameRepository;

namespace Proiect.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GameController : ControllerBase
    {
        private readonly IGameRepository _repository;
        private readonly ICreatorRepository _creators;

        public GameController(IGameRepository repository, ICreatorRepository creators)
        {
            _repository = repository;
            _creators = creators;
        }


        [HttpGet]
        [Authorize(Policy = "UserOrAdmin")]
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
        [Authorize(Policy = "UserOrAdmin")]
        public async Task<IActionResult> GetGameById(int id)
        {
            var game = await _repository.GetByIdWithAll(id);

            return Ok(new GameDTO(game));
        }


        [HttpGet("withCreators")]
        //[Authorize(Policy = "UserOrAdmin")]
        public async Task<IActionResult> GetAllGamesWithCreatorNames()
        {
            var games = await _repository.GetAllGamesWithCreator();
            var creators = await _creators.GetAllCreators();

            var gamesToReturn = new List<GameDTO>();

            foreach (var game in games)
            {
                gamesToReturn.Add(new GameDTO(game));
            }


            var joinResult = games.Join(creators,
                game => game.CreatorId,
                creat => creat.Id,
                (game, creat) => new
                {
                    GameName = game.Name,
                    CreatName = creat.Name
                });

            return Ok(joinResult);
        }


        [HttpPost]
        [Authorize(Policy = "Admin")]
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

        public class MyModel2
        {
            public string name { get; set; }
            public string creator { get; set; }
            public float price { get; set; }
        }

        public class MyModel3
        {
            public string name { get; set; }
            public string creator { get; set; }
        }

        [HttpPost("fromBody")]
        //[Authorize(Policy = "Admin")]
        public async Task<IActionResult> CreateGame([FromBody]MyModel2 game)        //pentru frontend
        {
            Game newgame = new Game();
            Creator newcreator = new Creator();
            newgame.Name = game.name;
            newcreator.Name = game.creator;
            newgame.Creator = newcreator;
            newgame.Price = game.price;

            _repository.Create(newgame);    //se executa doar in memorie, trebuie save

            await _repository.SaveAsync();

            var games2 = await _repository.GetAllGamesWithCreator();
            var creators2 = await _creators.GetAllCreators();

            var joinResult = games2.Join(creators2,
                game => game.CreatorId,
                creat => creat.Id,
                (game, creat) => new
                {
                    GameName = game.Name,
                    CreatName = creat.Name
                });

            return Ok(joinResult);
        }


        [HttpPut("{id}+{grade}")]
        [Authorize(Policy = "BasicUser")]

        public async Task<IActionResult> UpdateGrade(int id, float grade)
        {
            var newgame = await _repository.GetByIdWithAll(id);
            newgame.Grade = (newgame.Grade + grade) / 2;

            _repository.Update(newgame);
            await _repository.SaveAsync();
            return Ok(new GameDTO(newgame));
        }


        [HttpPut("")]   //endpoint pt frontend

        public async Task<IActionResult> UpdateGame([FromBody]MyModel3 game)
        {
            var newgame = await _repository.GetByName(game.name);
            var newcreator = new Creator();
            newcreator.Name = game.creator;
            newgame.Creator = newcreator;

            _repository.Update(newgame);
            await _repository.SaveAsync();

            var games2 = await _repository.GetAllGamesWithCreator();
            var creators2 = await _creators.GetAllCreators();

            var joinResult = games2.Join(creators2,
                game => game.CreatorId,
                creat => creat.Id,
                (game, creat) => new
                {
                    GameName = game.Name,
                    CreatName = creat.Name
                });

            return Ok(joinResult);
        }

        [HttpDelete("{id}")]
        [Authorize(Policy = "Admin")]
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

        public class MyModel
        {
            public string name { get; set; }
        }

        [HttpDelete("")]
        //[Authorize(Policy = "Admin")]
        public async Task<IActionResult> DeleteGameByName([FromBody]MyModel name)
        {
            var game = await _repository.GetByName(name.name);
            
            if (game == null)
            {
                return NotFound("Game does not exist");
            }
            _repository.Delete(game);
            await _repository.SaveAsync();

            var games2 = await _repository.GetAllGamesWithCreator();
            var creators2 = await _creators.GetAllCreators();

            var joinResult = games2.Join(creators2,
                game => game.CreatorId,
                creat => creat.Id,
                (game, creat) => new
                {
                    GameName = game.Name,
                    CreatName = creat.Name
                });

            return Ok(joinResult);
        }
    }
}
