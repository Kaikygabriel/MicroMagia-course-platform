using MicroMagia.Domain.BackOffice.Entities.Abstractions;
using MicroMagia.Domain.BackOffice.Exceptions;
using MicroMagia.Domain.BackOffice.ObjectValue;

namespace MicroMagia.Domain.BackOffice.Entities;

public class Student : Entity
{
    protected Student()
    {
        
    }
    public Student(string name,User user)
    {
        if (!IsValidName(name))
            throw new StudentException("Name is invalid");
        Name = name;
        Id = Guid.NewGuid();
        User = user;
        IsPremium = false;
    }

    public string Name { get;private set; }
    public User User { get;private set; }
    public bool IsPremium { get;private set; }

    public List<Course> Courses { get;private set; } = new ();

    public void AddCourse(Course course)
        => Courses.Add(course);
    private bool IsValidName(string name)
    {
        if (string.IsNullOrEmpty(name) || name.Length < 2)
            return false;
        return true;
    }

    public void ConvertToPremium()
        => IsPremium = true; 
}