using Entities.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic.ValidationRules.FluentValidation
{
    public class EntryValidator: AbstractValidator<Entry>
    {
        public EntryValidator() 
        {

        // Title Rules
        RuleFor(x=>x.Title).NotEmpty().MinimumLength(1).WithMessage("Başlık Boş Bırakılamaz");
        //Text Rules
        RuleFor(x => x.Text).NotEmpty().MinimumLength(10).WithMessage("İçerik Boş Bırakılamaz");
        // İmage Rules
        RuleFor(x=>x.İmage).NotEmpty().MinimumLength(1).WithMessage("Resim Gerekli");
        //CategoryId Rules
        RuleFor(x => x.CategoryId).NotEmpty().WithMessage("Kategori Seçiniz.");
        // Statu Rules
        RuleFor(x=>x.Statu).NotEmpty();
        // Release Date Rules
        RuleFor(x=>x.ReleaseDate).NotEmpty();
        
        }


    }
}
