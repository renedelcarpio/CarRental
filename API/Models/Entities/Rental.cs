using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace API.Models.Entities
{
  public class Rental
  {
    public int Id { get; set; }
    public string RentalStart { get; set; }
    public string RentalEnd { get; set; }
    public string ConfirmationStatus { get; set; } = "pending";

    [ForeignKey(nameof(User))]
    public int UserId { get; set; }
    public User User { get; set; }

    [ForeignKey(nameof(Car))]
    public int CarId { get; set; }
    public Car Car { get; set; }
  }
}