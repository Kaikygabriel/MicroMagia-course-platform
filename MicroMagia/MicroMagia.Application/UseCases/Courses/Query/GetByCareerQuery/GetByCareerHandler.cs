using System.ComponentModel;
using MediatR;
using MicroMagia.Domain.BackOffice.Entities;
using MicroMagia.Domain.BackOffice.Interfaces;

namespace MicroMagia.Application.UseCases.Courses.Query.GetByCareerQuery;

public class GetByCareerHandler  : HandlerBase,IRequestHandler<GetByCareerQuery,IEnumerable<Course>> 
{
    public GetByCareerHandler(IUnitOfWork ofWork) : base(ofWork)
    {
    }

    public async Task<IEnumerable<Course>> Handle(GetByCareerQuery request, CancellationToken cancellationToken)
    {
        var courses = await _ofWork.RepositoryCareer.GetAllByCareer(request.TitleCareer);
        return courses;
    }
}