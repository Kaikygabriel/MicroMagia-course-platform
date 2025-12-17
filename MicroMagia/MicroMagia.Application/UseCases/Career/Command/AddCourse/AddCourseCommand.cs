using MediatR;

namespace MicroMagia.Application.UseCases.Career.Command.AddCourse;

public record AddCourseCommand(Guid IdCourse,Guid IdCareer) : IRequest<bool>;