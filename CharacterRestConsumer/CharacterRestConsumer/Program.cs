using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace CharacterRestConsumer
{
    class Program
    {
        static async Task Main(string[] args)
        {
            var url = "https://localhost:44312/api/character";
            using (var httpClient = new HttpClient())
            {
                await PrintCharsAsync(httpClient, url);

                await AddCharacterAsync(url, httpClient);
                await PrintCharsAsync(httpClient, url);

                Console.ReadLine();

            }
        }

        static async Task AddCharacterAsync(string url, HttpClient httpClient)
        {
            var character = new Character { Id = 3, Name = "Bill" };

            var json = JsonConvert.SerializeObject(character);
            var content = new StringContent(json, Encoding.UTF8, "application/json");

            HttpResponseMessage response = await httpClient.PostAsync(url, content);

            response.EnsureSuccessStatusCode();
        }

        static async Task PrintCharsAsync(HttpClient httpClient, string url)
        {
            var request = new HttpRequestMessage(HttpMethod.Get, url);
            //request.Headers.Accept.ParseAdd("application/xml");

            HttpResponseMessage response = await httpClient.SendAsync(request);
            response.EnsureSuccessStatusCode();

            string responseText = await response.Content.ReadAsStringAsync();

            var characters = JsonConvert.DeserializeObject<List<Character>>(responseText);

            foreach (var item in characters)
            {
                Console.WriteLine($"ID {item.Id}, name {item.Name}");
            }
            Console.WriteLine();
        }
    }
}
