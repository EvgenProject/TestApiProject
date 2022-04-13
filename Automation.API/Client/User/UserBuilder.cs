using System.Collections.Generic;

namespace Automation.API.Client.User
{
    public class UserBuilder : BaseRequestBuilder
    {
        public UserBuilder(string baseUri) : base(baseUri)
        {
        }

        public UserBuilder WithBearerToken()
        {
            var bearerHeader = new Dictionary<string, string>
            {
                { 
                    "Authorization", "Bearer c8549cb40b36f71f65b6fcb9a0f6a66833c8d227ce48317a4893957b08a6743d"
                }
            };
            return (UserBuilder)WithHeaders(bearerHeader);
        }
    }
}
