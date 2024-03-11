using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.RequestParameters
{
    public class EntryRequestParameters
    {
        public List<Entry> Entries { get; set; }
        public int PageNumber { get; set; }
        public int PageSize { get; set; }

        public EntryRequestParameters() : this(1, 8)
        {

        }
        public EntryRequestParameters(int pageNumber = 1, int pageSize = 8)
        {
            PageNumber = pageNumber;
            PageSize = pageSize;
        }
    }
}
