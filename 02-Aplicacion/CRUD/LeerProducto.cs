using _02_Aplicacion.DTO;
using _03_Dominio.Entidades;
using _03_Dominio.Repositorios;


namespace _02_Aplicacion.CRUD
{
    public class LeerProducto
    {
        private ProductoRepositorio repositorio;

        public LeerProducto(ProductoRepositorio repositorio)
        {
            this.repositorio = repositorio;
        }

        public ProductoDTO Ejecutar(int productoId)
        {
            Producto producto = this.repositorio.ObtenerPorId(productoId);
            if(producto != null)
            {
                return new ProductoDTO(
                    producto.GetId(),
                    producto.GetNombre(),
                    producto.GetDescripcion(),
                    producto.GetPrecio(),
                    producto.GetCategoriaId(),
                    producto.GetCantidadStock(),
                    producto.GetEstado()
                    );
            }
            return null;
        }
    }
}
