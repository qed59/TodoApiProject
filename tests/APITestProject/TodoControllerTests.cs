using Microsoft.AspNetCore.Mvc;
using TodoApi.Controllers;
using TodoApi.Models;

namespace APITestProject
{
    public class TodoControllerTests
    {
        [Fact]
        public void Create_ShouldAddNewTodo()
        {
            // Arrange
            var controller = new TodoController();
            var newItem = new TodoItem { Title = "Test Task", IsComplete = false };

            // Act
            var result = controller.Create(newItem);

            // Assert
            var createdAt = Assert.IsType<CreatedAtActionResult>(result.Result);
            var todo = Assert.IsType<TodoItem>(createdAt.Value);
            Assert.Equal("Test Task", todo.Title);

            // Check that GetAll returns the item
            var getAll = controller.GetAll();
            var okResult = Assert.IsType<OkObjectResult>(getAll.Result);
            var todos = Assert.IsAssignableFrom<System.Collections.Generic.IEnumerable<TodoItem>>(okResult.Value);
            Assert.Single(todos);
        }

        [Fact]
        public void Delete_ShouldRemoveTodo()
        {
            // Arrange
            var controller = new TodoController();
            var newItem = new TodoItem { Title = "Delete Me", IsComplete = false };
            var created = controller.Create(newItem);
            var createdAt = Assert.IsType<CreatedAtActionResult>(created.Result);
            var todo = Assert.IsType<TodoItem>(createdAt.Value);

            // Act
            var deleteResult = controller.Delete(todo.Id);

            // Assert
            Assert.IsType<NoContentResult>(deleteResult);

            // Verify it's removed
            var getAll = controller.GetAll();
            var okResult = Assert.IsType<OkObjectResult>(getAll.Result);
            var todos = Assert.IsAssignableFrom<System.Collections.Generic.IEnumerable<TodoItem>>(okResult.Value);
            Assert.DoesNotContain(todos, t => t.Id == todo.Id);
        }
    }

}
