using Newtonsoft.Json;
using System;

namespace WetControllerClient.Models
{
    public class WetControllerModel
    {
        [JsonProperty("id")]
        public Guid? Id { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("reportIntervalSeconds")]
        public double ReportIntervalSeconds { get; set; }

        [JsonProperty("bottomWetEdge")]
        public double BottomWetEdge { get; set; }

        [JsonProperty("upperWetEdge")]
        public double UpperWetEdge { get; set; }
    }
}