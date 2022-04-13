using System;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using Newtonsoft.Json.Linq;

namespace Automation.Core.Models.Response
{
    public class ApiResponse
    {
        public HttpStatusCode StatusCode { get; set; }

        public HttpResponseHeaders Headers { get; set; }

        public string ContentAsString { get; set; }

        public JToken ContentAsJson => JToken.Parse(ContentAsString);

        public ApiResponse(HttpResponseMessage responseMessage)
        {
            StatusCode = responseMessage.StatusCode;
            ContentAsString = responseMessage.Content.ReadAsStringAsync().Result;
            Headers = responseMessage.Headers;
        }

        public T ContentJson<T>()
        {
            try
            {
                return ContentAsJson.ToObject<T>();
            }
            catch (Exception)
            {
                throw new Exception($"Could tor deserialize {ContentAsString}");
            }
        }

        public void EnsureSuccessful()
        {
            if ((int)StatusCode < 200 || (int)StatusCode >= 300)
            {
                throw new Exception(
                    $"StatusCode is {StatusCode}. Expected to be successful. Content = {ContentAsString}");
            }
        }
    }
}
