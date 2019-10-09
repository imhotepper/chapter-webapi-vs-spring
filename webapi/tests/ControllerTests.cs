using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.Controllers;
using api.Model;
using api.Servcies;
using Microsoft.AspNetCore.Mvc;
using Moq;
using Xunit;

namespace tests
{
    public class ControllerTests
    {
        [Fact]
        public void Todos_CanGetAllTodos()
        {
            // Arrange
            var todoServiceMock = new Mock<TodosService>();
            var todo = new Todo{Id=1,Title = "Mocked todo"};
            
            todoServiceMock.Setup(s=> s.GetAll())
                .Returns(new List<Todo>{todo})
                .Verifiable();
            var ctrl = new TodosController(todoServiceMock.Object);
            
            // Act
            var result =  ctrl.Get() as ActionResult<List<Todo>>;
            var data = result.Value as IEnumerable<Todo>;
            
            // Assert
            Assert.NotNull(data);
            Assert.True(data.Any());
            Assert.Equal(data.First().Title ,todo.Title);
            todoServiceMock.Verify();
        }
    }
}