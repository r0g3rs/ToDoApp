using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using ToDoApp.Model;
using ToDoApp.Service.Interfaces;

namespace ToDoApp.Web.Controllers
{
  [Produces("application/json")]
  [Route("api/ToDoList")]
  public class ToDoListController : Controller
  {
    private readonly IToDoService _toDoService;

    public ToDoListController(IToDoService toDoService)
    {
      _toDoService = toDoService;
    }

    [HttpGet]
    public IEnumerable<ToDoItem> GetAll()
    {
      return _toDoService.GetAllToDoItems();
    }

    [Route("~/api/GetById")]
    [HttpGet("{id}")]
    public IActionResult GetById(int id)
    {
      var item = _toDoService.GetToDo(id);
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

      _toDoService.CreateToDo(item);

      return new ObjectResult(item);
    }

    [Route("~/api/Update")]
    [HttpPut("{item}")]
    public IActionResult Update([FromBody] ToDoItem item)
    {
      var todo = _toDoService.GetToDo(item.ID);
      if (todo == null)
      {
        return NotFound();
      }

      todo.Done = item.Done;
      todo.Task = item.Task;

      _toDoService.UpdateToDo(todo);
      return new ObjectResult(todo);
    }

    [Route("~/api/Delete/{id}")]
    [HttpDelete("{id}")]
    public IActionResult Delete(int id)
    {
      var todo = _toDoService.GetToDo(id);
      if (todo == null)
      {
        return NotFound();
      }

      _toDoService.DeleteToDo(todo.ID);
      return new NoContentResult();
    }
  }
}
