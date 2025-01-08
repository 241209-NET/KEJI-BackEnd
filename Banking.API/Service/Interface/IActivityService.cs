using System.Data;
using Banking.API.DTO;

namespace Banking.API.Service;

public interface IActivityService
{
    ActivityResponseDTO CreateNewActivity(ActivityRequestDTO activity);
    IEnumerable<ActivityResponseDTO> GetAccountActivities(int AccountId);
    void SetStatementId(int statementId, int[] activitiesId);
}