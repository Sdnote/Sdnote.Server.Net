using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using SdnoteServer.Dto;
using SdnoteServer.Service;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace SdnoteServer.Controllers
{
    [Route("api/[controller]")]
    public class SubeventController : Controller
    {
        [HttpGet("{todoId}/subevent")]
        public IActionResult GetSubevent(int todoId)
        {
            var todo = TodoService.Current.Todos.SingleOrDefault(x => x.Id == todoId);
            if (todo == null)
            {
                return NotFound();
            }

            return Ok(todo.Subevent);
        }

        [HttpGet("{todoId}/subevent/{id}")]
        public IActionResult GetSubevent(int todoId, int id)
        {
            var todo = TodoService.Current.Todos.SingleOrDefault(x => x.Id == todoId);
            if (todo ==null)
            {
                return NotFound();
            }

            var subevent = todo.Subevent.SingleOrDefault(x => x.Id == id);
            if (subevent == null)
            {
                return NotFound();
            }
            return Ok(subevent);
        }
    }
}
