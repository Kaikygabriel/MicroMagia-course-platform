using MediatR;
using MicroMagia.Domain.BackOffice.Entities;

namespace MicroMagia.Application.UseCases.Courses.Query.GetAllCourse;

public record GetAllCourseQuery (int skip,int take): IRequest<IEnumerable<Course>>;