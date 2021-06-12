using AlbumApi.Domain.Models;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AlbumApi.Utility.Hateoas
{
    public class LinkGenerator
    {
        public void GenerateLinksForPhoto(Photo photo, HttpContext httpContext)
        {
            photo.Links.Add(new Link(httpContext.Request.Host.Value + "/api/Photos/" + photo.Id, "self", "GET"));
            photo.Links.Add(new Link(httpContext.Request.Host.Value + "/api/Photos", "update", "POST"));
            photo.Links.Add(new Link(httpContext.Request.Host.Value + "/api/Photos/" + photo.Id, "delete", "DELETE"));
        }
        public void GenerateLinksForAlbum(Album album, HttpContext httpContext)
        {
            album.Links.Add(new Link(httpContext.Request.Host.Value + "/api/Albums/" + album.Id, "self", "GET"));
            album.Links.Add(new Link(httpContext.Request.Host.Value + "/api/Albums", "update", "POST"));
            album.Links.Add(new Link(httpContext.Request.Host.Value + "/api/Albums/" + album.Id, "delete", "DELETE"));
        }
    }
}
