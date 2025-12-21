using System.Text.Json;

namespace MicroMagia.Web.Controllers.Abstraction;

public abstract class ServiceBase
{
    protected readonly IHttpClientFactory _clientFactory;
    protected readonly JsonSerializerOptions _options;
    
    public ServiceBase(IHttpClientFactory clientFactory)
    {
        _clientFactory = clientFactory;
        _options = new JsonSerializerOptions{ PropertyNameCaseInsensitive = true };
    }
}