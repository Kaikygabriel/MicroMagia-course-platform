namespace MicroMagia.Domain.BackOffice.Interfaces.Author;

public interface IRepositoryAuthor : IRepository<Entities.Author>
{
    Task<Entities.Author?> GetByEmailOrNull(string email);
}