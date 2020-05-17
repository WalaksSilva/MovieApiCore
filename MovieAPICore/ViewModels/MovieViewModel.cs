using System.Collections.Generic;

namespace MovieAPICore.ViewModels
{
    public class MovieViewModel
    {
        public string Title { get; set; }
        public List<string> Genre { get; set; }
        public string ReleaseDate { get; set; }
    }
}
