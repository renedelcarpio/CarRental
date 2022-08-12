using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using API.Data;
using API.Models.Entities;
using API.Service.Interface;

namespace API.Service.Process
{
  public class UnitOfWork : IUnitOfWork
  {
    private readonly RentalDbContext _context;
    private IGenericService<User> _users;
    private IGenericService<Car> _cars;
    // private IGenericService<Rental> _rentals;

    public UnitOfWork(RentalDbContext context)
    {
      _context = context;
    }
    public IGenericService<User> Users => _users ??= new GenericServices<User>(_context);

    public IGenericService<Car> Cars => _cars ??= new GenericServices<Car>(_context);

    // public IGenericService<Rental> Rentals => _rentals ??= new GenericServices<Rental>(_rentals);

    public void Dispose()
    {
      _context.Dispose();
      GC.SuppressFinalize(this);
    }

    public async Task Save()
    {
      await _context.SaveChangesAsync();
    }
  }
}