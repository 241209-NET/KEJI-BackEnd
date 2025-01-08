using Banking.API.DTO;
using Banking.API.Model;
using Banking.API.Repository;
using Banking.API.Utils;

namespace Banking.API.Service;

public class ActivityService : IActivityService
{
    private readonly IActivityRepository _activityRepository;
    public ActivityService(IActivityRepository activityRepository) => _activityRepository = activityRepository;

    public ActivityResponseDTO CreateNewActivity(ActivityRequestDTO _activity)
    {
        Activity activity = new();
        DTOToEntityRequest<ActivityRequestDTO, Activity>.ToEntity(_activity, activity);

        var repo = _activityRepository.CreateNewActivity(activity);

        ActivityResponseDTO res = new();
        EntityToDTORequest<Activity, ActivityResponseDTO>.ToDTO(repo, res);

        return res;
    }

    public IEnumerable<ActivityResponseDTO> GetAccountActivities(int AccountId)
    {
        var activities = _activityRepository.GetAccountActivities(AccountId);

        List<ActivityResponseDTO> res = [];

        foreach(Activity activity in activities){
            ActivityResponseDTO dto = new();

            EntityToDTORequest<Activity, ActivityResponseDTO>.ToDTO(activity, dto);

            res.Add(dto);
        }

        return res;
    }

    public void SetStatementId(int statementId, int[] activitiesId)
    {
        _activityRepository.SetStatementId(statementId, activitiesId);
    }
}