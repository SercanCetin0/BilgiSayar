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

    public class EfCategoryDal:EntityRepositoryBase<Category>,ICategoryDal
    {
        private readonly BilgiSayarDbContext _context;
        public EfCategoryDal(BilgiSayarDbContext context) : base(context)
        {
            _context = context;
        }

    }
}
