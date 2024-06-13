using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DailyApp.WPF.Services;

public interface IHttpClientService
{
    Task<string> GetAsync(string clientName, string uri, object queryParams = null);
    Task<string> PostAsync(string clientName, string uri, object data);
}
