using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using RandomRickAndMorty.Areas.Identity.Data;
using RandomRickAndMorty.Entities;

namespace RandomRickAndMorty.Data
{
    public class RandomRickAndMortyContext : IdentityDbContext<RandomRickAndMortyUser>
    {
        public RandomRickAndMortyContext(DbContextOptions<RandomRickAndMortyContext> options)
            : base(options)
        {
        }
        public DbSet<Character> Characters { get; set; }
        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
        }
    }
}
