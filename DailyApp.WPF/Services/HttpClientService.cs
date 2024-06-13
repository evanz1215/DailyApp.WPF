using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace DailyApp.WPF.Services;

public class HttpClientService : IHttpClientService
{
    private readonly IHttpClientFactory _httpClientFactory;

    public HttpClientService(IHttpClientFactory httpClientFactory)
    {
        _httpClientFactory = httpClientFactory;
    }

    public Task<string> GetAsync(string clientName, string uri, object queryParams = null)
    {
        var result = "result";

        return Task.FromResult(result);
    }

    public Task<string> PostAsync(string clientName, string uri, object data)
    {
        var result = "result";

        return Task.FromResult(result);
    }
}