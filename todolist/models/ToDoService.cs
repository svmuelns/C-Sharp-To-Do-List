using AppToDoList.models;
using System.Text;
using System.Text.Json;

namespace AppToDoList
{
    public class ToDoService
    {
        private List<ToDoItem> database = new List<ToDoItem>();
        private string filePath = "todolist.json";

        // ============ MÉTODOS ============

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
        public ToDoItem? BuscarTarea(string id)
        {
            ToDoItem? foundItem = database.FirstOrDefault(t => 
            t.Id.Trim().Equals(id.Trim(), StringComparison.OrdinalIgnoreCase));
            
            return foundItem;
        }
        public bool isEmpty()
        {
            return database.Count() == 0;
        }

        // public void ExportarArchivo(string archivo)
        // {
        //     try
        //     {
        //         var sb = new StringBuilder();
        //         sb.AppendLine("Base de datos: Tareas");
        //         sb.AppendLine();

        //         if(database.Count == 0)
        //         {
        //             System.Console.WriteLine("No se puede exportar porque no hay tareas...");
        //         }
        //         else
        //         {
        //             int contador = 1;
        //             foreach (var tarea in database)
        //             {
        //                 sb.AppendLine("Tarea " + contador + ":");
        //                 sb.AppendLine();
        //                 sb.AppendLine("     Id: " + tarea.Id);
        //                 sb.AppendLine("     Título: " + tarea.Titulo);
        //                 sb.AppendLine("     Descripción: " + tarea.Descripcion);
        //                 sb.AppendLine("     Tipo: " + tarea.Tipo);
        //                 sb.AppendLine("     Prioridad: " + tarea.Prioridad);
        //                 sb.AppendLine();
        //                 contador++;
        //             }
        //             File.WriteAllText(archivo, sb.ToString(), Encoding.UTF8);
        //             System.Console.WriteLine("Tareas exportadas exitosamente a: " + archivo );
        //         }
        //     }
        //     catch (Exception e)
        //     {
        //         System.Console.WriteLine("Error al exportar: " + e.Message);
        //     }
        // }
    
        // EXPORTAR
        public void GuardarTareas()
        {
            string json = JsonSerializer.Serialize(database, new JsonSerializerOptions
            {
                WriteIndented = true // para poder leerlo
            });
            File.WriteAllText(filePath, json);
            System.Console.WriteLine("Tareas guardadas con éxito en " + filePath);
        }
        public void CargarTareas()
        {
            if (!File.Exists(filePath))
            {
                System.Console.WriteLine("No hay archivo de tareas... Empezando de cero");
                return;
            }

            string json = File.ReadAllText(filePath);
            database = JsonSerializer.Deserialize<List<ToDoItem>>(json) ?? new List<ToDoItem>();
            System.Console.WriteLine("Tareas cargadas: " + database.Count);
        }
    }
}