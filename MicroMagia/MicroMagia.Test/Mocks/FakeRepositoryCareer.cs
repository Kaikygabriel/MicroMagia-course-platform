using System.Linq.Expressions;
using MicroMagia.Domain.BackOffice.Entities;
using MicroMagia.Domain.BackOffice.Interfaces.Career;

namespace MicroMagia.Test.Mocks;

public class FakeRepositoryCareer : IRepositoryCareer
{
    private readonly List<Career> _careers;

    public FakeRepositoryCareer()
    {
        _careers = new List<Career>
        {
            new Career("Backend Developer"){Id = Guid.Parse("3f7a9c2e-8b4d-4f6a-9c21-1e7d5b8a4c93")},
            new Career("Frontend Developer"),
            new Career("Fullstack Developer")
        };
    }

    public Task<IEnumerable<Career>> GetAllAsync(int skip, int take)
    {
        var result = _careers
            .Skip(skip)
            .Take(take)
            .AsEnumerable();

        return Task.FromResult(result);
    }

    public Task<Career?> GetByPredicateOrNull(Expression<Func<Career, bool>> predicate)
    {
        var compiled = predicate.Compile();
        var career = _careers.FirstOrDefault(compiled);

        return Task.FromResult(career);
    }

    public void Create(Career entity)
    {
        _careers.Add(entity);
    }

    public void Update(Career entity)
    {
        var index = _careers.FindIndex(x => x.Id == entity.Id);

        if (index >= 0)
            _careers[index] = entity;
    }

    public void Delete(Career entity)
    {
        _careers.Remove(entity);
    }

    public Task<IEnumerable<Course>> GetAllByCareer(string title)
    {
        var courses = _careers
                          .FirstOrDefault(c => c.Title == title)?
                          .Courses;

        return Task.FromResult(courses.AsEnumerable());
    }
}