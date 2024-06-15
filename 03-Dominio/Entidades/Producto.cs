using _03_Dominio.ValueObjects;

namespace _03_Dominio.Entidades
{
    public class Producto
    {
        Identificador id;
        Nombre nombre;
        Descripcion descripcion;
        Precio precio;
        CategoriaId categoriaId;
        CantidadStock cantidadStock;
        EstadoProducto estado;

        public Producto(int id, string nombre, string descripcion, decimal precio,int categoriaId, int cantidadStock, EstadoProducto estado)
        {
            this.id = new Identificador(id);     
            this.nombre = new Nombre(nombre);
            this.descripcion = new Descripcion(descripcion);
            this.precio = new Precio(precio);
            this.categoriaId = new CategoriaId(categoriaId);
            this.cantidadStock = new CantidadStock(cantidadStock);
            this.estado = estado;
        }

        //Getters
        public int GetId()
        {
            return this.id.Valor();
        }
        public string GetNombre()
        {
            return this.nombre.Valor();
        }
        public string GetDescripcion()
        {
            return this.descripcion.Valor();
        }
        public decimal GetPrecio()
        {
            return this.precio.Valor();
        }
        public int GetCategoriaId()
        {
            return this.categoriaId.Valor();
        }
        public int GetCantidadStock()
        {
            return this.cantidadStock.Valor();
        }
        public EstadoProducto GetEstado()
        {
            return this.estado;
        }

        //Setters

        public void SetIdentificador(int id)
        {
            this.id = new Identificador(id);
        }
        public void SetNombre(string nombre)
        {
            this.nombre = new Nombre(nombre);
        }
        public void SetDescripcion(string descripcion)
        {
            this.descripcion = new Descripcion(descripcion);
        }
        public void SetPrecio(decimal precio)
        {
            this.precio = new Precio(precio);
        }
        public void SetCategoriaId(int categoriaId)
        {
            this.categoriaId = new CategoriaId(categoriaId);
        }
        public void SetCantidadStock(int cantidadStock)
        {
            this.cantidadStock = new CantidadStock(cantidadStock);
        }
        public void SetEstado(EstadoProducto estado)
        {
            this.estado = estado;
        }
    }
}
