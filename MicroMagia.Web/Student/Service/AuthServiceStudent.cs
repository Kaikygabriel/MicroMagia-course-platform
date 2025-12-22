using System.Text;
using System.Text.Json;
using MicroMagia.Web.Abstraction;
using MicroMagia.Web.Student.Models;
using MicroMagia.Web.Student.Models.Login;

namespace MicroMagia.Web.Student.Service;

public class AuthServiceStudent : WebServiceBase
{
    public AuthServiceStudent(IHttpClientFactory clientFactory) : base(clientFactory)
    {
    }

    public async Task<StudentAuthResponse?> Register(StudentRegisterRequest request)
    {
        var client = _clientFactory.CreateClient("MicroMagia");
        var requestContent = 
            new StringContent(JsonSerializer.Serialize(request), Encoding.UTF8, "application/json");
        using var response = await client.PostAsync("Student/Register", requestContent);
        if (!response.IsSuccessStatusCode) return null;
        var token = await response.Content.ReadAsStringAsync();
        return new StudentAuthResponse(){ Token = token };
    }
    public async Task<StudentAuthResponse?> login(StudentLoginRequest request)
    {
        var client = _clientFactory.CreateClient("MicroMagia");
        var requestContent = 
            new StringContent(JsonSerializer.Serialize(request), Encoding.UTF8, "application/json");
        using var response = await client.PostAsync("Student/Login", requestContent);
        if (!response.IsSuccessStatusCode) return null;
        var token = await response.Content.ReadAsStringAsync();
        return new StudentAuthResponse(){ Token = token };
    }
}