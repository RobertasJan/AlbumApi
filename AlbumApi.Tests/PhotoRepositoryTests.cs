using AlbumApi.Infrastructure.Repository.Albums;
using AlbumApi.Infrastructure.Repository.Photos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Xunit;

namespace AlbumApi.Tests
{
    public class PhotoRepositoryTests
    {
        string connectionString = "Data Source=(LocalDB)\\MSSQLLocalDB;Initial Catalog=Albums;Integrated Security=True";

        [Fact]
        public async Task PhotoSave_Succeed()
        {
            var photoRepository = new PhotoRepository(new Infrastructure.AlbumDbContext(connectionString));
            var albumRepository = new AlbumRepository(new Infrastructure.AlbumDbContext(connectionString));

            var albumId = await SaveAlbum(albumRepository);
            var photo = await photoRepository.SetPhoto(new Domain.Models.Photo() {
                Size = 123,
                Name = "abc",
                Extension = "jpg",
                AlbumId = albumId
            }, CancellationToken.None);
            var photoId = photo.Id.Value;
            var photo2 = await photoRepository.GetPhoto(photoId, CancellationToken.None);

            Assert.Equal(photo2.Name, "abc");

            photoRepository.DeletePhoto(photoId, CancellationToken.None);
            albumRepository.DeleteAlbum(albumId, CancellationToken.None);
        }

        private async Task<int> SaveAlbum(AlbumRepository albumRepository)
        {
            var album = await albumRepository.SetAlbum(new Domain.Models.Album()
            {
                Name = "TestAlbum",
                DateCreated = DateTime.Now,
                DateModified = DateTime.Now,
                IsPublic = false,
                Total = 0,
                OwnerId = 0,
                Path = "testpath",
                PhotoGroup = "test photo group"
            }, CancellationToken.None);
            var albumId = album.Id.Value;
            return albumId;
        }
    }
}
