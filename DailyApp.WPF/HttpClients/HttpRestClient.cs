using Newtonsoft.Json;
using RestSharp;

namespace DailyApp.WPF.HttpClients;

public class HttpRestClient
{
    private readonly string baseUrl = "https://localhost:7265/api/";

    public HttpRestClient()
    {
    }

    public ApiResponse Execute(ApiRequest apiRequest)
    {
        var client = new RestClient($"{baseUrl}{apiRequest.Route}");

        var request = new RestRequest(apiRequest.Route, apiRequest.Method);
        request.AddHeader("Content-Type", apiRequest.ContentType);

        if (apiRequest.Parameters != null)
        {
            request.AddParameter("param", JsonConvert.SerializeObject(apiRequest.Parameters), ParameterType.RequestBody);
        }

        var res = client.Execute(request);

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