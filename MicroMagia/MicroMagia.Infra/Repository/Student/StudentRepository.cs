using System.Linq.Expressions;
using MicroMagia.Domain.BackOffice.Entities;
using MicroMagia.Domain.BackOffice.Interfaces.Student;
using MicroMagia.Infra.Data.Context;
using Microsoft.EntityFrameworkCore;

namespace MicroMagia.Infra.Repository;

public class StudentRepository : Repository<Student>,IRepositoryStudent
{
    public StudentRepository(AppDbContext context) : base(context)
    {
    }

    public async Task<Student?> GetByPredicate(Expression<Func<Student, bool>> predicate)
    {
        return await _context.Students.AsNoTracking()
            .Include(x => x.User)
            .Include(x=>x.Courses)
            .FirstOrDefaultAsync(predicate);
    }

    public async Task<Student?> GetByEmailOrNull(string email)
    {
        return await _context.Students.AsNoTracking()
            .Include(x => x.User)
            .Include(x=>x.Courses)
            .FirstOrDefaultAsync(x=>x.User.Email.Address == email);
    }
}