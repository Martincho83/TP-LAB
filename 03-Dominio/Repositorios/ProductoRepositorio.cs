using _03_Dominio.Entidades;

namespace _03_Dominio.Repositorios
{
    public interface ProductoRepositorio
    {
        public List<Producto> Listar();
        public void Grabar(Producto producto);
        Producto ObtenerPorId(int id);
        public void Actualizar(Producto producto);
        public void Eliminar(Producto producto);
        public bool ExisteProductoConId(int id);
    }
}
