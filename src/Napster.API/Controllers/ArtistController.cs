using Microsoft.AspNetCore.Mvc;
using Napster.Domain.AggregatesModel.ArtistAggregate;

namespace Napster.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ArtistController : ControllerBase
    {
        private readonly IArtistRepository _genreRepository;

        public ArtistController(IArtistRepository genreRepository)
        {
            _genreRepository = genreRepository;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllArtists()
        {
            var genres = await _genreRepository.GetAllArtists();
            return Ok(genres);
        }
    }
}
