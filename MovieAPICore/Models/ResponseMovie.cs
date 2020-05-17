using Newtonsoft.Json;
using System.Collections.Generic;

namespace MovieAPICore.Models
{
    public class ResponseMovie
    {
        [JsonProperty("Results")]
        public List<Movie> Movies { get; set; }
        public int Page { get; set; }
        [JsonProperty("Total_results")]
        public int TotalResults { get; set; }
        [JsonProperty("Total_pages")]
        public int TotalPages { get; set; }
    }


}
