using MicroMagia.Domain.BackOffice.Entities;

namespace MicroMagia.Domain.BackOffice.ObjectValue;

public class Category
{
    protected Category()
    {
        
    }
    public Category(string name)
    {
        if (IsValidName(name))
            throw new Exception("Category is invalid!");
        Name = name;
    }

    public string Name { get;private set; }
    public List<Course> Courses { get; private set; } = new();

    private bool IsValidName(string name)
        => string.IsNullOrWhiteSpace(name) || name.Length < 2;

    public void AddCourse(Course course)
        => Courses.Add(course);
}