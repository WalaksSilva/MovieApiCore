using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MovieAPICore.Services
{
    public interface IMovieService
    {
        Task<ViewModels.DataViewModel> GetMovieUpcoming(int page);
    }
}
