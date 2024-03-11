using DataAccess.Abstract;
using DataAccess.Abstract.EntityFramework;
using DataAccess.Contexts;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfCommentDal: EntityRepositoryBase<Comment>,ICommentDal
    {
        private readonly BilgiSayarDbContext _context;
        public EfCommentDal(BilgiSayarDbContext context) : base(context)
        {
            _context = context;
        }
    }
}
