using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using API.Models.Dtos.Rental;
using API.Models.Dtos.User;
using API.Models.Entities;
using AutoMapper;

namespace API.Models.AutoMapper
{
  public class RentalProfile : Profile
  {
    public RentalProfile()
    {
      CreateMap<CreateRentalDto, Rental>().ReverseMap();
      CreateMap<UpdateRentalDto, Rental>();
      CreateMap<RentalDto, Rental>().ForMember(d => d.User, x => x.Ignore())
                                          .ForMember(d => d.Car, x => x.Ignore())
                                          .ReverseMap()
                                          .PreserveReferences(); ;
    }
  }
}