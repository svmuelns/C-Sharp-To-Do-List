using AppToDoList.util;

namespace AppToDoList.models;

public class ToDoItem
{
    public string Id { get; set; }
    public String Titulo { get; set; }
    public String Descripcion { get; set;}
    public bool Prioridad { get; set; }
    public Tipo Tipo { get; set; }
    List<ToDoItem> database = new List<ToDoItem>();

    // =========== CONSTRUCTORES ============
    public ToDoItem(){}
    public ToDoItem(string titulo, string descripcion, Tipo tipo, bool prioridad)
    {
        Id = Guid.NewGuid().ToString("N");
        Titulo = titulo;
        Descripcion = descripcion;
        Tipo = tipo;
        Prioridad = prioridad;

        database.Add(this);
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

    // CREAR CONSTRUCTOR
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
