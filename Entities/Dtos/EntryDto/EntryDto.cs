using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Dtos.EntryDto
{
    public class EntryDto:Entry
    {
     
        public Entry? Entry { get; set; }
       public List<Category>? Categories { get; set; }

        public Writer? Writer { get; set; }

    }
}
