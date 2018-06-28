using Oxxo2.Models;
using System;
using Xunit;

namespace OxxoTest.ModelsTest
{
    public class SchedulerModelTest
    {
        [Fact]
        public void SchdlMdl_SchedulerIdInt_ReturnTrue()
        {
            //Act
            var prueba = new Schedulers();
            prueba.SchedulerId = 584;

            //Assert
            Assert.IsType<Int32>(prueba.SchedulerId);

        }

        [Fact]
        public void SchdlMdl_IsActiveBool_ReturnTrue()
        {
            //Act
            var prueba = new Schedulers();
            prueba.IsActive = false;

            //Assert
            Assert.IsType<bool>(prueba.IsActive);

        }

        [Fact]
        public void SchdlMdl_UsuarioString_ReturnTrue()
        {
            //Act
            var prueba = new Schedulers();
            prueba.Usuario = "Usuario de prueba";

            //Assert
            Assert.IsType<string>(prueba.Usuario);

        }
    }
}
