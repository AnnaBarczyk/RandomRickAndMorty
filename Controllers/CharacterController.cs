using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using RandomRickAndMorty.Service;
using System.Threading.Tasks;

namespace RandomRickAndMorty.Controllers
{
    public class CharacterController : Controller
    {
        private readonly ICharacterService _characterService;

        public CharacterController(ICharacterService characterService)
        {
            _characterService = characterService;
        }

        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> GetRandomCharactersFromAPI()
        {
            var results = await GetRandomCharacters.GetRandomCharacters.GetFiveRandomCharacters();

            var uniqueCharacters = await _characterService.ExtractUniqueAsync(results);

            await _characterService.SaveCharactersToDatabase(uniqueCharacters);

            ViewData["Characters"] = results;
            return View("AdminPanel");
        }

        [Authorize]
        public async Task<IActionResult> GetCharactersFromDatabase()
        {
            var results = await _characterService.GetCharactersFromDatabase();
            ViewData["Characters"] = results;
            return View("GatheredCharacters");
        }
    }
}
