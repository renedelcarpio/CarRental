using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using API.Models;

namespace API.Context
{
    // CarRentalDbContext hereda de DbContext
    public class CarRentalDbContext : DbContext
    {
        //Este es el constructor
        public CarRentalDbContext(DbContextOptions<CarRentalDbContext> options) : base(options)
        {

        }

        public DbSet<Car> Cars { get; set; }
        public DbSet<Rent> Rents { get; set; }
        public DbSet<User> Users { get; set; }
    }
}