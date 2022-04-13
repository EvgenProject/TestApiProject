using Automation.Core.Models;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using Automation.Core.Extensions;
using Automation.Core.Models.Response;
using Newtonsoft.Json;


namespace Automation.API.Client
{
    public class BaseRequestBuilder
    {
        protected HttpRequestMessage Request;
        private readonly HttpClient _client;

        protected Uri BaseServiceUri { get; set; }

        public BaseRequestBuilder(string baseUri)
        {
            _client = new HttpClient();
            Request = new HttpRequestMessage();
            Request.Headers.Add("Connection", "keep-alive");
            BaseServiceUri = new Uri(baseUri);
        }

        public BaseRequestBuilder WithHeaders(Dictionary<string, string> headers)
        {
            headers.ForEach(h => Request.Headers.Add(h.Key, h.Value));
            return this;
        }

        public ApiResponse Execute()
        {
            Request.Headers.Referrer = Request.RequestUri;
            var response = _client.SendAsync(Request).Result;
            return new ApiResponse(response);
        }

        public BaseRequestBuilder WithMethod(HttpMethod method)
        {
            Request.Method = method;
            return this;
        }

        public BaseRequestBuilder WithUri(string url)
        {
            Request.RequestUri = new Uri(BaseServiceUri.AbsoluteUri + url);
            return this;
        }

        public BaseRequestBuilder WithJsonBody<T>(T requestBody) where T : class
        {
            var stringContent = JsonConvert.SerializeObject(requestBody, Formatting.Indented);
            Request.Content = new StringContent(stringContent, Encoding.UTF8, "application/json");
            Request.Headers.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            return this;
        }
    }
}
