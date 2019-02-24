using System;
using System.Collections.Generic;
using System.Text;

namespace dotnet_code_challenge.Application
{
     public interface IFileReader
    {
        IEnumerable<Horse> GetHorse(string fileName);
    }
}
