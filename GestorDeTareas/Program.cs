﻿using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Text.Json;

namespace GestorDeTareas;

class Program
{
    static ControlTarea con = new(new GestorDeTareas());
    static string archivo = "tareas.json";
    static void Main(string[] args)
    {
        con.CargarTareas(archivo);
        int opcion;
        do
        {
            Console.Clear();
            System.Console.WriteLine("Gestor de tareas");
            Imprimemenu();
            while (true)
            {
                Console.Write("Ingrese una opcion:");

                try
                {
                    opcion = Convert.ToInt32(Console.ReadLine());
                    if (opcion < 1 || opcion > 6)
                    {
                        throw new ArgumentOutOfRangeException();
                    }
                    break;
                }
                catch (FormatException)
                {
                    System.Console.WriteLine("Fromato no valido");
                }
                catch (ArgumentOutOfRangeException)
                {
                    System.Console.WriteLine("Ingrese un numero entre 1 y 6");
                }
            }
            switch (opcion)
            {
                case 1:
                    con.AgregarTarea();
                    break;
                case 2:
                    con.VerTareas();
                    break;
                case 3:
                    con.QuitarTarea();
                    break;
                case 4:
                    con.MarcarTarea();
                    break;
                case 5:
                    con.VerOrdenado();
                    break;
                case 6:
                    break;
                default:
                    System.Console.WriteLine("Opcion no valida");
                    break;
            }

        } while (opcion != 6);

        con.GuardarTareas(archivo);

    }

    public static void Imprimemenu()
    {
        StringBuilder sb = new();
        sb.AppendLine("1. Crear Tarea");
        sb.AppendLine("2. Ver Tarea");
        sb.AppendLine("3. Eliminar Tarea");
        sb.AppendLine("4. Marcar Tarea");
        sb.AppendLine("5. Ordenar Tarea");
        sb.AppendLine("6. Salir");

        System.Console.WriteLine(sb.ToString()); // tambien podria ser sb y no sb.ToString()
    }
}