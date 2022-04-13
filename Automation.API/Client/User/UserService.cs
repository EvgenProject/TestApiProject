using Automation.Core.Models.Request;
using Automation.Core.Models.Response;

namespace Automation.API.Client.User
{
    public class UserService
    {
        private UserActions _actions;

        public UserService()
        {
            _actions = new UserActions();
        }

        public ApiResponse GetUserById(int userId)
        {
            var response = _actions.GetUserRequestById(Endpoints.GetUserById, userId);
            return response;
        }

        public ApiResponse CreateUser(UserRequestDto userDto)
        {
            var response = _actions.CreateUserRequest(Endpoints.PostUser, userDto);
            return response;
        }
    }
}
