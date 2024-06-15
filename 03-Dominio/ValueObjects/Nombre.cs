using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _03_Dominio.ValueObjects
{
    public class Nombre
    {
        private string valor;

        public Nombre(string valor)
        {
            this.debeContenerNombre(valor);
            this.valor = valor;
        }
        private void debeContenerNombre(string valor)
        {
            if(valor == "")
            {
                throw new Exception("El nombre no debe ser vacio");
            }
        }

        public string Valor()
        {
            return this.valor;
        }
    }
}
