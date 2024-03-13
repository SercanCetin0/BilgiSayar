using Entities.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic.ValidationRules.FluentValidation
{
    public class CategoryValidator:AbstractValidator<Category>
    {
        public CategoryValidator() 
        {
            RuleFor(x => x.CategoryName).NotEmpty().WithMessage("Category Boş Geçilemez");
        
        }  
    }
}
