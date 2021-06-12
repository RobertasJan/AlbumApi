using AlbumApi.Domain.Models;
using AlbumApi.Domain.Repository.Albums;
using AlbumApi.Utility.Hateoas;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace AlbumApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AlbumsController : ControllerBase
    {
        private readonly IAlbumRepository _albumRepository;
        private readonly LinkGenerator linkGenerator = new LinkGenerator();

        public AlbumsController(IAlbumRepository albumRepository)
        {
            _albumRepository = albumRepository;
        }


        // GET: api/<AlbumController>
        [HttpGet]
        public async Task<ICollection<Album>> Get(CancellationToken cancellationToken)
        {
            var albums = await _albumRepository.GetAlbums(cancellationToken);
            foreach (var al in albums)
            {
                linkGenerator.GenerateLinksForAlbum(al, HttpContext);
            }
            return albums;
        }

        // GET api/<AlbumController>/5
        [HttpGet("{id}")]
        public async Task<Album> Get(int id, CancellationToken cancellationToken)
        {
            var album = await _albumRepository.GetAlbum(id, cancellationToken);
            linkGenerator.GenerateLinksForAlbum(album, HttpContext);
            foreach (var ph in album.Photos)
            {
                linkGenerator.GenerateLinksForPhoto(ph, HttpContext);
            }
            return album;
        }

        // POST api/<AlbumController>
        [HttpPost]
        public async Task<Album> Post([FromBody] Album album, CancellationToken cancellationToken)
        {
            var albumResp = await _albumRepository.SetAlbum(album, cancellationToken);
            linkGenerator.GenerateLinksForAlbum(albumResp, HttpContext);
            return albumResp;
        }

        // DELETE api/<AlbumController>/5
        [HttpDelete("{id}")]
        public Task Delete(int id, CancellationToken cancellationToken)
        {
            return _albumRepository.DeleteAlbum(id, cancellationToken);
        }

    }
}
