using Entities.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic.ValidationRules.FluentValidation
{
    public class WriterValidator : AbstractValidator<Writer>
    {
        public WriterValidator() 
        {
            RuleFor(x => x.WriterFirstName).NotEmpty().WithMessage("İsim Boş Geçilemez");
            RuleFor(x => x.WriterLastName).NotEmpty().WithMessage("Soyisim Boş Geçilemez");
            RuleFor(x => x.WriterNickname).NotEmpty().WithMessage("Kullanıcı Boş Geçilemez");
            RuleFor(x => x.WriterEmail).NotEmpty().WithMessage("E-Mail Boş Geçilemez");
            RuleFor(x => x.WriterBio).NotEmpty().WithMessage("Biografi Boş Geçilemez");
        }
    }
}
