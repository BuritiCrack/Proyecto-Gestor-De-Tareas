namespace GestorDeTareas
{
    class Tarea : IComparable<Tarea>
    {
        public string Titulo { get; set; }
        public string Descripcion { get; set; }
        public DateTime FechaCreacion { get; }
        public NivelPrioridad Prioridad { get; set; }
        public EstadoTarea Estado { get; set; }

        public enum NivelPrioridad
        {
            noAsignado = 0,
            baja = 1,
            media = 2,
            alta = 3
        }

        public enum EstadoTarea
        {
            Pendiente,
            enProgreso,
            Completada
        }

        public Tarea() {}
        public Tarea(string titulo ,string descripcion)
        {
            Titulo = titulo;
            Descripcion = descripcion;
            FechaCreacion = DateTime.Now;
            Prioridad = NivelPrioridad.noAsignado;
            Estado = EstadoTarea.Pendiente;
        }

        public override bool Equals(object? obj)
        {
            if(obj == null)
            {
                return false;
            }

            Tarea tar = obj as Tarea;
            if(tar == null)
            {
                return false;
            }

            return (Titulo == tar.Titulo) && (Descripcion == tar.Descripcion);
        }

        public override int GetHashCode()
        {
            int hash = 3;
            hash = (hash * 7) + Titulo.GetHashCode();
            hash = (hash * 7) + Descripcion.GetHashCode();

            return hash;
        }

        public int CompareTo(Tarea? otro)
        {
            return Titulo.CompareTo(otro.Titulo);
        }

        public override string ToString()
        {
            return string.Format("Titulo: {0}\nDescripcion: {1}\nFecha De Creacion: {2}\nPrioridad: {3}\nEstado: {4}",
                                  Titulo,Descripcion,FechaCreacion,Prioridad,Estado);
        }
    }
}