using YourProject.Domain.Common;

namespace YourProject.Domain.Models;

public class Project : BaseEntity
{
    public string Title { get; set; }
    
    public string ShortDescription { get; set; }
    
    public string Description { get; set; }
    
    public DateTime Started { get; set; }
    
    public string Status { get; set; }
    
    public int LikeCount { get; set; }

    public IList<ApplicationUser> ApplicationUsers { get; private set; } = new List<ApplicationUser>();
    
    public IList<Comment> Comments { get; private set; } = new List<Comment>();
}