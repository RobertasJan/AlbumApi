using AlbumApi.Domain.Models;
using AlbumApi.Domain.Repository.Albums;
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

        public AlbumsController(IAlbumRepository albumRepository)
        {
            _albumRepository = albumRepository;
        }


        // GET: api/<AlbumController>
        [HttpGet]
        public Task<ICollection<Album>> Get(CancellationToken cancellationToken)
        {
            return _albumRepository.GetAlbums(cancellationToken);
        }

        // GET api/<AlbumController>/5
        [HttpGet("{id}")]
        public Task<Album> Get(int id, CancellationToken cancellationToken)
        {
            return _albumRepository.GetAlbum(id, cancellationToken);
        }

        // POST api/<AlbumController>
        [HttpPost]
        public Task<Album> Post([FromBody] Album album, CancellationToken cancellationToken)
        {
            return _albumRepository.SetAlbum(album, cancellationToken);
        }

        // DELETE api/<AlbumController>/5
        [HttpDelete("{id}")]
        public Task Delete(int id, CancellationToken cancellationToken)
        {
            return _albumRepository.DeleteAlbum(id, cancellationToken);
        }
    }
}
