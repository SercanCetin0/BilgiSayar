using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic.Abstract
{
    public interface ICategoryService
    {
     public List<Category> GetAll();
        Category Get(int id);

        void Add(Category category);
        void Update(Category category);
        void Delete(Category category);
    }
}
