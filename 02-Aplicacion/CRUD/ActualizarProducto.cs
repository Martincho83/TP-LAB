using _02_Aplicacion.DTO;
using _03_Dominio.Entidades;
using _03_Dominio.Repositorios;

namespace _02_Aplicacion.CRUD
{
    public class ActualizarProducto
    {
        private readonly ProductoRepositorio repositorio;

        public ActualizarProducto(ProductoRepositorio repositorio)
        {
            this.repositorio = repositorio ?? throw new ArgumentNullException(nameof(repositorio),"El repositorio no puede ser nulo.");
        }
        public void Ejecutar(ProductoDTO productoDTO)
        {
            if(productoDTO == null)
            {
                throw new ArgumentNullException(nameof(productoDTO), "El DTO del producto no puede ser nulo.");
            }
            // Obtener el producto existente por su ID
            Producto productoExistente = repositorio.ObtenerPorId(productoDTO.GetId());
            if(productoExistente == null)
            {
                throw new InvalidOperationException($"No se encontró ningún producto con el ID {productoDTO.GetId()}.");
            }

            // Actualizar los atributos del producto con los valores del DTO
            productoExistente.SetNombre(productoDTO.GetNombre());
            productoExistente.SetDescripcion(productoDTO.GetDescripcion());
            productoExistente.SetPrecio(productoDTO.GetPrecio());
            productoExistente.SetCategoriaId(productoDTO.GetCategoriaId());
            productoExistente.SetCantidadStock(productoDTO.GetCantidadStock());
            productoExistente.SetEstado(productoDTO.GetEstado());

            // Actualizar el producto en el repositorio
            repositorio.Actualizar(productoExistente);
        }

        public bool ExisteProductoConId(int id)
        {
            return repositorio.ExisteProductoConId(id);
        }
    }
}
