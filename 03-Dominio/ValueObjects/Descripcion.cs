

namespace _03_Dominio.ValueObjects
{
    public class Descripcion
    {
        private string valor;

        public Descripcion(string valor)
        {
            this.DebeContenerMasDe4Caracteres(valor);
            this.DebeContenerMenosDe20Caracteres(valor);
            this.NoPuedeEstarVacio(valor);
            this.valor = valor;
        }
        private void DebeContenerMasDe4Caracteres(string valor)
        {
            if (valor.Length < 4)
            {
                throw new ArgumentException("El nombre debe contener, al menos, 4 caracteres.");
            }
        }

        private void DebeContenerMenosDe20Caracteres(string valor)
        {
            if (valor.Length > 20)
            {
                throw new ArgumentException("El nombre debe contener un máximo de 20 caracteres.");
            }
        }

        private void NoPuedeEstarVacio(string value)
        {
            if (string.IsNullOrWhiteSpace(value))
            {
                throw new ArgumentException("El nombre no puede estar vacio.");

            }
        }

        public string Valor()
        {
            return this.valor;
        }
    }
}
