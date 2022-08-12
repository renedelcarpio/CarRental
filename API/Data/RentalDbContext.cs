using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Threading.Tasks;
using API.Models.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;

namespace API.Data
{
  public class RentalDbContext : DbContext
  {
    public RentalDbContext(DbContextOptions<RentalDbContext> options) : base(options)
    {

    }

    public DbSet<Car> Cars { get; set; }
    public DbSet<Rental> Rentals { get; set; }
    public DbSet<User> Users { get; set; }

    protected override void OnModelCreating(ModelBuilder builder)
    {
      builder.Entity<User>().HasData(
        new User
        {
          Id = 1,
          Username = "Admin",
          Email = "admin@email.com",
          Password = "Pa$$w0rd",
          IsAdmin = true
        },
        new User
        {
          Id = 2,
          Username = "Bob",
          Email = "bob@email.com",
          Password = "Pa$$w0rd",
          IsAdmin = false
        },
        new User
        {
          Id = 3,
          Username = "Kurt",
          Email = "kurt@email.com",
          Password = "Pa$$w0rd",
          IsAdmin = false
        }
      );

      builder.Entity<Car>().HasData(
        new Car
        {
          Id = 1,
          BrandAndModel = "Suzuki Alto",
          Seaters = "4 seaters",
          TrunkSize = "254 liters",
          GearBox = "Manual Transmission",
          PictureUrl = "https://th.bing.com/th/id/R.0a70c93cc6dcc81661078747bc4a9cc4?rik=lwiiImmqtAwm5w&riu=http%3a%2f%2fwww.autosarena.com%2fwp-content%2fuploads%2f2016%2f05%2fMaruti-Suzuki-Alto-800-Superior-White.png&ehk=aEBUZIxBqD3apL6Fs1lA2XzJodnd4nKa2maaCE01%2bDg%3d&risl=&pid=ImgRaw&r=0&sres=1&sresct=1",
          Price = 100,
          Type = "Small",
          Available = true
        },
          new Car
          {
            Id = 2,
            BrandAndModel = "Suzuki Celerio",
            Seaters = "5 seaters",
            TrunkSize = "254 liters",
            GearBox = "Automatic Transmission",
            PictureUrl = "https://th.bing.com/th/id/R.d0586968de8a43eee95a1a41e5966e12?rik=ioti2Vk%2bdocK1Q&riu=http%3a%2f%2fwww.pngimagesfree.com%2fCar%2fMaruti%2fCelerio+Car+png.png&ehk=FuAjI5ipREVLyIRS4%2bf9G0ES6WWDuCKrwc8qBjjhjsY%3d&risl=&pid=ImgRaw&r=0",
            Price = 135,
            Type = "Small",
            Available = true
          },
          new Car
          {
            Id = 3,
            BrandAndModel = "Hyundai Accent",
            Seaters = "5 seaters",
            TrunkSize = "388 liters",
            GearBox = "Automatic Transmission",
            PictureUrl = "https://th.bing.com/th/id/R.877bd017bab0e235737cb90a0af61ecd?rik=QhUPGYNejHH0oQ&riu=http%3a%2f%2fwww.pngimagesfree.com%2fCar%2fhyundai%2fHundai-accent-png_angular-front.png&ehk=Lbq%2btnlPeIidhdzUDKBkRkSTyXl0lXN3JlIsZTzItPo%3d&risl=&pid=ImgRaw&r=0",
            Price = 170,
            Type = "Medium",
            Available = true
          },
          new Car
          {
            Id = 4,
            BrandAndModel = "Suzuki Vitara",
            Seaters = "5 seaters",
            TrunkSize = "375 liters",
            GearBox = "Manual Transmission",
            PictureUrl = "https://www.autokpplus.cz/User_Files/photos/60361f1ac420d5be032658d065vitarafront.png",
            Price = 200,
            Type = "Medium",
            Available = true
          },
          new Car
          {
            Id = 5,
            BrandAndModel = "Toyota Hilux",
            Seaters = "5 seaters",
            TrunkSize = "1 Ton",
            GearBox = "Manual Transmission",
            PictureUrl = "https://i1.wp.com/fairwheels.com/wp-content/uploads/2016/11/Toyota-Hilux-Revo-V-Automatic-3.0-price-and-specification.png?fit=980%2C559&ssl=1",
            Price = 240,
            Type = "Large",
            Available = true
          },
          new Car
          {
            Id = 6,
            BrandAndModel = "Toyota Prado",
            Seaters = "7 seaters",
            TrunkSize = "640 liters",
            GearBox = "Automatic Transmission",
            PictureUrl = "https://th.bing.com/th/id/R.1da109636cf679c449393fabd969aef2?rik=ca5rpoWTp9%2fyIQ&pid=ImgRaw&r=0",
            Price = 300,
            Type = "Large",
            Available = true
          }
      );


    }

  }
}