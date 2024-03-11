using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Extensions
{
    public static class ToPaginate
    {
        public static List<Entry> ToPaginates(this List<Entry> entries,
           int pageNumber, int pageSize)
        {
            return entries
                .Skip(((pageNumber - 1) * pageSize))
                .Take(pageSize).ToList();
        }

    }
}
