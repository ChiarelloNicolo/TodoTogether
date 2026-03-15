using Supabase.Postgrest.Attributes;
using Supabase.Postgrest.Models;

namespace TodoTogether.Blazor.Models;

[Table("task_group_members")]
public class TaskGroupMember : BaseModel
{
    [PrimaryKey("task_group_id", false)]
    public Guid TaskGroupId { get; set; }

    [PrimaryKey("user_id", false)]
    public Guid UserId { get; set; }

    [Column("created_at")]
    public DateTime CreatedAt { get; set; }
}
