using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using API.Data;
using API.Models.Dtos.User;
using API.Models.Entities;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Microsoft.IdentityModel.JsonWebTokens;
using Microsoft.IdentityModel.Tokens;

namespace API.Controllers
{
  [ApiController]
  [Route("api/[controller]")]
  public class AuthController : ControllerBase
  {
    private readonly RentalDbContext _context;
    private readonly IMapper _mapper;
    private readonly IConfiguration _configuration;

    public AuthController(RentalDbContext context, IMapper mapper, IConfiguration configuration)
    {
      _context = context;
      _mapper = mapper;
      _configuration = configuration;
    }

    [HttpPost("Login")]
    public async Task<ActionResult<RegisterDto>> Post([FromBody] LoginDto loginDto)
    {
      if (loginDto != null && loginDto.Username != null && loginDto.Password != null)
      {
        var userData = await GetUser(loginDto.Username, loginDto.Password);
        return Ok(userData);


      }
      else
      {
        return BadRequest("Invalid Credentials");
      }
    }

    [HttpGet]
    public async Task<User> GetUser(string username, string password)
    {
      return await _context.Users.FirstOrDefaultAsync(x => x.Username == username && x.Password == password);
    }
  }
}