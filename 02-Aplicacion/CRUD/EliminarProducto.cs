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
        private ProductoRepositorio repositorio;

        public EliminarProducto(ProductoRepositorio repositorio)
        {
            this.repositorio = repositorio;
        }

        public void Ejecutar(int productoId)
        {
            Producto productoExistente = this.repositorio.ObtenerPorId(productoId);
            if(productoExistente != null )
            {
                this.repositorio.Eliminar(productoExistente);
            }
        }
    }
}
