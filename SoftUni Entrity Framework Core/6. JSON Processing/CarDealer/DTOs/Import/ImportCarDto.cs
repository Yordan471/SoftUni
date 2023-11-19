using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace CarDealer.DTOs.Import
{
    public class ImportCarDto
    {
        public ImportCarDto() 
        {
            PartsId = new HashSet<int>();
        }
        [JsonProperty("make")]
        public string Make { get; set; } = null!;

        [JsonProperty("model")]
        public string Model { get; set; } = null!;

        public long TravelledDistance { get; set; }

        public ICollection<int> PartsId { get; set; }
    }
}
