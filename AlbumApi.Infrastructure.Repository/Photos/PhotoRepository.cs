using AlbumApi.Domain.Models;
using AlbumApi.Domain.Repository.Photos;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace AlbumApi.Infrastructure.Repository.Photos
{
    public class PhotoRepository : IPhotoRepository
    {
        private readonly AlbumDbContext _db;

        public PhotoRepository(AlbumDbContext dbContext)
        {
            _db = dbContext;
        }
        public async Task DeletePhoto(int id, CancellationToken cancellationToken)
        {
            var entity = await _db.Photos.FirstOrDefaultAsync(x => x.Id == id, cancellationToken);
            if (entity == null)
            {
                throw new Exception("Photo not found");
            }
            _db.Photos.Remove(entity);
        }

        public async Task<Photo> GetPhoto(int id, CancellationToken cancellationToken)
        {
            var entity = await _db.Photos.FirstOrDefaultAsync(x => x.Id == id, cancellationToken);
            if (entity == null)
            {
                throw new Exception("Photo not found");
            }
            return entity;
        }

        public async Task<ICollection<Photo>> GetPhotos(CancellationToken cancellationToken)
        {
            return await _db.Photos.ToListAsync(cancellationToken);
        }

        public async Task<Photo> SetPhoto(Photo photo, CancellationToken cancellationToken)
        {
            if (photo == null)
            {
                throw new NullReferenceException("Photo is empty model");
            }
            var entity = new Photo();
            if (photo.Id == null)
            {
                entity = photo;
                _db.Photos.Add(entity);
            }
            else
            {
                entity = await _db.Photos.FirstOrDefaultAsync(x => x.Id == photo.Id, cancellationToken);
                if (entity == null)
                {
                    throw new Exception("Photo not found");
                }
                entity = photo;
            }
            await _db.SaveChangesAsync(cancellationToken);
            return entity;
        }
    }
}
