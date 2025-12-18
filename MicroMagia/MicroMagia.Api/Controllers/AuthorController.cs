using MediatR;
using MicroMagia.Application.UseCases.Author.Command.Login;
using MicroMagia.Application.UseCases.Author.Command.Register;
using MicroMagia.Application.UseCases.Student.Command.Login;
using MicroMagia.Application.UseCases.Student.Command.Register;
using Microsoft.AspNetCore.Mvc;

namespace MicroMagia.Api.Controllers;

[ApiController]
[Route("[controller]")]
public class AuthorController : ControllerBase
{
    private readonly IMediator _mediator;

    public AuthorController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpPost("Register")]
    public async Task<ActionResult> Register([FromBody] RegisterAuthorCommand request)
    {
        var result = await _mediator.Send(request);
        return result is not null ? Ok(result) : BadRequest("Falha ao registrar author!");
    }
    [HttpPost("Login")]
    public async Task<ActionResult> Login([FromBody] LoginAuthorCommand request)
    {
        var result = await _mediator.Send(request);
        return result is not null ? Ok(result) : BadRequest("Falha ao logar author!");
    }
}