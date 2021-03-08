using RandomRickAndMorty.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace RandomRickAndMorty.Repositories
{
    public interface ICharacterRepository
    {
        Task AddAsync(Character fact);
        Task AddRangeAsync(List<Character> facts);
        Task<List<Character>> GetAllAsync();
        Task<Character> GetById(string id);
    }
}
