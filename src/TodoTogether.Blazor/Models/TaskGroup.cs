using Supabase.Postgrest.Attributes;
using Supabase.Postgrest.Models;

namespace TodoTogether.Blazor.Models;

[Table("task_groups")]
public class TaskGroup : BaseModel
{
    [PrimaryKey("id", false)]
    public Guid Id { get; set; }

    [Column("created_at")]
    public DateTime CreatedAt { get; set; }

    [Column("created_by")]
    public Guid? CreatedBy { get; set; }

    [Column("name")]
    public string Name { get; set; } = string.Empty;

    [Column("description")]
    public string? Description { get; set; }
}
