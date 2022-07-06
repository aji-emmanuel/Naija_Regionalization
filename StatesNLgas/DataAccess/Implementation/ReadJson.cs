using Newtonsoft.Json;
using StatesNLgas.Models;
using System;
using System.IO;
using System.Threading.Tasks;

namespace StatesNLgas.DataAccess
{
    public class ReadJson : IReadJson
    {
        private readonly string filePath = Path.Combine(Environment.CurrentDirectory, @"Json\");

        public async Task<T> GetAll<T>(string jsonFile)
        {
            var readText = await File.ReadAllTextAsync(filePath + jsonFile);

            using var stringReader = new StringReader(readText);
            using var jsonReader = new JsonTextReader(stringReader);
            T json = new JsonSerializer().Deserialize<T>(jsonReader);
            return json;
        }


        public async Task<StateLgas> GetStateLgas(string query, string jsonFile)
        {
            var readText = await File.ReadAllTextAsync(filePath + jsonFile);

            using (var stringReader = new StringReader(readText))
            using (var jsonReader = new JsonTextReader(stringReader))
            {
                jsonReader.SupportMultipleContent = true;

                while (jsonReader.Read())
                {
                    var stateNlgas = new JsonSerializer().Deserialize<StateLgas>(jsonReader);

                    if (stateNlgas.State.ToLower() == query.ToLower())
                    {
                        return stateNlgas;
                    }
                }
            }
            return null;
        }
    }
}
