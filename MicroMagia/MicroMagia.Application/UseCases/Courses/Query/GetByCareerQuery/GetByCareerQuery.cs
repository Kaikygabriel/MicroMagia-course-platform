using MediatR;
using MicroMagia.Domain.BackOffice.Entities;

namespace MicroMagia.Application.UseCases.Courses.Query.GetByCareerQuery;

public record GetByCareerQuery(string TitleCareer) : IRequest<IEnumerable<Course>>; 