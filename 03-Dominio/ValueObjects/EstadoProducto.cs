
namespace _03_Dominio.ValueObjects
{
    public class EstadoProducto
    {
        private readonly string estado;

        private static readonly Dictionary<string, string> estadoMapping = new Dictionary<string, string>
        {
            { "Activo", "Activo" },
            { "Inactivo", "Inactivo" },
            { "Pendiente", "Pendiente" }
        };

        public EstadoProducto(string estado)
        {
            if (!estadoMapping.ContainsKey(estado))
            {
                throw new ArgumentException("Estado inválido. Debe ser 'Activo', 'Inactivo', o 'Pendiente'.");
            }
            this.estado = estado;
        }

        public string Valor()
        {
            return estadoMapping[this.estado];
        }

        public override string ToString()
        {
            return Valor();
        }

        public override bool Equals(object obj)
        {
            if (obj == null || GetType() != obj.GetType())
            {
                return false;
            }

            EstadoProducto other = (EstadoProducto)obj;
            return estado == other.estado;
        }

        public override int GetHashCode()
        {
            return estado.GetHashCode();
        }
    }
}