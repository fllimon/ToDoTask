using Xunit;
using Moq;
using ToDoApi.Controllers;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;
using System;
using Domain.Interfaces;
using ToDoApi.Models;

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
            var data = new PostToDo { Date = DateTime.Now, Description = "aafsdgfg"};

            var mockToDoCrud = new Mock<IToDoCrud>();
            var mockFactory = new Mock<IToDoFactory>();

            mockToDoCrud.Setup(x => x.AddAsync(mockFactory.Object.GetToDo(0, data.Description, data.Date, 0, 0))).ReturnsAsync(true);

            ToDoController controller = new ToDoController(mockToDoCrud.Object, mockFactory.Object);

            var result = await controller.Post(data);

            Assert.IsType<OkObjectResult>(result);    // ToDo: проверка на налл
        }

        //[Fact]
        //public async Task DeleteData()
        //{
        //    var data = new ToDo(5, "fjrm", DateTime.Now, 0, 0);

        //    var mockToDoCrud = new Mock<IToDoCrud>();
        //    mockToDoCrud.Setup(x => x.Remove(data.Id)).ReturnsAsync(true);

        //    ToDoController controller = new ToDoController(mockToDoCrud.Object);

        //    var result = await controller.Delete(5);

        //    Assert.IsType<OkObjectResult>(result);
        //}

        [Fact]
        public async Task UpdateData()
        {
            var data = new PutToDo {Id = 2, Description = "sadf", Date = DateTime.Now, IsComplete = 0 };

            var mockToDoCrud = new Mock<IToDoCrud>();
            var mockFactory = new Mock<IToDoFactory>();

            mockToDoCrud.Setup(x => x.Update(mockFactory.Object.GetToDo(data.Id, data.Description, data.Date, data.IsComplete, 0))).ReturnsAsync(true);

            ToDoController controller = new ToDoController(mockToDoCrud.Object, mockFactory.Object);

            var result = await controller.Put(data);

            Assert.IsType<OkObjectResult>(result);
        }

        //[Fact]
        //public async Task GetData()
        //{
        //    var data = new ToDo(4, "fjrm", DateTime.Now, 0, 0);

        //    var mockToDoCrud = new Mock<IToDoCrud>();
        //    mockToDoCrud.Setup(x => x.GetAllAsync()).ReturnsAsync(new List<ToDo>());

        //    ToDoController controller = new ToDoController(mockToDoCrud.Object);

        //    var result = await controller.Get();

        //    Assert.IsType<OkObjectResult>(result);
        //}

        //[Fact]
        //public async Task GetById()
        //{
        //    var data = new ToDo(4, "fjrm", DateTime.Now, isComplete: 0, 0);

        //    var mockToDoCrud = new Mock<IToDoCrud>();
        //    mockToDoCrud.Setup(x => x.GetToDoById(data.Id)).ReturnsAsync(data);

        //    ToDoController controller = new ToDoController(mockToDoCrud.Object);

        //    var result = await controller.GetById(data.Id);

        //    Assert.IsType<OkObjectResult>(result);
        //}
    }
}
