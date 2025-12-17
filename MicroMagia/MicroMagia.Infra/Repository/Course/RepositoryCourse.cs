using MicroMagia.Domain.BackOffice.Interfaces.Course;
using MicroMagia.Infra.Data.Context;
using Microsoft.EntityFrameworkCore;

namespace MicroMagia.Infra.Repository.Course;

public class RepositoryCourse:  Repository<Domain.BackOffice.Entities.Course>,IRepositoryCourse
{
    public RepositoryCourse(AppDbContext context) : base(context)
    {
    }
}