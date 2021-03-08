using Newtonsoft.Json;
using RandomRickAndMorty.Models;
using RandomRickAndMorty.Shared;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace RandomRickAndMorty.GetRandomCharacters
{
    public static class GetRandomCharacters
    {
        /// <summary>
        /// Gets five random id numbers, then returns list of CharacterModels 
        /// with that ID from given, external API.
        /// </summary>
        public static async Task<List<CharacterModel>> GetFiveRandomCharacters()
        {
            using var client = new HttpClient();
            client.BaseAddress = new Uri("https://rickandmortyapi.com/api/character/");
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            
            var rnd = new Random();
            var rndNumbersToUrl = new StringBuilder();
            for (int i = 0; i < Const.NumberOfCharacters; i++)
            {
                if (i == Const.NumberOfCharacters)
                {
                    rndNumbersToUrl.Append(rnd.Next(0, Const.NumberOfCharactersInAPI));
                }
                else
                {
                    rndNumbersToUrl.Append(rnd.Next(0, Const.NumberOfCharactersInAPI));
                    rndNumbersToUrl.Append(',');
                }
            }
            var url = rndNumbersToUrl.ToString();
            var response = await client.GetAsync(url);
            string json;
            using (var content = response.Content)
            {
                if (response.IsSuccessStatusCode)
                {
                    json = await content.ReadAsStringAsync();
                }
                else
                {
                    throw new Exception(response.ReasonPhrase);
                }
            }
            return JsonConvert.DeserializeObject<List<CharacterModel>>(json);
        }
    }
}