using Xunit;
using Moq;
using ToDoApi.Controllers;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;
using System;
using Domain.Interfaces;
using ToDoApi.Models;
using FluentAssertions;

namespace ToDoApi.Test
{
    public class ToDoControllerTest
    {
        private ToDoController _ctrl;
        private Mock<IToDoCrud> _mockToDoCrud;
        private Mock<IToDoFactory> _mockFactory;

        public ToDoControllerTest()
        {
            _mockToDoCrud = new Mock<IToDoCrud>();
            _mockFactory = new Mock<IToDoFactory>();

            _ctrl = new ToDoController(_mockToDoCrud.Object, _mockFactory.Object);
        }

        [Fact]
        public async Task AddDataOkResult()
        {
            //Arrange
            var data = new PostToDo { Date = DateTime.MaxValue, Description = "aafsdgfg"};
            var returnResult = new ToDoTest();

            _mockFactory.Setup(x => x.GetToDo(It.IsAny<long>(), It.IsAny<string>(), It.IsAny<DateTime>(), It.IsAny<byte>(), It.IsAny<byte>())).Returns(returnResult);
            _mockToDoCrud.Setup(x => x.AddAsync(It.IsAny<IToDo>())).ReturnsAsync(true);

            //Act
            var result = await _ctrl.Post(data);

            // Assertion
            result.Should().BeOfType<OkObjectResult>();  
        }
    }
}
