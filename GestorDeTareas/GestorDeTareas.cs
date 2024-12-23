using System.Text;
using System.Text.Json;

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

        public void EliminarTarea(int eliminado)
        {

            _Tareas.RemoveAt(eliminado);
        }

        public bool NoHayTareas()
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

            System.Console.WriteLine(CadenaDeTareas(tareas));

        }

        public int tamañoLista()
        {
            return _Tareas.Count;
        }

        public void GuardarTareas(string archivo)
        {
            string json = JsonSerializer.Serialize(_Tareas);
            File.WriteAllText(archivo, json);
        }

        public void CargarTareas(string archivo)
        {
            if (File.Exists(archivo))
            {
                string json = File.ReadAllText(archivo);
                _Tareas = JsonSerializer.Deserialize<List<Tarea>>(json) ?? new List<Tarea>();
            }
        }

        public void EditarEstadoTarea(int tarea, Tarea.EstadoTarea estado)
        {
            _Tareas[tarea].Estado = estado;
        }

        public void OrdenarTareasPorPrioridadAscendente()
        {
            _Tareas.Sort(Tarea.PrioridadAscendenteComparer);
        }

        public void OrdenarTareasPorPrioridadDescendente()
        {
            _Tareas.Sort(Tarea.PrioridadDescendenteComparer);
        }

        public void OrdenarTareasPorFechaAscendente()
        {
            _Tareas.Sort(Tarea.FechaAscendenteComparer);
        }

        public void OrdenarTareasPorFechaDescendente()
        {
            _Tareas.Sort(Tarea.FechaDescendenteComparer);
        }

        private string CadenaDeTareas(List<Tarea> tareas)
        {
            StringBuilder sb = new StringBuilder();
            int i = 0;
            foreach (Tarea tarea in tareas)
            {
                if(_Tareas[0] == null) {continue;}
                i ++;
                string dato = string.Format("{0}. {1}\n",i,tarea);

                sb.Append(dato);
            }

            return sb.ToString();
        }        
    }
}