using _02_Aplicacion.DTO;
using _03_Dominio.Entidades;
using _03_Dominio.Repositorios;
using _03_Dominio.ValueObjects;

namespace _02_Aplicacion.CRUD
{
    public class CrearProducto
    {
        private readonly ProductoRepositorio repositorio;

        public CrearProducto(ProductoRepositorio repositorio)
        {
            this.repositorio = repositorio ?? throw new ArgumentNullException(nameof(repositorio), "El repositorio no puede ser nulo.");
        }

        public void Ejecutar(ProductoDTO productoDTO)
        {
            if (productoDTO == null)
            {
                throw new ArgumentNullException(nameof(productoDTO), "El DTO del producto no puede ser nulo.");
            }

            /* // Verificar si el producto ya existe
             if (repositorio.ExisteProductoConId(productoDTO.GetId()))
             {
                 throw new InvalidOperationException("El ID del producto ya está registrado. Por favor, ingrese otro ID.");
             }*/
            // Validaciones

            ValidarProductoDTO(productoDTO);
            // Crear el objeto Producto

            Producto producto = new Producto(
                productoDTO.GetId(),
                productoDTO.GetNombre(),
                productoDTO.GetDescripcion(),
                productoDTO.GetPrecio(),
                productoDTO.GetCategoriaId(),
                productoDTO.GetCantidadStock(),
                productoDTO.GetEstado()
            );

            // Grabar el producto en el repositorio
            repositorio.Grabar(producto);
        }
        private void ValidarProductoDTO(ProductoDTO productoDTO)
        {
            if (repositorio.ExisteProductoConId(productoDTO.GetId()))
            {
                throw new InvalidOperationException("El ID del producto ya está registrado. Por favor, ingrese otro ID.");
            }

            new Identificador(productoDTO.GetId());
            new Nombre(productoDTO.GetNombre());
            new Descripcion(productoDTO.GetDescripcion());
            new Precio(productoDTO.GetPrecio());
            new CategoriaId(productoDTO.GetCategoriaId());
            new CantidadStock(productoDTO.GetCantidadStock());
            new EstadoProducto(productoDTO.GetEstado().ToString());
        }
        public bool ExisteProductoConId(int id)
        {
            return repositorio.ExisteProductoConId(id);
        }
    }
}
