using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Proiect.Entities;
using Proiect.Entities.DTOs;
using Proiect.Repositories.CreatorRepository;

namespace Proiect.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CreatorController : ControllerBase
    {
        private readonly ICreatorRepository _repository;

        public CreatorController(ICreatorRepository repository)
        {
            _repository = repository;
        }


        [HttpGet]
        public async Task<IActionResult> GetAllCreators()
        {
            var creators = await _repository.GetAllCreators();

            var creatorsToReturn = new List<CreatorDTO>();

            foreach (var creator in creators)
            {
                creatorsToReturn.Add(new CreatorDTO(creator));
            }

            return Ok(creatorsToReturn);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetCreatorById(int id)
        {
            var creator = await _repository.GetById(id);

            return Ok(new CreatorDTO(creator));
        }


        [HttpPost]
        public async Task<IActionResult> CreateCreator(CreateCreatorDTO dto)
        {
            Creator newcreator = new Creator();
            newcreator.Name = dto.Name;
            newcreator.NetWorth = dto.NetWorth;
            newcreator.NumberOfEmployees = dto.NumberOfEmployees;


            _repository.Create(newcreator);    //se executa doar in memorie, trebuie save

            await _repository.SaveAsync();

            return Ok(new CreatorDTO(newcreator));
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCreatorById(int id)
        {
            var creator = await _repository.GetById(id);
            if (creator == null)
            {
                return NotFound("Creator does not exist");
            }
            _repository.Delete(creator);
            await _repository.SaveAsync();

            return NoContent();
        }
    }
}
