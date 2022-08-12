using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using API.Models.Dtos.Car;
using API.Models.Entities;
using AutoMapper;

namespace API.Models.AutoMapper
{
  public class CarProfile : Profile
  {
    public CarProfile()
    {
      CreateMap<CreateCarDto, Car>().ReverseMap();
      CreateMap<UpdateCarDto, Car>();
      CreateMap<Car, CarDto>();

    }
  }
}