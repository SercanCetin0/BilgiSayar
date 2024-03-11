using Entities.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Concrete
{
    public class Entry:IEntity
    {
        public int? ContentId { get; set; }
        public int? CategoryId { get; set; }
        public int? WriterId { get; set; }
        public string? Title { get; set; }
        public string? Text { get; set; }
        public DateTime? ReleaseDate { get; set; }
        public string? İmage { get; set; }
        public bool? Statu {  get; set; }
        public Category? Category { get; set; }

    }
}
