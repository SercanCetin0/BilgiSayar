using BusinessLogic.Abstract;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.ErrorModels.Exceptions;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using BusinessLogic.Controls;
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
            DataControl.ControlNullData(category);

            if (_validator.Validate(category).IsValid)
            {
                _categoryDal.Add(category);
            }
        }

        public void Delete(Category category)
        {
            DataControl.ControlNullData(category);
            _categoryDal.Delete(category);
        }

        public Category Get(int id)
        {
            DataControl.ControlNullData(id);
            var data = _categoryDal.Get(x => x.CategoryId.Equals(id));
            DataControl.ControlFoundData(data);
            return data;
        }

        public List<Category> GetAll()
        {
            var data = _categoryDal.GetAll();
            DataControl.ControlFoundData(data);
            return data;
        }

        public void Update(Category category)
        {
            
            
            DataControl.ControlNullData(category);
            _categoryDal.Update(category);
        }

        

    }
}
