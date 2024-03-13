using BusinessLogic.Abstract;
using DataAccess.Abstract;
using Entities.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic.Concrete
{

    public class CategoryManager : ICategoryService
    {

        private readonly ICategoryDal _categoryDal;
        private readonly IValidator<Category> _validator;
        public CategoryManager(ICategoryDal categoryDal, IValidator<Category> validator)
        {
            _categoryDal = categoryDal;
            _validator = validator;
        }
        public void Add(Category category)
        {
            if (_validator.Validate(category).IsValid)
            {
                _categoryDal.Add(category);
            }
        }

        public void Delete(Category category)
        {
            _categoryDal.Delete(category);
        }

        public Category Get(int id)
        {
            return _categoryDal.Get(x => x.CategoryId.Equals(id));
        }

        public List<Category> GetAll()
        {
            return _categoryDal.GetAll();
        }

        public void Update(Category category)
        {
            _categoryDal.Update(category);
        }
    }
}
