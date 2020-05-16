using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;

namespace MovieAPICore.Services
{
    public class Movie
    {
        private readonly IConfiguration _configuration;
        private static string _baseUrl;
        private static string _key;
        private static string _language;

        public Movie(IConfiguration configuration)
        {
            _configuration = configuration;
            _baseUrl = _configuration.GetSection("AppSettings").GetSection("TheMovie.Url").Value;
            _key = _configuration.GetSection("AppSettings").GetSection("TheMovie.Key").Value;
            _language = _configuration.GetSection("AppSettings").GetSection("TheMovie.Language").Value;
        }

        public async Task<ViewModels.DataViewModel> GetMovieUpcoming(int page)
        {
            string action = $"movie/upcoming?api_key={_key}&language={_language}&page={page}";

            HttpRequestMessage request = new HttpRequestMessage(HttpMethod.Get, _baseUrl + action);

            HttpResponseMessage response = await HttpInstance.GetHttpClientInstance().SendAsync(request);


            var contents = await response.Content.ReadAsStringAsync();
            var results = JsonConvert.DeserializeObject<Models.Response>(contents);

            var data = new ViewModels.DataViewModel
            {
                Page = results.Page,
                TotalPages = results.Total_pages,
                TotalResults = results.Total_results,
                Movies = results.Results.Select(x => new ViewModels.MovieViewModel
                {
                    title = x.Title,
                    ReleaseDate = x.Release_date
                }).ToList()
            };

            return data;
        }

        public async Task<List<Models.Genre>> GetGenres()
        {
            string action = $"/genre/movie/list?api_key={_key}&language={_language}";

            HttpRequestMessage request = new HttpRequestMessage(HttpMethod.Get, _baseUrl + action);

            HttpResponseMessage response = await HttpInstance.GetHttpClientInstance().SendAsync(request);

            var generes = new List<Models.Genre>();

            var contents = await response.Content.ReadAsStringAsync();
            generes = JsonConvert.DeserializeObject<List<Models.Genre>>(contents);

            return generes;
        }
    }
}
