using Oxxo2.Models;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace OxxoTest.ModelsTest
{
    public class ProductosModelTest
    {
        [Fact]
        public void ProductosMdl_ProductoIdInt_ReturnTrue()
        {
            //Act
            var prueba = new Productos();
            prueba.ProductoId = 58596;

            //Assert
            Assert.IsType<Int32>(prueba.ProductoId);

        }

        [Fact]
        public void ProductosMdl_productoDescrString_ReturnTrue()
        {
            //Act
            var prueba = new Productos();
            prueba.productoDescr = "Descripción de producto Prueba";

            //Assert
            Assert.IsType<string>(prueba.productoDescr);

        }

        [Fact]
        public void ProductosMdl_ProveedorIdInt_ReturnTrue()
        {
            //Act
            var prueba = new Productos();
            prueba.ProveedorId = 5;

            //Assert
            Assert.IsType<Int32>(prueba.ProveedorId);

        }

        [Fact]
        public void ProductosMdl_existenciaInt_ReturnTrue()
        {
            //Act
            var prueba = new Productos();
            prueba.existencia = 556355;

            //Assert
            Assert.IsType<Int32>(prueba.existencia);

        }
    }
}
