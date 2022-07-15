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
    public class RentsController : ControllerBase
    {
        private readonly CarRentalDbContext _context;
        public RentsController(CarRentalDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<IActionResult> GetRents()
        {
            var list = await _context.Rents.OrderBy(u => u.Id).Include(c => c.CarId).Include(u => u.ClientId).ToListAsync();
            return Ok(list);
        }

        [HttpGet("{id}", Name = "GetRentById")]
        public async Task<IActionResult> GetRentById(int id)
        {
            var rent = await _context.Rents.FirstOrDefaultAsync(r => r.Id == id);
            if(rent == null)
            {
                return NotFound();
            }
            return Ok(rent);
        }

        [HttpPost]
        public async Task<IActionResult> CreateRent([FromBody] Rent rent)
        {
            if(rent == null)
            {
                return BadRequest(ModelState);
            }
            if(!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            await _context.AddAsync(rent);
            await _context.SaveChangesAsync();

            return CreatedAtRoute("GetRentById", new {id = rent.Id}, rent);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateRent(int id, Rent rent)
        {
            if(rent.Id != id)
            {
                return BadRequest();
            }
            
            _context.Entry(rent).State = EntityState.Modified;
            
            try
            {
                await _context.SaveChangesAsync();
            }
            catch(DbUpdateConcurrencyException)
            {
                if(!RentExist(id))
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
        public async Task<IActionResult> DeleteRent(int id)
        {
            var deletedRent = await _context.Rents.FindAsync(id);
            if(deletedRent == null)
            {
                return NotFound();
            }

            _context.Rents.Remove(deletedRent);
            await _context.SaveChangesAsync();

            return Ok();
        }

        private bool RentExist(int id)
        {
            return _context.Rents.Any(r => r.Id == id);
        }
    }
}