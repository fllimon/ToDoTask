using Xunit;
using Moq;
using ToDoApi.Controllers;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ToDoApi.Test
{
    public class ToDoControllerTest
    {
        [Fact]
        public async Task ViewDataNotNull()
        {
            var data = new ToDo
            {
                Key = "123",
                Name = "dfd",
                IsComplete = true
            };

            var mockToDoCrud = new Mock<IToDoCrud>();

            mockToDoCrud.Setup(x => x.GetAllAsync()).ReturnsAsync(data);

            ToDoController controller = new ToDoController(mockToDoCrud.Object);

            //var taskResult = controller.Get();
            //Task.WaitAll(taskResult);
            //var resultFromTask = taskResult.Result;    // Выполняется в await под капотом 

            var result = await controller.Get() as OkObjectResult;

            Assert.NotNull(result);
            Assert.Equal(200, result.StatusCode);
        }

        [Fact]
        public void AddData()
        {
            var mockToDoCrud = new Mock<IToDoCrud>();

            ToDoController controller = new ToDoController(mockToDoCrud.Object);

            var data = new ToDo
            {
                Key = "123",
                Name = "name",
                IsComplete = false
            };

            var result = controller.Post(data);

            Assert.NotNull(result);

        }
    }
}
