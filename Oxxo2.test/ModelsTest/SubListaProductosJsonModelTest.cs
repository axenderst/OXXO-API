using Oxxo2.Models;
using System;
using Xunit;

namespace OxxoTest.ModelsTest
{
    public class SubListaProductosJsonModelTest
    {
        [Fact]
        public void SubListProdJsonMdl_idInt_ReturnTrue()
        {
            //Act
            var prueba = new SubListaProductosJson();
            prueba.id = 5;

            //Assert
            Assert.IsType<Int32>(prueba.id);

        }

        [Fact]
        public void SubListProdJsonMdl_descripcionString_ReturnTrue()
        {
            //Act
            var prueba = new SubListaProductosJson();
            prueba.descripcion = "Descripción de Prueba";

            //Assert
            Assert.IsType<string>(prueba.descripcion);

        }

        [Fact]
        public void SubListProdJsonMdl_proveedorIdInt_ReturnTrue()
        {
            //Act
            var prueba = new SubListaProductosJson();
            prueba.proveedorId = 84485;

            //Assert
            Assert.IsType<Int32>(prueba.proveedorId);

        }

        [Fact]
        public void SubListProdJsonMdl_existenciaInt_ReturnTrue()
        {
            //Act
            var prueba = new SubListaProductosJson();
            prueba.id = 74855;

            //Assert
            Assert.IsType<Int32>(prueba.existencia);

        }
    }
}
