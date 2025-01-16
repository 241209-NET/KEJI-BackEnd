using Banking.API.Model;
using Banking.API.Repository;
using Banking.API.Service;
using Moq;

namespace Banking.TEST;

public class StatementServiceTests
{
    [Fact]
    public async Task GetStatement_ShouldReturnNull_WhenStatementDoesNotExist()
    {
        // Arrange
        Mock<IStatementRepository> mockRepo = new();
        StatementService statementService = new(mockRepo.Object);

        var date = new DateOnly(2023, 1, 1);
        var accountId = 1;

        mockRepo.Setup(repo => repo.GetStatement(date, accountId)).ReturnsAsync((Statement?)null);

        // Act
        var result = await statementService.GetStatement(date, accountId);

        // Assert
        Assert.Null(result);
    }
}