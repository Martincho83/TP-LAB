

namespace _03_Dominio.ValueObjects
{
    public class CategoriaId
    {
        private readonly int valor; 

        public CategoriaId (int valor)
        {
            this.ValidarCategoriaId(valor);
            this.valor = valor;
        }

        private void ValidarCategoriaId(int valor)
        {
            if(valor <= 0)
            {
                throw new ArgumentException("El identificador debe ser mayor que cero");
            }
        }

        public int Valor()
        {
            return this.valor;
        }
    }
}
