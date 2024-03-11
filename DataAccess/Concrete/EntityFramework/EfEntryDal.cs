using DataAccess.Abstract;
using DataAccess.Abstract.EntityFramework;
using DataAccess.Contexts;

using Entities.Concrete;
using DataAccess.Extensions;
using Microsoft.EntityFrameworkCore;
using Microsoft.Identity.Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using Entities.RequestParameters;
using Entities.Dtos.EntryDto;
using System.Collections;

namespace DataAccess.Concrete.EntityFramework
{

    public class EfEntryDal : EntityRepositoryBase<Entry>, IEntryDal
    {
        private readonly BilgiSayarDbContext _context;
 
        public EfEntryDal(BilgiSayarDbContext context) : base(context)
        {
            _context = context;
        }

       

        public List<Entry> GetActiveEntries(EntryRequestParameters? e)
        {


            var data = _context.Set<Entry>().Where(x => x.Statu.Equals(true)).OrderByDescending(x => x.ReleaseDate).ToList().ToPaginates( e.PageNumber,e.PageSize);
             //  var data = from x in _context.Entries where x.Statu == true select x;
                return data.ToList();
            
        }
        public int GetActiveEntriesCount()
        {


            var data = _context.Set<Entry>().Where(x => x.Statu.Equals(true)).OrderByDescending(x => x.ReleaseDate).ToList().Count;
            //  var data = from x in _context.Entries where x.Statu == true select x;
            return (int)data;

        }


        public List<Entry> GetByCategory(EntryRequestParameters e, int? categoryId, string? search)
        {

            if (categoryId == null && string.IsNullOrWhiteSpace(search))
            {
                return _context.Set<Entry>().ToList().ToPaginates(e.PageNumber,e.PageSize);// Daha sonra Allert olucak

            }
            else if (categoryId == null && !string.IsNullOrWhiteSpace(search))
            {
                // return _context.Set<Entry>().Where(x=>x.Title.ToLower().Contains(search.ToLower())).ToList();
                return _context.Set<Entry>().Where(x => x.Title.ToLower().Contains(search.ToLower())).ToList().ToPaginates(e.PageNumber, e.PageSize);
            }

            var data = _context.Set<Entry>().Include(x => x.Category).Where(y => y.CategoryId.Equals(categoryId) && y.Statu.Equals(true)).ToList().ToPaginates(e.PageNumber, e.PageSize);

            return data;


        }
        public List<Entry> GetDetailCategory()
        {
           
                var data = (from entry in _context.Entries
                            join category   in  _context.Categories on entry.CategoryId equals category.CategoryId
                            join writer in _context.Writers on entry.WriterId equals writer.WriterId
                            select new Entry
                            {
                                ContentId = entry.ContentId,
                                //CategoryName = category.CategoryName,
                                Title = entry.Title,
                                Text = entry.Text,
                                //WriterName=writer.WriterFirstName+ " " +writer.WriterLastName
                                
                            }).ToList();

                return data;
            }

        public List<Entry> GetWantedEntry(string? search, bool? statu)
        {
           return  _context.Set<Entry>().Where(x => x.Title.ToLower().Contains(search.ToLower()) || x.Statu==statu).OrderByDescending(z=>z.ReleaseDate).ToList();
        }
        public List<Entry> GetEntryByDesc()
        {
            return  _context.Set<Entry>().OrderByDescending(z => z.ReleaseDate).ToList();
        }
    }        
    }

