
using TaskManager.Core;

namespace TaskManager.Persistence;

public class TaskEntity
{
    public int Id { get; set; }

    public string CreatedBy { get; set; }

    public string? AssignedTo { get; set; }

    public string Title { get; set; }

    public string Description { get; set; }

    public Status Status { get; set; }

    public DateTimeOffset CreatedTime { get; set; }

    public int? Index { get; set; }
}
