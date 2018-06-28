using Microsoft.AspNetCore.Mvc;
using SdnoteServer.Service;
using System.Linq;
using Microsoft.AspNetCore.JsonPatch;
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

            //DataAnnotations 验证不通过，ModelState.IsValid 为 False
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var maxId = TodoService.Current.Todos.Max(x => x.Id);
            var newTodo = new Todo
            {
                Id = ++maxId, //ID 顺位加一
                TdName = todo.TdName,
                TdTime = todo.TdTime
            };

            TodoService.Current.Todos.Add(newTodo);

            return CreatedAtRoute("GetTodo",new {id = newTodo.Id}, newTodo);
            //return new JsonResult(todo);
        }

        //全局更新 put，body 无此内容，put 后为 null
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] TodoModification todo)
        {
            if (todo == null)
            {
                return BadRequest();
            }

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var model = TodoService.Current.Todos.SingleOrDefault(x => x.Id == id);
            if (model == null)
            {
                return NotFound();
            }

            model.TdName = todo.TdName;
            model.TdTime = todo.TdTime;

            //return Ok(model);
            return NoContent();
        }

        //部分参数 patch 更新
        //patch eg ： [ { "op":"replace", "path":"/tdName", "value":"patch it!@!!" } ]
        [HttpPatch("{id}")]
        public IActionResult Patch(int id, [FromBody] JsonPatchDocument<TodoModification> patchDoc)
        {
            if (patchDoc == null)
            {
                return BadRequest();
            }
            var model = TodoService.Current.Todos.SingleOrDefault(x => x.Id == id);
            if (model == null)
            {
                return NotFound();
            }

            //创建一个 TodoModification
            var toPatch = new TodoModification
            {
                TdName = model.TdName,
                TdTime = model.TdTime
            };

            //将 patchDoc 添加
            patchDoc.ApplyTo(toPatch, ModelState);

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            //再次手动验证（防止非法修改）eg : [ { "op":"remove", "path":"/tdName" } ]
            TryValidateModel(toPatch);
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            model.TdName = toPatch.TdName;
            model.TdTime = toPatch.TdTime;

            return NoContent();
        }



    }
}