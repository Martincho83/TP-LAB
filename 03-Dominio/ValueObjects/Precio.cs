

namespace _03_Dominio.ValueObjects
{
    public class Precio
    {
        private decimal valor;

        public Precio ( decimal valor)
        {
            this.ValidarPrecioPositivo(valor);
            this.valor = valor;
        }

        private void ValidarPrecioPositivo(decimal valor)
        {
            if(valor <= 0)
            {
                throw new ArgumentException("El precio debe ser mayor que cero");
            }
        }

        public decimal Valor()
        {
            return this.valor;
        }

    }
}
