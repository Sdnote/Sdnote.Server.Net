using Microsoft.AspNetCore.Mvc;
using SdnoteServer.Service;
using System.Linq;

namespace SdnoteServer.Controllers
{
    [Route("api/[controller]")]
    public class TodoController:Controller
    {
        [HttpGet("all")]
        public IActionResult GetTodo()
        {
            return Ok(TodoService.Current.Todos);
        }

        [Route("{id}")]
        public IActionResult GetTodo(int id)
        {
            var todo = TodoService.Current.Todos.SingleOrDefault(x => x.Id == id);
            if (todo == null)
            {
                return NotFound();
            }

            return Ok(todo);
        }
    }
}