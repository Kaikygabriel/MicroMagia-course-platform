using MicroMagia.Domain.BackOffice.Interfaces;
using MicroMagia.Domain.BackOffice.Interfaces.Author;
using MicroMagia.Domain.BackOffice.Interfaces.Career;
using MicroMagia.Domain.BackOffice.Interfaces.Course;
using MicroMagia.Domain.BackOffice.Interfaces.Student;
using MicroMagia.Domain.BackOffice.Interfaces.User;

namespace MicroMagia.Test.Mocks;

public class FakeUnitOfWork : IUnitOfWork
{
    public IRepositoryAuthor RepositoryAuthor { get; }
    public IRepositoryCareer RepositoryCareer { get; } = new FakeRepositoryCareer();
    public IRepositoryCourse RepositoryCourse { get; } = new FakeRepositoryCourse();
    public IRepositoryStudent RepositoryStudent { get; }
    public IRepositoryUser RepositoryUser { get; }
    public async Task CommitAsync()
    {
        await Task.Delay(0);
    }
}