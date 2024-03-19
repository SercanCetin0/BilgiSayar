using BusinessLogic.Abstract;
using BusinessLogic.ValidationRules.FluentValidation;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.RequestParameters;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace BusinessLogic.Concrete
{
    public class EntryManager : IEntryService
    {
        private readonly IEntryDal _entryDal;
        private readonly IValidator<Entry> _validator;
        public EntryManager(IEntryDal entryDal, IValidator<Entry> validator)
        {
            _entryDal = entryDal;
            _validator = validator;
        }

        public void Add(Entry entry)
        {

            if (_validator.Validate(entry).IsValid)
            {
                _entryDal.Add(entry);
            }
            
            
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

        public List<Entry> GetPassiveEntries()
        {
            return _entryDal.GetPassiveEntries();
        }

        public List<Entry> GetWantedEntry(string? search, bool? statu)
        {

            if (!string.IsNullOrEmpty(search))
            {
                return _entryDal.GetWantedEntry(search, statu);
                
            }

            if (statu == false)
            {
                return _entryDal.GetWantedEntry(search, statu);
               
            }
            return _entryDal.GetEntryByDesc();
        }

        public void Update(Entry entry)
        {
            if (entry.Statu == true)
            {
                entry.Statu = false;
            }
            else
            {
                entry.Statu = true;
            }
            _entryDal.Update(entry);
        }
    }
}
