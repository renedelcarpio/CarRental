using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.Models.Dtos.Rental
{
  public class RentalUserDto
  {
    public int Id { get; set; }
    public string RentalStart { get; set; }
    public string RentalEnd { get; set; }
    public string ConfirmationStatus { get; set; } = "pending";
    public int UserId { get; set; }
    public int CarId { get; set; }
    public string Username { get; set; }
    public string Email { get; set; }
  }
}