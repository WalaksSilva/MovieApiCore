using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MovieAPICore.Models
{
    public class ResponseMovie
    {
        public List<Movie> Results { get; set; }
        public int Page { get; set; }
        public int Total_results { get; set; }
        public int Total_pages { get; set; }
    }


}
