using FootballApp.Exceptions;
using FootballApp.Helpers.Forms;
using FootballApp.Models.Requests;
using FootballApp.Models.Responses;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using System;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace FootballApp.Services
{
    public class ApiService
    {
        private readonly HttpClient _httpClient;
        private readonly TokenService _tokenService;
        private const string ApiBaseUrl = "http://10.0.2.2:5222";

        private readonly JsonSerializerSettings _jsonSettings = new JsonSerializerSettings
        {
            ContractResolver = new CamelCasePropertyNamesContractResolver()
        };

        public ApiService(TokenService tokenService)
        {
            _httpClient = new HttpClient();
            _httpClient.BaseAddress = new Uri(ApiBaseUrl);
            _tokenService = tokenService;
        }

        public async Task PostRegisterAsync(RegisterRequest request)
        {
            await SendAsync<RegisterRequest, RegisterResponse>(HttpMethod.Post, "/accounts/register", request, false, false);
        }

        public async Task PostLoginAsync(LoginRequest request)
        {
            var response = await SendAsync<LoginRequest, LoginResponse>(HttpMethod.Post, "/accounts/login", request, false, true);

            _tokenService.AccessToken = response.AccessToken;
        }

        public Task SendAsync(HttpMethod method, string path, bool authed) =>
            SendAsync<object, object>(method, path, null, authed, false);
        public Task SendAsync<TRequest>(HttpMethod method, string path, TRequest body, bool authed) =>
            SendAsync<TRequest, object>(method, path, body, authed, false);
        public Task<TResponse> SendAsync<TResponse>(HttpMethod method, string path, bool authed) =>
            SendAsync<object, TResponse>(method, path, null, authed, true);

        public async Task<TResponse> SendAsync<TRequest, TResponse>(HttpMethod method, string path, TRequest body,
            bool authed, bool hasResponse, bool logoutOnUnauthorized = true)
        {
            using (var requestMessage = new HttpRequestMessage())
            {
                requestMessage.Version = new Version(1, 0);
                requestMessage.Method = method;
                requestMessage.RequestUri = new Uri(path, UriKind.Relative);

                if (body != null)
                {
                    var bodyType = body.GetType();
                    if (bodyType == typeof(string))
                    {
                        requestMessage.Content = new StringContent((object)bodyType as string, Encoding.UTF8,
                            "application/x-www-form-urlencoded; charset=utf-8");
                    }
                    else if (bodyType == typeof(MultipartFormDataContent))
                    {
                        requestMessage.Content = body as MultipartFormDataContent;
                    }
                    else
                    {
                        requestMessage.Content = new StringContent(JsonConvert.SerializeObject(body, _jsonSettings),
                            Encoding.UTF8, "application/json");
                    }
                }

                if (authed)
                {
                    requestMessage.Headers.Add("Authorization", string.Concat("Bearer ", _tokenService.AccessToken));
                }
                if (hasResponse)
                {
                    requestMessage.Headers.Add("Accept", "application/json");
                }

                HttpResponseMessage response;
                try
                {
                    response = await _httpClient.SendAsync(requestMessage);
                }
                catch (Exception e)
                {
                    throw new ApiException(null, HttpStatusCode.BadGateway);
                }
                if (hasResponse && response.IsSuccessStatusCode)
                {
                    var responseJsonString = await response.Content.ReadAsStringAsync();
                    
                    return JsonConvert.DeserializeObject<TResponse>(responseJsonString);
                }
                else if (!response.IsSuccessStatusCode)
                {
                    var error = await HandleErrorAsync(response, false, authed, logoutOnUnauthorized);

                    if(error != null)
                        throw new ApiException(error.Key, error.StatusCode);

                    throw new ApiException();
                }
                return (TResponse)(object)null;
            }
        }

        private async Task<ErrorResponse> HandleErrorAsync(HttpResponseMessage response, bool tokenError,
            bool authed, bool logoutOnUnauthorized = true)
        {
            if (authed
                &&
                (
                    (tokenError && response.StatusCode == HttpStatusCode.BadRequest)
                    ||
                    (logoutOnUnauthorized && response.StatusCode == HttpStatusCode.Unauthorized)
                    ||
                    response.StatusCode == HttpStatusCode.Forbidden
                ))
            {
                // TODO should log out
                return null;
            }
            try
            {
                    var responseJsonString = await response.Content.ReadAsStringAsync();
                    var apiResponse = JsonConvert.DeserializeObject<ApiResponse>(responseJsonString);

                return new ErrorResponse(response.StatusCode, apiResponse.Key);
            }
            catch
            {
                return null;
            }
        }
    }

    public class ErrorResponse
    {
        public string Key { get; set; }
        public HttpStatusCode StatusCode { get; set; }

        public ErrorResponse(HttpStatusCode statusCode, string key)
        {
            Key = key;
            StatusCode = statusCode;
        }
    }

    public class ApiResponse
    {
        public string Key { get; set; }
    }
}
