using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
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
        public async Task<ActionResult<List<Character>>> Get()
        {
            return Ok(await _characterService.GetAllCharacters());
        }

        [HttpGet("{id}")]
        public async Task<ActionResult?> GetCharacterById(int id)
        {
            return Ok(await _characterService.GetCharacterById(id));
        }

        [HttpGet("GetDefault")]
        public async Task<ActionResult<Character>> GetDefault()
        {
            return Ok(_characterService.GetDefault());
        }

        [HttpPost]
        public async Task<ActionResult<List<Character>>> AddCharacter(Character newCharacter)
        { 
            return Ok(await _characterService.AddCharacter(newCharacter));
        }
    }
}
