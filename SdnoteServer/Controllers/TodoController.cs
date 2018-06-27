using Microsoft.AspNetCore.Mvc;
using SdnoteServer.Service;
using System.Linq;
using SdnoteServer.Dto;

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

        [Route("{id}", Name ="GetTodo")]
        public IActionResult GetTodo(int id)
        {
            var todo = TodoService.Current.Todos.SingleOrDefault(x => x.Id == id);
            if (todo == null)
            {
                return NotFound();
            }

            return Ok(todo);
        }

        //POST 添加todo
        [HttpPost]
        public IActionResult Post([FromBody] TodoCreation todo)
        {
            if (todo == null)
            {
                return BadRequest();
            }

            var maxId = TodoService.Current.Todos.Max(x => x.Id);
            var newTodo = new Todo()
            {
                Id = ++maxId, //ID 顺位加一
                TdName = todo.TdName,
                TdTime = todo.TdTime
            };

            TodoService.Current.Todos.Add(newTodo);

            return CreatedAtRoute("GetTodo",new {id = newTodo.Id, newTodo });
        }
    }
}