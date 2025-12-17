using MediatR;
using MicroMagia.Domain.BackOffice.Entities;

namespace MicroMagia.Application.UseCases.Courses.Query.GetById;

public record GetByIdQuery(Guid id) : IRequest<Course>;