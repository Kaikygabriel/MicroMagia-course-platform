using MicroMagia.Domain.BackOffice.Entities.Abstractions;
using MicroMagia.Domain.BackOffice.ObjectValue;

namespace MicroMagia.Domain.BackOffice.Entities;

public class Course : Entity
{
     protected Course()
    {
        
    }
    public Course(Category category, string title, string summary)
    {
        Category = category;
        Title = title;
        Summary = summary;
        Id = Guid.NewGuid();
    }
    
    public Category Category{ get;private set; }
    public string Title { get;private set; }
    public string Summary { get;private set; }
    public Career? Career { get;private set; }
    
    public List<Student> Students { get;private set; } = new();

    public void AddStudent(Student student)
        => Students.Add(student);

    public void AddCareer(Career career)
        => Career = career;
    
}