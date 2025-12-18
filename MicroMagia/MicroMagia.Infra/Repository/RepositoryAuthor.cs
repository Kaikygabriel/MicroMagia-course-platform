using MicroMagia.Domain.BackOffice.Entities;
using MicroMagia.Domain.BackOffice.Interfaces.Author;
using MicroMagia.Infra.Data.Context;
using Microsoft.EntityFrameworkCore;

namespace MicroMagia.Infra.Repository;

public class RepositoryAuthor : Repository<Author>,IRepositoryAuthor
{
    public RepositoryAuthor(AppDbContext context) : base(context)
    {
    }

    public async Task<Author?> GetByEmailOrNull(string email)
    { 
        return await _context.Authors.AsNoTracking().Include(x => x.User)
            .FirstOrDefaultAsync(x => x.User.Email.Address == email);
    }
}