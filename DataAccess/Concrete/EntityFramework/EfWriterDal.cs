using DataAccess.Abstract;
using DataAccess.Contexts;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfWriterDal : EntityRepositoryBase<Writer>, IWriterDal
    {

        private readonly BilgiSayarDbContext _context;
        public EfWriterDal(BilgiSayarDbContext context) : base(context)
        {
            _context = context;
        }

        public Writer GetWriterByUsername(string username)
        {
            return _context.Writers
       .Where(x => x.WriterNickname == username && x.WriterNickname != null)
       .FirstOrDefault();
        }
    }
}
