using Microsoft.AspNetCore.Mvc;
using Napster.Domain.AggregatesModel.AlbumAggregate;
using Napster.Domain.AggregatesModel.ArtistAggregate;

namespace Napster.API.Controllers
{
    [Route("api/tracks")]
    [ApiController]
    public class TracksController : ControllerBase
    {
        private readonly IAlbumRepository _albumRepository;
        private readonly IArtistRepository _artistRepository;

        public TracksController(IAlbumRepository albumRepository, IArtistRepository artistRepository)
        {
            _albumRepository = albumRepository;
            _artistRepository = artistRepository;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllTracks()
        {
            var tracks = await _albumRepository.GetAllTracks();
            return Ok(tracks);
        }

        [HttpGet("{trackId}")]
        public async Task<IActionResult> GetTrackById(string trackId)
        {
            var track = await _albumRepository.GetTrackById(trackId);

            if (track is null)
            {
                return NotFound();
            }

            return Ok(track);
        }

        [HttpGet("{trackId}/artist")]
        public async Task<IActionResult> GetArtistByTrackId(string trackId)
        {
            var track = await _albumRepository.GetTrackById(trackId);

            if (track is null)
            {
                return NotFound();
            }
            
            var artist = await _artistRepository.GetArtistById(track.ArtistId);

            if (artist is null)
            {
                return NotFound();
            }

            return Ok(artist);
        }

        [HttpGet("{trackId}/album")]
        public async Task<IActionResult> GetAlbumByTrackId(string trackId)
        {
            var track = await _albumRepository.GetTrackById(trackId);

            if (track is null)
            {
                return NotFound();
            }

            var album = await _albumRepository.GetAlbumById(track.AlbumId);

            if (album is null)
            {
                return NotFound();
            }

            return Ok(album);
        }
    }
}
