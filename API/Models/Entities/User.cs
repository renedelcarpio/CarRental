using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;

namespace API.Models.Entities
{
  public class User
  {
    public int Id { get; set; }
    public string Username { get; set; }
    public string Email { get; set; }
    public string Password { get; set; }
    public bool IsAdmin { get; set; }
    // public List<Rental>? Rentals { get; set; }
  }

  public class Jwt
  {
    public string key { get; set; }
    public string Issuer { get; set; }
    public string Audience { get; set; }
    public string Subject { get; set; }
  }
}