using Banking.API.Model;

namespace Banking.API.Repository;

public interface IActivityRepository
{
    Activity CreateNewActivity(Activity activity);
    IEnumerable<Activity> GetAccountActivities(int AccountId);
    void SetStatementId(int statementId, int[] activitiesId);
}