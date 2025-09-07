using Microsoft.AspNetCore.Mvc;
using TodoApi.Models;

namespace TodoApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class TodoController : ControllerBase
    {
        private static readonly List<TodoItem> _todos = new();
        private static int _nextId = 1 ;

        [HttpGet]
        public ActionResult<IEnumerable<TodoItem>> GetAll()
        {
            return Ok(_todos);
        }

        [HttpPost]
        public ActionResult<TodoItem> Create([FromForm] TodoItem item)
        {
            item.Id = _nextId++;
            _todos.Add(item);
            return CreatedAtAction(nameof(GetAll), new { id = item.Id }, item);
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var todo = _todos.FirstOrDefault(t => t.Id == id);
            if (todo == null) return NotFound();
            _todos.Remove(todo);
            return NoContent();
        }
    }
}
