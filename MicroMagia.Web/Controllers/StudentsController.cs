using MicroMagia.Web.Student.Models;
using MicroMagia.Web.Student.Models.Login;
using MicroMagia.Web.Student.Service;
using Microsoft.AspNetCore.Mvc;

namespace MicroMagia.Web.Controllers;

[Route("[controller]")]
public class StudentsController : Controller
{
    private const string COOKIES_EMAIL = "Email-x";

    private const string COOKIES_TOKEN = "Token-x";
    private readonly AuthServiceStudent _authServiceStudent;

    public StudentsController(AuthServiceStudent authServiceStudent)
    {
        _authServiceStudent = authServiceStudent;
    }

    [HttpGet("Register")]
    public IActionResult Register()
    {
        if(TokenExists())
            return RedirectToAction("Index","Home");
        return View();
    } 
    [HttpPost("Register")]
    public async Task<IActionResult> Register(StudentRegisterRequest request)
    {
        var result = await _authServiceStudent.Register(request);
        if (result is null)
            return View(request);
        CreateCookies(result);
        
        return RedirectToAction("Index","Home");
    } 
    
    [HttpGet("Login")]
    public IActionResult Login()
    {
        if(TokenExists())
            return RedirectToAction("Index","Home");
        return View();
    } 
    [HttpPost("Login")]
    public async Task<IActionResult> Login(StudentLoginRequest request)
    {
        var result = await _authServiceStudent.login(request);
        if (result is null)
            return View(request);
        CreateCookies(result);
        
        return RedirectToAction("Index","Home");
    }

    private bool TokenExists()
    {
        if (Request.Cookies.TryGetValue(COOKIES_TOKEN, out string tokenCookie))
            return true;
        return false;
    }

    private void CreateCookies(StudentAuthResponse model)
    {
        Response.Cookies.Append(COOKIES_TOKEN,model.Token);
        Response.Cookies.Append(COOKIES_EMAIL,model.Email);
    }
}