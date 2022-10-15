using YourProject.Application.TodoLists.Queries.ExportTodos;

namespace YourProject.Application.Common.Interfaces;

public interface ICsvFileBuilder
{
    byte[] BuildTodoItemsFile(IEnumerable<TodoItemRecord> records);
}