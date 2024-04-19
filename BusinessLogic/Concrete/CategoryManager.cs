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
        private readonly ILoggerService _loggerService;
        public CategoryManager(ICategoryDal categoryDal, IValidator<Category> validator, ILoggerService loggerService)
        {
            _categoryDal = categoryDal;
            _validator = validator;
            _loggerService = loggerService;
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
            _loggerService.LogInfo($"{category.CategoryId} Nolu {category.CategoryName} Adlı Nesne Silindi.");
        }

        public Category Get(int id)
        {
            DataControl.ControlNullData(id);
            var data = _categoryDal.Get(x => x.CategoryId.Equals(id));
            _loggerService.LogInfo($"{data.CategoryId} Nolu {data.CategoryName} Adlı Nesne Çağırıldı.");
            DataControl.ControlFoundData(data);
            return data;
        }
        //Categorye log yapıldı diğerlerinede yapılacka

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
            _loggerService.LogInfo($"{category.CategoryId} Nolu {category.CategoryName} Adlı Nesne Güncellendi.");
        }

        

    }
}
