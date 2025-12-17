using MediatR;
using MicroMagia.Domain.BackOffice.Entities;
using MicroMagia.Domain.BackOffice.Interfaces;

namespace MicroMagia.Application.UseCases.Courses.Command.Create;

public class CreateCourseHandler : HandlerBase , IRequestHandler<CreateCourseCommand,bool>
{
    public CreateCourseHandler(IUnitOfWork ofWork) : base(ofWork)
    {
    }

    public async Task<bool> Handle(CreateCourseCommand request, CancellationToken cancellationToken)
    {
            return await Create(request);
        
    }

    private async Task<bool> Create(CreateCourseCommand request)
    {
        if (await _ofWork.RepositoryCourse.GetByPredicateOrNull(x => x.Title == request.Course.Title) is not null)
            return false;
        Course course = request.Course;
        if(request.CareerTitle is not null)
            await AddCourseInCareerOrVoid(course,request.CareerTitle);
        _ofWork.RepositoryCourse.Create(course);
        await _ofWork.CommitAsync();
        return true;
    }

    private async Task AddCourseInCareerOrVoid(Course request,string titleCareer)
    {
        var career = await _ofWork.RepositoryCareer.GetByPredicateOrNull(x => x.Title == titleCareer);
        if (career is null)
            return;
        career.AddCourse(request);
        request.AddCareer(career);
    }
}