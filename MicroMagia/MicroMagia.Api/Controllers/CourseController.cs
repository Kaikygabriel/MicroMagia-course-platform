using MediatR;
using MicroMagia.Application.UseCases.Courses.Command.Create;
using MicroMagia.Application.UseCases.Courses.Query.GetAllCourse;
using MicroMagia.Application.UseCases.Courses.Query.GetByCareerQuery;
using MicroMagia.Application.UseCases.Courses.Query.GetById;
using MicroMagia.Infra.Data.Context;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace MicroMagia.Api.Controllers;

[ApiController]
[Route("[controller]")]
public class CourseController : ControllerBase
{
    private readonly IMediator _mediator;

    public CourseController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpPost]
    public async Task<ActionResult> Create([FromBody]CreateCourseCommand create)
    {
        var result = await _mediator.Send(create);
        return result ? Created() : BadRequest("Falha ao criar course");
    }

    [HttpGet]
    public async Task<ActionResult> GetAll([FromQuery] GetAllCourseQuery query)
    {
        var courses = await _mediator.Send(query);
        return Ok(courses);
    }
    [HttpGet("GetById")]
    public async Task<ActionResult> GetById([FromQuery] GetByIdQuery query)
    {
        var courses = await _mediator.Send(query);
        return Ok(courses);
    }
    [HttpGet("GetByCareer")]
    public async Task<ActionResult> GetById([FromQuery] GetByCareerQuery query)
    {
        var courses = await _mediator.Send(query);
        return Ok(courses);
    }
}