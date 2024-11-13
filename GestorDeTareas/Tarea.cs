namespace GestorDeTareas
{
    class Tarea : IComparable<Tarea>
    {
        public string Titulo { get; set; }
        public string Descripcion { get; set; }
        public DateTime FechaCreacion { get; set; }
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

        public Tarea()
        {
            Titulo = "";
            Descripcion = "";
            FechaCreacion = DateTime.UtcNow;
            Prioridad = NivelPrioridad.noAsignado;
            Estado = EstadoTarea.Pendiente;

        }
        public Tarea(string titulo, string descripcion, DateTime fechaDeCreacion)
        {
            Titulo = titulo;
            Descripcion = descripcion;
            FechaCreacion = fechaDeCreacion;
            Prioridad = NivelPrioridad.noAsignado;
            Estado = EstadoTarea.Pendiente;
        }

        
        public override bool Equals(object? obj)
        {
            if (obj == null)
            {
                return false;
            }

            Tarea? tar = obj as Tarea;
            if (tar == null)
            {
                return false;
            }

            return (FechaCreacion == tar.FechaCreacion) && (Descripcion == tar.Descripcion) && (Prioridad == tar.Prioridad);
            // Tambie se pueden comparar de la siguiente manera
            // return DateTime.Equals(FechaCreacion, tar.FechaCreacion) && Descripcion.Equals(tar.Descripcion) && Prioridad.Equals(tar.Prioridad);
        }

        public override int GetHashCode()
        {
            int hash = 3;
            hash = (hash * 7) + FechaCreacion.GetHashCode();
            hash = (hash * 7) + Descripcion.GetHashCode();
            hash = (hash * 7) + Prioridad.GetHashCode();

            return hash;
        }
        
        public int CompareTo(Tarea? other)
        {
            if (other == null) return 1;
            return FechaCreacion.CompareTo(other.FechaCreacion);
        }

        // Comparador por prioridad
        public static IComparer<Tarea> PrioridadAscendenteComparer { get; } = new PrioridadAscendenteComparerImpl();
        private class PrioridadAscendenteComparerImpl : IComparer<Tarea>
        {
            public int Compare(Tarea? x, Tarea? y)
            {
                return x?.Prioridad.CompareTo(y?.Prioridad ?? NivelPrioridad.baja) ?? -1;
            }
        }

        public static IComparer<Tarea> PrioridadDescendenteComparer { get; } = new PrioridadDescendenteComparerImpl();
        private class PrioridadDescendenteComparerImpl : IComparer<Tarea>
        {
            public int Compare(Tarea? x, Tarea? y)
            {
                return y?.Prioridad.CompareTo(x?.Prioridad ?? NivelPrioridad.baja) ?? 1;
            }
        }

        // Comparador por fecha
        public static IComparer<Tarea> FechaAscendenteComparer { get; } = new FechaAscendenteComparerImpl();
        private class FechaAscendenteComparerImpl : IComparer<Tarea>
        {
            public int Compare(Tarea? x, Tarea? y)
            {
                return x?.FechaCreacion.CompareTo(y?.FechaCreacion ?? DateTime.MinValue) ?? -1;
            }
        }

        public static IComparer<Tarea> FechaDescendenteComparer { get; } = new FechaDescendenteComparerImpl();
        private class FechaDescendenteComparerImpl : IComparer<Tarea>
        {
            public int Compare(Tarea? x, Tarea? y)
            {
                return y?.FechaCreacion.CompareTo(x?.FechaCreacion ?? DateTime.MinValue) ?? 1;
            }
        }

        public override string ToString()
        {
            return string.Format("Titulo: {0}\nDescripcion: {1}\nEstado: {2}\nPrioridad: {3}\nFecha De Creacion: {4}\n",
                                  Titulo, Descripcion, Estado, Prioridad, FechaCreacion);
        }
    }
}