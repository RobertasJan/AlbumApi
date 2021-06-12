using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlbumApi.Domain.Models
{
    public class Photo
    {
        public int? Id { get; set; }
        public string Name { get; set; }
        public string Extension { get; set; }
        public long Size { get; set; }
        public Album Album { get; set; }
        public int AlbumId { get; set; }

        [NotMapped]
        public List<Link> Links { get; set; } = new List<Link>();
    }
}
