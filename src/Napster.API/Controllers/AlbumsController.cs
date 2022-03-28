using Microsoft.AspNetCore.Mvc;
using Napster.Domain.AggregatesModel.AlbumAggregate;
using Napster.Domain.AggregatesModel.ArtistAggregate;
using Napster.Domain.AggregatesModel.GenreAggregate;

namespace Napster.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AlbumsController : ControllerBase
    {
        private readonly IAlbumRepository _albumRepository;
        private readonly IGenreRepository _genreRepository;
        private readonly IArtistRepository _artistRepository;

        public AlbumsController(IAlbumRepository albumRepository, IArtistRepository artistRepository, IGenreRepository genreRepository)
        {
            _albumRepository = albumRepository;
            _genreRepository = genreRepository;
            _artistRepository = artistRepository;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllAlbums()
        {
            var albums = await _albumRepository.GetAllAlbums();
            return Ok(albums);
        }

        [HttpGet("{albumId}")]
        public async Task<IActionResult> GetAlbumById(string albumId)
        {
            var album = await _albumRepository.GetAlbumById(albumId);

            if (album is null)
            {
                return NotFound();
            }


            return Ok(album);
        }

        [HttpGet("{albumId}/genres")]
        public async Task<IActionResult> GetGenresByAlbumId(string albumId)
        {
            var album = await _albumRepository.GetAlbumById(albumId);

            if (album is null)
            {
                return NotFound();
            }

            var genres = await _genreRepository.GetGenreByIds(album.GenreIds);

            return Ok(genres);
        }

        [HttpGet("{albumId}/artist")]
        public async Task<IActionResult> GetArtistByAlbumId(string albumId)
        {
            var album = await _albumRepository.GetAlbumById(albumId);

            if (album is null)
            {
                return NotFound();
            }

            var artist = await _artistRepository.GetArtistById(album.ArtistId);

            if (artist is null)
            {
                return NotFound();
            }

            return Ok(artist);
        }

        [HttpGet("{albumId}/tracks")]
        public async Task<IActionResult> GetTracksByAlbumId(string albumId)
        {
            var album = await _albumRepository.GetAlbumById(albumId);

            if (album is null)
            {
                return NotFound();
            }


            return Ok(album.Tracks);
        }
    }
}
