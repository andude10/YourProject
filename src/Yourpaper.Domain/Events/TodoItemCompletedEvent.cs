using Yourpaper.Domain.Common;
using Yourpaper.Domain.Entities;

namespace Yourpaper.Domain.Events;

public class TodoItemCompletedEvent : BaseEvent
{
    public TodoItemCompletedEvent(TodoItem item)
    {
        Item = item;
    }

    public TodoItem Item { get; }
}
