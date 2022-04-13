using Automation.Core.Extensions;
using Automation.Core.Models.Request;
using Automation.Core.Models.Response;
using FluentAssertions;
using NUnit.Framework;

namespace Automation.Tests.UserTests
{
    public class UserTest : BaseTest
    {
        [Test]
        public void CreateUserTest()
        {
            //Arrange
            var userRequestDto = new UserRequestDto
            {
                Name = "Tetiana Petrash",
                Email = "testuser1991@zulauf.info",
                Gender = "female",
                Status = "active"
            };

            //Act
            var createdUserResponse = UserService.CreateUser(userRequestDto);
            var createdUserDto = createdUserResponse.ContentJson<UserResponseDto>();
            var generatedDtoBasedOnResponse = createdUserDto.CreateUserRequestDtoBasedOnResponse();

            //Assert
            createdUserDto.Should().BeEquivalentTo(generatedDtoBasedOnResponse);
        }
    }
}
