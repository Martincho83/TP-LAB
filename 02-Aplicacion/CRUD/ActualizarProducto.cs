using _02_Aplicacion.DTO;
using _03_Dominio.Entidades;
using _03_Dominio.Repositorios;

namespace _02_Aplicacion.CRUD
{
    public class ActualizarProducto
    {
        private ProductoRepositorio repositorio;

        public ActualizarProducto(ProductoRepositorio repositorio)
        {
            this.repositorio = repositorio;
        }
        public void Ejecutar(ProductoDTO productoDTO)
        {
            Producto productoExistente = this.repositorio.ObtenerPorId(productoDTO.GetId());
            if(productoExistente != null )
            {
                productoExistente.SetNombre(productoDTO.GetNombre());
                productoExistente.SetDescripcion(productoDTO.GetDescripcion());
                productoExistente.SetPrecio(productoDTO.GetPrecio());
                productoExistente.SetCategoriaId(productoDTO.GetCategoriaId());
                productoExistente.SetCantidadStock(productoDTO.GetCantidadStock());
                productoExistente.SetEstado(productoDTO.GetEstado());
                this.repositorio.Actualizar(productoExistente);
            }
        }
    }
}
