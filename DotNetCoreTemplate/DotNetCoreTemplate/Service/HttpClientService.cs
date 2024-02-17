using System.Collections.Specialized;
using System.Net;
using System.Net.Http.Headers;
using System.Text;
using DotNetCore.Enums;
using DotNetCore.Exceptions;
using DotNetCore.Helpers;
using DotNetCore.Models;
using DotNetCore.Service.Interfaces;
using Newtonsoft.Json;

namespace DotNetCore.Service;

public class HttpClientService : IHttpClientService
{
    #region Fields

    private readonly HttpClient _httpClient;
    private readonly ILoggerService _logger;
    private readonly IHttpContextAccessor _httpContextAccessor;

    #endregion Fields

    #region Constructor

    public HttpClientService(HttpClient httpClient, ILoggerService logger, IHttpContextAccessor httpContextAccessor)
    {
        _logger = logger;
        _httpContextAccessor = httpContextAccessor;
        _httpClient = httpClient;
    }

    #endregion Constructor

    #region Customer Http Client

    public async Task<TResponse> RequestTo<TResponse, TRequest>(string requestUrl, TRequest requestBody, string token = null)
    {
        var traceId = GetTraceId();
        ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12;

        _logger.Info(
            $"[Send][Request] URL :: {requestUrl}, RequestBody : {JsonConvert.SerializeObject(requestBody)}");

        try
        {
            var stringContent = new StringContent(JsonConvert.SerializeObject(requestBody), Encoding.UTF8,
                "application/json");
            stringContent.Headers.Add(NlogTag.TraceId, traceId);
            
            if (!string.IsNullOrEmpty(token))
            {
                _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue(token);
            }

            var response = await _httpClient.PostAsync(requestUrl, stringContent);
            if (response.IsSuccessStatusCode)
            {
                var readAsStringAsync = await response.Content.ReadAsStringAsync();
                _logger.Info($"[Send][Response] ResponseBody : {readAsStringAsync}");
                return DeserializeObject<TResponse>(readAsStringAsync);
            }

            _logger.Error(
                $"[Send][Response] Http Status Error: {response.StatusCode}, ResponseBody : {await response.Content.ReadAsStringAsync()}");
        }
        catch (Exception e)
        {
            _logger.Error(
                $"[Send][Response] ResponseBody null or empty due to exception occurred", e);
            throw new ApiException(ApiErrorEnum.ApiRequestException, e.Message);
        }

        return default;
    }

    #endregion Customer Http Client

    #region Http GET

    public async Task<ApiBaseResponse<string>> GetHttpGetResponseWithHeaderAsync<TBody>(string subUrl,
        NameValueCollection headers)
        where TBody : class
    {
        return await GetResponseAsync(HttpMethod.Get, subUrl, headers, default(TBody));
    }

    public async Task<ApiBaseResponse<string>> GetHttpGetResponseWithoutHeaderAsync<TBody>(string subUrl)
        where TBody : class
    {
        return await GetResponseAsync(HttpMethod.Get, subUrl, new NameValueCollection(), default(TBody));
    }

    public async Task<ApiBaseResponse<string>> GetHttpGetResponseRestful<TBody>(string subUrl,
        NameValueCollection headers, TBody requestBody) where TBody : class
    {
        return await GetResponseRestful(HttpMethod.Get, subUrl, headers, requestBody);
    }

    public async Task<TResponse> GetAsync<TResponse>(string requestUrl)
    {
        try
        {
            return DeserializeObject<TResponse>(await GetFromApiAsync(requestUrl));
        }
        catch (ApiException)
        {
            throw;
        }
        catch (Exception ex)
        {
            _logger.Error(
                $"[GET][Send][Response] ResponseBody null or empty due to exception occurred", ex);
            throw new ApiException(ApiErrorEnum.ApiRequestException, ex.Message);
        }
    }

    // public async Task<TResponse> GetXmlAsync<TResponse>(string requestUrl) where TResponse : class
    // {
    //     try
    //     {
    //         return DeserializeXmlObject<TResponse>(await GetFromApiAsync(requestUrl));
    //     }
    //     catch (ApiException)
    //     {
    //         throw;
    //     }
    //     catch (Exception ex)
    //     {
    //         _logger.Error(
    //             $"[GET][Send][Response] ResponseBody null or empty due to exception occurred", ex);
    //         throw new ApiException(ApiErrorEnum.ApiRequestException, ex.Message);
    //     }
    // }

    public async Task<string> GetFromApiAsync(string requestUrl)
    {
        GetTraceId();
        ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12;

        _logger.Info(
            $"[GET][Send][Request] URL :: {requestUrl}");

        try
        {
            var response = await _httpClient.GetAsync(requestUrl);

            var readAsStringAsync = await response.Content.ReadAsStringAsync();
            if (response.IsSuccessStatusCode)
            {
                _logger.Info($"[GET][Send][Response] Response : {readAsStringAsync}");
                return readAsStringAsync;
            }

            _logger.Error(
                $"[GET][Send][Response] Http Status Error: {response.StatusCode}, Response : {readAsStringAsync}");
            return readAsStringAsync;
        }
        catch (Exception e)
        {
            _logger.Error(
                $"[GET][Send][Response] ResponseBody null or empty due to exception occurred", e);
            throw new ApiException(ApiErrorEnum.ApiRequestException, e.Message);
        }
    }

    #endregion Http GET

    #region Http POST

    public async Task<ApiBaseResponse<string>> GetHttpPostResponseWithHeaderAsync<TBody>(string subUrl,
        NameValueCollection headers, TBody requestBody)
        where TBody : class
    {
        return await GetResponseAsync(HttpMethod.Post, subUrl, headers, requestBody);
    }

    public async Task<ApiBaseResponse<string>> GetHttpPostResponseWithoutHeaderAsync<TBody>(string subUrl,
        TBody requestBody, bool isUseHttp2 = false)
        where TBody : class
    {
        return await GetResponseAsync(HttpMethod.Post, subUrl, new NameValueCollection(), requestBody,
            isUseHttp2: isUseHttp2);
    }

    public async Task<ApiBaseResponse<string>> GetHttpPostResponseWithContentType<TBody>(string subUrl,
        TBody requestBody, RequestContentTypeEnum contentType) where TBody : class
    {
        return await GetResponseAsync(HttpMethod.Post, subUrl, new NameValueCollection(), requestBody, contentType);
    }

    public async Task<ApiBaseResponse<string>> GetHttpPostResponseWithContentTypeAndHeader<TBody>(string subUrl,
        NameValueCollection headers, TBody requestBody, RequestContentTypeEnum contentType) where TBody : class
    {
        return await GetResponseAsync(HttpMethod.Post, subUrl, headers, requestBody, contentType);
    }

    public async Task<ApiBaseResponse<string>> GetHttpPatchResponseWithHeaderAsync<TBody>(string subUrl,
        NameValueCollection headers, TBody requestBody,
        RequestContentTypeEnum contentType) where TBody : class
    {
        return await GetResponseAsync(new HttpMethod("PATCH"), subUrl, headers, requestBody, contentType);
    }

    public async Task<ApiBaseResponse<string>> GetHttpDeleteResponseWithHeaderAsync<TBody>(string subUrl,
        NameValueCollection headers, TBody requestBody,
        RequestContentTypeEnum contentType) where TBody : class
    {
        return await GetResponseAsync(new HttpMethod("DELETE"), subUrl, headers, requestBody, contentType);
    }

    public async Task<ApiBaseResponse<string>> GetHttpPostResponseRestful<TBody>(string subUrl,
        NameValueCollection headers, TBody requestBody) where TBody : class
    {
        return await GetResponseRestful(HttpMethod.Post, subUrl, headers, requestBody);
    }

    #endregion Http POST

    #region Private Method

    private async Task<ApiBaseResponse<string>> GetResponseAsync<TBody>(HttpMethod httpMethod, string requestUrl,
        NameValueCollection headers, TBody requestBody,
        RequestContentTypeEnum contentTypeEnum = RequestContentTypeEnum.Json, bool isUseHttp2 = false)
        where TBody : class
    {
        ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12;
        try
        {
            var request = new HttpRequestMessage()
            {
                Method = httpMethod,
                RequestUri = new Uri(requestUrl, UriKind.RelativeOrAbsolute),
            };

            if (isUseHttp2)
            {
                request.Version = new Version(2, 0);
            }

            if (contentTypeEnum == RequestContentTypeEnum.XWwwFormUrlEncoded)
            {
                request.Content =
                    new FormUrlEncodedContent(requestBody as IEnumerable<KeyValuePair<string, string>>);
            }
            else if (httpMethod.Equals(HttpMethod.Post))
            {
                request.Content = new StringContent(JsonConvert.SerializeObject(requestBody), Encoding.UTF8,
                    "application/json");
            }

            var traceId = GetTraceId();
            request.Headers.Add(NlogTag.TraceId, traceId);

            foreach (string header in headers)
            {
                request.Headers.Add(header, headers[header]);
            }

            _logger.Info(
                $"[Send][Request] URL :: {requestUrl}, Header :: {JsonConvert.SerializeObject(headers) ?? "None"}, RequestBody : {JsonConvert.SerializeObject(requestBody)}");

            var response = await _httpClient.SendAsync(request);

            ApiBaseResponse<string> result;

            if (response.IsSuccessStatusCode)
            {
                string responseString;
                using (var stream = new StreamReader(await response.Content.ReadAsStreamAsync()))
                {
                    responseString = await stream.ReadToEndAsync();
                }

                _logger.Info(
                    $"[Send][Response] URL :: {requestUrl}, StatusCode :: {(int)response.StatusCode}, ResponseBody :: {responseString}");
                result = new ApiBaseResponse<string>(responseString);
            }
            else
            {
                _logger.Error(
                    $"[Send][Response] URL :: {requestUrl}, StatusCode :: {(int)response.StatusCode}, ResponseBody :: {await response.Content.ReadAsStringAsync()}");
                result = new ApiBaseResponse<string>(ApiErrorEnum.ApiReturnNot200);
            }

            result.ErrorMessage = response.StatusCode.ToString();

            return result;
        }
        catch (Exception e)
        {
            _logger.Error(
                $"[Send][Response] URL :: {requestUrl}, ResponseBody null or empty due to exception occurred", e);
            throw new ApiException(ApiErrorEnum.ApiRequestException, e.Message);
        }
    }

    private async Task<ApiBaseResponse<string>> GetResponseRestful<TBody>(HttpMethod httpMethod, string requestUrl,
        NameValueCollection headers, TBody requestBody,
        RequestContentTypeEnum contentTypeEnum = RequestContentTypeEnum.Json, bool isUseHttp2 = false)
        where TBody : class
    {
        var guId = Guid.NewGuid().ToString("N")[..8];
        ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12;
        try
        {
            var request = new HttpRequestMessage()
            {
                Method = httpMethod,
                RequestUri = new Uri(requestUrl, UriKind.RelativeOrAbsolute),
            };

            if (isUseHttp2)
            {
                request.Version = new Version(2, 0);
            }

            if (contentTypeEnum == RequestContentTypeEnum.XWwwFormUrlEncoded)
            {
                request.Content =
                    new FormUrlEncodedContent(requestBody as IEnumerable<KeyValuePair<string, string>>);
            }
            else if (httpMethod.Equals(HttpMethod.Post))
            {
                request.Content = new StringContent(JsonConvert.SerializeObject(requestBody), Encoding.UTF8,
                    "application/json");
            }

            var traceId = GetTraceId();
            request.Headers.Add(NlogTag.TraceId, traceId);

            foreach (string header in headers)
            {
                request.Headers.Add(header, headers[header]);
            }

            _logger.Info(
                $"[{guId}][Send][Request] URL :: {requestUrl}, Header :: {JsonConvert.SerializeObject(headers) ?? "None"}, RequestBody : {JsonConvert.SerializeObject(requestBody)}");

            var response = await _httpClient.SendAsync(request);


            string responseString;
            using (var stream = new StreamReader(await response.Content.ReadAsStreamAsync()))
            {
                responseString = await stream.ReadToEndAsync();
            }

            _logger.Info(
                $"[{guId}][Send][Response] URL :: {requestUrl}, StatusCode :: {(int)response.StatusCode}, ResponseBody :: {responseString}");

            var result = new ApiBaseResponse<string>(responseString)
            {
                ErrorMessage = response.StatusCode.ToString()
            };

            return result;
        }
        catch (Exception e)
        {
            _logger.Error(
                $"[{guId}][Send][Response] URL :: {requestUrl}, ResponseBody null or empty due to exception occurred :: {e}");
            throw new ApiException(ApiErrorEnum.ApiRequestException, e.Message);
        }
    }

    private TResponse DeserializeObject<TResponse>(string readAsStringAsync)
    {
        if (typeof(TResponse) == typeof(string))
        {
            return (TResponse)Convert.ChangeType(readAsStringAsync, typeof(TResponse));
        }

        return JsonConvert.DeserializeObject<TResponse>(readAsStringAsync);
    }
    
    // private TResponse DeserializeXmlObject<TResponse>(string readAsStringAsync) where TResponse : class
    // {
    //     return TiXmlHelper.Deserialize<TResponse>(readAsStringAsync);
    // }

    private string GetTraceId()
    {
        if (!NlogContextHelper.TryGetScopeProperty(NlogTag.TraceId, out object traceId) ||
            string.IsNullOrEmpty(traceId?.ToString()))
        {
            string newTraceId = Guid.NewGuid().ToString().Replace("-", "");

            NlogContextHelper.PushScopeProperty(NlogTag.TraceId, newTraceId);
            return newTraceId;
        }

        return traceId.ToString();
    }

    #endregion Private Method
}