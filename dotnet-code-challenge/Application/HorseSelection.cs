using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace dotnet_code_challenge.Application
{
    public class HorseSelection
    {
        public string Id { get; set; }
        public decimal Price { get; set; }
        public Tags Tags { get; set; }
    }

    public class Tags
    {
        [JsonProperty("participant")]
        public int Participant { get; set; }
        [JsonProperty("name")]
        public string Name { get; set; }
    }
}
