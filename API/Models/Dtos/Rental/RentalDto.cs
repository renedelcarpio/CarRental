using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using API.Models.Dtos.Car;
using API.Models.Dtos.User;

namespace API.Models.Dtos.Rental
{
  public class RentalDto
  {
    public int Id { get; set; }
    public string RentalStart { get; set; }
    public string RentalEnd { get; set; }
    public string ConfirmationStatus { get; set; } = "pending";
    public UserDto User { get; set; }
    public CarDto Car { get; set; }
  }
}