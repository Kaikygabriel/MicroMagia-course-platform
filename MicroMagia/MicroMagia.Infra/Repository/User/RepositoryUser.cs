using System.Linq.Expressions;
using MediatR;
using MicroMagia.Domain.BackOffice.Interfaces.User;
using MicroMagia.Infra.Data.Context;

namespace MicroMagia.Infra.Repository.User;

public class RepositoryUser : Repository<Domain.BackOffice.Entities.User>,IRepositoryUser
{
    public RepositoryUser(AppDbContext context) : base(context)
    {
    }
}