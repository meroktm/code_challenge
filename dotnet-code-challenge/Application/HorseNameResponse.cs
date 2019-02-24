using System;
using System.Collections.Generic;
using System.Text;

namespace dotnet_code_challenge.Application
{
    public class HorseInformationResponse
    {
        public IEnumerable<HorseViewModel> HorseViewModels { get; set; }
    }
}
