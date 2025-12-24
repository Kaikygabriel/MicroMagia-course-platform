namespace MicroMagia.Web.Career.Interfaces;

public interface IServiceCareer
{
    Task<IEnumerable<Domain.BackOffice.Entities.Career>> GetCareer(int skip = 0, int take = 25);
    Task<IEnumerable<Domain.BackOffice.Entities.Course>> GetCoursesByCareer(string titleCareer, int page = 0);

}