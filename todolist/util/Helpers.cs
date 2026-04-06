namespace AppToDoList.util
{
    public static class Helpers
    {
        // HELPER 1: VALIDADOR DE INT
        public static int ScannerHelperInt (String aviso, int min, int max)
        {
            while (true)
            {
                int input;

                System.Console.WriteLine(aviso);

                try
                {
                    int.TryParse(Console.ReadLine(), out input);
                    if (input >= min && input <= max)
                    {
                        return input;
                    } else
                    {
                        System.Console.WriteLine("Opción inválida, elige un número entre " + min + " y " + max);
                    }
                }
                catch (System.Exception)
                {
                    System.Console.WriteLine("Opción inválida, elige un número.");
                }
            }
        }

        // HELPER 2: VALIDADOR DE STRING
        public static String ScannerHelperString (String aviso, int min, int max)
        {
            while (true)
            {
                System.Console.WriteLine(aviso);
                try
                {
                    string input = (Console.ReadLine() ?? "").Trim();

                    if (string.IsNullOrEmpty(input))
                    {
                        throw new ArgumentException("No puede estar vacío o ser solo espacios...");
                    }
                    else if (input.Length > max)
                    {
                        throw new ArgumentException("Es muy largo, máximo " + max + " caracteres...");
                    }
                    else if (input.Length < min)
                    {
                        throw new ArgumentException("Es muy corto, mínimo " + min + "caracteres..."); 
                    }
                    else if (!System.Text.RegularExpressions.Regex.IsMatch(input, @"^[a-zA-Z0-9\s\-\.,!?;:()]+$"))
                    {
                        throw new ArgumentException("Contiene caracteres inválidos...");
                    }
                    return input;
                }
                catch (ArgumentException e)
                {
                    System.Console.WriteLine("Error: " + e.Message);
                }
            }
        }
    }
}