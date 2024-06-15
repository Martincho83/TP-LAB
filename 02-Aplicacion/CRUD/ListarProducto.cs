using _02_Aplicacion.DTO;
using _03_Dominio.Entidades;
using _03_Dominio.Repositorios;

namespace _02_Aplicacion.CRUD
{
    public class ListarProducto
    {
        private ProductoRepositorio repositorio;

        public ListarProducto(ProductoRepositorio repositorio)
        {
            this.repositorio = repositorio;
        }

        public List<ProductoDTO> Ejecutar()
        {
            List<ProductoDTO> productosDTO = new List<ProductoDTO>();
            List<Producto> productos = this.repositorio.Listar();
            foreach(Producto producto in productos)
            {
                ProductoDTO productoDTO = new ProductoDTO(
                    producto.GetId(),
                    producto.GetNombre(),
                    producto.GetDescripcion(),
                    producto.GetPrecio(),
                    producto.GetCategoriaId(),
                    producto.GetCantidadStock(),
                    producto.GetEstado()
                    );
                productosDTO.Add( productoDTO );
            }
            return productosDTO;
        }
    }
}
