using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ToDoApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ToDoController : ControllerBase
    {
        private IToDoCrud _crud;

        public ToDoController(IToDoCrud crud)
        {
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
        public IActionResult Get(long id)
        {
            var data = _crud.GetToDoById(id);

            return data != null ? Ok(data) : BadRequest(data);
        }

        // POST api/<ToDoControllerEF>
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] ToDo data)
        {
           bool result = await _crud.AddAsync(data);

           return result ? Ok(result) : BadRequest(result);
        }

        // PUT api/<ToDoControllerEF>
        [HttpPut]
        public async Task<IActionResult> Put([FromBody] ToDo data)
        {
            bool result = await _crud.Update(data);

            return result ? Ok(result) : BadRequest(result);
        }

        // DELETE api/<ToDoControllerEF>/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(long id)
        {
            bool result = await _crud.Remove(id);

            return result ? Ok(result) : BadRequest(result);
        }
    }
}
