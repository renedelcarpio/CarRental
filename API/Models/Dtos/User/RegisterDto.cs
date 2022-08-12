using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.Models.Dtos.User
{
  public class RegisterDto : LoginDto
  {
    public string Email { get; set; }
  }
}