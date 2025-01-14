using Banking.API.Repository;
using Banking.API.Service;
using Moq;

namespace Banking.TEST;

public class AccountServiceTests
{
    [Fact]
    public void GetAccountBalance_ShouldReturnCorrectBalance()
    {
        // Arrange
        Mock<IAccountRepository> mockRepo = new();
        AccountService accountService = new(mockRepo.Object);

        int accountId = 1;
        double expectedBalance = 2000;

        mockRepo.Setup(repo => repo.GetAccountBalance(accountId)).Returns(expectedBalance);

        // Act
        var result = accountService.GetAccountBalance(accountId);

        // Assert
        Assert.Equal(expectedBalance, result);
        mockRepo.Verify(repo => repo.GetAccountBalance(accountId), Times.Once);
    }
}