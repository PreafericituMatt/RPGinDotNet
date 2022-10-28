using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RPGinDotNet.Dtos.Character;
using RPGinDotNet.Models;
using RPGinDotNet.Services.Interfaces;

namespace RPGinDotNet.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CharacterController : ControllerBase
    {   
        private readonly ICharacterService _characterService;
        public CharacterController(ICharacterService characterService )
        {
            _characterService = characterService;
        }

        [HttpGet("GetAll")]
        public async Task<ActionResult<ServiceResponse<List<GetCharacterDto>>>> Get()
        {
            return Ok(await _characterService.GetAllCharacters());
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<ServiceResponse<GetCharacterDto>>?> GetCharacterById(int id)
        {
            return Ok(await _characterService.GetCharacterById(id));
        }

        [HttpGet("GetDefault")]
        public async Task<ActionResult<GetCharacterDto>> GetDefault()
        {
            return Ok(_characterService.GetDefault());
        }

        [HttpPost]
        public async Task<ActionResult<ServiceResponse<List<GetCharacterDto>>>> AddCharacter(AddCharacterDto newCharacter)
        { 
            return Ok(await _characterService.AddCharacter(newCharacter));
        }
    }
}
