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
using ToDo.EFDatabase.Context;
using Microsoft.EntityFrameworkCore;
using FluentValidation.Results;

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
            _mockToDoCrud.Setup(x => x.AddAsync(It.IsAny<IToDo>())).ReturnsAsync(true).Verifiable();

            //Act
            var result = await _ctrl.Post(data);

            // Assertion
            result.Should().BeOfType<OkObjectResult>();
            _mockToDoCrud.VerifyAll();
        }

        [Fact]
        public async Task AddDataBadResult()
        {
            //Arrange
            var data = new PostToDo { Date = DateTime.MaxValue, Description = "aaf" };
            var returnResult = new ToDoTest();

            _mockFactory.Setup(x => x.GetToDo(It.IsAny<long>(), It.IsAny<string>(), It.IsAny<DateTime>(), It.IsAny<byte>(), It.IsAny<byte>())).Returns(returnResult);
            _mockToDoCrud.Setup(x => x.AddAsync(It.IsAny<IToDo>())).ReturnsAsync(false).Verifiable();

            //Act
            var result = await _ctrl.Post(data);

            // Assertion
            result.Should().BeOfType<BadRequestObjectResult>();
            _mockToDoCrud.VerifyAll();
        }

        [Fact]
        public async Task UpdateDataBadResult()
        {
            //Arrange
            var data = new PutToDo { Id = 2, Date = DateTime.MaxValue, Description = "aaf", IsComplete = 0 };
            var returnResult = new ToDoTest();

            _mockFactory.Setup(x => x.GetToDo(It.IsAny<long>(), It.IsAny<string>(), It.IsAny<DateTime>(), It.IsAny<byte>(), It.IsAny<byte>())).Returns(returnResult);
            _mockToDoCrud.Setup(x => x.UpdateAsync(It.IsAny<IToDo>())).ReturnsAsync(false).Verifiable();
            _mockToDoCrud.Setup(x => x.IsIdExist(It.IsAny<long>())).ReturnsAsync(true);

            //Act
            var result = await _ctrl.Put(data);

            // Assertion
            result.Should().BeOfType<BadRequestObjectResult>();
            var res = result as ObjectResult;
            var value = res.Value as List<ValidationFailure>;
            value.Should().Contain(x => x.ErrorMessage == "Description must greater then 5");
            _mockToDoCrud.VerifyAll();
        }

        [Fact]
        public async Task UpdateDataOkResult()
        {
            //Arrange
            var data = new PutToDo { Id = 2, Date = DateTime.MaxValue, Description = "aaffdfdsf", IsComplete = 0 };
            var returnResult = new ToDoTest();
           
            _mockFactory.Setup(x => x.GetToDo(It.IsAny<long>(), It.IsAny<string>(), It.IsAny<DateTime>(), It.IsAny<byte>(), It.IsAny<byte>())).Returns(returnResult);
            _mockToDoCrud.Setup(x => x.UpdateAsync(It.IsAny<IToDo>())).ReturnsAsync(true).Verifiable();
            _mockToDoCrud.Setup(x => x.IsIdExist(It.IsAny<long>())).ReturnsAsync(true);

            //Act
            var result = await _ctrl.Put(data);

            // Assertion
            result.Should().BeOfType<OkObjectResult>();
            _mockToDoCrud.VerifyAll();  // Проверка на то что вызывались все методы помеченые Verifiable
        }
    }
}
