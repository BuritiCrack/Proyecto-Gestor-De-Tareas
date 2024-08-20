using System.Security.Cryptography.X509Certificates;
using System.Text;

namespace GestorDeTareas;

class Program
{
    static ControlTarea con = new ControlTarea(new GestorDeTareas());
    static void Main(string[] args)
    {
        string opcion = "";
        do
        {
            Console.Clear();
            System.Console.WriteLine("Gestor de tareas");
            Imprimemenu();
            System.Console.Write("Seleccione una opcion: ");
            opcion = Console.ReadLine();
            switch (opcion)
            {
                case "1":
                    con.AgregarTarea();
                    break;
                case "2":
                    con.VerTareas();
                    break;
                case "3":
                    con.QuitarTarea();
                    break;
                default:
                    System.Console.WriteLine("Opcion no valida");
                    break;
            }

        } while (opcion != "6");


    }

    public static void Imprimemenu()
    {
        StringBuilder sb = new StringBuilder();
        sb.AppendLine("1. Crear Tarea");
        sb.AppendLine("2. Ver Tarea");
        sb.AppendLine("3. Eliminar Tarea");
        sb.AppendLine("4. Marcar Tarea");
        sb.AppendLine("5. Ordenar Tarea");
        sb.AppendLine("6. Crear Tarea");

        System.Console.WriteLine(sb.ToString());
    }
}
