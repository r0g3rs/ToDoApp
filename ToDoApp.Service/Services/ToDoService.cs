using System.Collections.Generic;
using System.Linq;
using ToDoApp.Data.Interfaces;
using ToDoApp.Model;
using ToDoApp.Service.Interfaces;

namespace ToDoApp.Service.Services
{
    public class ToDoService : IToDoService
    {
        private readonly IToDoRepository _repository;

        public ToDoService(IToDoRepository repository)
        {
            _repository = repository;
        }

        public ToDoItem CreateToDo(ToDoItem toDo)
        {
            _repository.Create(toDo);

            return toDo;
        }

        public void DeleteToDo(int id)
        {
            _repository.Delete(id);
        }

        public IList<ToDoItem> GetAllToDoItems()
        {
            return _repository.GetAll().ToList();
        }

        public ToDoItem GetToDo(int id)
        {
            return _repository.GetById(id);
        }

        public void UpdateToDo(ToDoItem toDo)
        {
            _repository.Update(toDo);
        }
    }
}
