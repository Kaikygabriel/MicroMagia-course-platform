using MicroMagia.Web.Career.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace MicroMagia.Web.Controllers;

[Route("[controller]")]
public class CareerController : Controller
{
    private readonly IServiceCareer _service;

    public CareerController(IServiceCareer service)
    {
        _service = service;
    }

    [HttpGet]
    public async Task<ActionResult> Index()
    {
        var career = await _service.GetCareer();
        return View(career);
    }
}