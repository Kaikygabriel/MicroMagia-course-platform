using MicroMagia.Web.Student.Models;
using MicroMagia.Web.Student.Models.Login;
using MicroMagia.Web.Student.Service;
using Microsoft.AspNetCore.Mvc;

namespace MicroMagia.Web.Controllers;

[Route("[controller]")]
public class StudentsController : Controller
{
    private readonly AuthServiceStudent _authServiceStudent;

    public StudentsController(AuthServiceStudent authServiceStudent)
    {
        _authServiceStudent = authServiceStudent;
    }

    [HttpGet("Register")]
    public IActionResult Register()
    {
        return View();
    } 
    [HttpPost("Register")]
    public async Task<IActionResult> Register(StudentRegisterRequest request)
    {
        var result = await _authServiceStudent.Register(request);
        if (result is null)
            return View(request);
        Response.Cookies.Append("Token-x",result.Token);
        
        return RedirectToAction("Index","Home");
    } 
    
    [HttpGet("Login")]
    public IActionResult Login()
    {
        return View();
    } 
    [HttpPost("Login")]
    public async Task<IActionResult> Login(StudentLoginRequest request)
    {
        var result = await _authServiceStudent.login(request);
        if (result is null)
            return View(request);
        Response.Cookies.Append("Token-x",result.Token);
        
        return RedirectToAction("Index","Home");
    } 
}