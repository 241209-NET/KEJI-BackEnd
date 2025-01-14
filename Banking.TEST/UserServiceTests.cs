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

    
}