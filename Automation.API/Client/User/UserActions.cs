using System;
using System.Collections.Generic;
using System.Linq;
using Automation.Core;
using Automation.Core.Models.Response;
using System.Net.Http;

namespace Automation.API.Client.User
{
    public class UserActions
    {
        private UserBuilder _request;

        public ApiResponse GetUserRequestById(string endPoint, int userId)
        {
            var customEndpoint = string.Format(endPoint, userId);
            var baseRequest = new UserBuilder(Configuration.BaseUrl)
                .WithMethod(HttpMethod.Get)
                .WithUri(customEndpoint);

            return baseRequest.Execute();
        }

        public ApiResponse CreateUserRequest(string endPoint, object body)
        {
            var baseRequest = new UserBuilder(Configuration.BaseUrl)
                .WithMethod(HttpMethod.Post)
                .WithUri(endPoint)
                .WithJsonBody(body);

            _request = ((UserBuilder) baseRequest)
                .WithBearerToken();

            return _request.Execute();
        }
    }
}
