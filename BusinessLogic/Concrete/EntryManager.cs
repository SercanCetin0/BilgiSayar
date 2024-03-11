using BusinessLogic.Abstract;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.RequestParameters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic.Concrete
{
    public class EntryManager : IEntryService
    {
        private readonly IEntryDal _entryDal;

        public EntryManager(IEntryDal entryDal)
        {
            _entryDal = entryDal;
        }

        public void Add(Entry entry)
        {
            _entryDal.Add(entry);
        }

        public void Delete(Entry entry)
        {
            _entryDal.Delete(entry);
        }

        public Entry Get(int id)
        {
            return _entryDal.Get(x => x.ContentId.Equals(id));
        }

        public List<Entry> GetActiveEntries(EntryRequestParameters e)
        {
            return _entryDal.GetActiveEntries(e);
        }

        public int GetActiveEntriesCount()
        {
            return _entryDal.GetActiveEntriesCount();
        }

        public List<Entry> GetAll()
        {
            return _entryDal.GetAll();  
        }

        public List<Entry> GetByCategory(EntryRequestParameters e, int? categoryId, string? search)
        {
           return _entryDal.GetByCategory( e, categoryId,search);
        }

        public List<Entry> GetDetailCategory()
        {
            return _entryDal.GetDetailCategory();
        }

        public List<Entry> GetEntryByDesc()
        {
            return _entryDal.GetEntryByDesc();
        }

        public List<Entry> GetWantedEntry(string? search, bool? statu)
        {
           return _entryDal.GetWantedEntry(search, statu );
        }

        public void Update(Entry entry)
        {
            _entryDal.Update(entry);
        }
    }
}
