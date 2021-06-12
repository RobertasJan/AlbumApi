using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlbumApi.Domain.Models
{
    public class Album
    {
        public int? Id { get; set; }
        public string Name { get; set; }
        public int OwnerId { get; set; }
        public DateTime DateCreated { get; set; }
        public DateTime DateModified { get; set; }
        public bool IsPublic { get; set; }
        public string Path { get; set; }
        public int Total { get; set; }
        public string PhotoGroup { get; set; }
        public ICollection<Photo> Photos { get; set; }
        [NotMapped]
        public List<Link> Links { get; set; } = new List<Link>();
    }
}
