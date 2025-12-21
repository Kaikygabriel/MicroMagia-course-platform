using Dapper;
using MicroMagia.Application.DTOs.Course;
using MicroMagia.Domain.BackOffice.Interfaces.Course;
using MicroMagia.Infra.Data.Context;
using Microsoft.EntityFrameworkCore;

namespace MicroMagia.Infra.Repository.Course;

public class RepositoryCourse:  Repository<Domain.BackOffice.Entities.Course>,IRepositoryCourse
{
    public RepositoryCourse(AppDbContext context) : base(context)
    {
    }

    public override async Task<IEnumerable<Domain.BackOffice.Entities.Course>> GetAllAsync(int skip, int take)
    {
        return await _context.Courses.AsNoTracking().Skip(skip).Take(take).ToListAsync();
    }
}