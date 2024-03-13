using DataAccess.Abstract.EntityFramework;
using Entities.Concrete;
using Entities.Dtos.EntryDto;
using Entities.RequestParameters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Abstract
{
    public interface IEntryDal: IEntityRepository<Entry>
    {
        List<Entry> GetActiveEntries(EntryRequestParameters e);
        List<Entry> GetDetailCategory();
        List<Entry> GetByCategory(EntryRequestParameters e, int? categoryId, string? search);
        int GetActiveEntriesCount();
        List<Entry> GetWantedEntry(string? search, bool? statu);
        List<Entry> GetPassiveEntries();

        List<Entry> GetEntryByDesc();
   
    }
}
