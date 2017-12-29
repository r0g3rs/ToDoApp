using System.Collections.Generic;
using System.Linq;
using ToDoApp.Data;
using ToDoApp.Model;

namespace ToDoApp.Business
{
    public class BLToDo
    {
        Repository<ToDoItem> _repository = Repository<ToDoItem>.Instance;
        public IList<ToDoItem> GetAllToDoItems()
        {  
            return _repository.GetAll().ToList();
        }

        public ToDoItem GetToDo(int id)
        {
            return _repository.GetById(id);
        }

        public ToDoItem CreateToDo(ToDoItem toDo)
        {
            _repository.Create(toDo);

            return toDo;
        }

        public void UpdateToDo(ToDoItem toDo)
        {
            _repository.Update(toDo);
        }

        public void DeleteToDo(int id)
        {
            _repository.Delete(id);
        }

        public long RowCountToDo()
        {
            return _repository.RowCount();
        }
    }
}