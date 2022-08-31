using System.Globalization;
using CsvHelper;
using Yourpaper.Application.Common.Interfaces;
using Yourpaper.Application.TodoLists.Queries.ExportTodos;
using Yourpaper.Infrastructure.Files.Maps;

namespace Yourpaper.Infrastructure.Files;

public class CsvFileBuilder : ICsvFileBuilder
{
    public byte[] BuildTodoItemsFile(IEnumerable<TodoItemRecord> records)
    {
        using var memoryStream = new MemoryStream();
        using (var streamWriter = new StreamWriter(memoryStream))
        {
            using var csvWriter = new CsvWriter(streamWriter, CultureInfo.InvariantCulture);

            csvWriter.Configuration.RegisterClassMap<TodoItemRecordMap>();
            csvWriter.WriteRecords(records);
        }

        return memoryStream.ToArray();
    }
}
