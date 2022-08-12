using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.Models.Dtos.User
{
  public class UpdateUserDto
  {
    public string Id { get; set; }
    public string Username { get; set; }
    public string Email { get; set; }
    public string Password { get; set; }
    public bool IsAdmin { get; set; }
  }
}