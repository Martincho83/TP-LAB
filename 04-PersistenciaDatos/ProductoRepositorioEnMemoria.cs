using _03_Dominio.Entidades;
using _03_Dominio.Repositorios;

namespace _04_PersistenciaDatos
{
    public class ProductoRepositorioEnMemoria : ProductoRepositorio
    {
        private List<Producto> productos = new List<Producto>();

        public List<Producto> Listar()
        {
            return this.productos;
        }
        public void Grabar(Producto producto)
        {
            this.productos.Add(producto);
        }
        public Producto ObtenerPorId(int id)
        {
            //return this.productos.Find(p => p.GetId() == id);
            foreach (Producto producto in this.productos)
            {
                if(producto.GetId() == id)
                {
                    return producto;
                }
            }
            return null;//Retorna null si no se encuentra el producto con el ID dado
        }

        public void Actualizar(Producto producto)
        {
            //int index = this.productos.FindIndex(p => p.GetId() == producto.GetId());
            //if(index == -1)
            //{
            //    this.productos[index] = producto;
            //}
            for(int i = 0; i < this.productos.Count; i++)
            {
                if (this.productos[i].GetId() == producto.GetId())
                {
                    this.productos[i] = producto;
                    return;//Tenrmina la busqueda despues de actualizar el producto
                }
            }
            //Si el producto no existe en la lista, no se realiza ninguna actualizacion
        }
        public void Eliminar (Producto producto)
        {
            this.productos.Remove(producto);
        }

        public bool ExisteProductoConId(int id)
        {
            throw new NotImplementedException();
        }
    }
}
