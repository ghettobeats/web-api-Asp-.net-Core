using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using dotnet_RPG.Dtos.Character;
using dotnet_RPG.Models;
using dotnet_RPG.Services.CharacterService;
using Microsoft.AspNetCore.Mvc;


namespace dotnet_RPG.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CharacterController : ControllerBase
    {
        private readonly ICharacterService _characterService;

        public CharacterController(ICharacterService characterService)
        {
            _characterService = characterService;
        }

        [HttpGet("GetAll")]
        public async Task<IActionResult> Get(){
            return Ok(await _characterService.GetAllCharacter());
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetSingle(int id){
            return Ok(await _characterService.GetCharacterById(id));
        }
        [HttpPost]
        public async Task<IActionResult> AddCharacter(AddCharacterDto newCharacter){            
            return Ok(await _characterService.AddCharacter(newCharacter));

        }
         [HttpPut]
         public async Task<IActionResult> UpdateCharacter(UpdateCharacterDto newCharacter){       
                  ServiceResponse<GetCharacterDto> response 
                  = await _characterService.UpdateCharacter(newCharacter);
                  if(response.Data == null){
                      return NotFound(response);
                  }
            return Ok(response);
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCharacter(int id){       
                  ServiceResponse<List<GetCharacterDto>> response 
                  = await _characterService.DeleteCharacter(id);
                  if(response.Data == null){
                      return NotFound(response);
                  }
            return Ok(response);
        }
    }
}