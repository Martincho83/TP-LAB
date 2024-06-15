 using _03_Dominio.Repositorios;
using _03_Dominio.Entidades;
using MySql.Data.MySqlClient;
using _03_Dominio.ValueObjects;

namespace _04_PersistenciaDatos
{
    public class ProductoRepositorioMySQL : ProductoRepositorio
    {
        private string connectionString;

        public ProductoRepositorioMySQL()
        {
            MySQLConnectionSingleton dbSingleton = MySQLConnectionSingleton.Instance(
                "localhost",
                "dbservicio",
                "root",
                "root"
            );
            this.connectionString = dbSingleton.GetConnection().ConnectionString;
        }

        public void Grabar(Producto producto)
        {
            using (MySqlConnection connection = new MySqlConnection(this.connectionString))
            using (MySqlCommand comando = new MySqlCommand(
                "INSERT INTO productos (id, nombre, descripcion, precio, categoriaId, cantidadStock, estado) VALUES (@id, @nombre, @descripcion, @precio, @categoriaId, @cantidadStock, @estado)",
                connection))
            {
                comando.Parameters.AddWithValue("@id", producto.GetId());
                comando.Parameters.AddWithValue("@nombre", producto.GetNombre());
                comando.Parameters.AddWithValue("@descripcion", producto.GetDescripcion());
                comando.Parameters.AddWithValue("@precio", producto.GetPrecio());
                comando.Parameters.AddWithValue("@categoriaId", producto.GetCategoriaId());
                comando.Parameters.AddWithValue("@cantidadStock", producto.GetCantidadStock());
                comando.Parameters.AddWithValue("@estado", producto.GetEstado().Valor());

                connection.Open();
                comando.ExecuteNonQuery();
            }
        }

        public List<Producto> Listar()
        {
            List<Producto> productos = new List<Producto>();
            using (MySqlConnection connection =  new MySqlConnection(this.connectionString))
            using (MySqlCommand command = new MySqlCommand(
                "SELECT id, nombre, descripcion, precio, categoriaId, cantidadStock, estado FROM productos",
                connection))
            {
                connection.Open();
                using (MySqlDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        int id = reader.GetInt32(0);
                        string nombre = reader.GetString(1);
                        string descripcion = reader.GetString(2);
                        decimal precio = reader.GetDecimal(3);
                        int categoriaId = reader.GetInt32(4);
                        int cantidadStock = reader.GetInt32(5);
                        string estadoString = reader.GetString(6);

                        EstadoProducto estado = new EstadoProducto(estadoString);

                        Producto producto = new Producto(id, nombre, descripcion, precio, categoriaId, cantidadStock, estado);
                        productos.Add(producto);
                    }
                }
            }
            return productos;
        }

        public Producto ObtenerPorId(int id)
        {
            Producto producto = null;
            using (MySqlConnection connection =  new MySqlConnection(this.connectionString))
            using (MySqlCommand command = new MySqlCommand(
                "SELECT id, nombre, descripcion, precio, categoriaId, cantidadStock, estado FROM productos WHERE id = @id",
                connection))
            {
                command.Parameters.Add("@id", MySqlDbType.Int32).Value = id;
                connection.Open();
                using (MySqlDataReader reader = command.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        int productoId = reader.GetInt32(0);
                        string nombre = reader.GetString(1);
                        string descripcion = reader.GetString(2);
                        decimal precio = reader.GetDecimal(3);
                        int categoriaId = reader.GetInt32(4);
                        int cantidadStock = reader.GetInt32(5);
                        string estadoString = reader.GetString(6);

                        EstadoProducto estado = new EstadoProducto(estadoString);

                        producto = new Producto(productoId, nombre, descripcion, precio, categoriaId, cantidadStock, estado);
                    }
                }
            }
            return producto;
        }

        public void Actualizar(Producto producto)
        {
            using (MySqlConnection connection = new MySqlConnection(this.connectionString))
            using (MySqlCommand comando = new MySqlCommand(
                "UPDATE productos SET nombre = @nombre, descripcion = @descripcion, precio = @precio, categoriaId = @categoriaId, cantidadStock = @cantidadStock, estado = @estado WHERE id = @id",
                connection))
            {
                comando.Parameters.AddWithValue("@id", producto.GetId());
                comando.Parameters.AddWithValue("@nombre", producto.GetNombre());
                comando.Parameters.AddWithValue("@descripcion", producto.GetDescripcion());
                comando.Parameters.AddWithValue("@precio", producto.GetPrecio());
                comando.Parameters.AddWithValue("@categoriaId", producto.GetCategoriaId());
                comando.Parameters.AddWithValue("@cantidadStock", producto.GetCantidadStock());
                comando.Parameters.AddWithValue("@estado", producto.GetEstado().Valor());

                connection.Open();
                comando.ExecuteNonQuery();
            }
        }

        public void Eliminar(Producto producto)
        {
            using (MySqlConnection connection =  new MySqlConnection(this.connectionString))
            using (MySqlCommand comando = new MySqlCommand(
                "DELETE FROM productos WHERE id = @id",
                connection))
            {
                comando.Parameters.AddWithValue("@id", producto.GetId());

                connection.Open();
                comando.ExecuteNonQuery();
            }
        }

        public bool ExisteProductoConId(int id)
        {
            bool existe = false;
            using (MySqlConnection connection =  new MySqlConnection(this.connectionString))
            using (MySqlCommand command = new MySqlCommand(
                "SELECT COUNT(1) FROM productos WHERE id = @id",
                connection))
            {
                command.Parameters.Add("@id", MySqlDbType.Int32).Value = id;
                connection.Open();
                existe = Convert.ToInt32(command.ExecuteScalar()) > 0;
            }
            return existe;
        }
    }
}
