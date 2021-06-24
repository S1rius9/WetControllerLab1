using Newtonsoft.Json;
using System;

namespace WetControllerClient.Models
{
    public class CreateWetReportModel
    {
        [JsonProperty("controllerId")]
        public Guid ControllerId { get; set; }

        [JsonProperty("wetPercent")]
        public double WetPercent { get; set; }
    }
}
