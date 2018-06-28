using Oxxo2.Models;
using System;
using Xunit;

namespace OxxoTest.ModelsTest
{
    public class ProveedoresModelTest
    {
        [Fact]
        public void ProveedorMdl_ProveedorIdInt_ReturnTrue()
        {
            //Act
            var prueba = new Proveedores();
            prueba.ProveedorId = 5;

            //Assert
            Assert.IsType<Int32>(prueba.ProveedorId);

        }

        [Fact]
        public void ProveedorMdl_Proveed_nombreString_ReturnTrue()
        {
            //Act
            var prueba = new Proveedores();
            prueba.Proveed_nombre = "Proveedor de prueba";

            //Assert
            Assert.IsType<string>(prueba.Proveed_nombre);

        }

        [Fact]
        public void ProveedorMdl_Proveed_LogoUrlString_ReturnTrue()
        {
            //Act
            var prueba = new Proveedores();
            prueba.Proveed_LogoUrl = "http://urldeprueba.com";

            //Assert
            Assert.IsType<string>(prueba.Proveed_LogoUrl);

        }
    }
}
