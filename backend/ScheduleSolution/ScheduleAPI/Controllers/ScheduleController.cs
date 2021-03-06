using ScheduleAPI.Adapters;

namespace ScheduleAPI.Controllers;

[Route("schedule")]
public class ScheduleController : ControllerBase
{
    private readonly ScheduleAdapter _adapter;

    public ScheduleController(ScheduleAdapter adapter)
    {
        _adapter = adapter;
    }

    // GET /schedule/{courseId}
    [HttpGet("{courseId}")]
    public async Task<ActionResult<ScheduleResponse>> GetCourseById(string courseId)
    {
        var data = await _adapter.GetForClass(courseId);
        if (data == null)
        {
            return NotFound();
        } 
        else
        {
            var response = new ScheduleResponse { Data = data, CourseId = courseId };
            return Ok(response);
        }
       
    }
}

public record ScheduleItem
{
    public DateTime StartDate { get; init; }
    public DateTime EndDate { get; init; }
}



public record ScheduleResponse
{
    public List<ScheduleItem> Data { get; init; } = new List<ScheduleItem>();
    public string CourseId { get; init; } = string.Empty;
}
