using Microsoft.EntityFrameworkCore;
using RandomRickAndMorty.Data;
using RandomRickAndMorty.Entities;
using RandomRickAndMorty.Repositories;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace RandomRickAndMorty
{
    public class CharacterRepository : ICharacterRepository
    {
        private readonly RandomRickAndMortyContext _context;
        private readonly DbSet<Character> table;

        public CharacterRepository(RandomRickAndMortyContext context)
        {
            _context = context;
            table = _context.Set<Character>();
        }
        public async Task AddAsync(Character fact)
        {
            await _context.AddAsync(fact);
            await _context.SaveChangesAsync();
        }

        public async Task AddRangeAsync(List<Character> characters)
        {
            await _context.AddRangeAsync(characters);
            await _context.SaveChangesAsync();
        }

        public async Task<List<Character>> GetAllAsync()
        {
            var result = await table.ToListAsync();
            return result;
        }

        public async Task<Character> GetById(string id)
        {
            var allCharacters = await GetAllAsync();
            return allCharacters.Find(x => x.Id == id);
        }
    }

}
