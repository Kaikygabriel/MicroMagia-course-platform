using MediatR;
using MicroMagia.Domain.BackOffice.Interfaces;

namespace MicroMagia.Application.UseCases.Career.Query.GetAll;

public class GetAllCareerHandler : HandlerBase,
    IRequestHandler<GetAllCareerQuery,IEnumerable<Domain.BackOffice.Entities.Career>>
{
    public GetAllCareerHandler(IUnitOfWork ofWork) : base(ofWork)
    {
    }

    public async Task<IEnumerable<Domain.BackOffice.Entities.Career>> Handle(GetAllCareerQuery request, CancellationToken cancellationToken=default)
    {
        return await _ofWork.RepositoryCareer.GetAllAsync(request.Skip, request.Take);
    }
}