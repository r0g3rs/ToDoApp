using FluentNHibernate.Mapping;

namespace ToDoApp.Model
{
    public class ToDoMap : ClassMap<ToDoItem>
    {
        public ToDoMap()
        {
            Id(x => x.ID);
            Map(x => x.Task);
            Map(x => x.Done).Default("0");
            Table("ToDo");
        }
    }
}
