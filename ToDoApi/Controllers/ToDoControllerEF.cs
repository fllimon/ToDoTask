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
    public class ToDoControllerEF : ControllerBase
    {
        private IToDoCrud _crud;

        public ToDoControllerEF(IToDoCrud crud)
        {
            _crud = crud;
        }

        // GET: api/<ToDoControllerEF>
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var data = await _crud.GetAllAsync();

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

        // PUT api/<ToDoControllerEF>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<ToDoControllerEF>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
