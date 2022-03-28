using Microsoft.AspNetCore.Mvc;
using Napster.Domain.AggregatesModel.AlbumAggregate;
using Napster.Domain.AggregatesModel.ArtistAggregate;
using Napster.Domain.AggregatesModel.GenreAggregate;

namespace Napster.API.Controllers
{
    [Route("api/artists")]
    [ApiController]
    public class ArtistsController : ControllerBase
    {
        private readonly IArtistRepository _artistRepository;
        private readonly IAlbumRepository _albumRepository;
        private readonly IGenreRepository _genreRepository;

        public ArtistsController(IArtistRepository artistRepository, IAlbumRepository albumRepository, IGenreRepository genreRepository)
        {
            _artistRepository = artistRepository;
            _albumRepository = albumRepository;
            _genreRepository = genreRepository;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllArtists()
        {
            var artists = await _artistRepository.GetAllArtists();
            return Ok(artists);
        }

        [HttpGet("{artistId}")]
        public async Task<IActionResult> GetArtistById(string artistId)
        {
            var artist = await _artistRepository.GetArtistById(artistId);

            if (artist is null)
            {
                return NotFound();
            }

            return Ok(artist);
        }

        [HttpGet("{artistId}/albums")]
        public async Task<IActionResult> GetAlbumsByArtistId(string artistId)
        {
            var albums = await _albumRepository.GetAlbumsByArtistId(artistId);

            if (albums.Count() == 0)
            {
                return NotFound();
            }

            return Ok(albums);
        }

        [HttpGet("{artistId}/tracks")]
        public async Task<IActionResult> GetTracksByArtistId(string artistId)
        {
            var tracks = await _albumRepository.GetTrackByArtistId(artistId);

            if (tracks.Count() == 0)
            {
                return NotFound();
            }

            return Ok(tracks);
        }

        [HttpGet("{artistId}/genres")]
        public async Task<IActionResult> GetGenresByArtistId(string artistId)
        {
            var artist = await _artistRepository.GetArtistById(artistId);

            if (artist is null)
            {
                return NotFound();
            }

            var genres = await _genreRepository.GetGenreByIds(artist.GenreIds);

            return Ok(genres);
        }
    }
}
