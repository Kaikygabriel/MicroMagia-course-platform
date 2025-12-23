using System.Text;
using System.Text.Json;
using MicroMagia.Web.Abstraction;
using MicroMagia.Web.Student.Models;
using MicroMagia.Web.Student.Models.Login;

namespace MicroMagia.Web.Student.Service;

public class AuthServiceStudent : WebServiceBase
{
    private const string NameClient =  "MicroMagia";
    public AuthServiceStudent(IHttpClientFactory clientFactory) : base(clientFactory)
    {
    }

    public async Task<StudentAuthResponse?> Register(StudentRegisterRequest request)
    {
        var client = _clientFactory.CreateClient(NameClient);
        var requestContent =CreateStringContentOfModel(JsonSerializer.Serialize(request));
        
        using var response = await client.PostAsync("Student/Register", requestContent);
        if (!response.IsSuccessStatusCode) return null;
        var token = await response.Content.ReadAsStringAsync();
        return GenerateResponseOfResponse(token,request.userDto.Email);
    }
    public async Task<StudentAuthResponse?> login(StudentLoginRequest request)
    {
        var client = _clientFactory.CreateClient(NameClient);
        var requestContent = CreateStringContentOfModel(JsonSerializer.Serialize(request));
        
        using var response = await client.PostAsync("Student/Login", requestContent);
        if (!response.IsSuccessStatusCode) return null;
        var token = await response.Content.ReadAsStringAsync();
        return GenerateResponseOfResponse(token,request.addressEmail);
    }

    private StringContent CreateStringContentOfModel(string model)
    {
        return new StringContent(model, Encoding.UTF8, "application/json");
    }

    private StudentAuthResponse GenerateResponseOfResponse(string token,string email)
    {
        return new StudentAuthResponse(token,email);
    }
}