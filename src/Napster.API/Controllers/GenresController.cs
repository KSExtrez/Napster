using Microsoft.AspNetCore.Mvc;
using Napster.Domain.AggregatesModel.AlbumAggregate;
using Napster.Domain.AggregatesModel.ArtistAggregate;
using Napster.Domain.AggregatesModel.GenreAggregate;

namespace Napster.API.Controllers
{
    [Route("api/genres")]
    [ApiController]
    public class GenresController : ControllerBase
    {
        private readonly IGenreRepository _genreRepository;
        private readonly IArtistRepository _artistRepository;
        private readonly IAlbumRepository _albumRepository;

        public GenresController(IGenreRepository genreRepository, IArtistRepository artistRepository, IAlbumRepository albumRepository)
        {
            _genreRepository = genreRepository;
            _artistRepository = artistRepository;
            _albumRepository = albumRepository;
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

        [HttpGet("{genreId}/sub-genres")]
        public async Task<IActionResult> GetGenresByParentId(string genreId)
        {
            var genres = await _genreRepository.GetGenresByParentGenreId(genreId);

            if (genres.Count() == 0)
            {
                return NotFound();
            }

            return Ok(genres);
        }

        [HttpGet("{genreId}/artists")]
        public async Task<IActionResult> GetArtistsByParentId(string genreId)
        {
            var artists = await _artistRepository.GetArtistsByGenreId(genreId);

            if (artists.Count() == 0)
            {
                return NotFound();
            }

            return Ok(artists);
        }

        [HttpGet("{genreId}/albums")]
        public async Task<IActionResult> GetAlbumsByParentId(string genreId)
        {
            var albums = await _albumRepository.GetAlbumsByGenreId(genreId);

            if (albums.Count() == 0)
            {
                return NotFound();
            }

            return Ok(albums);
        }
    }
}
