using AppToDoList.util;
using AppToDoList.models;

class ToDoList
{
    static void Main()
    {
        bool salir;

        System.Console.WriteLine("Inciando programa...");
        do
        {
            salir = false;
            bool invalidInput = false;

            MainMenu();

            do
            {
                String aviso = "\nElige una opción: ";
                int mainInput = Helpers.ScannerHelperInt(aviso, 0, 5);

                switch (mainInput)
                {
                    case 1:
                        System.Console.WriteLine("\n*+-.-+*+-. AGREGAR TAREA .-+*+-.-+*\n");      
                        
                       /*  String titulo = ToDoItem.AgregarTitulo();
                        System.Console.WriteLine("Titulo: " + titulo);

                        String descripcion = ToDoItem.AgregarDescripcion();
                        System.Console.WriteLine("Descripcion: " + descripcion);

                        Tipo tipo = ToDoItem.AgregarTipo();
                        System.Console.WriteLine("Tipo: " + tipo);
                         */

                        ToDoItem.CrearTarea();

                        break;
                    case 2:
                        System.Console.WriteLine("\n*+-.-+*+-. VER TAREAS .-+*+-.-+*\n");
                        break;
                    case 3:
                        System.Console.WriteLine("\n*+-.-+*+-. BUSCAR TAREA .-+*+-.-+*\n");
                        break;
                    case 4:
                        System.Console.WriteLine("\n*+-.-+*+-. ELIMINAR TAREA .-+*+-.-+*\n");
                        break;
                    case 5:
                        System.Console.WriteLine("\n*+-.-+*+-. EXPORTAR TAREA .-+*+-.-+*\n");
                        break;
                    case 0:
                        salir = true;
                        System.Console.WriteLine("\nSaliendo del programa...");
                        break;
                }
            } while (invalidInput);
        } while (!salir);

        // ============== METODOS ==============
        
        // MENÚ PRINCIPAL
        static void MainMenu()
        {
            System.Console.WriteLine("\n*+-.-+*+-. TO-DO LIST .-+*+-.-+*\n");
            System.Console.WriteLine("1. Crear tarea");
            System.Console.WriteLine("2. Ver tareas");
            System.Console.WriteLine("3. Buscar tarea");
            System.Console.WriteLine("4. Eliminar tarea");
            System.Console.WriteLine("5. Exportar tareas");
            System.Console.WriteLine("0. Salir");
        }

        
    }
}

// TO DO LIST

// 1. Crear tareas: id, nombre, descripción, tipo, prioridad
// 2. Buscar tareas: se pedirá tipo de tarea
// 3. Eliminar tarea: se pedirá ID y se eliminará
// 4. Exportar tareas: genera fichero "tareas.txt"
// 5. Importar tareas: importa tareas.txt a base de datos de tareas

// ID: aleatorio. Maximo 7 numeros
// Tipo (enum): persona, trabajo, ocio.
// Prioridad (boolean)
