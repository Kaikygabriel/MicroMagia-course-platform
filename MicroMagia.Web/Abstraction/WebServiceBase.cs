using System.Text.Json;

namespace MicroMagia.Web.Abstraction;

public abstract class WebServiceBase
{
    protected readonly IHttpClientFactory _clientFactory;
    protected readonly JsonSerializerOptions _options;
    
    public WebServiceBase(IHttpClientFactory clientFactory)
    {
        _clientFactory = clientFactory;
        _options = new JsonSerializerOptions{ PropertyNameCaseInsensitive = true };
    }
}