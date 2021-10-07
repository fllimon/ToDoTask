using Xunit;
using Moq;
using ToDoApi.Controllers;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;
using System;

namespace ToDoApi.Test
{
    public class ToDoControllerTest
    {
        [Fact]
        public async Task ViewDataNotNull()
        {
            var data = new ToDo(5, "saf", DateTime.Now, 0, 0);

            //var mockToDoCrud = new Mock<IToDoCrud>();

            //mockToDoCrud.Setup(x => x.GetAllAsync()).ReturnsAsync(data);

            //ToDoController controller = new ToDoController(mockToDoCrud.Object);

            //var taskResult = controller.Get();
            //Task.WaitAll(taskResult);
            //var resultFromTask = taskResult.Result;    // Выполняется в await под капотом 

            //var result = await controller.Get() as OkObjectResult;

            //Assert.NotNull(result);
            //Assert.Equal(200, result.StatusCode);
        }

        [Fact]
        public void AddData()
        {
            var mockToDoCrud = new Mock<IToDoCrud>();

            ToDoController controller = new ToDoController(mockToDoCrud.Object);

            var data = new ToDo(4, "fjrm", DateTime.Now, 0, 0);

            var result = controller.Post(data);

            Assert.NotNull(result);

        }
    }
}
