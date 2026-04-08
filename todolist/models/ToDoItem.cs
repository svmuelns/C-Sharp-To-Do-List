using AppToDoList.util;

namespace AppToDoList.models;

public class ToDoItem
{
    public string Id { get; set; }
    public String Titulo { get; set; }
    public String Descripcion { get; set;}
    public bool Prioridad { get; set; }
    public Tipo Tipo { get; set; }

    // =========== CONSTRUCTORES ============
    public ToDoItem(){}
    public ToDoItem(string titulo, string descripcion, Tipo tipo, bool prioridad)
    {
        Id = Guid.NewGuid().ToString("N");
        Titulo = titulo;
        Descripcion = descripcion;
        Tipo = tipo;
        Prioridad = prioridad;
    }

    // =============== METODOS ==============
    
    // MÉTODO 1: AGREGAR TITULO
    public static String AgregarTitulo()
    {
        String aviso = "Escribe el título de la tarea: ";

        String titulo = Helpers.ScannerHelperString(aviso, 1, 50);

        return titulo;
    }

    // MÉTODO 2: AGREGAR DESCRIPCION
    public static String AgregarDescripcion()
    {
        String aviso = "Escribe la descripción: ";
        
        String descripcion = Helpers.ScannerHelperString(aviso, 0, 100);

        return descripcion;
    }

    // MÉTODO 3: AGREGAR TIPO
    public static Tipo AgregarTipo()
    {
        
        MostrarMenuTipo();

        String aviso = "Elige el tipo: ";

        int tipoChoice = Helpers.ScannerHelperInt(aviso, 1, 3);
        
        Tipo tipo = tipoChoice switch
        {
            1 => Tipo.Personal,
            2 => Tipo.Trabajo,
            3 => Tipo.Ocio,
            _ => Tipo.Personal
        };

        return tipo;
    }

    // MÉTODO 4: AGREGAR PRIORIDAD
    public static bool AgregarPrioridad()
    {
        String aviso = "Esta tarea es importante? (1. Sí   2. No): ";

        bool prioridad = Helpers.ScannerHelperInt(aviso, 1,2) == 1;

        return prioridad;
    }

    // CREAR TAREA
    public static ToDoItem CrearTarea()
    {
        string titulo = AgregarTitulo();
        string descripcion = AgregarDescripcion();
        Tipo tipo = AgregarTipo();
        bool prioridad = AgregarPrioridad();

        return new ToDoItem(titulo, descripcion, tipo, prioridad);
    }

    // ============== MENÚ'S ===============

    // MENÚ 
    public static void MostrarMenuTipo()
    {
        System.Console.WriteLine("\n     1. Personal     2. Trabajo     3. Ocio\n");
    }

    // MOSTRAR TAREA
    public static void MostrarTarea(ToDoItem item)
    {
        System.Console.WriteLine("     Id: " + item.Id);
        System.Console.WriteLine("     Título: " + item.Titulo);
        System.Console.WriteLine("     Descripción: " + item.Descripcion);
        System.Console.WriteLine("     Tipo: " + item.Tipo);
        System.Console.WriteLine("     Prioridad: " + item.Prioridad);
    }

    // LOOP MOSTRAR TAREA
    public static void LoopMostrarTareas(ToDoService service)
    {
        if (service.isEmpty())
        {
            System.Console.WriteLine("No hay tareas todavía...");
        } 
        else
        {
            int counter = 1;
            foreach (ToDoItem tarea in service.getDatabase())
            {
                if (counter > 1) { System.Console.WriteLine(); } // un espacio
                System.Console.WriteLine("Tarea " + counter + ": ");
                MostrarTarea(tarea);
                counter++;
            }
        }
    }
    
    // BUSCAR TAREA POR ID
    public static void BuscarTareaPorID(ToDoService service)
    {
        if (service.isEmpty())
        {
            Console.WriteLine("No hay tareas todavía...");
            return;
        }
        else
        {
            String aviso = "Escribe el ID de la tarea: ";
            String userInput = Helpers.ScannerHelperString(aviso, 32, 32);

            ToDoItem? tarea = service.BuscarTarea(userInput);

            if (tarea == null)
            {
                System.Console.WriteLine("Tarea no encontrada...");
                return;
            }
            else
            {
                System.Console.WriteLine("\n======== TAREA ENCONTRADA! =========\n");
                MostrarTarea(tarea);
            }
        }
    }

    // ELIMINAR TAREA
    public static void EliminarTarea(ToDoService service)
    {
        if (service.isEmpty())
        {
            System.Console.WriteLine("No hay tareas todavía...");
        }
        else
        {
            String aviso = "Escribe el ID de la tarea que deseas eliminar: ";

            String userInput = Helpers.ScannerHelperString(aviso, 32, 32);

            ToDoItem? tarea = service.BuscarTarea(userInput);

            if (tarea != null)
            {
                aviso = "¿Estás seguro que deseas eliminar la tarea '" + tarea.Titulo + "'? (1. Sí   2. No):";
                int eliminarChoice = Helpers.ScannerHelperInt(aviso, 1, 2);

                switch (eliminarChoice)
                {
                    case 1:
                        service.EliminarTarea(tarea.Id);
                        System.Console.WriteLine("La tarea ha sido eliminada con éxito!");
                        break;
                    case 2:
                        break;
                }
                
            }
            else
            {
                System.Console.WriteLine("No se puede eliminar porque la tarea no ha sido encontrada...");
            }
        }
    }
}



// TO DO LIST

// 1. Crear tareas: id, titulo, descripción, tipo, prioridad
// 2. Buscar tareas: se pedirá tipo de tarea
// 3. Eliminar tarea: se pedirá ID y se eliminará
// 4. Exportar tareas: genera fichero "tareas.txt"
// 5. Importar tareas: importa tareas.txt a base de datos de tareas

// ID: aleatorio. Maximo 7 numeros
// Tipo (enum): persona, trabajo, ocio.
// Prioridad (boolean)
