using System.Collections.Generic;
using Newtonsoft.Json;

namespace TTSSApi.Web.Models.Vendor
{
    internal class GeoStops
    {
        [JsonProperty("stops")]
        public List<GeoStop> Stops { get; set; }
    }
}