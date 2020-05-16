using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;

namespace MovieAPICore.Controllers
{
    [ApiController]
    [Route("api/movie")]
    public class MovieController : ControllerBase
    {
        private readonly Services.Movie _srvMovie;
        private readonly IConfiguration _configuration;

        public MovieController(IConfiguration configuration)
        {
            _configuration = configuration;
            _srvMovie = new Services.Movie(_configuration);
        }

        [HttpGet("upcoming/{page:int}")]
        public async Task<IActionResult> GetUpcoming(int page)
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