using System.Collections.Generic;

namespace ToDoApp.Service.Interfaces
{
    public interface IServiceBase<TEntity>
    {
        IList<TEntity> GetAllToDoItems();
        TEntity GetToDo(int id);
        TEntity CreateToDo(TEntity entity);
        void UpdateToDo(TEntity entity);
        void DeleteToDo(int id);
    }
}
