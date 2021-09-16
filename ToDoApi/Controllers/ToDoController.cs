using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ToDoApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ToDoController : ControllerBase
    {
        private readonly IToDoCrud _data;

        public ToDoController(IToDoCrud data)
        {
            _data = data ?? throw new ArgumentException(nameof(data));
        }

        // GET: api/<ToDoController>
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> Get()
        {
            var data = await _data.GetAllAsync();

            return data != null ? Ok(data) : BadRequest();
        }

        // GET api/<ToDoController>/5
        [HttpGet("{key}")]
        public async Task<IActionResult> Get(string key)
        {
            var data = await _data.FindAsync(key);

            return data != null ? Ok(data) : BadRequest();
        }

        // POST api/<ToDoController>
        [HttpPost]
        public async Task Post([FromBody] ToDo data)    // ToDo: Как обработать с IActionResult 
        {
            if (data == null)
            {
                return;
            }

            await _data.AddAsync(data);
        }

        // PUT api/<ToDoController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<ToDoController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
