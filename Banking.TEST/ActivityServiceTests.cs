using Banking.API.DTO;
using Banking.API.Model;
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
        

        [Fact]
        public void CreateNewActivity_ShouldReturnValidActivityResponseDTO()
        {
            // Arrange
            Mock<IActivityRepository> mockRepo = new();
            ActivityService activityService = new(mockRepo.Object);

            var activityRequestDTO = new ActivityRequestDTO
            {
                Name = "Grocery Shopping",
                Amount = 100.5,
                Description = "Monthly groceries",
                IsRecurring = false,
                ActivityDate = new DateOnly(2023, 12, 1),
                AccountId = 1
            };

            var activityEntity = new Activity
            {
                ActivityId = 1,
                Name = "Grocery Shopping",
                Amount = 100.5,
                Description = "Monthly groceries",
                IsRecurring = false,
                ActivityDate = new DateOnly(2023, 12, 1),
                AccountId = 1
            };

            mockRepo.Setup(repo => repo.CreateNewActivity(It.IsAny<Activity>())).Returns(activityEntity);

            // Act
            var result = activityService.CreateNewActivity(activityRequestDTO);

            // Assert
            Assert.NotNull(result);
            Assert.Equal(activityEntity.ActivityId, result.ActivityId);
            Assert.Equal(activityEntity.Name, result.Name);
            Assert.Equal(activityEntity.Amount, result.Amount);
            Assert.Equal(activityEntity.Description, result.Description);
            Assert.Equal(activityEntity.IsRecurring, result.IsRecurring);
            Assert.Equal(activityEntity.ActivityDate, result.ActivityDate);

            mockRepo.Verify(repo => repo.CreateNewActivity(It.IsAny<Activity>()), Times.Once);
        }

        [Fact]
        public void GetAccountActivities_ShouldReturnActivitiesForValidAccoundId()
        {
            //Arrange
            Mock<IActivityRepository> mockRepo = new();
            ActivityService activityService = new(mockRepo.Object);

            int accountId = 1;
            var activities = new List<Activity>
            {
                new Activity
                {
                    ActivityId = 1,
                    Name = "Grocery Shopping",
                    Amount = 100.5,
                    Description = "Monthly groceries",
                    IsRecurring = false,
                    ActivityDate = new DateOnly(2023, 12, 1),
                    AccountId = accountId
                },

                new Activity
                {
                    ActivityId = 2,
                    Name = "Netflix Subscription",
                    Amount = 15.0,
                    Description = "Monthly subscription",
                    IsRecurring = true,
                    ActivityDate = new DateOnly(2023, 12, 5),
                    AccountId = accountId
                }
            };
            mockRepo.Setup(repo => repo.GetAccountActivities(accountId)).Returns(activities);
            
            //Act
            var result = activityService.GetAccountActivities(accountId);

            //Assert
            Assert.NotNull(result);
            Assert.Equal(activities.Count, result.Count());

            var resultList = result.ToList();
            Assert.Equal(activities[0].ActivityId, resultList[0].ActivityId);
            Assert.Equal(activities[1].ActivityId, resultList[1].ActivityId);

            mockRepo.Verify(repo => repo.GetAccountActivities(accountId), Times.Once);

        }
    
}