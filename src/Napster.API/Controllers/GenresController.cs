using Microsoft.AspNetCore.Mvc;
using Napster.Domain.AggregatesModel.GenreAggregate;

namespace Napster.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GenresController : ControllerBase
    {
        private readonly IGenreRepository _genreRepository;
        public GenresController(IGenreRepository genreRepository)
        {
            _genreRepository = genreRepository;
        }

        [HttpGet(Name = "GetGenres")]
        public async Task<IActionResult> GetAllGenres()
        {
            var genres = await _genreRepository.GetAllGenres();

            return Ok(genres);
        }
    }
}
