using System;
using System.Collections.Generic;
using System.Globalization;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using Newtonsoft.Json.Linq;

namespace AskKirk
{
    partial class Program
    {
        private static HttpClient _client;
        private static string _endpoint = "https://swapi.co/api/starships";

        static void Main()
        {
            var starShips = new List<StarShip>();
            Console.WriteLine("Space: The Final Frontier.");
            Console.WriteLine("Hi This is Kirk, We need to plan our next Journey.");
            Console.Write("Please enter distance to cover in mega lights (MGLT) for our next journey: ");
            Int64 distanceToCover = Int64.Parse(Console.ReadLine());
            Console.WriteLine($"The distance to our distination is {distanceToCover}");
            Console.WriteLine("Wait, I am planning itenary for our travel.................................");
            do
            {
                starShips.AddRange(GetStarShips().Result);
            } while (_endpoint != string.Empty);
            PrintItenary(distanceToCover, starShips);
            Console.Read();
        }

        private static async Task<List<StarShip>> GetStarShips()
        {
            if (string.IsNullOrEmpty(_endpoint)) return new List<StarShip>();
            _client = new HttpClient { BaseAddress = new Uri(_endpoint) };
            _client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

            var streamTask = await _client.GetAsync(string.Empty);
            if (streamTask.IsSuccessStatusCode)
            {
                var data = streamTask.Content.ReadAsStringAsync().Result;
                var jsonObject = JObject.Parse(data);
                var result = jsonObject["results"].ToObject<List<StarShip>>();
                _endpoint = jsonObject["next"].ToString();
                return result;
            }
            return new List<StarShip>();
        }

        private static void PrintItenary(Int64 distanceToCover, List<StarShip> listOfShips)
        {
            Console.WriteLine("Name Of Ship -- Number Of Stops Required");
            foreach (var ship in listOfShips)
            {
                Console.WriteLine($"{ship.Name} -- {CalculateStops(distanceToCover, ship.MaxAtmospheringSpeed)}");
            }
            Console.WriteLine("....................................Thank You.................................");
        }

        private static string CalculateStops(long distanceToCover, string shipMaxAtmospheringSpeed)
        {
            var isNumber = Int64.TryParse(shipMaxAtmospheringSpeed, NumberStyles.Any, null, out var maxSpeed);
            if (isNumber)
            {
                return (distanceToCover / maxSpeed).ToString();
            }

            return "Speed Not Available";
        }
    }
}
