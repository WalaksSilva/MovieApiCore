using Newtonsoft.Json;
using System.Collections.Generic;

namespace MovieAPICore.Models
{
    public class Movie
    {
        public string Title { get; set; }
        [JsonProperty("Release_date")]
        public string ReleaseDate { get; set; }
        [JsonProperty("Genre_ids")]
        public List<int> GenreIds { get; set; }
    }
}
