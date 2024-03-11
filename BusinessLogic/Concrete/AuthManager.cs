using AutoMapper;
using BusinessLogic.Abstract;
using Entities.Dtos;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic.Concrete
{
    public class AuthManager : IAuthService
    {
        private readonly RoleManager<IdentityRole> _roleManager;
        private readonly UserManager<IdentityUser> _userManager;
        private readonly IMapper _mapper;

        public AuthManager(RoleManager<IdentityRole> roleManager, UserManager<IdentityUser> userManager, IMapper mapper)
        {
            _roleManager = roleManager;
            _userManager = userManager;
            _mapper = mapper;
        }

        public IEnumerable<IdentityRole> Roles => _roleManager.Roles.ToList(); // dikkaT HATA OLABİLİR

        public IEnumerable<IdentityUser> Users => _userManager.Users.ToList();

        public async Task<IdentityResult> CreateUser(UserDtoForCreation creation)
        {
            var user = _mapper.Map<IdentityUser>(creation);

            var result = await _userManager.CreateAsync(user, creation.Password);
            if (!result.Succeeded) { throw new Exception("Kullanıcı Oluşturulma Sırasında Hata Oluştu"); }

            if (creation.Roles.Count > 0)
            {
                var rolesResult = await _userManager.AddToRolesAsync(user, creation.Roles);
                if (!rolesResult.Succeeded) { throw new Exception("Rol Oluşturulamadı"); }

            }
            return result;
        }

        public async Task<IdentityResult> DeleteOneUser(string username)
        {
           var user= await GetOneUser(username);
            var result = await _userManager.DeleteAsync(user);
            if (!result.Succeeded)
            {
                throw new Exception("Kullanıcı Silinemedi");
            }

            return result;
        }

        public async Task<IdentityUser> GetOneUser(string username)
        {
            var user = await _userManager.FindByNameAsync(username);
            if (user is not null)
            {

                return user;

            }

            throw new Exception("Kullanıcı Bulanamadı!");
        }

        public async Task<UserDtoForUpdate> GetOneUserForUpdate(string username)
        {
            var user=await GetOneUser(username);

            var userDto=_mapper.Map<UserDtoForUpdate>(user);
            
            userDto.Roles=new HashSet<string>(Roles.Select(x => x.Name).ToList());

            userDto.UserRoles = new HashSet<string>(await _userManager.GetRolesAsync(user));

            return userDto;
        }

        //public async Task<IdentityUser> GetWriter()
        //{
        //    // Butun userlari getirecek 
        //}

        public async Task<IdentityResult> ResetPassword(UserResetPasswordDto userResetPassword)
        {
            var user = await GetOneUser(userResetPassword.UserName);
            await _userManager.RemovePasswordAsync(user);

            var result = await _userManager.AddPasswordAsync(user,userResetPassword.Password);
            return result;
        }


        public async Task Update(UserDtoForUpdate userDto)
        {
            // Bul
            var user = await GetOneUser(userDto.Username);
            user.PhoneNumber = userDto.PhoneNumber;
            user.Email = userDto.Email;
            // Kullanıcıyı update et
            var result = await _userManager.UpdateAsync(user);
            if (userDto.Roles.Count > 0)
            {
                // verilen rolleri önce al 
                var userRoles = await _userManager.GetRolesAsync(user);
                //alınan rolleri kaldır
                var removeRole = await _userManager.RemoveFromRolesAsync(user,userRoles);

                //yeni rolleri tanımla
                var addRole = await _userManager.AddToRolesAsync(user, userDto.Roles);
            }
            return;
        }

       
    }
}
