using Microsoft.AspNetCore.Mvc;
using SdnoteServer.Service;
using System.Linq;

namespace SdnoteServer.Controllers
{
    [Route("api/[controller]")]
    public class TodoController:Controller
    {
        [HttpGet("all")]
        public JsonResult GetTodo()
        {
            return new JsonResult(TodoService.Current.Todos);
        }

        [Route("{id}")]
        public JsonResult GetTodo(int id)
        {
            return new JsonResult(TodoService.Current.Todos.SingleOrDefault(x => x.Id == id));
        }
    }
}