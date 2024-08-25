using System.Net;
using Newtonsoft.Json;
using RestSharp;
using ScadaAPI.Logic.Config;

namespace ScadaAPI.Logic.API;

/// <summary>
/// Base class for API operations.
/// </summary>
public class BaseApi
{
    /// <summary>
    /// The base URL of the API.
    /// </summary>
    protected readonly string BaseUrl = $"{AppSettings.Configuration.BaseUrl}";

    /// <summary>
    /// The RestClient instance used for making API requests.
    /// </summary>
    private readonly RestClient _client;

    /// <summary>
    /// Initializes a new instance of the <see cref="BaseApi"/> class.
    /// </summary>
    protected BaseApi()
    {
        _client = new RestClient(BaseUrl);
    }

    /// <summary>
    /// Executes the API request with deserialization of the response content.
    /// </summary>
    /// <typeparam name="T">The type to deserialize the response content to.</typeparam>
    /// <param name="method">The HTTP method.</param>
    /// <param name="endPoint">The API endpoint.</param>
    /// <param name="body">The request body.</param>
    /// <param name="expectedStatusCode">The expected HTTP status code.</param>
    /// <returns>The deserialized response content.</returns>
    protected virtual T ExecuteWithDeserialization<T>(Method method, string endPoint, object body, HttpStatusCode? expectedStatusCode)
    {
        var content = Execute(method, endPoint, body, expectedStatusCode).Content;
        return content == null ? default : JsonConvert.DeserializeObject<T>(content);
    }

    /// <summary>
    /// Executes the API request without deserialization of the response content.
    /// </summary>
    /// <param name="method">The HTTP method.</param>
    /// <param name="endPoint">The API endpoint.</param>
    /// <param name="body">The request body.</param>
    /// <param name="expectedStatusCode">The expected HTTP status code.</param>
    /// <returns>The raw response.</returns>
    protected virtual RestResponse ExecuteWithoutDeserialization(Method method, string endPoint, object body, HttpStatusCode? expectedStatusCode)
    {
        return Execute(method, endPoint, body, expectedStatusCode);
    }

    /// <summary>
    /// Executes the API request.
    /// </summary>
    /// <param name="method">The HTTP method.</param>
    /// <param name="endPoint">The API endpoint.</param>
    /// <param name="body">The request body.</param>
    /// <param name="expectedStatusCode">The expected HTTP status code.</param>
    /// <returns>The response.</returns>
    protected virtual RestResponse Execute(Method method, string endPoint, object body, HttpStatusCode? expectedStatusCode)
    {
        var request = new RestRequest(endPoint, method)
        {
            RequestFormat = DataFormat.Json,
        };

        AddHeader(request);
        AddAuthorization(request);

        if (body != null)
        {
            request.AddJsonBody(JsonConvert.SerializeObject(body));
        }

        var response = _client.Execute(request);

        if (expectedStatusCode != response.StatusCode)
        {
            throw new InvalidOperationException($"Request failed with code {response.StatusCode}\r\nmessage {response.Content}");
        }

        return response;
    }

    /// <summary>
    /// Adds headers to the API request.
    /// </summary>
    /// <param name="request">The API request.</param>
    protected virtual void AddHeader(RestRequest request)
    {
    }

    /// <summary>
    /// Adds authorization to the API request.
    /// </summary>
    /// <param name="request">The API request.</param>
    protected virtual void AddAuthorization(RestRequest request)
    {
    }
}