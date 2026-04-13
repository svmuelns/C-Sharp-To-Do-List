using AppToDoList.models;
using System.Text;
using System.Text.Json;

namespace AppToDoList
{
    public class ToDoService
    {
        private List<ToDoItem> database = new List<ToDoItem>();
        private string filePath = "tareas.json";
        private string filePathTxt = "tareas";

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

        // Un método exporta el texto y el otro lo guarda las 
        // tareas en json para que sea más fácil importar al inicio de la aplicación
        public void ExportarTxt(string tareas)
        {
            try
            {
                var sb = new StringBuilder();
                sb.AppendLine("Base de datos: Tareas");
                sb.AppendLine();

                if(database.Count == 0)
                {
                    System.Console.WriteLine("No se puede exportar porque no hay tareas...");
                }
                else
                {
                    int contador = 1;
                    foreach (var tarea in database)
                    {
                        sb.AppendLine("Tarea " + contador + ":");
                        sb.AppendLine();
                        sb.AppendLine("     Id: " + tarea.Id);
                        sb.AppendLine("     Título: " + tarea.Titulo);
                        sb.AppendLine("     Descripción: " + tarea.Descripcion);
                        sb.AppendLine("     Tipo: " + tarea.Tipo);
                        sb.AppendLine("     Prioridad: " + tarea.Prioridad);
                        sb.AppendLine();
                        contador++;
                    }
                    File.WriteAllText(tareas, sb.ToString(), Encoding.UTF8);
                    System.Console.WriteLine("Tareas (.txt) guardadas con éxito en: " + tareas );
                }
            }
            catch (Exception e)
            {
                System.Console.WriteLine("Error al exportar: " + e.Message);
            }
        }
    
        // GUARDAR TAREAS EN .json
        public void ExportarTareas()
        {
            if (database.Count == 0)
            {
                System.Console.WriteLine("No se puede exportar porque no hay tareas...");
            }
            else
            {
                string json = JsonSerializer.Serialize(database, new JsonSerializerOptions
                {
                    WriteIndented = true // para poder leerlo
                });
                File.WriteAllText(filePath, json);
                System.Console.WriteLine("Tareas (.json) guardadas con éxito en " + filePath);

                ExportarTxt(filePathTxt);
            }

        }
        public void ImportarTareas()
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