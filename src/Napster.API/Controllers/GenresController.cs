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

        [HttpGet]
        public async Task<IActionResult> GetAllGenres()
        {
            var genres = await _genreRepository.GetAllGenres();
            return Ok(genres);
        }

        [HttpGet("{genreId}")]
        public async Task<IActionResult> GetGenreById(string genreId)
        {
            var genre = await _genreRepository.GetGenreById(genreId);

            if (genre is null)
            {
                return NotFound();
            }

            return Ok(genre);
        }

        [HttpGet("{parentId}/sub-genre")]
        public async Task<IActionResult> GetGenresByParentId(string parentId)
        {
            var genres = await _genreRepository.GetGenresByParentGenreId(parentId);
            return Ok(genres);
        }
    }
}
