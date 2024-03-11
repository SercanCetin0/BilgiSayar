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
    public class EfContentImageDal: EntityRepositoryBase<ContentImage>,IContentImageDal
    {
        private readonly BilgiSayarDbContext _context;
        public EfContentImageDal(BilgiSayarDbContext context) : base(context)
        {
            _context = context;
        }
    }
}
