using _02_Aplicacion.DTO;
using _03_Dominio.Entidades;
using _03_Dominio.Repositorios;
using System;

namespace _02_Aplicacion.CRUD
{
    public class LeerProducto
    {
        private readonly ProductoRepositorio repositorio;

        public LeerProducto(ProductoRepositorio repositorio)
        {
            this.repositorio = repositorio ?? throw new ArgumentNullException(nameof(repositorio), "El repositorio no puede ser nulo.");
        }

        public ProductoDTO Ejecutar(int productoId)
        {
            // Obtener el producto del repositorio
            Producto producto = repositorio.ObtenerPorId(productoId);

            // Verificar si se encontró el producto
            if (producto != null)
            {
                // Crear un DTO utilizando el constructor adecuado
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
            // Devolver null si no se encontró el producto
            return null;
        }
    }
}
