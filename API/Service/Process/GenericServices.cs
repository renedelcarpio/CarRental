using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Runtime.CompilerServices;
using System.Runtime.Versioning;
using System.Threading.Tasks;
using API.Data;
using API.Service.Interface;
using Microsoft.EntityFrameworkCore;

namespace API.Service.Process
{
  public class GenericServices<T> : IGenericService<T> where T : class
  {
    private readonly RentalDbContext _context;
    private readonly DbSet<T> _db;

    public GenericServices(RentalDbContext context)
    {
      _context = context;
      _db = _context.Set<T>();
    }
    public async Task<IList<T>> GetAll(
        Expression<Func<T, bool>> expression = null,
        Func<IQueryable<T>, IOrderedQueryable<T>> orderBy = null,
        List<string> includes = null)
    {
      IQueryable<T> query = _db;
      if (expression != null)
      {
        query = query.Where(expression);
      }
      if (includes != null)
      {
        foreach (var includeProperty in includes)
        {
          query = query.Include(includeProperty);
        }
      }
      if (orderBy != null)
      {
        query = orderBy(query);
      }

      return await query.AsNoTracking().ToListAsync();
    }

    public async Task<T> Get(Expression<Func<T, bool>> expression, List<string> includes = null)
    {
      IQueryable<T> query = _db;
      if (includes != null)
      {
        foreach (var includeProperty in includes)
        {
          query = query.Include(includeProperty);
        }
      }

      return await query.AsNoTracking().FirstOrDefaultAsync(expression);
    }

    public async Task Insert(T entity)
    {
      await _db.AddAsync(entity);
    }

    public void Update(T entity)
    {
      _db.Attach(entity);
      _context.Entry(entity).State = EntityState.Modified;
    }

    public async Task Delete(int id)
    {
      var entity = await _db.FindAsync(id);
      _db.Remove(entity);
    }


  }
}