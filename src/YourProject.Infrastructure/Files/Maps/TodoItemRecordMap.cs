using System.Globalization;
using CsvHelper.Configuration;
using YourProject.Application.TodoLists.Queries.ExportTodos;

namespace YourProject.Infrastructure.Files.Maps;

public class TodoItemRecordMap : ClassMap<TodoItemRecord>
{
    public TodoItemRecordMap()
    {
        AutoMap(CultureInfo.InvariantCulture);

        Map(m => m.Done).ConvertUsing(c => c.Done ? "Yes" : "No");
    }
}
