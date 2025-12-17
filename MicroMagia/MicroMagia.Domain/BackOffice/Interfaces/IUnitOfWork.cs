using MicroMagia.Domain.BackOffice.Interfaces.Author;
using MicroMagia.Domain.BackOffice.Interfaces.Career;
using MicroMagia.Domain.BackOffice.Interfaces.Course;
using MicroMagia.Domain.BackOffice.Interfaces.Student;
using MicroMagia.Domain.BackOffice.Interfaces.User;

namespace MicroMagia.Domain.BackOffice.Interfaces;

public interface IUnitOfWork
{
    public IRepositoryAuthor RepositoryAuthor { get; }
    public IRepositoryCareer RepositoryCareer { get; }
    public IRepositoryCourse RepositoryCourse { get; }
    public IRepositoryStudent RepositoryStudent { get; }
    public IRepositoryUser RepositoryUser { get; }

    Task CommitAsync();
}