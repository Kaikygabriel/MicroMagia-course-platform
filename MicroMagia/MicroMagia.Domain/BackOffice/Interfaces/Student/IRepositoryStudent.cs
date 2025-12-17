using System.Linq.Expressions;

namespace MicroMagia.Domain.BackOffice.Interfaces.Student;

public interface IRepositoryStudent
{
    Task<Entities.Student?> GetByPredicate(Expression<Func<Entities.Student, bool>> predicate);

    void Create(Entities.Student student);

    void Delete(Entities.Student student);
    Task<Entities.Student?> GetByEmailOrNull(string email);
}