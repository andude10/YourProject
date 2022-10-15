using FluentAssertions;
using NUnit.Framework;
using YourProject.Application.Common.Exceptions;
using YourProject.Application.TodoItems.Commands.CreateTodoItem;
using YourProject.Application.TodoItems.Commands.DeleteTodoItem;
using YourProject.Application.TodoLists.Commands.CreateTodoList;
using YourProject.Domain.Models;

namespace YourProject.Application.IntegrationTests.TodoItems.Commands;

using static Testing;

public class DeleteTodoItemTests : BaseTestFixture
{
    [Test]
    public async Task ShouldRequireValidTodoItemId()
    {
        var command = new DeleteTodoItemCommand(Guid.NewGuid());

        await FluentActions.Invoking(() =>
            SendAsync(command)).Should().ThrowAsync<NotFoundException>();
    }

    [Test]
    public async Task ShouldDeleteTodoItem()
    {
        var listId = await SendAsync(new CreateTodoListCommand
        {
            Title = "New List"
        });

        var itemId = await SendAsync(new CreateTodoItemCommand
        {
            ListId = listId,
            Title = "New Item"
        });

        await SendAsync(new DeleteTodoItemCommand(itemId));

        var item = await FindAsync<TodoItem>(Guid.NewGuid());

        item.Should().BeNull();
    }
}
