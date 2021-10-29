using Domain.Interfaces;
using FluentValidation.Results;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ToDoApi.Models;
using ToDoApi.Validator;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ToDoApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ToDoController : ControllerBase
    {
        private IToDoCrud _crud;
        private IToDoFactory _factory;
        
        public ToDoController(IToDoCrud crud, IToDoFactory factory)
        {
            _factory = factory;
            _crud = crud ?? throw new ArgumentException(nameof(crud));
        }

        // GET: api/<ToDoControllerEF>
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> Get()
        {
            var data = await _crud.GetAllAsync();    //ToDo: read MiddleWare filter.

            return data != null ? Ok(data) : BadRequest();
        }

        // GET api/<ToDoControllerEF>/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(long id)
        {
            var data = await _crud.GetToDoById(id);

            return data != null ? Ok(data) : BadRequest(data);
        }

        // POST api/<ToDoControllerEF>
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] PostToDo data)    // ToDo: Поправить валидатор, error в json ИД = 0
        {
            var validator = new PostValidator(_crud);

            ValidationResult result = validator.Validate(data);

            if (result.IsValid)
            {
                return Ok(await _crud.AddAsync(_factory.GetToDo(0, data.Description, data.Date, 0)));
            }

            return BadRequest(result.Errors);
        }

        // PUT api/<ToDoControllerEF>
        [HttpPut]
        public async Task<IActionResult> Put([FromBody] PutToDo data)
        {
            var validator = new PutValidator(_crud);
            ValidationResult result = validator.Validate(data);

            if (result.IsValid)
            {
                return Ok(await _crud.Update(_factory.GetToDo(data.Id, data.Description, data.Date, data.IsComplete)));
            }

            return BadRequest(result.Errors);
        }

        // DELETE api/<ToDoControllerEF>/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(long id)
        {
            //var validator = new ToDoValidator(_crud);
            //ValidationResult result = validator.Validate(id);

            //if (result.IsValid)
            //{
            //    return Ok(await _crud.Update(data));
            //}

            bool result = await _crud.Remove(id);

            return result ? Ok(result) : BadRequest(result);
        }
    }
}
