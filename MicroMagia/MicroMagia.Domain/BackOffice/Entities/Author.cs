using MicroMagia.Domain.BackOffice.Entities.Abstractions;
using MicroMagia.Domain.BackOffice.ObjectValue;

namespace MicroMagia.Domain.BackOffice.Entities;

public class Author : Entity
{
    protected Author()
    {
        
    }
    public Author(string name, User user)
    {
        Id = Guid.NewGuid();
        Name = name;
        User = user;
        IsPremium = true;
    }

    public bool IsPremium { get; }
    public string Name { get;private set; }
    public User User { get;private set; }
    public List<Course>Courses { get; set; }
    
}