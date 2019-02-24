using dotnet_code_challenge.Application;
using dotnet_code_challenge.Infrastructure;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Xml;

namespace dotnet_code_challenge
{
    class Program
    {
        static void Main(string[] args)
        {
            var horseViewModelList = new List<HorseViewModel>();
            var filePath = Path.Combine(Environment.CurrentDirectory, "FeedData");
            string[] files = Directory.GetFiles(filePath);
            foreach (var fileName in files)
            {
                IFileReader fileReader = ReaderFactory.CreateFileReader(fileName);
                var horseService = new HorseService(fileReader);
                var result = horseService.GetHorseNameViewModels(fileName);
                horseViewModelList.AddRange(result.HorseViewModels);
            }

            foreach (var horse in horseViewModelList.OrderBy(x=>x.Price))
            {
                Console.WriteLine($"Horse Name : {horse.Name}");
            }
            Console.ReadLine();
        }
    }
}
