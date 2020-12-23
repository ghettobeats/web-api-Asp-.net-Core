using System.Collections.Generic;
using System.Threading.Tasks;
using dotnet_RPG.Dtos.Character;
using dotnet_RPG.Models;

namespace dotnet_RPG.Services.CharacterService
{
    public interface ICharacterService
    {
         Task<ServiceResponse<List<GetCharacterDto>>> AddCharacter(AddCharacterDto add);
         Task<ServiceResponse<List<GetCharacterDto>>> GetAllCharacter();
        Task<ServiceResponse<GetCharacterDto>> GetCharacterById(int id);
        
        Task<ServiceResponse<GetCharacterDto>> UpdateCharacter(UpdateCharacterDto update);
         Task<ServiceResponse<List<GetCharacterDto>>> DeleteCharacter(int id);
    }
}