using dotnet_code_challenge.Application;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace dotnet_code_challenge.Infrastructure
{
    class JsonReader : IFileReader
    {
        public IEnumerable<Horse> GetHorse(string filePath)
        {
            try
            {
                using (StreamReader file = File.OpenText(filePath))
                {
                    string jsonString = file.ReadToEnd();
                    var parsedObject = JObject.Parse(jsonString);
                    var jsonArrayMarket = (JArray)parsedObject["RawData"]["Markets"];

                    var horseSelection = jsonArrayMarket.Children()
                        .SelectMany(jo => jo["Selections"].ToObject<List<HorseSelection>>())
                        .ToList();

                    return horseSelection.Select(x => new Horse()
                    {
                        Name = x.Tags.Name,
                        Price = x.Price
                    });
                }
            }
            catch (Exception ex)
            {
                //trace log
                return new List<Horse>();
            }
        }
    }
}
