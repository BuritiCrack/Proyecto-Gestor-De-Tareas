namespace GestorDeTareas;

class Program
{   
    static ControlTarea con = new ControlTarea(new GestorDeTareas());
    static void Main(string[] args)
    {
        
        con.AgregarTarea();
        con.VerTareas();
        
    }
}
