using ToDoApp.Data.Interfaces;
using ToDoApp.Model;
using ToDoApp.Service.Interfaces;

namespace ToDoApp.Service.Services
{
    public class ToDoService : ServiceBase<ToDoItem>, IToDoService
    {        
        public ToDoService(IToDoRepository repository) : base(repository)
        {
            
        }
    }
}
