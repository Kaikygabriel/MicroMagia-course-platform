using MediatR;
using MicroMagia.Domain.BackOffice.Interfaces;

namespace MicroMagia.Application.UseCases.Career.Command.AddCourse;

public class AddCourseHandler : HandlerBase,IRequestHandler<AddCourseCommand,bool>
{
    public AddCourseHandler(IUnitOfWork ofWork) : base(ofWork)
    {
    }

    public async Task<bool> Handle(AddCourseCommand request, CancellationToken cancellationToken)
    {
        try
        {
            return await AddCourseInCareer(request);
        }
        catch (Exception e)
        {
            return false;
        }
    }

    private async Task<bool> AddCourseInCareer(AddCourseCommand request)
    {
        var career = await _ofWork.RepositoryCareer.GetByPredicateOrNull(x => x.Id == request.IdCareer);
        var course = await _ofWork.RepositoryCourse.GetByPredicateOrNull(x => x.Id == request.IdCourse);
        if (course is null || career is null) return false;
        
        career.AddCourse(course);
        
        _ofWork.RepositoryCareer.Update(career);
        _ofWork.RepositoryCourse.Update(course);

        await _ofWork.CommitAsync();
        return true;
    }
}