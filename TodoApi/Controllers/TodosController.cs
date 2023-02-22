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
        public ActionResult<IEnumerable<TodoModel>> Get(int id)
        {
            TodoModel? providedTodo = context.Todos.FirstOrDefault(t => t.Id == id);

            if (providedTodo != null)
            {
                return Ok(providedTodo);
            }
            else
            {
                return NotFound("The provided id number doesn't exist in the database!");
            }
        }

        // POST api/<TodosController>
        [HttpPost]
        public IActionResult Post([FromBody] TodoModel todo)
        {
            List<TodoModel> todos = context.Todos.ToList();
            TodoModel? providedTodo = todos.FirstOrDefault(t => t.Description.ToLower() == todo.Description.Trim().ToLower());

            if (providedTodo == null)
            {
                context.Todos.Add(todo);

                context.SaveChanges();

                return Ok();
            }
            else
            {
                return NotFound("The provided todo description already exists in the database!");
            }
        }

        //// PUT api/<TodosController>/5
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] TodoModel todo)
        {
            List<TodoModel> todos = context.Todos.ToList();
            TodoModel? providedTodo = todos.FirstOrDefault(t => t.Id == id);

            if (providedTodo != null)
            {
                providedTodo.Description = todo.Description;

                providedTodo.Completed = todo.Completed;

                context.Todos.Update(providedTodo);

                context.SaveChanges();

                return Ok();
            }
            else
            {
                return NotFound("The provided id number doesn't exist in the database!");
            }
        }

        // DELETE api/<TodosController>/5
        [HttpDelete("{id}")]
        public ActionResult<IEnumerable<TodoModel>> Delete(int id)
        {
            TodoModel? providedTodo = context.Todos.FirstOrDefault(t => t.Id == id);

            if (providedTodo != null)
            {
                context.Todos.Remove(providedTodo);

                context.SaveChanges();

                return Ok();
            }
            else
            {
                return NotFound("The provided id number doesn't exist in the database!");
            }
        }
    }
}
