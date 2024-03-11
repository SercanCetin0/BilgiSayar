using AutoMapper;
using Entities.Concrete;
using Entities.Dtos;
using Entities.Dtos.EntryDto;
using Microsoft.AspNetCore.Identity;

namespace Bilgi_SayarUI.Infrastructure.Mapper
{
    public class MappingProfile:Profile
    {

        public MappingProfile()
        {
            CreateMap<UserDtoForCreation, IdentityUser>();
            CreateMap<UserDtoForUpdate, IdentityUser>();
            CreateMap<UserDtoForUpdate, IdentityUser>().ReverseMap();

            //CreateMap<EntryDto, Entry>();
        }

    }
}
