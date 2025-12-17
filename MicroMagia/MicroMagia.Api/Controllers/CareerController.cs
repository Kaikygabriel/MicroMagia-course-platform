using MediatR;
using MicroMagia.Application.UseCases.Career.Command.AddCourse;
using MicroMagia.Application.UseCases.Career.Command.Create;
using MicroMagia.Application.UseCases.Career.Query.GetAll;
using Microsoft.AspNetCore.Mvc;

namespace MicroMagia.Api.Controllers;

[ApiController]
[Route("[controller]")]
public class CareerController : ControllerBase
{
    private readonly IMediator _mediator;

    public CareerController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpPost]
    public async Task<ActionResult> Create([FromBody] CreateCareerCommand request)
    {
        var result = await _mediator.Send(request);
        return result ? Created() : BadRequest("Falha ao criar career");
    }

    [HttpGet]
    public async Task<ActionResult> GetAll([FromQuery]GetAllCareerQuery query)
    {
        var careers = await _mediator.Send(query);
        return Ok(careers);
    }
    [HttpPost("AddCourse")]
    public async Task<ActionResult> AddCourse([FromBody] AddCourseCommand request)
    {
        var result = await _mediator.Send(request);
        return result ? Created() : BadRequest("Falha ao add course in career");
    }
}