using ScheduleAPI.Controllers;
using System.Text.Json;

namespace ScheduleAPI.Adapters;

public class ScheduleAdapter
{
    private readonly Dictionary<string, List<ScheduleItem>> _items;

    public ScheduleAdapter()
    {
        _items = new Dictionary<string, List<ScheduleItem>>();
        var file = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Schedule", "schedule.json");
        using var sr = new StreamReader(file);

        string json = sr.ReadToEnd(); // not async cuz ctor, only call once on app startup
        var items = JsonSerializer.Deserialize<List<StoredScheduleItem>>(json);

        foreach (var item in items)
        {
            if (!_items.ContainsKey(item.id))
            {
                _items.Add(item.id, new List<ScheduleItem>());
            }
            var newItem = new ScheduleItem
            {
                StartDate = DateTime.Parse(item.StartDate),
                EndDate = DateTime.Parse(item.EndDate),
            };
            _items[item.id].Add(newItem);
        }
    }

    public async Task<Dictionary<string, List<ScheduleItem>>> GetScheduleAsync()
    {
        return _items;
    }

    public async Task<List<ScheduleItem>?> GetForClass(string id)
    {
        if (!_items.ContainsKey(id))
        {
            return null;
        }
        return _items[id];
    }
}


public class StoredScheduleItem
{
    public string id { get; set; } = string.Empty;
    public string Title { get; set; } = string.Empty;
    public string StartDate { get; set; } = string.Empty;
    public string EndDate { get; set; } = string.Empty;
}
