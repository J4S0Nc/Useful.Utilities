using System;
using System.Diagnostics;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using Useful.Utilities.Useful.Utilities.Web.Models;

namespace Useful.Utilities
{


    /// <summary>
    /// Base class for building Web Clients that take and return typed objects. 
    /// </summary>
    /// <code lang="C#">
    /// //Example client class using JSON.Net 
    /// public class JsonWebClient : WebBase
    /// {
    ///    protected override T DeserializeObject&lt;T&gt;(string content)
    ///    {
    ///        return JsonConvert.DeserializeObject&lt;T&gt;(content);
    ///    }
    ///    public override HttpContent SerializeObject(object content)
    ///    {
    ///        return new JsonContent(JsonConvert.SerializeObject(content));
    ///    }
    ///    public override string BaseUrl { get { return "http://SomeUrl/MyApp/"; } }
    /// }
    /// </code>
    public abstract class WebBase
    {


        /// <summary>
        /// Abstract hook for wiring object deserialization
        /// </summary>
        /// <code lang="C#">
        /// //Using Json.Net
        /// return JsonConvert.DeserializeObject&lt;T&gt;(content)
        /// </code>
        /// <typeparam name="T">The Type to deserialize the string in to</typeparam>
        /// <param name="content">Body of the request</param>
        /// <returns></returns>
        protected abstract T DeserializeObject<T>(string content);

        /// <summary>
        /// Abstract hook for wiring object serialization
        /// </summary>
        /// <code lang="C#">
        /// //Using Json.Net
        /// return new JsonContent(JsonConvert.SerializeObject(content));
        /// </code>
        /// <param name="content">Body of the request</param>
        /// <returns></returns>
        public abstract HttpContent SerializeObject(object content);

        /// <summary>
        /// Base URL that can be prepended to requests
        /// </summary>
        public abstract string BaseUrl { get; }


        /// <summary>
        /// Build an HTTP Client and sent a request to the given URL. 
        /// The resulting status will be validated to match the expected status parameter
        /// </summary>
        /// <param name="uri">The URI to send the request to</param>
        /// <param name="content">Body of the request, This is not valid on GET requests</param>
        /// <param name="expectedStatus">Expected status will be checked against the response status code</param>
        /// <param name="method">HTTP Method of the request: GET, POST, PUT, DELETE</param>
        /// <param name="preRequest">Optional action that can modify the request object before it is sent</param>
        /// <returns></returns>
        public HttpResponse Go(Uri uri, HttpContent content = null, HttpStatusCode expectedStatus = HttpStatusCode.OK, Method method = Method.GET, Action<HttpRequestMessage> preRequest = null)
        {
            Debug.WriteLine(method + ": " + uri.AbsoluteUri);

            var client = new HttpClient();
#if DEBUG
            client.Timeout = TimeSpan.FromMinutes(15);//hold for debugger
#endif

            var request = new HttpRequestMessage()
            {
                RequestUri = uri,
                Method = new HttpMethod(method.ToString()),
            };
            if (method == Method.GET && content != null)
                throw new InvalidOperationException("A content body is not valid on a GET request");

            if (content != null)
                request.Content = content;

            preRequest?.Invoke(request);

            var response = client.SendAsync(request).Result;
            var body = response.Content.ReadAsStringAsync().Result;

            Debug.WriteLine(response.StatusCode + ": " + body);

            if ((int)expectedStatus < 299 && !response.IsSuccessStatusCode)
                throw new WebException("Response Status was not successful. Status is: " + response.StatusCode);
            if (expectedStatus != response.StatusCode)
                throw new WebException("Response Status was not expected. Status is: " + response.StatusCode + ", but expected: " + expectedStatus);

            return new HttpResponse { RawContent = body, Response = response };
        }


        /// <summary>
        /// Build an HTTP Client and sent a typed request to the given URL. 
        /// The response will be deserialized into a typed response object. 
        /// The requested type and response type can be different types. 
        /// The resulting status will be validated to match the expected status parameter.
        /// </summary>
        /// <typeparam name="TO">Type of HTTP response content object</typeparam>
        /// <typeparam name="T">Type of the request content object</typeparam>
        /// <param name="uri">The URI to send the request to</param>
        /// <param name="content">Body of the request, This is not valid on GET requests</param>
        /// <param name="expectedStatus">Expected status will be checked against the response status code</param>
        /// <param name="method">HTTP Method of the request: GET, POST, PUT, DELETE</param>
        /// <param name="preRequest">Optional action that can modify the request object before it is sent</param>
        /// <returns></returns>
        public HttpResponse<TO> Go<TO, T>(Uri uri, T content, HttpStatusCode expectedStatus = HttpStatusCode.OK, Method method = Method.GET, Action<HttpRequestMessage> preRequest = null)
        {
            HttpContent data = content as HttpContent;
            if (content != null && data == null)
            {
                data = SerializeObject(content);
            }
            var resp = Go(uri, data, expectedStatus, method, preRequest);

            var typedResp = new HttpResponse<TO>
            {
                RawContent = resp.RawContent,
                Response = resp.Response,
                Content = DeserializeObject<TO>(resp.RawContent)
            };
            if (expectedStatus == HttpStatusCode.NoContent) return typedResp;
            if (typedResp.Content == null) throw new NullReferenceException("Response Content is Null");

            return typedResp;
        }

        /// <summary>
        /// Build an HTTP Client and sent a typed request to the given URL. 
        /// The response will be deserialized into a typed response object. 
        /// The request type and response type will be the same. 
        /// The resulting status will be validated to match the expected status parameter.
        /// </summary>
        /// <typeparam name="T">The type of the request and response objects</typeparam>
        /// <param name="uri">The URI to send the request to</param>
        /// <param name="content">Body of the request, This is not valid on GET requests</param>
        /// <param name="expectedStatus">Expected status will be checked against the response status code</param>
        /// <param name="method">HTTP Method of the request: GET, POST, PUT, DELETE</param>
        /// <param name="preRequest">Optional action that can modify the request object before it is sent</param>
        /// <returns></returns>
        public HttpResponse<T> Go<T>(Uri uri, T content, HttpStatusCode expectedStatus = HttpStatusCode.OK, Method method = Method.GET, Action<HttpRequestMessage> preRequest = null)
        {
            return Go<T, T>(uri, content, expectedStatus, method, preRequest);
        }

        /// <summary>
        /// Takes a string URL and converts it to a URI object. 
        /// If the string starts with http:// or https:// it is simply returned. 
        /// Else the BaseUrl property is prepended to the URL.
        /// </summary>
        /// <param name="url">The URL to send the request to</param>
        /// <returns></returns>
        public Uri MakeUri(string url)
        {
            if (url.StartsWith("http://", StringComparison.CurrentCultureIgnoreCase) ||
              url.StartsWith("https://", StringComparison.CurrentCultureIgnoreCase))
                return new Uri(url);

            if (BaseUrl.EndsWith("/") && url.StartsWith("/")) url = url.Substring(2);
            if (!BaseUrl.EndsWith("/") && !url.StartsWith("/")) url = "/" + url;
            return new Uri(BaseUrl + url);
        }

        /// <summary>
        /// Preform a GET Request and return a generic response object
        /// </summary>
        /// <param name="url">The URL to send the request to</param>
        /// <param name="expectedStatus">Expected status will be checked against the response status code</param>
        /// <param name="preRequest">Optional action that can modify the request object before it is sent</param>
        /// <returns></returns>
        public HttpResponse Get(string url, HttpStatusCode expectedStatus = HttpStatusCode.OK, Action<HttpRequestMessage> preRequest = null)
        {
            return Go(MakeUri(url), null, expectedStatus, Method.GET, preRequest);
        }

        /// <summary>
        /// Preform a GET Request and return a typed response object
        /// </summary>
        /// <typeparam name="T">Type of HTTP response content object</typeparam>
        /// <param name="url">The URL to send the request to</param>
        /// <param name="expectedStatus">Expected status will be checked against the response status code</param>
        /// <param name="preRequest">Optional action that can modify the request object before it is sent</param>
        /// <returns></returns>
        public HttpResponse<T> Get<T>(string url, HttpStatusCode expectedStatus = HttpStatusCode.OK, Action<HttpRequestMessage> preRequest = null) where T : class
        {
            return Go<T>(MakeUri(url), null, expectedStatus, Method.GET, preRequest);
        }

        /// <summary>
        /// Preform a POST Request and return a typed response object
        /// </summary>
        /// <typeparam name="T">Type of HTTP response content object</typeparam>
        /// <param name="url">The URL to send the request to</param>
        /// <param name="content">Body of the request</param>
        /// <param name="expectedStatus">Expected status will be checked against the response status code</param>
        /// <param name="preRequest">Optional action that can modify the request object before it is sent</param>
        /// <returns></returns>
        public HttpResponse<T> Post<T>(string url, T content = default(T), HttpStatusCode expectedStatus = HttpStatusCode.OK, Action<HttpRequestMessage> preRequest = null)
        {
            return Go<T>(MakeUri(url), content, expectedStatus, Method.POST, preRequest);
        }
        /// <summary>
        /// Preform a POST Request with a different type and return a typed response object
        /// </summary>
        /// <typeparam name="TOut">Type of HTTP response content object</typeparam>
        /// <typeparam name="TIn">Type of request content object</typeparam>
        /// <param name="url">The URL to send the request to</param>
        /// <param name="content">Body of the request</param>
        /// <param name="expectedStatus">Expected status will be checked against the response status code</param>
        /// <param name="preRequest">Optional action that can modify the request object before it is sent</param>
        /// <returns></returns>
        public HttpResponse<TOut> Post<TOut, TIn>(string url, TIn content, HttpStatusCode expectedStatus = HttpStatusCode.OK, Action<HttpRequestMessage> preRequest = null)
        {
            return Go<TOut, TIn>(MakeUri(url), content, expectedStatus, Method.POST, preRequest);
        }
        /// <summary>
        /// Preform a PUT Request and return a typed response object
        /// </summary>
        /// <typeparam name="T">Type of HTTP response content object</typeparam>
        /// <param name="url">The URL to send the request to</param>
        /// <param name="content">Body of the request</param>
        /// <param name="expectedStatus">Expected status will be checked against the response status code</param>
        /// <param name="preRequest">Optional action that can modify the request object before it is sent</param>
        /// <returns></returns>
        public HttpResponse<T> Put<T>(string url, T content = default(T), HttpStatusCode expectedStatus = HttpStatusCode.OK, Action<HttpRequestMessage> preRequest = null)
        {
            return Go<T>(MakeUri(url), content, expectedStatus, Method.PUT, preRequest);
        }

        /// <summary>
        /// Preform a PUT Request and return a typed response object
        /// </summary>
        /// <typeparam name="TOut">Type of HTTP response content object</typeparam>
        /// <typeparam name="TIn">Type of request content object</typeparam>
        /// <param name="url">The URL to send the request to</param>
        /// <param name="content">Body of the request</param>
        /// <param name="expectedStatus">Expected status will be checked against the response status code</param>
        /// <param name="preRequest">Optional action that can modify the request object before it is sent</param>
        /// <returns></returns>
        public HttpResponse<TOut> Put<TOut, TIn>(string url, TIn content, HttpStatusCode expectedStatus = HttpStatusCode.OK, Action<HttpRequestMessage> preRequest = null)
        {
            return Go<TOut, TIn>(MakeUri(url), content, expectedStatus, Method.PUT, preRequest);
        }

        /// <summary>
        /// Preform a DELETE Request and return a typed response object
        /// </summary>
        /// <typeparam name="T">Type of HTTP response content object</typeparam>
        /// <param name="url">The URL to send the request to</param>
        /// <param name="content">Body of the request</param>
        /// <param name="expectedStatus">Expected status will be checked against the response status code</param>
        /// <param name="preRequest">Optional action that can modify the request object before it is sent</param>
        /// <returns></returns>
        public HttpResponse<T> Delete<T>(string url, T content = default(T), HttpStatusCode expectedStatus = HttpStatusCode.OK, Action<HttpRequestMessage> preRequest = null)
        {
            return Go<T>(MakeUri(url), content, expectedStatus, Method.DELETE, preRequest);
        }

        /// <summary>
        /// Preform a DELETE Request and return a typed response object
        /// </summary>
        /// <typeparam name="TOut">Type of HTTP response content object</typeparam>
        /// <typeparam name="TIn">Type of request content object</typeparam>
        /// <param name="url">The URL to send the request to</param>
        /// <param name="content">Body of the request</param>
        /// <param name="expectedStatus">Expected status will be checked against the response status code</param>
        /// <param name="preRequest">Optional action that can modify the request object before it is sent</param>
        /// <returns></returns>
        public HttpResponse<TOut> Delete<TOut, TIn>(string url, TIn content, HttpStatusCode expectedStatus = HttpStatusCode.OK, Action<HttpRequestMessage> preRequest = null)
        {
            return Go<TOut, TIn>(MakeUri(url), content, expectedStatus, Method.DELETE, preRequest);
        }

    }

    /// <summary>
    /// Provides HTTP content based on JSON string. Sets media type to "application/json" 
    /// </summary>
    public class JsonContent : StringContent
    {
        public JsonContent(string content) : base(content, Encoding.UTF8, "application/json") { }
    }


    namespace Useful.Utilities.Web.Models
    {
        /// <summary>
        /// Model for storing raw HTTP responses. 
        /// </summary>
        public class HttpResponse
        {
            /// <summary>
            /// Response content as a raw string
            /// </summary>
            public string RawContent { get; set; }
            /// <summary>
            /// Full response message
            /// </summary>
            public HttpResponseMessage Response { get; set; }
        }

        /// <summary>
        /// Model for storing typed HTTP responses. 
        /// </summary>
        /// <typeparam name="T">The Type of content in the response</typeparam>
        public class HttpResponse<T> : HttpResponse
        {
            /// <summary>
            /// Typed content from the response
            /// </summary>
            public T Content { get; set; }
        }

        /// <summary>
        /// Supported HTTP Methods: GET, POST, PUT, DELETE
        /// </summary>
        public enum Method { GET, POST, PUT, DELETE, HEAD, OPTIONS }

    }

    namespace Useful.Utilities.Web.Ext
    {
        /// <summary>
        /// Web Request Extension methods
        /// </summary>
        public static class WebRequestExt
        {
            /// <summary>
            /// Add a Bearer Token authorization header to the request object
            /// </summary>
            /// <param name="request"></param>
            /// <param name="token"></param>
            public static void AddBearer(this HttpRequestMessage request, string token)
            {
                request.Headers.Authorization = new AuthenticationHeaderValue("Bearer", token);
            }

            /// <summary>
            /// Add an unvalidated header and value to the request object
            /// </summary>
            /// <param name="request"></param>
            /// <param name="name">Header name</param>
            /// <param name="value">Header value</param>
            /// <returns></returns>
            public static bool AddHeader(this HttpRequestMessage request, string name, string value)
            {
                return request.Headers.TryAddWithoutValidation(name, value);
            }
        }
    }
}
