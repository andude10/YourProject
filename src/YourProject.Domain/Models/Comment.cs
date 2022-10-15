using YourProject.Domain.Common;

namespace YourProject.Domain.Models;

public class Comment : BaseAuditableEntity
{
    public Guid UserId { get; set; }
    
    public string Text { get; set; }
    
    public int LikeCount { get; set; }
}