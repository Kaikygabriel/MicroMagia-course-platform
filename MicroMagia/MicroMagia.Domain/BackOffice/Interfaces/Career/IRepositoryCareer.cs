namespace MicroMagia.Domain.BackOffice.Interfaces.Career;

public interface IRepositoryCareer : IRepository<Entities.Career>
{
    Task<IEnumerable<Entities.Course>> GetAllByCareer(string title);

}