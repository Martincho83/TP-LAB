using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _03_Dominio.ValueObjects
{
    public class Identificador
    {
        private int valor;

        public Identificador (int valor)
        {
            this.debeContenerIdentificador(valor);
            this.valor = valor;
        }

        private void debeContenerIdentificador(int valor)
        {
            if (valor < 0)
            {
                throw new Exception("El valor no puede ser negativo");
            }
        }

        public int Valor()
        {
            return this.valor;
        }
    }
}
