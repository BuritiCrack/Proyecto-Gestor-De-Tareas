using System.ComponentModel;
using System.Text;

namespace GestorDeTareas
{
    class ControlTarea
    {
        private GestorDeTareas _gestorDeTareas;


        public ControlTarea(GestorDeTareas gestorDeTareas)
        {
            _gestorDeTareas = gestorDeTareas;
        }

        public void AgregarTarea()
        {   
            Limpiar();
            System.Console.WriteLine("Nueva Tarea");

            Tarea tarea = new Tarea();

            System.Console.Write("Titulo: ");
            tarea.Titulo = Console.ReadLine();
            System.Console.Write("Descripcion: ");
            tarea.Descripcion = Console.ReadLine();
            Limpiar();
            NivelPrioridad();
            int opcion = Convert.ToInt32(Console.ReadLine());
            switch (opcion)
            {
                case 1:
                    tarea.Prioridad = Tarea.NivelPrioridad.baja;
                    break;
                case 2:
                    tarea.Prioridad = Tarea.NivelPrioridad.media;
                    break;
                case 3:
                    tarea.Prioridad = Tarea.NivelPrioridad.alta;
                    break;
                default:
                    System.Console.WriteLine("Opcion no valida");
                break;
            }
            /*
            Limpiar();
            Estado();
            int op = Convert.ToInt32(Console.ReadLine());
            switch (op)
            {
                case 1:
                    tarea.Estado = Tarea.EstadoTarea.Pendiente;
                    break;
                case 2:
                    tarea.Estado = Tarea.EstadoTarea.enProgreso;
                    break;
                case 3:
                    tarea.Estado = Tarea.EstadoTarea.Completada;
                    break;
                default:
                    System.Console.WriteLine("Opcion no valida");
                    break;
            }*/
            _gestorDeTareas.CrearTarea(tarea);

        }

        
        public void VerTareas()
        {
            _gestorDeTareas.MostrarTareas();
            
            PresionaParaContinuar();
        }

        public void NivelPrioridad()
        {
            StringBuilder builder = new StringBuilder();

            builder.AppendLine("Seleccione el nivel de prioridad:");
            builder.AppendLine("1. Baja");
            builder.AppendLine("2. Media");
            builder.AppendLine("3. Alta");
            builder.Append("Seleccione una opcion: ");

            System.Console.Write(builder);
        }

        public void Estado()
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine("Seleccione el estado de la tarea:");
            sb.AppendLine("1. Pendiente");
            sb.AppendLine("2. En Progreso");
            sb.AppendLine("3. Completada");

            System.Console.WriteLine(sb.ToString());
        }

        private static void PresionaParaContinuar()
        {
            System.Console.WriteLine("Presiona una tecla para continuar");
            Console.ReadKey();
        }

        private static void Limpiar()
        {
            Console.Clear();
        }
    }
}