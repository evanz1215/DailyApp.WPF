using Newtonsoft.Json;
using RestSharp;

namespace DailyApp.WPF.HttpClients;

public class HttpRestClient
{
    private readonly string baseUrl = "http://localhost:5017/api/";
    private readonly RestClient _client;

    public HttpRestClient()
    {
        _client = new RestClient();
    }

    public ApiResponse Execute(ApiRequest apiRequest)
    {
        RestRequest request = new RestRequest(apiRequest.Method);
        request.AddHeader("Content-Type", apiRequest.ContentType);

        if (apiRequest.Parameters != null)
        {
            request.AddParameter("param", JsonConvert.SerializeObject(apiRequest.Parameters), ParameterType.RequestBody);
        }

        _client.BaseUrl = new Uri(baseUrl + apiRequest.Route);
        var res = _client.Execute(request);

        if (res.StatusCode == System.Net.HttpStatusCode.OK)
        {
            return JsonConvert.DeserializeObject<ApiResponse>(res.Content);
        }
        else
        {
            return new ApiResponse
            {
                ResultCode = -1,
                Msg = res.ErrorMessage
            };
        }
    }
}