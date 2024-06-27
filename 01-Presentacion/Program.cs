using _02_Aplicacion.CRUD;
using _02_Aplicacion.DTO;
using _03_Dominio.ValueObjects;
using _04_PersistenciaDatos;


namespace _01_Presentacion
{
    class Program
    {
        static void Main(string[] args)
        {
            //Crear el repositorio en memoria
            //ProductoRepositorioEnMemoria productoRepositorio = new ProductoRepositorioEnMemoria();

            // Crear el repositorio en base de datos
            ProductoRepositorioMySQL productoRepositorio = new ProductoRepositorioMySQL();

            // Inicializar los casos de uso
            CrearProducto crearProducto = new CrearProducto(productoRepositorio);
            ListarProducto listarProducto = new ListarProducto(productoRepositorio);
            ActualizarProducto actualizarProducto = new ActualizarProducto(productoRepositorio);
            EliminarProducto eliminarProducto = new EliminarProducto(productoRepositorio);
            LeerProducto leerProducto = new LeerProducto(productoRepositorio);

            while (true)
            {
                MostrarMenuPrincipal();
                string opcion = Console.ReadLine();

                try
                {
                    switch (opcion)
                    {
                        case "1":
                            CrearProducto(crearProducto);
                            break;
                        case "2":
                            ListarProducto(listarProducto);
                            break;
                        case "3":
                            ActualizarProducto(actualizarProducto);
                            break;
                        case "4":
                            EliminarProducto(eliminarProducto);
                            break;
                        case "5":
                            LeerProducto(leerProducto);
                            break;
                        case "6":
                            Console.WriteLine("Saliendo del programa...");
                            return;
                        default:
                            MostrarMensajeError("Opción no válida. Por favor, intente de nuevo.");
                            break;
                    }
                }
                catch (Exception ex)
                {
                    MostrarMensajeError($"Error: {ex.Message}");
                }
            }
        }

        static void MostrarMenuPrincipal()
        {
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine("╔════════════════════════════════════════╗");
            Console.WriteLine("║           Gestión de Productos         ║");
            Console.WriteLine("╠════════════════════════════════════════╣");
            Console.WriteLine("║  1. Crear Producto                     ║");
            Console.WriteLine("║  2. Listar Productos                   ║");
            Console.WriteLine("║  3. Actualizar Producto                ║");
            Console.WriteLine("║  4. Eliminar Producto                  ║");
            Console.WriteLine("║  5. Leer Producto                      ║");
            Console.WriteLine("║  6. Salir                              ║");
            Console.WriteLine("╚════════════════════════════════════════╝");
            Console.ResetColor();
            Console.Write("\nSeleccione una opción: ");
        }

        static void MostrarMensajeError(string mensaje)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine(mensaje);
            Console.ResetColor();
            Console.WriteLine("\nPresione cualquier tecla para continuar...");
            Console.ReadKey();
        }

        static void MostrarMensajeExito(string mensaje)
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine(mensaje);
            Console.ResetColor();
            Console.WriteLine("\nPresione cualquier tecla para continuar...");
            Console.ReadKey();
        }

        static void CrearProducto(CrearProducto crearProducto)
        {
            try
            {
                Console.Clear();
                Console.WriteLine("===================================");
                Console.WriteLine("        Crear Nuevo Producto       ");
                Console.WriteLine("===================================");

                int id = SolicitarIdentificador(crearProducto);
                string nombre = SolicitarNombre();
                string descripcion = SolicitarDescripcion();
                decimal precio = SolicitarPrecio();
                int categoriaId = SolicitarCategoriaId();
                int cantidadStock = SolicitarCantidadStock();
                EstadoProducto estado = SolicitarEstado();

                ProductoDTO productoDTO = new ProductoDTO(id, nombre, descripcion, precio, categoriaId, cantidadStock, estado);
                crearProducto.Ejecutar(productoDTO);
                MostrarMensajeExito("Producto creado exitosamente.");
            }
            catch (InvalidOperationException ex)
            {
                MostrarMensajeError(ex.Message);
            }
            catch (FormatException)
            {
                MostrarMensajeError("Formato de entrada no válido. Por favor, intente nuevamente.");
            }
            catch (Exception ex)
            {
                MostrarMensajeError($"Error al crear el producto: {ex.Message}");
            }
        }

        static int SolicitarIdentificador(CrearProducto crearProducto)
        {
            while (true)
            {
                try
                {
                    Console.Write("Ingrese el ID del producto: ");
                    int id = int.Parse(Console.ReadLine());


                    //Verificar si el ID ya está registrado
                    if (crearProducto.ExisteProductoConId(id))
                    {
                        throw new InvalidOperationException("El ID del producto ya está registrado. Por favor, ingrese otro ID.");
                    }

                    //Validacion del Value Object Identificador
                    new Identificador(id); // Validación
                    return id;
                }
                catch (Exception ex)
                {
                    MostrarMensajeError(ex.Message);
                }
            }
        }

        static  string SolicitarNombre()
        {
            while (true)
            {
                try
                {
                    Console.Write("Ingrese el nombre del producto: ");
                    string nombre = Console.ReadLine();
                    new Nombre(nombre); // Validación
                    return nombre;
                }
                catch (Exception ex)
                {
                    MostrarMensajeError(ex.Message);
                }
            }
        }

        static  string SolicitarDescripcion()
        {
            while (true)
            {
                try
                {
                    Console.Write("Ingrese la descripción del producto: ");
                    string descripcion = Console.ReadLine();
                    new Descripcion(descripcion); // Validación
                    return descripcion;
                }
                catch (Exception ex)
                {
                    MostrarMensajeError(ex.Message);
                }
            }
        }

        static  decimal SolicitarPrecio()
        {
            while (true)
            {
                try
                {
                    Console.Write("Ingrese el precio del producto: ");
                    decimal precio = decimal.Parse(Console.ReadLine());
                    new Precio(precio); // Validación
                    return precio;
                }
                catch (Exception ex)
                {
                    MostrarMensajeError(ex.Message);
                }
            }
        }

        static  int SolicitarCategoriaId()
        {
            while (true)
            {
                try
                {
                    Console.Write("Ingrese el ID de la categoría: ");
                    int categoriaId = int.Parse(Console.ReadLine());
                    new CategoriaId(categoriaId); // Validación
                    return categoriaId;
                }
                catch (Exception ex)
                {
                    MostrarMensajeError(ex.Message);
                }
            }
        }

        static  int SolicitarCantidadStock()
        {
            while (true)
            {
                try
                {
                    Console.Write("Ingrese la cantidad en stock: ");
                    int cantidadStock = int.Parse(Console.ReadLine());
                    new CantidadStock(cantidadStock); // Validación
                    return cantidadStock;
                }
                catch (Exception ex)
                {
                    MostrarMensajeError(ex.Message);
                }
            }
        }

        static  EstadoProducto SolicitarEstado()
        {
            while (true)
            {
                try
                {
                    Console.Write("Ingrese el estado del producto (Activo, Inactivo, Pendiente): ");
                    string estado = Console.ReadLine();
                    return new EstadoProducto(estado); // Validación
                }
                catch (Exception ex)
                {
                    MostrarMensajeError(ex.Message);
                }
            }
        }

        static void ListarProducto(ListarProducto listarProducto)
        {
            try
            {
                List<ProductoDTO> productos = listarProducto.Ejecutar();

                Console.Clear();
                Console.WriteLine("===================================");
                Console.WriteLine("        Listado de Productos       ");
                Console.WriteLine("===================================");

                // Encabezado de la tabla
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine("{0, -5} {1, -15} {2, -20} {3, -10} {4, -15} {5, -18} {6,-10}",
                    "ID", "Nombre", "Descripcion", "Precio", "Categoria ID", "Cantidad en Stock", "Estado");
                Console.WriteLine(new string('-', 105));
                Console.ResetColor();

                // Filas de la tabla
                foreach (var producto in productos)
                {
                    Console.WriteLine("{0, -5} {1, -15} {2, -20} {3, -10} {4, -15} {5, -18} {6,-10}",
                        producto.GetId(),
                        PadRight(producto.GetNombre(), 15),
                        PadRight(producto.GetDescripcion(), 20),
                        producto.GetPrecio(),
                        producto.GetCategoriaId(),
                        producto.GetCantidadStock(),
                        producto.GetEstado().Valor());
                }
                Console.WriteLine("\nPresione cualquier tecla para continuar...");
                Console.ReadKey();
            }
            catch (Exception ex)
            {
                MostrarMensajeError($"Error al listar productos: {ex.Message}");
            }
        }

        static string PadRight(string value, int totalWidth)
        {
            if (string.IsNullOrEmpty(value))
            {
                return new string(' ', totalWidth);
            }
            else if (value.Length >= totalWidth)
            {
                return value.Substring(0, totalWidth);
            }
            else
            {
                return value.PadRight(totalWidth);
            }
        }

        static void ActualizarProducto(ActualizarProducto actualizarProducto)
        {
            try
            {
                Console.Clear();
                Console.WriteLine("===================================");
                Console.WriteLine("        Actualizar Producto        ");
                Console.WriteLine("===================================");

                Console.Write("Ingrese el ID del Producto a actualizar: ");
                int id = int.Parse(Console.ReadLine());

                // Verificar si el producto existe antes de actualizar
                if (!actualizarProducto.ExisteProductoConId(id))
                {
                    throw new InvalidOperationException($"No se encontró ningún producto con el ID {id}. No se puede actualizar.");
                }

                // Solicitar los nuevos datos del producto
                Console.Write("Ingrese Nuevo Nombre del Producto: ");
                string nombre = Console.ReadLine();
                Console.Write("Ingrese Nueva Descripcion del Producto: ");
                string descripcion = Console.ReadLine();
                Console.Write("Ingrese Nuevo Precio del Producto: ");
                decimal precio = decimal.Parse(Console.ReadLine());
                Console.Write("Ingrese Nuevo ID de la Categoria: ");
                int categoriaId = int.Parse(Console.ReadLine());
                Console.Write("Ingrese Nueva Cantidad de Stock: ");
                int cantidadStock = int.Parse(Console.ReadLine());
                Console.Write("Ingrese el estado del Producto (Activo, Inactivo, Pendiente): ");
                string estado = Console.ReadLine();

                // Crear el DTO del producto con los datos ingresados
                EstadoProducto estadoProducto = new EstadoProducto(estado);
                ProductoDTO productoDTO = new ProductoDTO(id, nombre, descripcion, precio, categoriaId, cantidadStock, estadoProducto);

                // Ejecutar la actualización del producto
                actualizarProducto.Ejecutar(productoDTO);

                MostrarMensajeExito("Producto actualizado con éxito.");
            }
            catch (FormatException)
            {
                MostrarMensajeError("Formato de entrada no válido. Por favor, intente nuevamente.");
            }
            catch (InvalidOperationException ex)
            {
                MostrarMensajeError(ex.Message);
            }
            catch (Exception ex)
            {
                MostrarMensajeError($"Error al actualizar el producto: {ex.Message}");
            }
        }

        static void EliminarProducto(EliminarProducto eliminarProducto)
        {
            try
            {
                Console.Clear();
                Console.WriteLine("===================================");
                Console.WriteLine("        Eliminar Producto          ");
                Console.WriteLine("===================================");

                Console.Write("Ingrese el ID del Producto a eliminar: ");
                int id = int.Parse(Console.ReadLine());

                eliminarProducto.Ejecutar(id);

                MostrarMensajeExito("Producto eliminado con éxito.");
            }
            catch (Exception ex)
            {
                MostrarMensajeError($"Error al eliminar el producto: {ex.Message}");
            }
        }

        static void LeerProducto(LeerProducto leerProducto)
        {
            try
            {
                Console.Clear();
                Console.WriteLine("===================================");
                Console.WriteLine("        Leer Producto              ");
                Console.WriteLine("===================================");

                Console.Write("Ingrese el ID del Producto: ");
                int id = int.Parse(Console.ReadLine());

                ProductoDTO producto = leerProducto.Ejecutar(id);

                if (producto != null)
                {
                    Console.WriteLine("\nProducto encontrado:");
                    Console.WriteLine($"ID: {producto.GetId()}");
                    Console.WriteLine($"Nombre: {producto.GetNombre()}");
                    Console.WriteLine($"Descripción: {producto.GetDescripcion()}");
                    Console.WriteLine($"Precio: {producto.GetPrecio()}");
                    Console.WriteLine($"Categoría ID: {producto.GetCategoriaId()}");
                    Console.WriteLine($"Cantidad en Stock: {producto.GetCantidadStock()}");
                    Console.WriteLine($"Estado: {producto.GetEstado().Valor()}");
                }
                else
                {
                    Console.WriteLine("\nProducto no encontrado.");
                }
            }
            catch (FormatException)
            {
                MostrarMensajeError("Formato de entrada no válido. Por favor, ingrese un número entero para el ID del producto.");
            }
            catch (Exception ex)
            {
                MostrarMensajeError($"Error al leer el producto: {ex.Message}");
            }

            Console.WriteLine("\nPresione cualquier tecla para continuar...");
            Console.ReadKey();
        }
    }
}
