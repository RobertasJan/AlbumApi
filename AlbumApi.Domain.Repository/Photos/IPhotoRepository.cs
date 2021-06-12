using AlbumApi.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace AlbumApi.Domain.Repository.Photos
{
    public interface IPhotoRepository
    {
        public Task<ICollection<Photo>> GetPhotos(CancellationToken cancellationToken);
        public Task<Photo> GetPhoto(int id, CancellationToken cancellationToken);
        public Task<Photo> SetPhoto(Photo photo, CancellationToken cancellationToken);
        public Task DeletePhoto(int id, CancellationToken cancellationToken);
    }
}
