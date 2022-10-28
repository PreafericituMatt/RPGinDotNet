using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RPGinDotNet.Models;

namespace RPGinDotNet.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CharacterController : ControllerBase
    {
        private static Character knight = new();
        [HttpGet]
        public ActionResult<Character> Get()
        {
            return Ok(knight);
        }
    }
}
