using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using ToDoApp.Business;
using ToDoApp.Model;

namespace ToDoApp.Web.Controllers
{
  [Produces("application/json")]
  [Route("api/ToDoList")]
  public class ToDoListController : Controller
  {
    [HttpGet]
    public IEnumerable<ToDoItem> GetAll()
    {
      return new BLToDo().GetAllToDoItems();
    }

    [Route("~/api/GetById")]
    [HttpGet("{id}")]
    public IActionResult GetById(int id)
    {
      var item = new BLToDo().GetToDo(id);
      if (item == null)
      {
        return NotFound();
      }
      return new ObjectResult(item);
    }

    [Route("~/api/Create")]
    [HttpPost("{item}")]
    public IActionResult Create([FromBody] ToDoItem item)
    {
      if (item == null)
      {
        return BadRequest();
      }

      new BLToDo().CreateToDo(item);
      
      return new ObjectResult(item);
    }

    [Route("~/api/Update")]
    [HttpPut("{item}")]
    public IActionResult Update([FromBody] ToDoItem item)
    {      
      var todo = new BLToDo().GetToDo(item.ID);
      if (todo == null)
      {
        return NotFound();
      }

      todo.Done = item.Done;
      todo.Task = item.Task;

      new BLToDo().UpdateToDo(todo);
      return new ObjectResult(todo);
    }

    [Route("~/api/Delete/{id}")]
    [HttpDelete("{id}")]
    public IActionResult Delete(int id)
    {
      var todo = new BLToDo().GetToDo(id);
      if (todo == null)
      {
        return NotFound();
      }

      new BLToDo().DeleteToDo(todo.ID);
      return new NoContentResult();
    }
  }
}
