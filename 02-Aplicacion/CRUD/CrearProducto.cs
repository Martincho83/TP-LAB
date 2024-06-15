using _02_Aplicacion.DTO;
using _03_Dominio.Entidades;
using _03_Dominio.Repositorios;

namespace _02_Aplicacion.CRUD
{
    public class CrearProducto
    {
        private readonly ProductoRepositorio repositorio;

        public CrearProducto(ProductoRepositorio repositorio)
        {
            this.repositorio = repositorio;
        }

        public void Ejecutar(ProductoDTO productoDTO)
        {
            if (repositorio.ExisteProductoConId(productoDTO.GetId()))
            {
                throw new InvalidOperationException("El ID del producto ya está registrado. Por favor, ingrese otro ID.");
            }
            Producto producto = new Producto(
                productoDTO.GetId(),
                productoDTO.GetNombre(),
                productoDTO.GetDescripcion(),
                productoDTO.GetPrecio(),
                productoDTO.GetCategoriaId(),
                productoDTO.GetCantidadStock(),
                productoDTO.GetEstado()
                );
            repositorio.Grabar(producto);
        }

        public bool ExisteProductoConId(int id)
        {
            return repositorio.ExisteProductoConId(id);
        }
    }
}
