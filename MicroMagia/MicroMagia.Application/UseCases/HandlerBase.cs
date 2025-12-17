using MicroMagia.Domain.BackOffice.Interfaces;

namespace MicroMagia.Application.UseCases;

public abstract class HandlerBase
{
    protected readonly IUnitOfWork _ofWork;

    protected HandlerBase(IUnitOfWork ofWork)
    {
        _ofWork = ofWork;
    }
}