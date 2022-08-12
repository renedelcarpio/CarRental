using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using API.Models.Dtos.Car;
using API.Models.Dtos.User;

namespace API.Models.Dtos.Rental
{
  public class CreateRentalDto
  {
    public string RentalStart { get; set; }
    public string RentalEnd { get; set; }
    public int UserId { get; set; }
    public int CarId { get; set; }
  }
}