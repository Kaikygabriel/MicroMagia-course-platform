using MicroMagia.Domain.BackOffice.Interfaces.Career;
using MicroMagia.Infra.Data.Context;
using Microsoft.EntityFrameworkCore;

namespace MicroMagia.Infra.Repository.Career;

public class RepositoryCareer :Repository<Domain.BackOffice.Entities.Career>, IRepositoryCareer
{
    public RepositoryCareer(AppDbContext context) : base(context)
    {
    }

    public async Task<IEnumerable<Domain.BackOffice.Entities.Course>> GetAllByCareer(string title)
    {
        var career =  await _context.Careers.AsNoTracking().Include(x => x.Courses)
            .FirstOrDefaultAsync(x => x.Title == title);
        return career.Courses;
    }
}