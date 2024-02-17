using System.Collections.Specialized;
using DotNetCore.Enums;
using DotNetCore.Models;

namespace DotNetCore.Service.Interfaces;

public interface IHttpClientService
{
    Task<TResponse> RequestTo<TResponse, TRequest>(string url, TRequest request, string token = null);

    Task<TResponse> GetAsync<TResponse>(string url);

    // Task<TResponse> GetXmlAsync<TResponse>(string url) where TResponse : class;

    Task<ApiBaseResponse<string>> GetHttpGetResponseWithHeaderAsync<TBody>(string subUrl,
        NameValueCollection headers)
        where TBody : class;

    Task<ApiBaseResponse<string>> GetHttpGetResponseWithoutHeaderAsync<TBody>(string subUrl)
        where TBody : class;

    Task<ApiBaseResponse<string>> GetHttpPostResponseWithHeaderAsync<TBody>(string subUrl,
        NameValueCollection headers, TBody requestBody)
        where TBody : class;

    Task<ApiBaseResponse<string>> GetHttpPostResponseWithoutHeaderAsync<TBody>(string subUrl,
        TBody requestBody, bool isUseHttp2 = false)
        where TBody : class;

    Task<ApiBaseResponse<string>> GetHttpPostResponseWithContentType<TBody>(string subUrl, TBody requestBody,
        RequestContentTypeEnum contentType) where TBody : class;

    Task<ApiBaseResponse<string>> GetHttpPostResponseWithContentTypeAndHeader<TBody>(string subUrl,
        NameValueCollection headers, TBody requestBody, RequestContentTypeEnum contentType) where TBody : class;

    Task<ApiBaseResponse<string>> GetHttpDeleteResponseWithHeaderAsync<TBody>(string subUrl,
        NameValueCollection headers, TBody requestBody, RequestContentTypeEnum contentType) where TBody : class;

    Task<ApiBaseResponse<string>> GetHttpPatchResponseWithHeaderAsync<TBody>(string subUrl,
        NameValueCollection headers, TBody requestBody, RequestContentTypeEnum contentType) where TBody : class;

    Task<ApiBaseResponse<string>> GetHttpGetResponseRestful<TBody>(string subUrl,
        NameValueCollection headers, TBody requestBody)
        where TBody : class;

    Task<ApiBaseResponse<string>> GetHttpPostResponseRestful<TBody>(string subUrl,
        NameValueCollection headers, TBody requestBody)
        where TBody : class;
}