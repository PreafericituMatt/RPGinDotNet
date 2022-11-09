using AutoMapper;
using Microsoft.EntityFrameworkCore;
using RPGinDotNet.Data;
using RPGinDotNet.Dtos.Character;
using RPGinDotNet.Models;
using RPGinDotNet.Services.Interfaces;

namespace RPGinDotNet.Services.Implementation
{
    public class CharacterService : ICharacterService
    {
        private static Character defaultCharacter = new() { Name = "default", Id = 0 };
        /*
        private static List<Character> characters = new()
        {
            new Character(){Name = "cineva",Id = 2, HitPoints = 100,Defence = 20,Class = RpgClass.Mage},
            new Character(){Name = "Ghiza",Id = 1, Intelligence = 69,Class = RpgClass.Knight}
        };
        */
        private readonly IMapper _mapper;
        private readonly DataContext _context;

        public CharacterService(IMapper mapper,DataContext context )
        {
            _mapper = mapper;
            _context = context;
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
            var response = new ServiceResponse<List<GetCharacterDto>>();
            var dbCharacters = await _context.Characters.ToListAsync();
            response.Data = dbCharacters.Select(c => _mapper.Map<GetCharacterDto>(c)).ToList();
            return response;

        }

        public async Task<ServiceResponse<GetCharacterDto>>? GetCharacterById(int id)
        {
            var serviceResponse = new ServiceResponse<GetCharacterDto>();
           var dbCharacter = await _context.Characters.FirstOrDefaultAsync(c => c.Id == id);
           serviceResponse.Data = _mapper.Map<GetCharacterDto>(dbCharacter);
            return serviceResponse;
        }

        public async Task<ServiceResponse<List<GetCharacterDto>>> AddCharacter(AddCharacterDto newCharacter)
        {
            var serviceResponse = new ServiceResponse<List<GetCharacterDto>>();
            Character character = _mapper.Map<Character>(newCharacter);
            _context.Characters.Add(character);
           // characters.Add(character);
            await _context.SaveChangesAsync();
            serviceResponse.Data = await _context.Characters
                .Select(c => _mapper.Map<GetCharacterDto>(c))
                .ToListAsync();
            return serviceResponse;
        }

        public async Task<ServiceResponse<GetCharacterDto>> UpdateCharacter(UpdateCharacterDto updatedCharacter)
        {
            ServiceResponse<GetCharacterDto> response = new ServiceResponse<GetCharacterDto>();

            try
            { 
                var character = await _context.Characters
                    .FirstOrDefaultAsync(c => c.Id == updatedCharacter.Id);

                _mapper.Map(updatedCharacter, character);

                await _context.SaveChangesAsync();

                response.Data = _mapper.Map<GetCharacterDto>(character);
            }
            catch (Exception ex)
            {
                response.Success = false;
                response.Message = ex.Message;
            }
            return response;


        }

        public async Task<ServiceResponse<List<GetCharacterDto>>> DeleteCharacter(int id)
        {
            ServiceResponse<List<GetCharacterDto>> response = new ServiceResponse<List<GetCharacterDto>>();

            try
            {
              var character = await _context.Characters
                  .FirstAsync(c => c.Id == id);
                _context.Characters.Remove(character);
                await _context.SaveChangesAsync();

                response.Data = _context.Characters.Select(c => _mapper.Map<GetCharacterDto>(c)).ToList();
            }
            catch (Exception ex)
            {
                response.Success = false;
                response.Message = ex.Message;
            }
            return response;

        }
    }
}
