using Microsoft.AspNetCore.Identity;

namespace RandomRickAndMorty.Areas.Identity.Data
{
    public class RandomRickAndMortyUser : IdentityUser
    {
        public bool IsAdmin { get; set; }
    }
}
