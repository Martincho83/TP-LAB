using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace _03_Dominio.ValueObjects
{
    public class EstadoProducto
    {
        private readonly int estado;

        private static readonly Dictionary<int, string> estadoMapping = new Dictionary<int, string>();
        private static readonly Dictionary<string, int> estadoMappingReverse = new Dictionary<string, int>();

        static EstadoProducto()
        {
            estadoMapping.Add(0, "Activo");
            estadoMapping.Add(1, "Inactivo");
            estadoMapping.Add(2, "Pendiente");

            foreach (var kvp in estadoMapping)
            {
                estadoMappingReverse.Add(kvp.Value, kvp.Key);
            }
        }

        public EstadoProducto(string estado)
        {
            if (!estadoMappingReverse.ContainsKey(estado))
            {
                throw new ArgumentException("Estado inválido. Debe ser 'Activo', 'Inactivo', o 'Pendiente'.");
            }
            this.estado = estadoMappingReverse[estado];
        }

        public EstadoProducto(int estado)
        {
            if (!estadoMapping.ContainsKey(estado))
            {
                throw new ArgumentException("Estado inválido. Debe ser 0 (Activo), 1 (Inactivo), o 2 (Pendiente).");
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