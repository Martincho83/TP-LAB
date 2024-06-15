using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _03_Dominio.ValueObjects
{
    public class Descripcion
    {
        private string valor;

        public Descripcion(string valor)
        {
            this.debeContenerDescripcion(valor);
            this.valor = valor;
        }
        private void debeContenerDescripcion(string valor)
        {
            if (valor == "")
            {
                throw new Exception("La descriopcion no debe ser vacio");
            }
        }
        public string Valor()
        {
            return this.valor;
        }
    }
}
