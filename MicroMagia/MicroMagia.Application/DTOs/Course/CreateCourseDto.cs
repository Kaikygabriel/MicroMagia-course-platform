using MicroMagia.Domain.BackOffice.ObjectValue;

namespace MicroMagia.Application.DTOs.Course;

public class CreateCourseDto
{
    public string Title { get;set; }
    public string Summary { get; set; }
    public string Category { get; set; }

    public static implicit operator Domain.BackOffice.Entities.Course(CreateCourseDto course)
    {
        return new Domain.BackOffice.Entities.Course(new Category(course.Category), course.Title, course.Summary);
    }
}