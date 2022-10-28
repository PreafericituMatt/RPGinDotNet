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
            new Character(){Name = "ghiza",Id = 1, Intelligence = 69,Class = RpgClass.Knight}
        };

        public async Task<Character> GetDefault()
        {
            return defaultCharacter;
        }
        public async Task<List<Character>> GetAllCharacters()
        {
            return characters;
        }

        public async Task<Character>? GetCharacterById(int id)
        {
            return characters.FirstOrDefault(c => c.Id == id);
        }

        public async Task<List<Character>> AddCharacter(Character newCharacter)
        {
            characters.Add(newCharacter);
            return characters;
        }
    }
}
