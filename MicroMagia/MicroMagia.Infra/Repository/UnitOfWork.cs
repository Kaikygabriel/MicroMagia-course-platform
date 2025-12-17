using MicroMagia.Domain.BackOffice.Interfaces;
using MicroMagia.Domain.BackOffice.Interfaces.Author;
using MicroMagia.Domain.BackOffice.Interfaces.Career;
using MicroMagia.Domain.BackOffice.Interfaces.Course;
using MicroMagia.Domain.BackOffice.Interfaces.Student;
using MicroMagia.Domain.BackOffice.Interfaces.User;
using MicroMagia.Infra.Data.Context;
using MicroMagia.Infra.Repository.Career;
using MicroMagia.Infra.Repository.Course;
using MicroMagia.Infra.Repository.User;

namespace MicroMagia.Infra.Repository;

public class UnitOfWork : IUnitOfWork
{
    private RepositoryUser _repositoryUser;
    private RepositoryCourse _repositoryCourse;
    private StudentRepository _studentRepository;
    private RepositoryCareer _repositoryCareer;
    
    private readonly AppDbContext _context;

    public UnitOfWork(AppDbContext context)
    {
        _context = context;
    }

    public IRepositoryAuthor RepositoryAuthor { get; }

    public IRepositoryCareer RepositoryCareer
    {
        get
        {
            return _repositoryCareer = _repositoryCareer ?? new(_context);
        }
    }

    public IRepositoryCourse RepositoryCourse
    {
        get
        {
            return _repositoryCourse = _repositoryCourse ?? new(_context);
        }
    }

    public IRepositoryStudent RepositoryStudent
    {
        get
        {
            return _studentRepository = _studentRepository ?? new(_context);
        }
    }

    public IRepositoryUser RepositoryUser
    {
        get
        {
            return _repositoryUser = _repositoryUser ?? new(_context);
        }
    }

    public async Task CommitAsync()
    {
        await _context.SaveChangesAsync();
    }
}