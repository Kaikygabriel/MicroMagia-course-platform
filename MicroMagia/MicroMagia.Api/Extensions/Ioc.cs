using MicroMagia.Application.Services;
using MicroMagia.Application.Services.Abstractions;
using MicroMagia.Application.UseCases;
using MicroMagia.Domain.BackOffice.Interfaces;
using MicroMagia.Domain.BackOffice.Interfaces.Author;
using MicroMagia.Domain.BackOffice.Interfaces.Career;
using MicroMagia.Domain.BackOffice.Interfaces.Course;
using MicroMagia.Domain.BackOffice.Interfaces.Student;
using MicroMagia.Infra.Repository;
using MicroMagia.Infra.Repository.Career;
using MicroMagia.Infra.Repository.Course;

namespace MicroMagia.Api.Extensions;

public static class Ioc
{
    public static IServiceCollection AddDependencyInjection(this IServiceCollection services)
    {
        services.AddScoped<IUnitOfWork, UnitOfWork>();
        services.AddScoped<IRegisterUserService,RegisterUserService>();

        services.AddMediatR(x => x.RegisterServicesFromAssembly(typeof(HandlerBase).Assembly));
        services.AddScoped(typeof(IRepository<>), typeof(Repository<>));
        services.AddScoped<IRepositoryCareer, RepositoryCareer>();
        services.AddScoped<IRepositoryCourse,RepositoryCourse>();
        services.AddScoped<IRepositoryAuthor,RepositoryAuthor>();
        services.AddScoped<IRepositoryStudent,StudentRepository>();

        services.AddScoped<ITokenService,TokenService>();

        return services;
    }
}
