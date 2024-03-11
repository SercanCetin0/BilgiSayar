using Entities.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Concrete
{
    public class ContentImage:IEntity
    {
        public int? ImageId { get; set; }
        public int? EntryId { get; set; }
        public string? Image { get; set; }


    }
}
