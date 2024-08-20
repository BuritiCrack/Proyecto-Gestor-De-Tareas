using System.Text;

namespace GestorDeTareas
{
    class GestorDeTareas
    {
        
        private List<Tarea> _Tareas;

        public GestorDeTareas()
        {
            _Tareas = new List<Tarea>();
        }

        public void CrearTarea(Tarea tarea)
        {
            _Tareas.Add(tarea);
        }

        private bool NoHayTareas()
        {
            if(_Tareas.Count == 0)
            {
                System.Console.WriteLine("No hay tareas");
                return true;
            }
            else
            {
                return false;
            }
        }

        public void MostrarTareas()
        {
            if(NoHayTareas())
            {
                return;
            }

            List<Tarea> tareas = new List<Tarea>(_Tareas);
            tareas.Sort();

            System.Console.WriteLine(CadenaDeTareas(tareas));

        }

        private string CadenaDeTareas(List<Tarea> tareas)
        {
            StringBuilder sb = new StringBuilder();

            foreach (Tarea tarea in tareas)
            {
                int i = 0;
                if(_Tareas[0] == null) {continue;}

                string dato = string.Format("{0}. {1}",i+1,tarea);
                sb.Append(dato);
            }

            return sb.ToString();
        }

        
    }
}