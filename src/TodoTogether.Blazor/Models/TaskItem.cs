using Supabase.Postgrest.Attributes;
using Supabase.Postgrest.Models;
using TodoTogether.Blazor.Models.Enums;

namespace TodoTogether.Blazor.Models;

[Table("tasks")]
public class TaskItem : BaseModel
{
    [PrimaryKey("id")] public Guid Id { get; set; }

    [Column("created_at")] public DateTime CreatedAt { get; set; }

    [Column("title")] public string Title { get; set; } = string.Empty;

    [Column("description")] public string? Description { get; set; }

    [Column("is_completed")] public bool IsCompleted { get; set; }

    [Column("due_at")] public DateTime? DueAt { get; set; }

    [Column("completed_at")] public DateTime? CompletedAt { get; set; }

    [Column("season")] public Seasons? Seasons { get; set; }

    [Column("latitude")] public double? Latitude { get; set; }

    [Column("longitude")] public double? Longitude { get; set; }

    [Column("task_group_id")] public Guid? TaskGroupId { get; set; }

    public TaskItem Clone()
    {
        return new TaskItem
        {
            Id = Id,
            CreatedAt = CreatedAt,
            Title = Title,
            Description = Description,
            IsCompleted = IsCompleted,
            DueAt = DueAt,
            CompletedAt = CompletedAt,
            Seasons = Seasons,
            Latitude = Latitude,
            Longitude = Longitude,
            TaskGroupId = TaskGroupId
        };
    }
}
