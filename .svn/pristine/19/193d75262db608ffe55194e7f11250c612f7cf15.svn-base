using Oxxo2.Models;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace OxxoTest.ModelsTest
{
    public class EnableModelTest
    {
        [Fact]
        public void EnableModel_EnablerIdInt_ReturnTrue()
        {
            //Act
            var prueba = new Enable();
            prueba.EnablerId = 1;
            
            //Assert
            Assert.IsType<Int32>(prueba.EnablerId);
     
        }

        [Fact]
        public void EnableModel_IsActiveBool_ReturnTrue()
        {
            //Act
            var prueba = new Enable();
            prueba.IsActive = true;
            
            //Assert
            Assert.IsType<bool>(prueba.IsActive);


        }
        [Fact]
        public void EnableModel_UsuarioString_ReturnTrue()
        {
            //Act
            var prueba = new Enable();
            prueba.Usuario = "Alex";

            //Assert
            Assert.IsType<string>(prueba.Usuario);

        }
    }
}
