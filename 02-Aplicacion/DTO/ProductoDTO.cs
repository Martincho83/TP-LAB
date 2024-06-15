using _03_Dominio.ValueObjects;

namespace _02_Aplicacion.DTO
{
    public class ProductoDTO
    {
        private int id;
        private string nombre;
        private string descripcion;
        private decimal precio;
        private int categoriaId;
        private int cantidadStock;
        private EstadoProducto estado;
    
        public ProductoDTO(int id, string nombre, string descripcion, decimal precio, int categoriaId, int cantidadStock,EstadoProducto estado)
        {
            this.id = id;
            this.nombre = nombre;
            this.descripcion = descripcion;
            this.precio = precio;
            this.categoriaId = categoriaId;
            this.cantidadStock = cantidadStock;
            this.estado = estado;
        }


        //Getters
        public int GetId()
        {
            return this.id;
        }
        public string GetNombre()
        {
            return this.nombre;
        }
        public string GetDescripcion()
        {
            return this.descripcion;
        }
        public decimal GetPrecio()
        {
            return this.precio;
        }
        public int GetCategoriaId()
        {
            return this.categoriaId;
        }
        public int GetCantidadStock()
        {
            return this.cantidadStock;
        }
        public EstadoProducto GetEstado()
        {
            return this.estado;
        }

        //Setters

        public void SetIdentificador(int id)
        {
            this.id = id;
        }
        public void SetNombre(string nombre)
        {
            this.nombre = nombre;
        }
        public void SetDescripcion(string descripcion)
        {
            this.descripcion = descripcion;
        }
        public void SetPrecio(decimal precio)
        {
            this.precio = precio;
        }
        public void SetCategoriaId(int categoriaId)
        {
            this.categoriaId = categoriaId;
        }
        public void SetCantidadStock(int cantidadStock)
        {
            this.cantidadStock = cantidadStock;
        }
        public void SetEstado(EstadoProducto estado)
        {
            this.estado = estado;
        }

    }
}
