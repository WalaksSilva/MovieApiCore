using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MovieAPICore.ViewModels
{
    public class DataViewModel
    {
        public List<MovieViewModel> Movies { get; set; }
        public int Page { get; set; }
        public int TotalResults { get; set; }
        public int TotalPages { get; set; }
        public int Total { get; set; }
    }
}
