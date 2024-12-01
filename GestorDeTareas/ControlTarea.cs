using System.ComponentModel;
using System.Text;
using System.IO;
using System.Text.Json;

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
            do
            {

                try
                {

                    System.Console.WriteLine("Nueva Tarea");

                    Tarea tarea = new();

                    System.Console.Write("Titulo: ");
                    tarea.Titulo = Console.ReadLine()!;
                    System.Console.Write("Descripcion: ");
                    tarea.Descripcion = Console.ReadLine()!;
                    tarea.FechaCreacion = DateTime.UtcNow;
                    Limpiar();
                    NivelPrioridad();
                    int opcion;
                    while (true)
                    {
                        try
                        {
                            opcion = Convert.ToInt32(Console.ReadLine());
                            if (opcion < 1 || opcion > 3)
                            {
                                throw new ArgumentOutOfRangeException();
                            }
                            break;
                        }
                        catch (FormatException)
                        {
                            System.Console.WriteLine("Opcion no valida. Por favor, ingrese un numero entre 1 y 3.");
                        }
                        catch (ArgumentOutOfRangeException)
                        {
                            System.Console.WriteLine("Opcion no valida. Por favor, ingrese un numero entre 1 y 3.");
                        }
                    }
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
                    }

                    _gestorDeTareas.CrearTarea(tarea);
                    Console.WriteLine("Tarea creada con exito!");
                    break;
                }
                catch (FormatException e)
                {
                    Console.WriteLine("\n", e.Message);
                    System.Console.WriteLine("Opcion no valida");
                }
                catch (ArgumentOutOfRangeException e)
                {
                    Console.WriteLine("\n", e.Message);
                    System.Console.WriteLine("Prioridad no valida");
                }
            } while (true);
        }

        public void QuitarTarea()
        {

            Limpiar();
            if (NoHayTareas())
            {
                return;
            }
                System.Console.WriteLine("Cual tarea quieres eliminar? ");

                VerTareas();

                System.Console.Write("Elige la tarea a eliminar: ");
                int eliminado = Convert.ToInt32(Console.ReadLine());
                while (true)
                {
                    try
                    {
                        if (eliminado < 1 || eliminado > _gestorDeTareas.tamañoLista())
                        {
                            throw new ArgumentOutOfRangeException();
                        }
                        break;
                    }
                    catch (ArgumentOutOfRangeException e)
                    {
                        Console.WriteLine("\n", e.Message);
                        System.Console.WriteLine("Ingrese un numero entre 1 y " + _gestorDeTareas.tamañoLista());
                        eliminado = Convert.ToInt32(Console.ReadLine());
                    }
                    catch (FormatException e)
                    {
                        Console.WriteLine("\n", e.Message);
                        System.Console.WriteLine("Opcion no valida");
                        eliminado = Convert.ToInt32(Console.ReadLine());
                    }

                }
                eliminado -= 1;

                _gestorDeTareas.EliminarTarea(eliminado);

                System.Console.WriteLine("Tarea borrada con exito!");
                PresionaParaContinuar();
        }
        public void VerTareas()
        {
            Limpiar();
            _gestorDeTareas.MostrarTareas();
            PresionaParaContinuar();
        }

        public void MarcarTarea()
        {
            Limpiar();
            if (NoHayTareas())
            {
                return;
            }

            System.Console.WriteLine("Cual tarea quieres marcar? ");

            VerTareas();

            System.Console.WriteLine("Elige la tarea a marcar: ");
            int tarea = Convert.ToInt32(Console.ReadLine());
            tarea -= 1;

            Limpiar();
            Estado();
            int op = Convert.ToInt32(Console.ReadLine());
            switch (op)
            {
                case 1:
                    _gestorDeTareas.EditarEstadoTarea(tarea, Tarea.EstadoTarea.Pendiente);
                    break;
                case 2:
                    _gestorDeTareas.EditarEstadoTarea(tarea, Tarea.EstadoTarea.enProgreso);
                    break;
                case 3:
                    _gestorDeTareas.EditarEstadoTarea(tarea, Tarea.EstadoTarea.Completada);
                    break;
                default:
                    System.Console.WriteLine("Opcion no valida");
                    break;
            }
            System.Console.WriteLine("Tarea marcada con exito!");
            PresionaParaContinuar();
        }

        public void VerOrdenado()
        {
            Limpiar();
            if (NoHayTareas())
            {
                return;
            }
            int opcion;
            do
            {
                Limpiar();
                _gestorDeTareas.MostrarTareas();
                MenuOrdenamiento();
                opcion = Convert.ToInt32(Console.ReadLine());
                switch (opcion)
                {
                    case 1:
                        _gestorDeTareas.OrdenarTareasPorPrioridadAscendente();
                        break;
                    case 2:
                        _gestorDeTareas.OrdenarTareasPorPrioridadDescendente();
                        break;
                    case 3:
                        _gestorDeTareas.OrdenarTareasPorFechaAscendente();
                        break;
                    case 4:
                        _gestorDeTareas.OrdenarTareasPorFechaDescendente();
                        break;
                    case 5:
                        return;
                    default:
                        System.Console.WriteLine("Opcion no valida");
                        break;
                }
                //PresionaParaContinuar();
            } while (opcion != 5);

        }

        public void MenuOrdenamiento()
        {
            StringBuilder sb = new();
            sb.AppendLine("Tareas ordenadas");
            sb.AppendLine("1. Por prioridad ascendente");
            sb.AppendLine("2. Por prioridad descendente");
            sb.AppendLine("3. Por fecha ascendente");
            sb.AppendLine("4. Por fecha descendente");
            sb.AppendLine("5. Salir");
            sb.Append("Selecciona una opcion: ");

            System.Console.WriteLine(sb.ToString());
        }
        public void NivelPrioridad()
        {
            {
                StringBuilder builder = new StringBuilder();
                builder.AppendLine("Seleccione el nivel de prioridad:");
                builder.AppendLine("1. Baja");
                builder.AppendLine("2. Media");
                builder.AppendLine("3. Alta");
                builder.Append("Seleccione una opcion: ");

                System.Console.Write(builder.ToString());
            }
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

        public void GuardarTareas(string archivo)
        {
            _gestorDeTareas.GuardarTareas(archivo);
        }

        public void CargarTareas(string archivo)
        {
            _gestorDeTareas.CargarTareas(archivo);
        }
        public bool NoHayTareas()
        {
            if (_gestorDeTareas.NoHayTareas())
            {
                PresionaParaContinuar();
                return true;
            }
            return false;
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