using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _03_Dominio.ValueObjects
{
    public class Identificador
    {
        private readonly int valor;

        public Identificador (int valor)
        {
            this.ValidarIdentificador(valor);
            this.valor = valor;
        }

        private void ValidarIdentificador(int valor)
        {
            if (valor <= 0)
            {
                throw new ArgumentException("El identificador debe ser mayor que cero.");
            }
        }

        public int Valor()
        {
            return this.valor;
        }
    }
}
