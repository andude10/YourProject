using Yourpaper.Domain.Common;
using Yourpaper.Domain.Entities;

namespace Yourpaper.Domain.Events;

public class TodoItemDeletedEvent : BaseEvent
{
    public TodoItemDeletedEvent(TodoItem item)
    {
        Item = item;
    }

    public TodoItem Item { get; }
}
