using AutoMapper;
using RPGinDotNet.Dtos.Character;
using RPGinDotNet.Models;
using RPGinDotNet.Services.Interfaces;

namespace RPGinDotNet.Services.Implementation
{
    public class CharacterService : ICharacterService
    {
        private static Character defaultCharacter = new() { Name = "default", Id = 0 };
        private static List<Character> characters = new()
        {
            new Character(){Name = "cineva",Id = 2, HitPoints = 100,Class = RpgClass.Mage},
            new Character(){Name = "Ghiza",Id = 1, Intelligence = 69,Class = RpgClass.Knight}
        };

        private readonly IMapper _mapper;

        public CharacterService(IMapper mapper )
        {
            _mapper = mapper;
        }



        public async Task<ServiceResponse<GetCharacterDto>> GetDefault()
        {
            var serviceResponse = new ServiceResponse<GetCharacterDto>();
            var character = defaultCharacter;
            serviceResponse.Data = _mapper.Map<GetCharacterDto>(character);
            return serviceResponse;
        }
        public async Task<ServiceResponse<List<GetCharacterDto>>> GetAllCharacters()
        {   
            return new ServiceResponse<List<GetCharacterDto>>
            {
                Data = characters.Select(c => _mapper.Map<GetCharacterDto>(c)).ToList()
            };
        }

        public async Task<ServiceResponse<GetCharacterDto>>? GetCharacterById(int id)
        {
            var serviceResponse = new ServiceResponse<GetCharacterDto>();
           var character = characters.FirstOrDefault(c => c.Id == id);
           serviceResponse.Data = _mapper.Map<GetCharacterDto>(character);
            return serviceResponse;
        }

        public async Task<ServiceResponse<List<GetCharacterDto>>> AddCharacter(AddCharacterDto newCharacter)
        {
            var serviceResponse = new ServiceResponse<List<GetCharacterDto>>();
            Character character = _mapper.Map<Character>(newCharacter);
            character.Id = characters.Max(c => c.Id) + 1;
            characters.Add(character);
            //characters.Add(_mapper.Map<Character>(newCharacter));
            serviceResponse.Data = characters.Select(c => _mapper.Map<GetCharacterDto>(c)).ToList();
            return serviceResponse;
        }

        public async Task<ServiceResponse<GetCharacterDto>> UpdateCharacter(UpdateCharacterDto updatedCharacter)
        {
            ServiceResponse<GetCharacterDto> response = new ServiceResponse<GetCharacterDto>();

            try
            { 
                Character character = characters.FirstOrDefault(c => c.Id == updatedCharacter.Id);

                _mapper.Map(updatedCharacter, character);
                
                response.Data = _mapper.Map<GetCharacterDto>(character);
            }
            catch (Exception ex)
            {
                response.Success = false;
                response.Mesage = ex.Message;
            }
            return response;


        }

        public async Task<ServiceResponse<List<GetCharacterDto>>> DeleteCharacter(int id)
        {
            ServiceResponse<List<GetCharacterDto>> response = new ServiceResponse<List<GetCharacterDto>>();

            try
            {
                Character character = characters.FirstOrDefault(c => c.Id == id);
                characters.Remove(character);
                response.Data = characters.Select(c => _mapper.Map<GetCharacterDto>(c)).ToList();
            }
            catch (Exception ex)
            {
                response.Success = false;
                response.Mesage = ex.Message;
            }
            return response;

        }
    }
}
