using AlbumApi.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace AlbumApi.Domain.Repository.Albums
{
    public interface IAlbumRepository
    {
        public Task<ICollection<Album>> GetAlbums(CancellationToken cancellationToken);
        public Task<Album> GetAlbum(int id, CancellationToken cancellationToken);
        public Task<Album> SetAlbum(Album album, CancellationToken cancellationToken);
        public Task DeleteAlbum(int id, CancellationToken cancellationToken);
    }
}
