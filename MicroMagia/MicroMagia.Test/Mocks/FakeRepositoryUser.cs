using System.Linq.Expressions;
using MicroMagia.Domain.BackOffice.Entities;
using MicroMagia.Domain.BackOffice.Interfaces.User;
using MicroMagia.Domain.BackOffice.ObjectValue;

namespace MicroMagia.Test.Mocks;

public class FakeRepositoryUser : IRepositoryUser
{
    private readonly List<User> _users;

    public FakeRepositoryUser()
    {
        _users = new List<User>
        {
            new User(new Email("admin@micromagia.com"), "admin123"),
            new User(new Email("user1@micromagia.com"), "123456"),
            new User(new Email("user2@micromagia.com"), "abc123"),
            new User(new Email("teste@micromagia.com"), "teste123")
        };
    }

    public Task<IEnumerable<User>> GetAllAsync(int skip, int take)
    {
        var result = _users
            .Skip(skip)
            .Take(take)
            .AsEnumerable();

        return Task.FromResult(result);
    }

    public Task<User?> GetByPredicateOrNull(Expression<Func<User, bool>> predicate)
    {
        var user = _users
            .AsQueryable()
            .FirstOrDefault(predicate);

        return Task.FromResult(user);
    }

    public void Create(User entity)
    {
        _users.Add(entity);
    }

    public void Update(User entity)
    {
        var index = _users.FindIndex(u => u.Id == entity.Id);
        if (index >= 0)
            _users[index] = entity;
    }

    public void Delete(User entity)
    {
        _users.Remove(entity);
    }
}