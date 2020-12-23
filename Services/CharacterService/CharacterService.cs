using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using dotnet_RPG.Dtos.Character;
using dotnet_RPG.Models;

namespace dotnet_RPG.Services.CharacterService
{
    public class CharacterService : ICharacterService
    {
          private readonly IMapper _autoMapper;
            private static List<Character> characters = new List<Character>{
            new Character(),
            new Character{
                Id = 1,
                Name = "froddo",
                Class = RpgClass.Cleric,
                Defense = 2,
                Intelligence = 3
            }
        };
      
        public CharacterService(IMapper autoMapper)
        {
           _autoMapper = autoMapper;
        }      

        public async Task<ServiceResponse<List<GetCharacterDto>>> AddCharacter(AddCharacterDto newCharacters)
        {      
            ServiceResponse<List<GetCharacterDto>> serviceResponse 
            = new ServiceResponse<List<GetCharacterDto>>();

            Character character = (_autoMapper.Map<Character>(newCharacters));
            character.Id = characters.Max(c => c.Id) + 1;
            characters.Add(character);
            serviceResponse.Data = (characters.Select(c => _autoMapper.Map<GetCharacterDto>(c))).ToList();

            return serviceResponse;            
        }

        public async Task<ServiceResponse<List<GetCharacterDto>>> GetAllCharacter()
        {
            ServiceResponse<List<GetCharacterDto>> serviceResponse 
            = new ServiceResponse<List<GetCharacterDto>>();

            serviceResponse.Data = (characters.Select(c => _autoMapper.Map<GetCharacterDto>(c))).ToList();
            return serviceResponse;
        }

        public async Task<ServiceResponse<GetCharacterDto>> GetCharacterById(int id)
        {
            ServiceResponse<GetCharacterDto> serviceResponse = new ServiceResponse<GetCharacterDto>();
            serviceResponse.Data = _autoMapper.Map<GetCharacterDto>(characters.FirstOrDefault(c => c.Id == id));
            return serviceResponse;
        }
       public async Task<ServiceResponse<GetCharacterDto>> UpdateCharacter(UpdateCharacterDto update){
            ServiceResponse<GetCharacterDto> service = new ServiceResponse<GetCharacterDto>();
            try
            {
                 Character character = characters.FirstOrDefault(c => c.Id == update.Id);
            character.Name = update.Name;
            character.Class = update.Class;
            character.Defense = update.Defense;
            character.HitPoints = update.HitPoints;
            character.Intelligence = update.Intelligence;
            character.Strength = update.Strength;
            service.Data = _autoMapper.Map<GetCharacterDto>(character);
            }
            catch (Exception ex)
            {
                service.Success = false;
             service.Message = ex.Message;
            
            }
           
            return service;
        }
        public async Task<ServiceResponse<List<GetCharacterDto>>> DeleteCharacter(int id){

            ServiceResponse<List<GetCharacterDto>> service = new ServiceResponse<List<GetCharacterDto>>();
            try
            {
            Character character = characters.First(c => c.Id == id);
            characters.Remove(character);
            service.Data = (characters.Select(c => _autoMapper.Map<GetCharacterDto>(c))).ToList();
            }
            catch (Exception ex)
            {
                service.Success = false;
             service.Message = ex.Message;
            
            }
            return service;
        }
    }
    

}