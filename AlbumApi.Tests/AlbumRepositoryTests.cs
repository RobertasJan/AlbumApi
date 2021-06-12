using AlbumApi.Infrastructure.Repository.Albums;
using System;
using System.Threading;
using System.Threading.Tasks;
using Xunit;

namespace AlbumApi.Tests
{
    public class AlbumRepositoryTests
    {
        string connectionString = "Data Source=(LocalDB)\\MSSQLLocalDB;Initial Catalog=Albums;Integrated Security=True";
   
        [Fact]
        public async Task AlbumSave_Succeed()
        {
            var albumRepository = new AlbumRepository(new Infrastructure.AlbumDbContext(connectionString));
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
            var album2 = await albumRepository.GetAlbum(albumId, CancellationToken.None);

            Assert.Equal(album2.Name, "TestAlbum");

            albumRepository.DeleteAlbum(albumId, CancellationToken.None);
        }
    }
}
