using Oxxo2.Models;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace OxxoTest.ModelsTest
{
    public class InventariosModelTest
    {
        [Fact]
        public void InvMdl_InventarioIdInt_ReturnTrue()
        {
            //Act
            var prueba = new Inventarios();
            prueba.InventarioId = 4586;

            //Assert
            Assert.IsType<Int32>(prueba.InventarioId);


        }

        [Fact]
        public void InvMdl_InventarioNombreString_ReturnTrue()
        {
            //Act
            var prueba = new Inventarios();
            prueba.InventarioNombre = "Nombre Prueba";

            //Assert
            Assert.IsType<string>(prueba.InventarioNombre);


        }

        [Fact]
        public void InvMdl_FolioGomaString_ReturnTrue()
        {
            //Act
            var prueba = new Inventarios();
            prueba.Folio_Goma = "Folio Prueba";

            //Assert
            Assert.IsType<string>(prueba.Folio_Goma);

        }

        [Fact]
        public void InvMdl_FinalizadoBool_ReturnTrue()
        {
            //Act
            var prueba = new Inventarios();
            prueba.Finalizado = true;

            //Assert
            Assert.IsType<bool>(prueba.Finalizado);

        }

    }
}
