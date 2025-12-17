namespace MicroMagia.Application.Services.Abstractions;

public interface IRegisterUserService
{
  Task<bool> Register(Domain.BackOffice.Entities.User request);
}