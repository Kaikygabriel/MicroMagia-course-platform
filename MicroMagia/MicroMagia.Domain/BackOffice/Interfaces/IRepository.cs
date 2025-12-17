using System.Linq.Expressions;
using MicroMagia.Domain.BackOffice.Entities.Abstractions;

namespace MicroMagia.Domain.BackOffice.Interfaces;

public interface IRepository<T> where T : Entity
{
    Task<IEnumerable<T>> GetAllAsync(int skip,int take);
    Task<T?> GetByPredicateOrNull(Expression<Func<T,bool>>predicate);
    void Create(T entity);
    void Update(T entity);
    void Delete(T entity);
}