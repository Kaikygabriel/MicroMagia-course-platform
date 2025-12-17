using MediatR;
using MicroMagia.Application.DTOs.Course;
using MicroMagia.Domain.BackOffice.Entities;
using MicroMagia.Domain.BackOffice.ObjectValue;

namespace MicroMagia.Application.UseCases.Courses.Command.Create;

public record CreateCourseCommand(CreateCourseDto Course,string? CareerTitle) : IRequest<bool>;