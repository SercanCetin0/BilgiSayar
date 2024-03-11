using Entities.Dtos;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic.Abstract
{
    public interface IAuthService
    {
        IEnumerable<IdentityRole> Roles { get; }

        IEnumerable<IdentityUser> Users { get; }

        public Task<IdentityResult> CreateUser(UserDtoForCreation creation);

        public Task<IdentityResult> DeleteOneUser(string username);

        public Task Update(UserDtoForUpdate userDto);

        public Task<IdentityUser> GetOneUser(string username);

        public Task<UserDtoForUpdate> GetOneUserForUpdate(String username);

        public Task<IdentityResult> ResetPassword(UserResetPasswordDto userResetPassword);


        //public Task<IdentityUser> GetWriter();
        





    }
}
