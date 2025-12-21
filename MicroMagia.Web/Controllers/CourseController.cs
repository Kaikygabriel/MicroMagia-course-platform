using MicroMagia.Web.Course.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace MicroMagia.Web.Controllers;

[Route("[controller]")]
public class CourseController : Controller
{
    private ICourseService _courseService;

    public CourseController(ICourseService courseService)
    {
        _courseService = courseService;
    }

    [HttpGet("Index")]
    public async Task<IActionResult> Index()
    {
        var courses = await _courseService.GetAllAsync();
        return View(courses);
    }
}