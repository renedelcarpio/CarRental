using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.Models.Dtos.Car
{
  public class CarDto
  {
    public int Id { get; set; }
    public string BrandAndModel { get; set; }
    public string Seaters { get; set; }
    public string TrunkSize { get; set; }
    public string GearBox { get; set; }
    public string PictureUrl { get; set; }
    public int Price { get; set; }
    public string Type { get; set; }
    public bool Available { get; set; }
  }
}