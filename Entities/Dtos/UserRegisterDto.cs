using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Dtos
{
    public record UserRegisterDto:UserDto
    {
        public String? Username { get; init; }
        public String? Password { get; init; }
        public String? Email { get; init; }

    }
}
