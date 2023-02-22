using Microsoft.AspNetCore.Mvc;
using TodoApi.Data;
using TodoApi.Models;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace TodoApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TodosController : ControllerBase
    {
        private readonly AppDbContext context;

        public TodosController(AppDbContext context)
        {
            this.context = context;
        }

        // GET: api/<TodosController>
        [HttpGet]
        public ActionResult<IEnumerable<TodoModel>> Get()
        {
            return Ok(context.Todos.ToList());
        }

        // GET api/<TodosController>/5
        [HttpGet("{id}")]
        public TodoModel? Get(int id)
        {
            return context.Todos.FirstOrDefault(t => t.Id == id);
        }

        // POST api/<TodosController>
        [HttpPost]
        public IActionResult Post([FromBody] TodoModel todo)
        {
        }

        // PUT api/<TodosController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<TodosController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
