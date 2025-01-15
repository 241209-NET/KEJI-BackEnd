using Banking.API.DTO;
using Banking.API.Model;
using Banking.API.Repository;
using Banking.API.Service;
using Moq;

namespace Banking.TEST;

public class UserServiceTests
{
    [Fact]
    public void TestCreateNewUser()
    {
        //Arrange
        Mock<IUserRepository> mockRepo = new();
        UserService userService = new(mockRepo.Object);

        var userRequestDTO = new UserRequestDTO
        {
            UserName = "Eldhose Salby",
            Email = "eldhose@example.com",
            Password = "password123"
        };

        var userEntity = new User
        {
            UserId = 1,
            UserName = "Eldhose Salby",
            Email = "eldhose@example.com",
            Password = "password123"
        };

        mockRepo.Setup(repo => repo.Add(It.IsAny<User>())).Returns(userEntity);
        //Act
        var result = userService.Register(userRequestDTO);
        
        //Assert
        Assert.NotNull(result);
        Assert.Equal(userEntity.UserId, result.UserId);
        Assert.Equal(userEntity.UserName, result.UserName);
        Assert.Equal(userEntity.Email, result.Email);
        Assert.Equal(userEntity.Password, result.Password);
    }

    [Fact]
        public void Login_ShouldReturnNull_WhenPasswordIsInvalid()
        {
            // Arrange
            Mock<IUserRepository> mockRepo = new();
            UserService userService = new(mockRepo.Object);

            var loginDTO = new LoginDTO
            {
                Email = "eldhose@example.com",
                Password = "password"
            };

            var userEntity = new User
            {
                UserId = 1,
                UserName = "Eldhose Salby",
                Email = "eldhose@example.com",
                Password = "password123" 
            };

            mockRepo.Setup(repo => repo.GetByEmail(loginDTO.Email)).Returns(userEntity);

            // Act
            var result = userService.Login(loginDTO);

            // Assert
            Assert.Null(result);
        }

        [Fact]
        public void Login_ShouldReturnToken_WhenValidCredentialsAreProvided()
        {
            // Arrange
            Mock<IUserRepository> mockRepo = new();
            UserService userService = new(mockRepo.Object);

            LoginDTO loginRequest = new()
            {
                Email = "eldhose@example.com",
                Password = "password123"
            };

            User existingUser = new()
            {
                UserId = 1,
                UserName = "TestUser",
                Email = "eldhose@example.com",
                Password = "password123"
            };

            mockRepo.Setup(repo => repo.GetByEmail(loginRequest.Email)).Returns(existingUser);

            // Act
            string? token = userService.Login(loginRequest);

            // Assert
            Assert.NotNull(token);
            Assert.Equal("SampleToken", token);
        }


        [Fact]
        public async Task GetUserById_ShouldReturnNull_WhenUserNotExist()
        {
            // Arrange
            Mock<IUserRepository> mockRepo = new();
            UserService userService = new(mockRepo.Object);

            int userId = 1;
            mockRepo.Setup(repo => repo.GetUserById(userId)).ReturnsAsync((User?)null);

            // Act
            var result = await userService.GetUserById(userId);

            // Assert
            Assert.Null(result);
        }
}