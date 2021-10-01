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
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<ToDoControllerEF>
        [HttpPost]
        public async Task Post([FromBody] ToDo data)
        {
            await _crud.AddAsync(data);
        }

        // PUT api/<ToDoControllerEF>
        [HttpPut]
        public async Task<IActionResult> Put([FromBody] ToDo data)
        {
            bool result = await _crud.Update(data);

            return result ? Ok(result) : BadRequest(result);
        }

        // DELETE api/<ToDoControllerEF>/5
        [HttpDelete("{key}")]
        public async Task<IActionResult> Delete(string key)
        {
            await _crud.Remove(key);

            return Ok();
        }
    }
}
