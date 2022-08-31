using Yourpaper.Domain.Common;
using Yourpaper.Domain.Entities;

namespace Yourpaper.Domain.Events;

public class TodoItemCreatedEvent : BaseEvent
{
    public TodoItemCreatedEvent(TodoItem item)
    {
        Item = item;
    }

    public TodoItem Item { get; }
}
