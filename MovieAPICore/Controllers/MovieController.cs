using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Memory;
using Microsoft.Extensions.Configuration;
using MovieAPICore.Services;
using System;
using System.Threading.Tasks;

namespace MovieAPICore.Controllers
{
    [ApiController]
    [Route("api/movie")]
    public class MovieController : ControllerBase
    {
        private readonly IMovieService _movieService;

        public MovieController(IMovieService movieService)
        {
            _movieService = movieService;
        }

        [HttpGet("upcoming")]
        public async Task<IActionResult> GetUpcoming(int page = 1)
        {
            try
            {
                var data = await _movieService.GetMovieUpcoming(page);

                return Ok(data);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}