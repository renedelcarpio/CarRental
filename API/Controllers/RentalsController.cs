using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using API.Data;
using API.Models.Dtos.Car;
using API.Models.Dtos.Rental;
using API.Models.Entities;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace API.Controllers
{
  [ApiController]
  [Route("api/[controller]")]
  public class RentalsController : ControllerBase
  {
    private readonly RentalDbContext _context;
    private readonly IMapper _mapper;
    private static readonly HttpClient client = new HttpClient();

    public RentalsController(RentalDbContext context, IMapper mapper)
    {
      _context = context;
      _mapper = mapper;
    }

    [HttpGet]
    public async Task<ActionResult<List<RentalDto>>> Get()
    {
      var rentalList = await _context.Rentals.OrderBy(x => x.Id).ToListAsync();
      var dtos = _mapper.Map<List<RentalDto>>(rentalList);

      return Ok(dtos);
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<RentalDto>> GetById(int id)
    {
      var rental = await _context.Rentals.FirstOrDefaultAsync(x => x.Id == id);
      var dto = _mapper.Map<RentalDto>(rental);

      if (dto == null) return NotFound();

      return Ok(dto);
    }

    [HttpPost]
    //Hacer una llamada post a un endpoint de elsa para que inicie el workflow
    public async Task<ActionResult<CreateRentalDto>> Create([FromBody] CreateRentalDto createRentalDto)
    {
      if (createRentalDto == null) return BadRequest();

      var rental = _mapper.Map<Rental>(createRentalDto);
      await _context.AddAsync(rental);
      await _context.SaveChangesAsync();

      return Ok(rental);
    }

    [HttpPost("RentalUser")]
    //Hacer una llamada post a un endpoint de elsa para que inicie el workflow
    public async Task<ActionResult<RentalDto>> CreateRentalUser([FromBody] CreateRentalDto createRentalDto)
    {
      if (createRentalDto == null) return BadRequest();

      var rentalUser = await _context.Users.FirstOrDefaultAsync(x => x.Id == createRentalDto.UserId);
      var rentalCar = await _context.Cars.FirstOrDefaultAsync(x => x.Id == createRentalDto.CarId);

      rentalCar.Available = false;


      var rental = _mapper.Map<Rental>(createRentalDto);
      rental.Car = rentalCar;
      rental.User = rentalUser;

      await _context.AddAsync(rental);
      await _context.SaveChangesAsync();

      var rentalDto = _mapper.Map<RentalDto>(rental);



      return Ok(rentalDto);
    }

    [HttpPut("{id}")]
    // Endpoint de elsa se comunica a este endpoint para cambiar el estado de confirmado (approve, rejected, pending)
    public async Task<ActionResult<UpdateRentalDto>> Update(int id, [FromBody] UpdateRentalDto updateRentalDto)
    {
      if (updateRentalDto == null) return BadRequest();
      if (updateRentalDto.Id != id) return NotFound();

      var rental = _mapper.Map<Rental>(updateRentalDto);
      _context.Update(rental);
      await _context.SaveChangesAsync();

      return Ok(rental);
    }

    [HttpDelete("{id}")]
    public async Task<ActionResult<RentalDto>> Delete(int id)
    {
      var rental = await _context.Rentals.FindAsync(id);

      if (rental == null) return NotFound();

      _context.Rentals.Remove(rental);
      await _context.SaveChangesAsync();

      return Ok();
    }

    [HttpPost("approve")]
    // Endpoint de elsa se comunica a este endpoint para cambiar el estado de confirmado (approve, rejected, pending)
    public async Task<ActionResult<RentalDto>> Approve([FromBody] int id)
    {
      var approveRental = await _context.Rentals.FirstOrDefaultAsync(x => x.Id == id);

      if (approveRental == null) return NotFound();

      approveRental.ConfirmationStatus = "approved";

      var rental = _mapper.Map<Rental>(approveRental);
      _context.Update(rental);
      await _context.SaveChangesAsync();

      return Ok();
    }

    [HttpPost("reject")]
    // Endpoint de elsa se comunica a este endpoint para cambiar el estado de confirmado (approve, rejected, pending)
    public async Task<ActionResult<RentalDto>> Reject([FromBody] int id)
    {
      var rejectRental = await _context.Rentals.FirstOrDefaultAsync(x => x.Id == id);

      if (rejectRental == null) return NotFound();

      rejectRental.ConfirmationStatus = "rejected";


      var rental = _mapper.Map<Rental>(rejectRental);
      _context.Update(rental);
      await _context.SaveChangesAsync();

      return Ok();
    }
  }
}