using MicroMagia.Domain.BackOffice.Entities.Abstractions;

namespace MicroMagia.Domain.BackOffice.Entities;

public class Career : Entity
{
    protected Career()
    {
        
    }
    public Career(string title)
    {
        Id = Guid.NewGuid();
        Title = title;
    }

    public string Title { get; set; }
    public List<Course> Courses { get; private set; } = new();

    public void AddCourse(Course course)
        => Courses.Add(course);
}