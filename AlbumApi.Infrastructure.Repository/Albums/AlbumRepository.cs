using AlbumApi.Domain.Models;
using AlbumApi.Domain.Repository.Albums;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace AlbumApi.Infrastructure.Repository.Albums
{
    public class AlbumRepository : IAlbumRepository
    {
        private readonly AlbumDbContext _db;

        public AlbumRepository(AlbumDbContext dbContext)
        {
            _db = dbContext;
        }
        public async Task DeleteAlbum(int id, CancellationToken cancellationToken)
        {
            var entity = await _db.Albums.FirstOrDefaultAsync(x => x.Id == id, cancellationToken);
            if (entity == null)
            {
                throw new Exception("Album not found");
            }
            _db.Albums.Remove(entity);
            await _db.SaveChangesAsync(cancellationToken);
        }

        public async Task<Album> GetAlbum(int id, CancellationToken cancellationToken)
        {
            var entity = await _db.Albums.Include(x => x.Photos).FirstOrDefaultAsync(x => x.Id == id, cancellationToken);
            if (entity == null)
            {
                throw new Exception("Album not found");
            }
            return entity;
        }

        public async Task<ICollection<Album>> GetAlbums(CancellationToken cancellationToken)
        {
            return await _db.Albums.ToListAsync(cancellationToken);
        }

        public async Task<Album> SetAlbum(Album album, CancellationToken cancellationToken)
        {
            if (album == null)
            {
                throw new NullReferenceException("Album is empty model");
            }
            var entity = new Album();
            if (album.Id == null)
            {
                entity = album;
                _db.Albums.Add(entity);
            } else
            {
                entity = await _db.Albums.FirstOrDefaultAsync(x => x.Id == album.Id, cancellationToken);
                if (entity == null)
                {
                    throw new Exception("Album not found");
                }
                entity = album;
            }
            await _db.SaveChangesAsync(cancellationToken);
            return entity;
        }
    }
}
