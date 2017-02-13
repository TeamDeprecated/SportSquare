using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SportSquare.Services
{

    // test class for future use!
    class GoogleLocationModel
    {
        [JsonProperty("results")]
        public Results[] Results { get; set; }

        [JsonProperty("status")]
        public string Status { get; set; }

    }
    public class Results
    {
       
    }
    public class AddressComponents
    {
        [JsonProperty("long_name")]
        public string LongName { get; set; }

        [JsonProperty("short_name")]
        public string ShortName { get; set; }

        [JsonProperty("types")]
        public string Types { get; set; }
    }
    public class SubResults
    {
        [JsonProperty("address_components")]
        public AddressComponents[] Components { get; set; }

        [JsonProperty("formatted_address")]
        public string Address { get; set; }

        [JsonProperty("geometry")]
        public string Geometry { get; set; }

        [JsonProperty("place_id")]
        public string PlaceId { get; set; }

        [JsonProperty("types")]
        public string Types { get; set; }

    }
}
