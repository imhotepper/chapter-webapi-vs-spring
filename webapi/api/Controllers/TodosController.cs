using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.Model;
using api.Servcies;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace api.Controllers
{
    [Route("api/[controller]")]
    public class TodosController : Controller
    {
        public TodosService _service { get; }

        public TodosController(TodosService service)
            => _service = service;

        // GET: api/todos
        [HttpGet]
        public ActionResult<List<Todo>> Get() => _service.GetAll();

        // GET api/todos/5
        [HttpGet("{id}")]
        public ActionResult<Todo> Get(int id) => Ok(_service.Get(id));

        // POST api/todos
        [HttpPost]
        public ActionResult Post([FromBody]Todo todo)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            _service.Create(todo);
            return Created("", todo);
        }

        // PUT api/todos/5
        [HttpPut("{id}")]
        public ActionResult Put(int id, [FromBody]Todo todo)
        {
            var td = _service.Update(id, todo);
            return Ok(td);
        }

        // DELETE api/todos/5
        [HttpDelete("{id}")]
        public ActionResult Delete(int id)
        {
            _service.Delete(id);
            return Accepted();
        }
    }
}
