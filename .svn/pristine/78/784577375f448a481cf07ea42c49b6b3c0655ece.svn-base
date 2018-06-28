using Oxxo2.Models;
using System;
using Xunit;

namespace OxxoTest.ModelsTest
{
    public class InventarioJsonModelTest
    {
        [Fact]
        public void InvJsonMdl_InventarioNombreString_ReturnTrue()
        {
            //Act
            var prueba = new InventarioJson();
            prueba.InventarioNombre = "Nombre Prueba";
          
            //Assert
            Assert.IsType<string>(prueba.InventarioNombre);
            

        }
        [Fact]
        public void InvJsonMdl_FolioGomaString_ReturnTrue()
        {
            //Act
            var prueba = new InventarioJson();            
            prueba.FolioGoma = "Folio Prueba";
             
            //Assert
            Assert.IsType<string>(prueba.FolioGoma);          

        }


        [Fact]
        public void InvJsonMdl_FinalizadoBool_ReturnTrue()
        {
            //Act
            var prueba = new InventarioJson();           
            prueba.Finalizado = true;                         
           
            //Assert
            Assert.IsType<bool>(prueba.Finalizado);         

        }


        [Fact]
        public void InvJsonMdl_InvIdInt_ReturnTrue()
        {
            //Act
            var prueba = new InventarioJson();           
            prueba.InvId = 5;
           
            //Assert
            Assert.IsType<Int32>(prueba.InvId);

        }
    }
}
