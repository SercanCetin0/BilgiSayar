using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Dtos
{
    public record UserResetPasswordDto
    {
        public string UserName { get; init; }

        public string Password { get; init; }

        [Compare("Password", ErrorMessage = "Şifre Eşleşmedi")]
        public string ConfigPassword { get; init; }
    }
}
