using AppToDoList.models;

namespace AppToDoList
{
    public class ToDoService
    {
        private List<ToDoItem> database = new List<ToDoItem>();
        public List<ToDoItem> getDatabase() 
        { 
            return database; 
        }
        public void AgregarTarea(ToDoItem item)
        { 
            database.Add(item); 
        }
        public void EliminarTarea(string id) 
        {
            database.RemoveAll( t => t.Id == id); 
        }
        public ToDoItem BuscarTarea(string id)
        {
            ToDoItem? foundItem = database.FirstOrDefault(t => 
            t.Id.Trim().Equals(id.Trim(), StringComparison.OrdinalIgnoreCase));
            
            if (foundItem == null)
            {
                System.Console.WriteLine("Tarea no encontrada.");  
            }
            return foundItem;
        }
        public bool isEmpty()
        {
            return database.Count() == 0;
        }
    }
}