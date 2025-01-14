using Banking.API.Repository;
using Banking.API.Service;
using Moq;

namespace Banking.TEST;

public class ActivityServiceTests
{
    [Fact]
        public void SetStatementId_ShouldCallRepositoryWithCorrectParameters()
        {
            // Arrange
            Mock<IActivityRepository> mockRepo = new();
            ActivityService activityService = new(mockRepo.Object);

            int statementId = 1;
            int[] activityIds = { 1, 2, 3 };

            // Act
            activityService.SetStatementId(statementId, activityIds);

            // Assert
            mockRepo.Verify(repo => repo.SetStatementId(statementId, activityIds), Times.Once);
        }
}