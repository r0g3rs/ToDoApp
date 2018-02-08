using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ToDoApp.Data.Interfaces;
using ToDoApp.Model.Interface;
using ToDoApp.Service.Interfaces;

namespace ToDoApp.Service.Services
{
    public class ServiceBase<TEntity> : IServiceBase<TEntity> where TEntity : IEntity
    {
        private readonly IRepositoryBase<TEntity> _repository;

        public ServiceBase(IRepositoryBase<TEntity> repository)
        {
            _repository = repository;
        }

        public TEntity CreateToDo(TEntity toDo)
        {
            _repository.Create(toDo);

            return toDo;
        }

        public void DeleteToDo(int id)
        {
            _repository.Delete(id);
        }

        public IList<TEntity> GetAllToDoItems()
        {
            return _repository.GetAll().ToList();
        }

        public TEntity GetToDo(int id)
        {
            return _repository.GetById(id);
        }

        public void UpdateToDo(TEntity toDo)
        {
            _repository.Update(toDo);
        }
    }
}
