using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using API.Context;
using API.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CarsController : ControllerBase
    {
        private readonly CarRentalDbContext _context;

        public CarsController(CarRentalDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<IActionResult> GetCars()
        {
            var list = await _context.Cars.OrderBy(c => c.Model).ToListAsync();
            return Ok(list);
        }

        [HttpGet("{id}", Name = "GetCarById")]
        public async Task<IActionResult> GetCarById(int id)
        {
            var car = await _context.Cars.FirstOrDefaultAsync(c => c.Id == id);
            if(car == null)
            {
                return NotFound();
            }
            return Ok(car);
        }

        [HttpPost]
        public async Task<IActionResult> CreateCar([FromBody] Car car)
        {
            if(car == null)
            {
                return BadRequest(ModelState);
            }
            if(!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            await _context.AddAsync(car);
            await _context.SaveChangesAsync();

            return CreatedAtRoute("GetCarById", new {id = car.Id}, car);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateCar(int id, Car car)
        {
            if(car.Id != id)
            {
                return BadRequest();
            }
            
            _context.Entry(car).State = EntityState.Modified;
            
            try
            {
                await _context.SaveChangesAsync();
            }
            catch(DbUpdateConcurrencyException)
            {
                if(!CarExist(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCar(int id)
        {
            var deletedCar = await _context.Cars.FindAsync(id);
            if(deletedCar == null)
            {
                return NotFound();
            }

            _context.Cars.Remove(deletedCar);
            await _context.SaveChangesAsync();

            return Ok();
        }

        private bool CarExist(int id)
        {
            return _context.Cars.Any(e => e.Id == id);
        }
    }
}