using YourProject.Domain.Common;
using YourProject.Domain.ValueObjects;

namespace YourProject.Domain.Models;

public class TodoList : BaseAuditableEntity
{
    public string? Title { get; set; }

    public Colour Colour { get; set; } = Colour.White;

    public IList<TodoItem> Items { get; private set; } = new List<TodoItem>();
}
