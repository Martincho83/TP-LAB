using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _03_Dominio.ValueObjects
{
    public class Precio
    {
        private decimal valor;

        public Precio ( decimal valor)
        {
            this.debeContenerPrecioPositivo(valor);
            this.valor = valor;
        }

        private void debeContenerPrecioPositivo(decimal valor)
        {
            if(valor < 0)
            {
                throw new Exception("El precio no puede ser negativo");
            }
        }

        public decimal Valor()
        {
            return this.valor;
        }

    }
}
