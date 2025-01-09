using Banking.API.DTO;
using Banking.API.Service;
using Microsoft.AspNetCore.Mvc;

namespace Banking.API.Controller;

[Route("api/[controller]")]
[ApiController]
public class ActivityController : ControllerBase
{
    private readonly IActivityService _activityService;

    public ActivityController(IActivityService activityService) => _activityService = activityService;

    [HttpPost]
    public IActionResult CreateNewActivity(ActivityRequestDTO _activity)
    {
        var activity = _activityService.CreateNewActivity(_activity);

        return Ok(activity);
    }

    [HttpGet("{AccountId}")]
    public IActionResult GetAccountActivities(int AccountId)
    {
        var activities = _activityService.GetAccountActivities(AccountId);

        return Ok(activities);
    }

    [HttpPatch("{StatementId}")]
    public IActionResult SetStatementId (int StatementId, int[] ActivitiesId)
    {
        _activityService.SetStatementId(StatementId, ActivitiesId);

        return Ok("Statement Assigned");
    }
}