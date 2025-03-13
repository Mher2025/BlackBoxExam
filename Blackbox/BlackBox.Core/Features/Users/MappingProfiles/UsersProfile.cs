using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using BlackBox.Core.Features.Users.DTOs;
using BlackBox.Domain.Entities;
namespace BlackBox.Core.Features.Users.MappingProfiles
{
    public class UsersProfile : Profile
    {
        public UsersProfile()
        {
            CreateMap<UsersEntity, GetUsersDTO>();
        }
    }
}
