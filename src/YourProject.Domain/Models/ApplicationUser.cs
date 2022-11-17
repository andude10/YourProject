using Microsoft.AspNetCore.Identity;

namespace YourProject.Domain.Models;

public class ApplicationUser : IdentityUser<Guid>
{
    public IList<Project> Projects { get; private set; } = new List<Project>();

    public IList<Comment> Comments { get; private set; } = new List<Comment>();
    
    public IList<Post> Posts { get; private set; } = new List<Post>();
}
