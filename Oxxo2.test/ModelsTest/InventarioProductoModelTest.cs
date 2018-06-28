using Oxxo2.Models;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace OxxoTest.ModelsTest
{
    public class InventarioProductoModelTest
    {
        [Fact]
        public void InvProdMdl_ProdInventIdInt_ReturnTrue()
        {
            //Act
            var prueba = new InvProdModel();
            prueba.ProdInventId = 5;

            //Assert
            Assert.IsType<Int32>(prueba.ProdInventId);

        }

        [Fact]
        public void InvProdMdl_ProductoIdInt_ReturnTrue()
        {
            //Act
            var prueba = new InvProdModel();
            prueba.ProductoId = 56258;

            //Assert
            Assert.IsType<Int32>(prueba.ProductoId);

        }

        [Fact]
        public void InvProdMdl_InventarioIdInt_ReturnTrue()
        {
            //Act
            var prueba = new InvProdModel();
            prueba.InventarioId = 748596;

            //Assert
            Assert.IsType<Int32>(prueba.InventarioId);

        }

        [Fact]
        public void InvProdMdl_ProveedorIdInt_ReturnTrue()
        {
            //Act
            var prueba = new InvProdModel();
            prueba.ProveedorId = 1475896325;

            //Assert
            Assert.IsType<Int32>(prueba.ProveedorId);

        }

        [Fact]
        public void InvProdMdl_IsSelectedBool_ReturnTrue()
        {
            //Act
            var prueba = new InvProdModel();
            prueba.IsSelected = false;

            //Assert
            Assert.IsType<bool>(prueba.IsSelected);

        }
    }
}
