using MicroMagia.Domain.BackOffice.Entities.Abstractions;

namespace MicroMagia.Domain.BackOffice.Entities;

public class Career : Entity
{
    protected Career()
    {
        
    }
    public Career(string title)
    {
        if (!IsValidTitle(title))
            throw new Exception("Career is invalid!");
        Id = Guid.NewGuid();
        Title = title;
    }

    public string Title { get; set; }
    public List<Course> Courses { get; private set; } = new();

    public void AddCourse(Course course)
        => Courses.Add(course);

    private bool IsValidTitle(string title)
    {
        if (string.IsNullOrWhiteSpace(title) || title.Length <= 2)
            return false;
        return true;
    } 
}