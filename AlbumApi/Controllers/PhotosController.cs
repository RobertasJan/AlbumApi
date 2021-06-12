using AlbumApi.Domain.Models;
using AlbumApi.Domain.Repository.Photos;
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
    public class PhotosController : ControllerBase
    {
        private readonly IPhotoRepository _photoRepository;

        public PhotosController(IPhotoRepository photoRepository)
        {
            _photoRepository = photoRepository;
        }


        // GET: api/<PhotosController>
        [HttpGet]
        public Task<ICollection<Photo>> Get(CancellationToken cancellationToken)
        {
            return _photoRepository.GetPhotos(cancellationToken);
        }

        // GET api/<PhotosController>/5
        [HttpGet("{id}")]
        public Task<Photo> Get(int id, CancellationToken cancellationToken)
        {
            return _photoRepository.GetPhoto(id, cancellationToken);
        }

        // POST api/<PhotoController>
        [HttpPost]
        public Task<Photo> Post([FromBody] Photo photo, CancellationToken cancellationToken)
        {
            return _photoRepository.SetPhoto(photo, cancellationToken);
        }

        // DELETE api/<PhotoController>/5
        [HttpDelete("{id}")]
        public Task Delete(int id, CancellationToken cancellationToken)
        {
            return _photoRepository.DeletePhoto(id, cancellationToken);
        }
    }
}
