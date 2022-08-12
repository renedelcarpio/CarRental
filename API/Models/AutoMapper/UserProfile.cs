using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using API.Models.Dtos.User;
using API.Models.Entities;
using AutoMapper;

namespace API.Models.AutoMapper
{
  public class UserProfile : Profile
  {
    public UserProfile()
    {
      CreateMap<CreateUserDto, User>().ReverseMap();
      CreateMap<UpdateUserDto, User>();
      CreateMap<User, UserDto>();
    }
  }
}