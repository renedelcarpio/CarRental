using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using API.Data;
using API.Models.Dtos.User;
using API.Models.Entities;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace API.Controllers
{
  [ApiController]
  [Route("api/[controller]")]
  public class UsersController : ControllerBase
  {
    private readonly RentalDbContext _context;
    private readonly IMapper _mapper;
    public UsersController(RentalDbContext context, IMapper mapper)
    {
      _context = context;
      _mapper = mapper;
    }

    [HttpGet]
    public async Task<ActionResult<List<UserDto>>> Get()
    {
      var usersList = await _context.Users.OrderBy(x => x.Id).ToListAsync();
      var dtos = _mapper.Map<List<UserDto>>(usersList);

      return Ok(dtos);
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<UserDto>> GetById(int id)
    {
      var user = await _context.Users.FirstOrDefaultAsync(x => x.Id == id);
      var dto = _mapper.Map<UserDto>(user);

      if (dto == null) return NotFound();

      return Ok(dto);
    }


    [HttpPost]
    public async Task<ActionResult<CreateUserDto>> Create([FromBody] CreateUserDto createUserDto)
    {
      if (createUserDto == null) return BadRequest();

      var user = _mapper.Map<User>(createUserDto);
      await _context.AddAsync(user);
      await _context.SaveChangesAsync();

      return Ok(user);
    }

    [HttpPut("{id}")]
    public async Task<ActionResult<UpdateUserDto>> Update(int id, [FromBody] UpdateUserDto updateUserDto)
    {
      if (updateUserDto == null) return BadRequest();

      var user = _mapper.Map<User>(updateUserDto);
      _context.Update(user);
      await _context.SaveChangesAsync();

      return Ok(user);
    }

    [HttpDelete("{id}")]
    public async Task<ActionResult<UserDto>> Delete(int id)
    {
      var user = await _context.Users.FindAsync(id);

      if (user == null) return NotFound();

      _context.Users.Remove(user);
      await _context.SaveChangesAsync();

      return Ok();
    }
  }
}