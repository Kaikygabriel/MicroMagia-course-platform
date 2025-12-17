using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using MicroMagia.Application.Services.Abstractions;
using MicroMagia.Domain.BackOffice.Interfaces;

namespace MicroMagia.Application.UseCases.Student.Command;

public abstract class HandlerStudentBase : HandlerBase
{
    protected readonly ITokenService _tokenService;
    public HandlerStudentBase(IUnitOfWork ofWork, ITokenService tokenService) : base(ofWork)
    {
        _tokenService = tokenService;
    }
    protected string CreateToken(Domain.BackOffice.Entities.Student student)
    {
        var claims = GetClaimsOfStudent(student);
        var token = _tokenService.GenerateAccessToken(claims);
        return token;
    }

    protected IEnumerable<Claim> GetClaimsOfStudent(Domain.BackOffice.Entities.Student student)
        => new List<Claim>()
        {
            new Claim(ClaimTypes.Email, student.User.Email.Address),
            new Claim(ClaimTypes.Name, student.Name),
            new Claim(ClaimTypes.Role, "Student"),
            new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString("N"))
        };
}