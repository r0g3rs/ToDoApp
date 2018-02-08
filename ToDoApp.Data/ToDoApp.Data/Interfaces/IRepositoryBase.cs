using System.Linq;
using ToDoApp.Model.Interface;

namespace ToDoApp.Data.Interfaces
{
    public interface IRepositoryBase<T> where T : IEntity
    {
        void Create(T entity);
        void Delete(int id);
        IQueryable<T> GetAll();
        T GetById(int id);
        void Update(T entity);
        long RowCount();
    }
}