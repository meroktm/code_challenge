using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace dotnet_code_challenge.Application
{
    public class HorseService
    {
        private readonly IFileReader _fileReader;

        public HorseService(IFileReader fileReader)
        {
            _fileReader = fileReader;
        }

        public HorseInformationResponse GetHorseNameViewModels(string fileName)
        {
            var horses = _fileReader.GetHorse(fileName);

            return new HorseInformationResponse()
            {
                HorseViewModels = horses.Select(x => new HorseViewModel { Name = x.Name, Price = x.Price }).ToList()
            };
        }
    }
}
