using Yourpaper.Application.Common.Mappings;
using Yourpaper.Domain.Entities;

namespace Yourpaper.Application.TodoLists.Queries.ExportTodos;

public class TodoItemRecord : IMapFrom<TodoItem>
{
    public string? Title { get; set; }

    public bool Done { get; set; }
}
