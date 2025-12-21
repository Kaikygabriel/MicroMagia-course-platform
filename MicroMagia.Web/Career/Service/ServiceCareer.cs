using System.Text.Json;
using MicroMagia.Web.Career.Interfaces;
using MicroMagia.Web.Controllers.Abstraction;

namespace MicroMagia.Web.Career.Service;

public class ServiceCareer :ServiceBase, IServiceCareer
{
    public ServiceCareer(IHttpClientFactory clientFactory) : base(clientFactory)
    {
        
    }

    public async Task<IEnumerable<Domain.BackOffice.Entities.Career>> GetCareer(int skip = 0, int take = 25)
    {
        var client = _clientFactory.CreateClient("MicroMagia");
        using var response = await client.GetAsync($"Career?skip=0&take=10");
        if (!response.IsSuccessStatusCode) return null;
        var content = await response.Content.ReadAsStreamAsync();
        return JsonSerializer.Deserialize<IEnumerable<Domain.BackOffice.Entities.Career>>(content,_options);

    }
}