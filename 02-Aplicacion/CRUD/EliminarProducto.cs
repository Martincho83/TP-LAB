using _03_Dominio.Entidades;
using _03_Dominio.Repositorios;
using _04_PersistenciaDatos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _02_Aplicacion.CRUD
{
    public class EliminarProducto
    {
        private readonly ProductoRepositorio repositorio;

        public EliminarProducto(ProductoRepositorio repositorio)
        {
            this.repositorio = repositorio ?? throw new ArgumentNullException(nameof(repositorio),"El repositorio no puede ser nulo.");
        }

        public void Ejecutar(int productoId)
        {
            // Obtener el producto existente por su ID
            Producto productoExistente = this.repositorio.ObtenerPorId(productoId);
            if(productoExistente == null )
            {
                throw new InvalidOperationException($"No se encontró ningún producto con el ID {productoId}.");
            }

            // Eliminar el producto del repositorio
            repositorio.Eliminar(productoExistente);
        }
    }
}
