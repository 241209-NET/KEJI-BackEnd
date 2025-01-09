using Banking.API.Data;
using Banking.API.Model;

namespace Banking.API.Repository;

public class ActivityRepository : IActivityRepository
{
    private readonly BankingContext _bankingContext;
    public ActivityRepository(BankingContext bankingContext) => _bankingContext = bankingContext;

    public Activity CreateNewActivity(Activity activity)
    {
        _bankingContext.Activity.Add(activity);
        _bankingContext.SaveChanges();

        return activity;
    }

    public IEnumerable<Activity> GetAccountActivities(int AccountId)
    {
        return _bankingContext.Activity.Where(a => a.AccountId == AccountId);
    }

    public void SetStatementId(int statementId, int[] activitiesId)
    {
        foreach (int id in activitiesId){
            var activity = _bankingContext.Activity.Single(a => a.ActivityId == id);

            activity.StatementId = statementId;
        }

        _bankingContext.SaveChanges();
    }
}