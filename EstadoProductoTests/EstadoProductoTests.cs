using _03_Dominio.ValueObjects;

namespace EstadoProductoTests
{
    public class EstadoProductoTests
    {
        [Fact]
        public void Constructor_CadenaValida_AsignaEstadoCorrectamente()
        {
            // Arrange
            var estado = "Activo";

            // Act
            var estadoProducto = new EstadoProducto(estado);

            // Assert
            Assert.Equal(estado, estadoProducto.Valor());
        }

        [Fact]
        public void Constructor_CadenaInvalida_LanzaExcepcion()
        {
            // Arrange
            var estado = "Desconocido";

            // Act & Assert
            Assert.Throws<ArgumentException>(() => new EstadoProducto(estado));
        }

        [Fact]
        public void Valor_RetornaValorCorrecto()
        {
            // Arrange
            var estado = "Pendiente";
            var estadoProducto = new EstadoProducto(estado);

            // Act
            var valor = estadoProducto.Valor();

            // Assert
            Assert.Equal(estado, valor);
        }

        [Fact]
        public void ToString_RetornaValorCorrecto()
        {
            // Arrange
            var estado = "Activo";
            var estadoProducto = new EstadoProducto(estado);

            // Act
            var valor = estadoProducto.ToString();

            // Assert
            Assert.Equal(estado, valor);
        }

        [Fact]
        public void Equals_CompararConMismoValor_RetornaVerdadero()
        {
            // Arrange
            var estado1 = new EstadoProducto("Activo");
            var estado2 = new EstadoProducto("Activo");

            // Act & Assert
            Assert.True(estado1.Equals(estado2));
        }

        [Fact]
        public void Equals_CompararConValorDiferente_RetornaFalso()
        {
            // Arrange
            var estado1 = new EstadoProducto("Activo");
            var estado2 = new EstadoProducto("Inactivo");

            // Act & Assert
            Assert.False(estado1.Equals(estado2));
        }

        [Fact]
        public void GetHashCode_MismoValor_RetornaMismoHashCode()
        {
            // Arrange
            var estado1 = new EstadoProducto("Activo");
            var estado2 = new EstadoProducto("Activo");

            // Act & Assert
            Assert.Equal(estado1.GetHashCode(), estado2.GetHashCode());
        }
    }
}