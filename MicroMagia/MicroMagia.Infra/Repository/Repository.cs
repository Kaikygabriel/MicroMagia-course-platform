using System.Linq.Expressions;
using MicroMagia.Domain.BackOffice.Entities.Abstractions;
using MicroMagia.Domain.BackOffice.Interfaces;
using MicroMagia.Infra.Data.Context;
using Microsoft.EntityFrameworkCore;

namespace MicroMagia.Infra.Repository;

public class Repository<T> : IRepository<T> where T : Entity
{
    protected readonly AppDbContext _context;

    public Repository(AppDbContext context)
    {
        _context = context;
    }

    public virtual async Task<IEnumerable<T>> GetAllAsync(int skip, int take)
    {
        if (skip > 50 || skip < 0) skip = 0;
        if (take > 50 || take < 0) skip = 50;
        return await _context.Set<T>().AsNoTracking().Skip(skip).Take(take).ToListAsync(); 
    }

    public async Task<T?> GetByPredicateOrNull(Expression<Func<T, bool>> predicate)
    {
        return await _context.Set<T>().AsNoTracking().FirstOrDefaultAsync(predicate);
    }

    public void Create(T entity)
    {
        if (entity is null)
            throw new ArgumentNullException(nameof(entity));
        _context.Set<T>().Add(entity);
    }

    public void Update(T entity)
    {
        if (entity is null)
            throw new ArgumentNullException(nameof(entity));
        _context.Set<T>().Update(entity);
    }

    public void Delete(T entity)
    {
        if (entity is null)
            throw new ArgumentNullException(nameof(entity));
        _context.Set<T>().Remove(entity);
    }
}