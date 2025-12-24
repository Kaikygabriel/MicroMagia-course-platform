using System.Text.Json;
using MicroMagia.Web.Abstraction;
using MicroMagia.Web.Course.Interfaces;
using MicroMagia.Web.Course.Models;

namespace MicroMagia.Web.Course.Service;

public class CourseWebService : WebServiceBase,ICourseService
{
    public CourseWebService(IHttpClientFactory clientFactory) : base(clientFactory)
    {
    }

    public async Task<IEnumerable<Domain.BackOffice.Entities.Course>> GetAllAsync(int page = 0)
    {
        var client = _clientFactory.CreateClient("MicroMagia");
        using var response = await client.GetAsync("Course?skip=0&take=10");
        if (!response.IsSuccessStatusCode) return null;
        var content = await response.Content.ReadAsStreamAsync();
        return JsonSerializer.Deserialize<IEnumerable<Domain.BackOffice.Entities.Course>>(content,_options);
    }
   
    public Task<Domain.BackOffice.Entities.Course> GetByCareer(string career)
    {
        throw new NotImplementedException();
    }
}