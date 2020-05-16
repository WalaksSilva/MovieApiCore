using Microsoft.Extensions.Caching.Memory;
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
        private IMemoryCache _cache;
        private static string _baseUrl;
        private static string _key;
        private static string _language;

        public Movie(IConfiguration configuration, IMemoryCache memoryCache)
        {
            _configuration = configuration;
            _cache = memoryCache;
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
            var responseMovie = JsonConvert.DeserializeObject<Models.ResponseMovie>(contents);
            var responseGenre = await GetGenres();

            var data = new ViewModels.DataViewModel
            {
                Page = responseMovie.Page,
                TotalPages = responseMovie.Total_pages,
                TotalResults = responseMovie.Total_results,
                Total = responseMovie.Results.Count,
                Movies = responseMovie.Results.Select(x => new ViewModels.MovieViewModel
                {
                    title = x.Title,
                    ReleaseDate = x.Release_date,
                    Genre = responseGenre.genres.Where(g => x.Genre_ids.Contains(g.Id)).Select(gn => gn.Name).ToList()
                }).ToList()
            };

            return data;
        }

        public async Task<Models.ResponseGenre> GetGenres()
        {
            
            var generes = new Models.ResponseGenre();


            if (!_cache.TryGetValue("_Generes", out generes))
            {

                string action = $"genre/movie/list?api_key={_key}&language={_language}";

                HttpRequestMessage request = new HttpRequestMessage(HttpMethod.Get, _baseUrl + action);

                HttpResponseMessage response = await HttpInstance.GetHttpClientInstance().SendAsync(request);

                var contents = await response.Content.ReadAsStringAsync();
                generes = JsonConvert.DeserializeObject<Models.ResponseGenre>(contents);

                _cache.Set("_Generes", generes, new MemoryCacheEntryOptions()
                {
                    AbsoluteExpiration = DateTime.Now.AddMinutes(2)
                });
            }

            return generes;
        }
    }
}
