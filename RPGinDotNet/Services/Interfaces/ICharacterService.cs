using RPGinDotNet.Models;

namespace RPGinDotNet.Services.Interfaces
{
    public interface ICharacterService
    {
        Task<List<Character>> GetAllCharacters();
        Task<Character> GetCharacterById(int id);
        Task<Character> GetDefault();
        Task<List<Character>> AddCharacter(Character newCharacter);
    }
}
