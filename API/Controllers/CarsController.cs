using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using API.Data;
using API.Models.Dtos.Car;
using API.Models.Entities;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace API.Controllers
{
  [ApiController]
  [Route("api/[controller]")]
  public class CarsController : ControllerBase
  {
    private readonly RentalDbContext _context;
    private readonly IMapper _mapper;
    public CarsController(RentalDbContext context, IMapper mapper)
    {
      _context = context;
      _mapper = mapper;
    }

    [HttpGet]
    public async Task<ActionResult<List<CarDto>>> Get()
    {
      var carList = await _context.Cars.OrderBy(x => x.Id).ToListAsync();
      var dtos = _mapper.Map<List<CarDto>>(carList);

      return Ok(dtos);
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<CarDto>> GetById(int id)
    {
      var car = await _context.Cars.FirstOrDefaultAsync(x => x.Id == id);
      var dto = _mapper.Map<CarDto>(car);

      if (dto == null) return NotFound();

      return Ok(dto);
    }

    [HttpPost]
    public async Task<ActionResult<CreateCarDto>> Create([FromBody] CreateCarDto createCarDto)
    {
      if (createCarDto == null) return BadRequest();

      var car = _mapper.Map<Car>(createCarDto);
      await _context.AddAsync(car);
      await _context.SaveChangesAsync();

      return Ok(car);
    }

    [HttpPut("{id}")]
    public async Task<ActionResult<UpdateCarDto>> Update(int id, [FromBody] UpdateCarDto updateCarDto)
    {
      if (updateCarDto == null) return BadRequest();
      if (updateCarDto.Id != id) return NotFound();

      var car = _mapper.Map<Car>(updateCarDto);
      _context.Update(car);
      await _context.SaveChangesAsync();

      return Ok(car);
    }

    [HttpDelete("{id}")]
    public async Task<ActionResult<CarDto>> Delete(int id)
    {
      var car = await _context.Cars.FindAsync(id);

      if (car == null) return NotFound();

      _context.Cars.Remove(car);
      await _context.SaveChangesAsync();

      return Ok();
    }
  }
}