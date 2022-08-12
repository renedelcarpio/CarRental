using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.Models.Dtos.Rental
{
  public class UpdateRentalDto
  {
    public int Id { get; set; }
    public string RentalStart { get; set; }
    public string RentalEnd { get; set; }
    public int UserId { get; set; }
    public int CarId { get; set; }
  }
}