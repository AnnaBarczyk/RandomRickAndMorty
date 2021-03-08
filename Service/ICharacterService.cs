using RandomRickAndMorty.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace RandomRickAndMorty.Service
{
    public interface ICharacterService
    {
        Task<List<CharacterModel>> ExtractUniqueAsync(List<CharacterModel> models);
        Task SaveCharactersToDatabase(List<CharacterModel> uniqueCharacters);
        Task<List<CharacterModel>> GetCharactersFromDatabase();
    }
}
