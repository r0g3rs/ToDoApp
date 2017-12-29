using ToDoApp.Model.Interface;

namespace ToDoApp.Model
{
    public class ToDoItem : IEntity
    {
        public virtual int ID { get; set; }
        public virtual string Task { get; set; }
        public virtual bool Done { get; set; }
    }
}