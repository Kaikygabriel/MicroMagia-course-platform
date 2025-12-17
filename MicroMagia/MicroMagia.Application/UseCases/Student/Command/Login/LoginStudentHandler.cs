using System.Security.Claims;
using MediatR;
using MicroMagia.Application.Services;
using MicroMagia.Application.Services.Abstractions;
using MicroMagia.Domain.BackOffice.Interfaces;
using Microsoft.IdentityModel.JsonWebTokens;

namespace MicroMagia.Application.UseCases.Student.Command.Login;

public class LoginStudentHandler :HandlerStudentBase, IRequestHandler<LoginStudentCommand,string?>
{
    public LoginStudentHandler(IUnitOfWork ofWork, ITokenService tokenService) : base(ofWork, tokenService)
    {
    }

    public async Task<string?> Handle(LoginStudentCommand request, CancellationToken cancellationToken)
    {
        var student = await _ofWork.RepositoryStudent.GetByEmailOrNull(request.AddressEmail);
        if (student is null || !ServiceCheckPassword.VerifyPassword(student.User.Password, request.Password))
            return null;
        return CreateToken(student);
    }
}