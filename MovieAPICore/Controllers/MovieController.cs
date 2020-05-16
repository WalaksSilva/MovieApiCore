using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Memory;
using Microsoft.Extensions.Configuration;

namespace MovieAPICore.Controllers
{
    [ApiController]
    [Route("api/movie")]
    public class MovieController : ControllerBase
    {
        private readonly Services.Movie _srvMovie;
        private readonly IConfiguration _configuration;
        private IMemoryCache _cache;

        public MovieController(IConfiguration configuration, IMemoryCache memoryCache)
        {
            _configuration = configuration;
            _cache = memoryCache;
            _srvMovie = new Services.Movie(_configuration, _cache);
        }

        [HttpGet("upcoming")]
        public async Task<IActionResult> GetUpcoming(int page = 1)
        {
            try
            {
                var data = await _srvMovie.GetMovieUpcoming(page);

                return Ok(data);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}