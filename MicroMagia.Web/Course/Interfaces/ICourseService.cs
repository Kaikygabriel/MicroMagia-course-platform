using MicroMagia.Web.Course.Models;

namespace MicroMagia.Web.Course.Interfaces;

public interface ICourseService
{
    Task<IEnumerable<Domain.BackOffice.Entities.Course>> GetAllAsync(int page = 0);
    Task<Domain.BackOffice.Entities.Course> GetByCareer(string career);
}