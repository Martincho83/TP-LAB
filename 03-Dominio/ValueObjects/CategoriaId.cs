using System;
using System.Collections.Generic;
using System.Linq;
using System.Security;
using System.Text;
using System.Threading.Tasks;

namespace _03_Dominio.ValueObjects
{
    public class CategoriaId
    {
        private int valor; 

        public CategoriaId (int valor)
        {
            this.debeContenerCategoriaId(valor);
            this.valor = valor;
        }

        private void debeContenerCategoriaId(int valor)
        {
            if(valor < 0)
            {
                throw new Exception("El identificador no puede ser negativo");
            }
        }

        public int Valor()
        {
            return this.valor;
        }
    }
}
