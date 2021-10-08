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
        //[Fact]
        //public async Task ViewDataNotNull()
        //{
        //    var data = new ToDo(5, "saf", DateTime.Now, 0, 0);

        //    //var mockToDoCrud = new Mock<IToDoCrud>();

        //    //mockToDoCrud.Setup(x => x.GetAllAsync()).ReturnsAsync(data);

        //    //ToDoController controller = new ToDoController(mockToDoCrud.Object);

        //    //var taskResult = controller.Get();
        //    //Task.WaitAll(taskResult);
        //    //var resultFromTask = taskResult.Result;    // Выполняется в await под капотом 

        //    //var result = await controller.Get() as OkObjectResult;

        //    //Assert.NotNull(result);
        //    //Assert.Equal(200, result.StatusCode);
        //}

        [Fact]
        public async Task AddData()
        {
            var data = new ToDo(0, "fjrm", DateTime.Now, 0, 0);

            var mockToDoCrud = new Mock<IToDoCrud>();

            mockToDoCrud.Setup(x => x.AddAsync(data)).ReturnsAsync(true);

            ToDoController controller = new ToDoController(mockToDoCrud.Object);

            var result = await controller.Post(data);

            Assert.IsType<OkObjectResult>(result);
        }

        [Fact]
        public async Task DeleteData()
        {
            var data = new ToDo(5, "fjrm", DateTime.Now, 0, 0);

            var mockToDoCrud = new Mock<IToDoCrud>();
            mockToDoCrud.Setup(x => x.Remove(data.Id)).ReturnsAsync(true);

            ToDoController controller = new ToDoController(mockToDoCrud.Object);

            var result = await controller.Delete(5);

            Assert.IsType<OkObjectResult>(result);
        }

        [Fact]
        public async Task UpdateData()
        {
            var data = new ToDo(5, "fjrm", DateTime.Now, 0, 0);

            var mockToDoCrud = new Mock<IToDoCrud>();
            mockToDoCrud.Setup(x => x.Update(data)).ReturnsAsync(true);

            ToDoController controller = new ToDoController(mockToDoCrud.Object);

            var result = await controller.Put(data);

            Assert.IsType<OkObjectResult>(result);
        }

        [Fact]
        public async Task GetData()
        {
            var data = new ToDo(4, "fjrm", DateTime.Now, 0, 0);

            var mockToDoCrud = new Mock<IToDoCrud>();
            mockToDoCrud.Setup(x => x.GetAllAsync()).ReturnsAsync(new List<ToDo>());

            ToDoController controller = new ToDoController(mockToDoCrud.Object);

            var result = await controller.Get();

            Assert.IsType<OkObjectResult>(result);
        }

        [Fact]
        public async Task GetById()
        {
            var data = new ToDo(4, "fjrm", DateTime.Now, 0, 0);

            var mockToDoCrud = new Mock<IToDoCrud>();
            mockToDoCrud.Setup(x => x.GetToDoById(data.Id)).ReturnsAsync(data);

            ToDoController controller = new ToDoController(mockToDoCrud.Object);

            var result = await controller.GetById(data.Id);

            Assert.IsType<OkObjectResult>(result);
        }
    }
}
