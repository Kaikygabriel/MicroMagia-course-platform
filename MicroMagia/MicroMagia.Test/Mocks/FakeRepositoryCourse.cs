using System.Linq.Expressions;
using MicroMagia.Domain.BackOffice.Entities;
using MicroMagia.Domain.BackOffice.Interfaces.Course;
using MicroMagia.Domain.BackOffice.ObjectValue;

namespace MicroMagia.Test.Mocks;

public class FakeRepositoryCourse : IRepositoryCourse
{
    private readonly List<Course> _courses;

    public FakeRepositoryCourse()
    {
        _courses = new List<Course>();

        // Seed opcional para testes
        var backendCategory = new Category("Backend");
        var frontendCategory = new Category("Frontend");

        var csharp = new Course(
            backendCategory,
            "C#",
            "Curso completo de C#"
        ){Id = Guid.Parse("a9c4e1b7-2d6f-4f8a-b3c2-7e5d91a6f204")};

        var aspnet = new Course(
            backendCategory,
            "ASP.NET Core",
            "Curso de ASP.NET Core do zero"
        );

        var html = new Course(
            frontendCategory,
            "HTML",
            "Curso de HTML básico"
        );

        backendCategory.AddCourse(csharp);
        backendCategory.AddCourse(aspnet);
        frontendCategory.AddCourse(html);

        _courses.AddRange(new[] { csharp, aspnet, html });
    }

    public Task<IEnumerable<Course>> GetAllAsync(int skip, int take)
    {
        var result = _courses
            .Skip(skip)
            .Take(take)
            .AsEnumerable();

        return Task.FromResult(result);
    }

    public Task<Course?> GetByPredicateOrNull(Expression<Func<Course, bool>> predicate)
    {
        var compiledPredicate = predicate.Compile();
        var course = _courses.FirstOrDefault(compiledPredicate);

        return Task.FromResult(course);
    }

    public void Create(Course entity)
    {
        _courses.Add(entity);
    }

    public void Update(Course entity)
    {
        var index = _courses.FindIndex(c => c.Id == entity.Id);
        if (index == -1)
            return;

        _courses[index] = entity;
    }

    public void Delete(Course entity)
    {
        _courses.RemoveAll(c => c.Id == entity.Id);
    }

    public Task<IEnumerable<Course>> GetAllDapperAsync(int skip, int take)
    {
        throw new NotImplementedException();
    }
}
