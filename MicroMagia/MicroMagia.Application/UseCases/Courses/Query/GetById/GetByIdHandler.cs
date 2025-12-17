using MediatR;
using MicroMagia.Domain.BackOffice.Entities;
using MicroMagia.Domain.BackOffice.Interfaces;

namespace MicroMagia.Application.UseCases.Courses.Query.GetById;

public class GetByIdHandler : HandlerBase,IRequestHandler<GetByIdQuery,Course>
{
    public GetByIdHandler(IUnitOfWork ofWork) : base(ofWork)
    {
    }

    public async Task<Course> Handle(GetByIdQuery request, CancellationToken cancellationToken)
    {
        var course = await _ofWork.RepositoryCourse.GetByPredicateOrNull(x => x.Id == request.id);
        return course;  
    }
}