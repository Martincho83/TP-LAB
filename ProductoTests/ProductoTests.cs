using _03_Dominio.Entidades;
using _03_Dominio.ValueObjects;

namespace ProductoTests
{
    public class ProductoTests
    {
        [Fact]
        public void producto_GettersAndSetters_WorkCorrectly()
        {
            //Arrange: Creamos un producto con datos iniciales para la prueba.
            var producto = new Producto(
                id: 1,
                nombre: "ProdPrueba",
                descripcion: "DescPrueba",
                precio: 129,
                categoriaId: 1,
                cantidadStock: 100,
                estado: new EstadoProducto("Activo")
                );

            //Act: Modificamos los atributos del producto usando los métodos setter.
            producto.SetNombre("ProdModificado");
            producto.SetDescripcion("DescModificada");
            producto.SetPrecio(199);
            producto.SetCategoriaId(2);
            producto.SetCantidadStock(50);
            producto.SetEstado(new EstadoProducto("Inactivo"));

            //Assert: Verificamos que los valores recuperados mediante los metodos getter son correctos
            Assert.Equal(1, producto.GetId());
            Assert.Equal("ProdModificado", producto.GetNombre());
            Assert.Equal("DescModificada", producto.GetDescripcion());
            Assert.Equal(199, producto.GetPrecio());
            Assert.Equal(2, producto.GetCategoriaId());
            Assert.Equal(50, producto.GetCantidadStock());
            Assert.Equal("Inactivo", producto.GetEstado().Valor());
        }
    }
}
