using MediatR;

namespace MicroMagia.Application.UseCases.Career.Query.GetAll;

public record GetAllCareerQuery(int Skip,int Take) : IRequest<IEnumerable<Domain.BackOffice.Entities.Career>>;