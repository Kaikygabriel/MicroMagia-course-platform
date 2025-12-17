using MediatR;
using MicroMagia.Application.UseCases.Student.Command.Login;
using MicroMagia.Application.UseCases.Student.Command.Register;
using Microsoft.AspNetCore.Mvc;

namespace MicroMagia.Api.Controllers;

[ApiController]
[Route("[controller]")]
public class StudentController : ControllerBase
{
    private readonly IMediator _mediator;

    public StudentController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpPost("Register")]
    public async Task<ActionResult> Register([FromBody] RegisterStudentCommand request)
    {
        var result = await _mediator.Send(request);
        return result is not null ? Ok(result) : BadRequest("Falha ao registrar student!");
    }
    [HttpPost("Login")]
    public async Task<ActionResult> Login([FromBody] LoginStudentCommand request)
    {
        var result = await _mediator.Send(request);
        return result is not null ? Ok(result) : BadRequest("Falha ao logar student!");
    }
}