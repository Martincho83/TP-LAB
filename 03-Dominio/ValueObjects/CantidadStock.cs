using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _03_Dominio.ValueObjects
{
    public class CantidadStock
    {
        private readonly int valor;

        public CantidadStock(int valor)
        {
            this.debeContenerStockPositivo(valor);
            this.valor = valor;
        }

        private void debeContenerStockPositivo(int valor)
        {
            if(valor < 0)
            {
                throw new Exception("La cantidad de stock no puede ser negativa");
            }
        }

        public int Valor()
        {
            return this.valor;
        }
    }
}
