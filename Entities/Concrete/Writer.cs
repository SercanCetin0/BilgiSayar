using Entities.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Concrete
{
    public class Writer:IEntity
    {
        public int? WriterId { get; set; }
        public string? WriterFirstName { get; set; }
        public string? WriterLastName { get; set; }
        public string? WriterNickname { get; set; }
        public string? WriterEmail { get; set; }
        public string? WriterBio { get; set; }
        public string? WriterImage { get; set; }

        public bool? WriterStatu {  get; set; }
    }
}
