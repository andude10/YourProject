using YourProject.Domain.Common;

namespace YourProject.Domain.Models;

public class Post : BaseAuditableEntity
{
    public string Title { get; set; }
}