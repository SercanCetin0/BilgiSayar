using Entities.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Concrete
{
    public class Comment:IEntity
    {
        public int? CommentId { get; set; }
        public int? EntryId { get; set; }
        public int? WriterId { get; set; }
        public string? CommentContent { get; set; }
        public DateTime? CommentReleaseDate { get; set; }
        public bool? CommentStatus { get; set; }
    }
}
