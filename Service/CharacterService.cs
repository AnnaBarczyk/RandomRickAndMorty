using RandomRickAndMorty.Mapping;
using RandomRickAndMorty.Models;
using RandomRickAndMorty.Repositories;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace RandomRickAndMorty.Service
{
    public class CharacterService : ICharacterService
    {
        private readonly ICharacterRepository _characterRepository;

        public CharacterService(ICharacterRepository characterRepository)
        {
            _characterRepository = characterRepository;
        }

        /// <summary>
        /// Checks if random characters are already 
        /// in database, then returns only unique CharacterModels in a list.
        /// </summary>
        public async Task<List<CharacterModel>> ExtractUniqueAsync(List<CharacterModel> models)
        {
            var results = new List<CharacterModel>();

            for (int i = 0; i < models.Count; i++)
            {
                if (await _characterRepository.GetById(models[i].Id.ToString()) == null)
                {
                    results.Add(models[i]);
                }
            }

            return results;
        }

        public async Task SaveCharactersToDatabase(List<CharacterModel> uniqueCharacters)
        {
            await _characterRepository.AddRangeAsync(Mapper.ToEntityList(uniqueCharacters));
        }

        public async Task<List<CharacterModel>> GetCharactersFromDatabase()
        {
            var results = await _characterRepository.GetAllAsync();
            return Mapper.ToModelList(results);
        }
    }
}
