using MediatR;
using MicroMagia.Domain.BackOffice.Interfaces;

namespace MicroMagia.Application.UseCases.Career.Command.Create;

public class CreateCareerHandler:  HandlerBase,IRequestHandler<CreateCareerCommand,bool>
{
    public CreateCareerHandler(IUnitOfWork ofWork) : base(ofWork)
    {
    }

    public async Task<bool> Handle(CreateCareerCommand request, CancellationToken cancellationToken)
    {
        try
        {
            return await Create(request);
        }
        catch (Exception e)
        {
            return false;
        }
    }

    private async Task<bool> Create(CreateCareerCommand request)
    {
        if (await _ofWork.RepositoryCareer.GetByPredicateOrNull
                (x => x.Title == request.Career.Title) is not null)
            return false;
        _ofWork.RepositoryCareer.Create(request.Career);
        await _ofWork.CommitAsync();
        return true;
    }
}