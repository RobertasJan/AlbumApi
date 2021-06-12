using AlbumApi.Domain.Models;
using AlbumApi.Domain.Repository.Photos;
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
    public class PhotosController : ControllerBase
    {
        private readonly IPhotoRepository _photoRepository;
        private readonly LinkGenerator linkGenerator = new LinkGenerator();

        public PhotosController(IPhotoRepository photoRepository)
        {
            _photoRepository = photoRepository;
        }


        // GET: api/<PhotosController>
        [HttpGet]
        public async Task<ICollection<Photo>> Get(CancellationToken cancellationToken)
        {
            var photos = await _photoRepository.GetPhotos(cancellationToken);
            foreach (var ph in photos)
            {
                linkGenerator.GenerateLinksForPhoto(ph, HttpContext);
            }
            return photos;
        }

        // GET api/<PhotosController>/5
        [HttpGet("{id}")]
        public async Task<Photo> Get(int id, CancellationToken cancellationToken)
        {
            var photo = await _photoRepository.GetPhoto(id, cancellationToken);
            linkGenerator.GenerateLinksForPhoto(photo, HttpContext);
            return photo;
        }

        // POST api/<PhotoController>
        [HttpPost]
        public async Task<Photo> Post([FromBody] Photo photo, CancellationToken cancellationToken)
        {
            var photoResp = await _photoRepository.SetPhoto(photo, cancellationToken);
            linkGenerator.GenerateLinksForPhoto(photoResp, HttpContext);
            return photoResp;
        }

        // DELETE api/<PhotoController>/5
        [HttpDelete("{id}")]
        public Task Delete(int id, CancellationToken cancellationToken)
        {
            return _photoRepository.DeletePhoto(id, cancellationToken);
        }
 
    }
}
