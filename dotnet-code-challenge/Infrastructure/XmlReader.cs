using dotnet_code_challenge.Application;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Linq;
 
namespace dotnet_code_challenge.Infrastructure
{
    class XmlReader : IFileReader
    {
        public IEnumerable<Horse> GetHorse(string filePath)
        {
            try
            {
                var loadElement = XElement.Load(filePath);

                decimal price = 0m;
                int number = 0;
                var horseDetails = new List<HorseDetail>();
                var horsePrices = new List<HorsePrice>();

                foreach (var races in loadElement.Descendants("race"))
                {
                    foreach (var horsesNode in races.Elements("horses"))
                    {
                        foreach (var horse in horsesNode.Descendants("horse"))
                        {
                            number = Helper.TryParse<int>(horse.Element("number").Value);
                            var horseDetail = new HorseDetail()
                            {
                                Name = horse.Attribute("name").Value,
                                Number = number
                            };
                            horseDetails.Add(horseDetail);
                        }
                    }
                }

                foreach (var prices in loadElement.Descendants("prices"))
                {
                    foreach (var horse in prices.Descendants("horse"))
                    {
                        price = Helper.TryParse<decimal>(horse.Attribute("Price").Value);
                        number = Helper.TryParse<int>(horse.Attribute("number").Value);
                        var horsePrice = new HorsePrice()
                        {
                            Price = price,
                            Number = number
                        };
                        horsePrices.Add(horsePrice);
                    }
                }

                var horses = new List<Horse>();
                if (horseDetails.Count() > 0 && horsePrices.Count() > 0)
                {
                    foreach (var horse in horseDetails)
                    {
                        var newHorse = new Horse()
                        {
                            Name = horse.Name,
                            Price = horsePrices.FirstOrDefault(x => x.Number == horse.Number).Price
                        };
                        horses.Add(newHorse);
                    }
                }
                return horses;
            }
            catch (Exception ex)
            {
                //Trace log
                return new List<Horse>();
            }           
        }
    }
}
