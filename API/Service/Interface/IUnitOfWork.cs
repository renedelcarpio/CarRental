using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using API.Models.Entities;

namespace API.Service.Interface
{
  public interface IUnitOfWork : IDisposable
  {
    IGenericService<User> Users { get; }
    IGenericService<Car> Cars { get; }
    // IGenericService<Rental> Rentals { get; }

    Task Save();
  }
}