using MediatR;
using MicroMagia.Domain.BackOffice.Entities;
using MicroMagia.Domain.BackOffice.Interfaces;

namespace MicroMagia.Application.UseCases.Courses.Query.GetAllCourse;

public class GetAllCourseHandler :HandlerBase, IRequestHandler<GetAllCourseQuery,IEnumerable<Course>>
{
    public GetAllCourseHandler(IUnitOfWork ofWork) : base(ofWork)
    {
    }

    public async Task<IEnumerable<Course>> Handle(GetAllCourseQuery request, CancellationToken cancellationToken)
    {
        return await _ofWork.RepositoryCourse.GetAllAsync(request.skip, request.take);
    }
}