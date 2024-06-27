using _02_Aplicacion.DTO;
using _03_Dominio.Entidades;
using _03_Dominio.Repositorios;
using System.Collections.Generic;

namespace _02_Aplicacion.CRUD
{
    public class ListarProducto
    {
        private readonly ProductoRepositorio repositorio;

        public ListarProducto(ProductoRepositorio repositorio)
        {
            this.repositorio = repositorio ?? throw new System.ArgumentNullException(nameof(repositorio), "El repositorio no puede ser nulo.");
        }

        public List<ProductoDTO> Ejecutar()
        {
            // Obtener la lista de productos del repositorio
            List<Producto> productos = repositorio.Listar();

            // Crear una lista para almacenar los DTOs de productos
            List<ProductoDTO> productosDTO = new List<ProductoDTO>();

            // Iterar sobre los productos y convertirlos en DTOs
            foreach (Producto producto in productos)
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
                productosDTO.Add(productoDTO);
            }

            // Devolver la lista de DTOs de productos
            return productosDTO;
        }
    }
}
