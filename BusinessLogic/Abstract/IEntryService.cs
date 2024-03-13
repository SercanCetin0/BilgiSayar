using Entities.Concrete;
using Entities.RequestParameters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic.Abstract
{
    public interface IEntryService
    {

        List<Entry> GetAll();
        public List<Entry> GetEntryByDesc();
        List<Entry> GetByCategory(EntryRequestParameters e, int? categoryId,string? search);
        List<Entry> GetActiveEntries(EntryRequestParameters e);
        List<Entry> GetDetailCategory();
        Entry Get(int id);

        List<Entry> GetWantedEntry(string? search, bool? statu);
        List<Entry> GetPassiveEntries();
        int GetActiveEntriesCount();

        void Add(Entry entry);
        void Update(Entry entry);
        void Delete(Entry entry);
    }
}
