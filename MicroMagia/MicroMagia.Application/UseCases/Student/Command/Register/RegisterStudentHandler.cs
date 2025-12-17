using MediatR;
using MicroMagia.Application.Services;
using MicroMagia.Application.Services.Abstractions;
using MicroMagia.Domain.BackOffice.Entities;
using MicroMagia.Domain.BackOffice.Interfaces;

namespace MicroMagia.Application.UseCases.Student.Command.Register;

public class RegisterStudentHandler : HandlerStudentBase, IRequestHandler<RegisterStudentCommand,string?>
{
    private readonly IRegisterUserService _userService;


    public RegisterStudentHandler(IUnitOfWork ofWork, ITokenService tokenService, IRegisterUserService userService)
        : base(ofWork, tokenService)
    {
        _userService = userService;
    }

    public async Task<string?> Handle(RegisterStudentCommand request, CancellationToken cancellationToken)
    {
        if (await StudentExisting(request.UserDto.Email))
            return null;
        var user = new User(new(request.UserDto.Email), request.UserDto.Password);
        var result = await _userService.Register(user);
        if (!result)
            return null;
        var student = new Domain.BackOffice.Entities.Student(request.name, user);
        _ofWork.RepositoryStudent.Create(student);
        await _ofWork.CommitAsync();
        
        return CreateToken(student);
    }

    private async Task<bool> StudentExisting(string email)
    {
        var studentExisting = await _ofWork.RepositoryStudent.GetByEmailOrNull(email);
        if (studentExisting is not null) return true;
        return false;
    }
}